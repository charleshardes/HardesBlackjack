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
#include "blackjack.h"

void spaces(int s) {
    
    int i;
    for(i = 0; i < s; i++) {
        printf(" ");
    }
}

void newlines(int n) {
    
    int i;
    assert(n >= 0);
    
    for (i = 0; i < n; i++) {
        printf("\n");
    }
}

void tabs(int t) {
    
    int i;
    assert(t >= 0);
    
    for (i = 0; i < t; i++) {
        printf("\t");
    }
}

int getPlayers() {
    
    int i, noPlayers;
    char buffer[BUFFERSIZE];
    
    do {
        printf("Enter a number of human players between 0 - 4\n");
        scanf_s("%d", &noPlayers);
    } while ((noPlayers > 4) || (noPlayers < 0));
    
    for (i = 0; i < noPlayers; i++) {
        printf("Enter player %d's name:\n", (i + 1));
        scanf_s(" %63s", buffer, 64);
        /*printf("string entered: %s\n", buffer);*/newlines(1);
        strcpy_s(playerArr[i], sizeof playerArr[i], buffer);
    }
    return noPlayers;
}

int getComps(int maxComps) {

    int no_Comps = 0;
    assert((maxComps >= 0) && (maxComps <= 4));
    if (maxComps != 0) {
        do {
            printf("Enter number of computer players between 0 - %d\n", maxComps);
            scanf_s(" %d", &no_Comps);
        }while ((no_Comps < 0) || (no_Comps > maxComps));
    }
    return no_Comps;
}



void dealStartingHands(table *t, deck *d) {

    int i;    
    assert((t) && (d));

    dealToPlayers(t, d);
    dealCard(t, d, t->dealer, 0);
    dealToPlayers(t, d);
    dealCard(t, d, t->dealer, 1);
    
    for (i = 0; i < t->NO_OF_PLAYERS; i++) {
        assessHand(t->players[i]->playerHand);
    }
    assessHand(t->dealer->playerHand);
    
    //displayTable(t);
}

void playerTurn(table *t, player *p, deck *d) {

    char ans;
    ans = 'd';
    assert((t) && (p) && (d));
    
    while ((ans != 's') && (p->playerHand->bust != 1)) {
        printf("Hit: h\tStay: s\n");
        newlines(1);
        tabs(t->margin);
        spaces(t->buffer);
        ans = getchar();
        
        if (ans == 'h') {
            dealCard(t, d, p, 1);
        }
        assessHand(p->playerHand);
        displayTable(t, 1);

    }
}

void dealerTurn(table *t, deck *d) {
    
    assert((t) && (d));
    
    showCard(t->dealer->playerHand->cards[0]);
    Sleep(1000);
    displayTable(t, 1);
    
    /*Condition for soft 17*/
    if ((t->dealer->playerHand->score == 17) &&
        (t->dealer->playerHand->cardCount == 2) &&
        (isHiAce(t->dealer->playerHand->cards[0]) ||
         isHiAce(t->dealer->playerHand->cards[1]))) {
            dealCard(t, d, t->dealer, 1);
            assessHand(t->dealer->playerHand);
            Sleep(1000);
            displayTable(t, 1);
    }
    
    while (t->dealer->playerHand->score < 17) {
        dealCard(t, d, t->dealer, 1);
        assessHand(t->dealer->playerHand);
        Sleep(1000);
        displayTable(t, 1);
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
