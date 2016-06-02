//
//  blackjack.c
//  Console_Cards
//
//  Created by Charles Hardes on 3/28/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//
#include <stdlib.h>
#include <stdio.h>
#include <assert.h>
#include <string.h>
//#include <unistd.h>
#include <Windows.h>
#include "cards_globals.h"
#include "cards_structs.h"
#include "cards_suits.h"
#include "cards_values.h"
#include "cards.h"
#include "decks.h"
#include "cards_test.h"
#include "blackjack_globals.h"
#include "blackjack_structs.h"
#include "blackjack_hands.h"
#include "blackjack_players.h"
#include "blackjack_table.h"
#include "blackjack_UIX.h"
#include "blackjack.h"

table *setTable() {

	int no_Comps, no_Human_Players, no_Total_Players;

    no_Human_Players = getPlayers();
    no_Comps = getComps(4 - no_Human_Players);
    no_Total_Players = no_Human_Players + no_Comps;

	return createTable(no_Total_Players, no_Comps);
}

int getPlayers() {
    
    int i, noPlayers;
    
    do {
		/*issue prompt and take input for number of human players*/
		prompt_noHumanPlayers();
		noPlayers = input_noHumanPlayers();
    } while ((noPlayers > 4) || (noPlayers < 0));
    
    for (i = 0; i < noPlayers; i++) {
		/*issue prompt and take input for names of human players*/
		prompt_playerName(i + 1);
        strcpy_s(playerArr[i], sizeof playerArr[i], input_playerName());
    }
    return noPlayers;
}

int getComps(int maxComps) {

    int no_Comps = 0;
    assert((maxComps >= 0) && (maxComps <= 4));
    if (maxComps != 0) {
        do {
			/*issue prompt and take input for number of computer players*/
			prompt_noCompPlayers(maxComps);
			no_Comps = input_noCompPlayers();
        }while ((no_Comps < 0) || (no_Comps > maxComps));
    }
    return no_Comps;
}

void dealCard(table *t, deck *d, player *p, int shown) {
    
    card *dealt, **curr;
    int i = 0;
    assert((d) && (p));
    assert(!isEmpty(d));
    
    dealt = _popCard(d);/*get top card from deck, assign to variable dealt*/
    dealt->shown = shown;
    curr = p->playerHand->cards;
    
    /*cycle through cards in hand to find last one, preparing to add an additional card in first empty slot*/
    while (curr[i] != NULL) {
        i++;
    }
    /*assigns (deals) popped card to player's hand*/
    curr[i] = dealt;
    if ((strcmp(dealt->value->name, "Ace") == 0)) {p->playerHand->hiAces++;}/*if ace, increment ace counter*/
    p->playerHand->cardCount++;
    
    /*If card dealt was last in deck, put all discarded cards back in deck and shuffle*/
    if (isEmpty(d)) {
        pileToDeck(t, d);
        shuffle(d);
        shuffle(d);
    }
}

void dealStartingHands(table *t, deck *d) {

    int i;    
    assert((t) && (d));

    dealToPlayers(t, d);
    dealCard(t, d, t->dealer, 0);
    dealToPlayers(t, d);
    dealCard(t, d, t->dealer, 1);
    
    for (i = 0; i < t->NO_OF_PLAYERS; i++) {
        assessHand(t->players[i]->playerHand, 0);
    }
    assessHand(t->dealer->playerHand, 0);
    
	t->handsAreDealt= 1;
}

void playerTurn(table *t, player *p, deck *d) {

    char ans;
    ans = 'd';
    assert((t) && (p) && (d));
    
	/*loops the player's turn until stay or bust*/
    while ((ans != 's') && (p->playerHand->bust != 1)) {

		/*issue prompt and take input for player's turn*/
		prompt_playerTurn(t);
		ans = input_playerTurn();
        
		/*if player hits/doubles down, deal card*/
		if ((ans == 'h') || (ans == 'd')) {
			dealCard(t, d, p, 1);
			if (ans == 'd') {p->playerHand->doubledDown = 1;}/*record that hand has doubled down*/
		}

		/*assess and update the hand after the player's turn*/
        assessHand(p->playerHand, (ans == 's' ? 1 : 0));

		/*show updated table*/
		displayTable(t);

		/*if hand is over (determined by assessHand), prepare for next player by exiting turn loop*/
		if (p->playerHand->hasEnded) {break;}
    }
}

void playerTurn_ALL(table *t, deck *d) {
		
	assert(t);

    /*Loop through all players' turns*/
	for (t->currPlayer = 0; t->currPlayer < t->NO_OF_PLAYERS; t->currPlayer++) {
		if (t->players[t->currPlayer]->playerHand->hasEnded) continue;/*iterate if turn over*/
		playerTurn(t, t->players[t->currPlayer], d);/*calls driver for each individual player turn*/
    }
    t->currPlayer = 0;/*set currPlayer counter back to start after loop finishes*/
}

void dealerTurn(table *t, deck *d) {
    
    assert((t) && (d));
    
    showCard(t->dealer->playerHand->cards[0]);
    Sleep(1000);
    displayTable(t);
    
    /*Condition for soft 17*/
    if ((t->dealer->playerHand->score == 17) &&
        (t->dealer->playerHand->cardCount == 2) &&
        (isHiAce(t->dealer->playerHand->cards[0]) ||
         isHiAce(t->dealer->playerHand->cards[1]))) {
            dealCard(t, d, t->dealer, 1);
            assessHand(t->dealer->playerHand, 0);
            Sleep(1000);
            displayTable(t);
    }
    
    while (t->dealer->playerHand->score < 17) {
        dealCard(t, d, t->dealer, 1);
        assessHand(t->dealer->playerHand, 0);
        Sleep(1000);
        displayTable(t);
    }
}

/*After a hand has been dealt and all hands assessed using the assessHand() funciton, this 
 function is called to determine if each player wins or loses each respective hand; whether there is a push,
 whether the player's blackjack wins, or if the dealer's blackjack creates an automatic loss
 for each player without a blackjack. This function must be called during each hand at two instances:
 once immediately after the deal in order to handle the dealer having blackjack (in which case, the hand
 is immediately ended), and once after all players have played their hands to take scores.
 -----------------------------------------------------------------------------------------
 Parameters:
 struct table *t,
 Preconditions: 
 - t is not null
 - Each hand including the dealer's has been dealt and received starting hands
 - Each hand has been assessed using the assessHand() function
 Postconditions:
 - In the instance of dealer having blackjack: 
   - All players without blackjack have the struct playerHand.lose = 1
   - Any players with blackjack have their struct playerHand.push = 1
 - All other player hand outcomes assigned a loss, win, or push as appropriate
 - Player chips updated according to outcome and bet amounts
 -----------------------------------------------------------------------------------------
 */
void takeScores(table *t) {
    
    int i;
    assert(t);
    
    for (i = 0; i < t->NO_OF_PLAYERS; i++) {
        
        /*Condition for dealer having blackjack*/
        if (t->dealer->playerHand->hasBlackjack) {
            /*Dealer and player both have blackjack = push*/
            if (t->players[i]->playerHand->hasBlackjack) {
                t->players[i]->playerHand->push = 1;
                continue;
            }
            /*Otherwise, if dealer has blackjack and player does not, automatic loss*/
            else {
                t->players[i]->playerHand->lose = 1;
                continue;
            }
        }
        /*Assigns loss to player's hand if bust*/
        if (t->players[i]->playerHand->bust) {
            t->players[i]->playerHand->lose = 1;
            continue;
        }
        /*Win condition: dealer busts or player has higher score without busting*/
        if ((t->dealer->playerHand->bust) ||
            (t->players[i]->playerHand->score > t->dealer->playerHand->score)) {
            
            /*Condition for player Blackjack; pays 3/2*/
            if (t->players[i]->playerHand->hasBlackjack) {
                t->players[i]->chips += ((t->players[i]->bet * 3) / 2);
            }
            /*all other wins pay 2/1*/
            else {
                t->players[i]->chips += t->players[i]->bet * 2;
            }
            t->players[i]->playerHand->win = 1;
        }
        /*Loss without bust condition if score does not beat dealer's*/
        else if (t->players[i]->playerHand->score < t->dealer->playerHand->score) {
            t->players[i]->playerHand->lose = 1;
        }
        /*Push condition for tying scores and no bust*/
        else if (t->players[i]->playerHand->score == t->dealer->playerHand->score) {
            t->players[i]->playerHand->push = 1;
            t->players[i]->chips += t->players[i]->bet;
        }
    }
}

void cleanUp(table *t, deck *d) {
    _deleteTable(t);
    _deleteDeck(d);
}
