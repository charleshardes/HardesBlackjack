//
//  blackjack_run.c
//  Console_Cards
//
//  Created by Charles Hardes on 3/28/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//
#include <stdlib.h>
#include <stdio.h>
#include <assert.h>
#include <string.h>
#include <math.h>
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
#include "blackjack_run.h"
#include "blackjack_UIX.h"

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

/*
Alert line display:
Displays an alert message when player has won, gotten blackjack, busted, lost, pushed
(as determined by the assessHand() function) and prints appropriate number of spaces 
to next player as per algorithms below
*/
void handFeedBack_Display_ALL(table *t) {



	int promptBuffer, line1Tabs, i;
	assert(t);

	line1Tabs = (int) (12 - (t->NO_OF_PLAYERS * 2.5));

    newlines(1);
    tabs(line1Tabs);
    for (i = 0; i < t->NO_OF_PLAYERS; i++) {
		CL_handFeedBack_Display(t, i);
    }
    newlines(1);
    tabs(line1Tabs);
    promptBuffer = 36 * t->currPlayer;
    spaces(promptBuffer);
    t->buffer = promptBuffer;
    t->margin = line1Tabs;
}


void CL_handFeedBack_Display(table *t, int player) {

	if (t->players[player]->playerHand->bust) {
        printf("BUSTED! ($%d-)", t->players[player]->bet);
        spaces(23 - (int)log10((double)t->players[player]->bet));
    }
    else if (t->players[player]->playerHand->hasBlackjack) {
        printf("BLACKJACK! ($%d+)", (int)((t->players[player]->bet * 3) / 2));
        spaces(20 - (int)log10((double)((t->players[player]->bet * 3) / 2)));
    }
    else if (t->players[player]->playerHand->win) {
        printf("WIN ($%d+)", t->players[player]->bet * 2);
        spaces(27 - (int)log10((double)(t->players[player]->bet * 2)));
    }
    else if (t->players[player]->playerHand->lose) {
        printf("LOSE ($%d-)", t->players[player]->bet);
        spaces(26 - (int)log10((double)t->players[player]->bet));
    }
    else if (t->players[player]->playerHand->push) {
        printf("PUSH ($0+)");
        spaces(26);
    }
    else spaces(36);
}

int continueGamePrompt(table *t) {

	char ans;
	assert(t);

    newlines(2);
    printf("Deal: d; Quit: q\n");
    ans = getchar();
    ans = getchar();
    if (ans == 'd') {
        clearTable(t);
		return 1;
    }
    else if (ans == 'q') {return 0;}
    else {
		printf("ERROR");
		continueGamePrompt(t);
		return 0;
	}
}

void getBets(table *t) {

	int bet;

	tabs(t->margin);
    spaces(36 * t->currPlayer);

    printf("Enter bet amount: ");
    /*Error handling loop*/
    while (1) {
        scanf_s(" %d", &bet);
		if ((bet >= 0) && (bet <= t->players[t->currPlayer]->chips)) break;/*break loop if in range*/
        /*Error message*/
        printf("\nERROR: Improper bet amount\nEnter bet amount: ");
    }
    t->players[t->currPlayer]->bet = bet;
    t->players[t->currPlayer]->chips -= bet;
            
    /*exit function, stop recursion if last player*/
    if (t->currPlayer == t->NO_OF_PLAYERS - 1) {
        t->currPlayer = 0;/*reset currPlayer for next line*/
        return;
    }
    t->currPlayer++;
            
    /*Recusively called for players 2 and higher*/
    displayTable(t);

	if (t->currPlayer == t->NO_OF_PLAYERS) {return;}

	getBets(t);
    return;/*extra recursive record exited*/
}

void displayDealer(table *t) {

	/*Dealer display line*/
    newlines(5);
    tabs(9);
    displayPlayer(t->dealer);
    newlines(2);
    tabs(9);
    /*Condition that hand has already been dealt*/
	if (t->handsAreDealt) {
        displayHand(t->dealer->playerHand, t->dealer);
    }
    else newlines(1);
    newlines(6);
}

void displayPlayer(player *p) {
    
    assert(p);
    
    if (p->dealer == 1) {printf("%s", p->name);}
    else {printf("%s     $%d", p->name, p->chips);}

	/*algorithm to print the number of spaces to next player - characters used in previous player*/
    spaces(30 - strlen(p->name) - (((int) log10((double)p->chips))  + 1));
}

void displayPlayerHand(player *p) {
    
    assert(p);
    if (p->dealer == 1) {return;}
    displayHand(p->playerHand, p);
}

void displayAllPlayerHands(table *t) {

	int i;

	if (!t->handsAreDealt) {return;}
	tabs(t->margin);

	for (i = 0; i < t->NO_OF_PLAYERS; i++) {/*All conditions eventually return or break loop*/
        
        /*Display player's hand and appropriate number of spaces to next player*/

        displayPlayerHand(t->players[i]);
        /*Spaces algorithm*/
        if (i < t->NO_OF_PLAYERS - 1) {
            spaces(35 - (t->players[i]->playerHand->cardCount * 2) -
                    (t->players[i]->playerHand->cardCount - 1));
        }/*condition for last player; exit loop*/
        else break;
    }
}

void displayPlayers(table *t) {
	
	int i;
	assert(t);

	tabs(t->margin);
    for (i = 0; i < t->NO_OF_PLAYERS; i++) {
        displayPlayer(t->players[i]);
    }
    newlines(1);
}

void displayBet(int bet) {

	printf("Bet:    $%d", bet);
        
    /*number of spaces to next player algorithm*/
    if (bet > 0) {
        spaces(27 - ((int)log10((double)bet)  + 1));
    }
    else spaces(26);
}

void displayAllBets(table *t) {

	int i;
	assert(t);

	tabs(t->margin);
    for (i = 0; i < t->NO_OF_PLAYERS; i++) {
		displayBet(t->players[i]->bet);
    }
    newlines(1);
}

void displayTable(table *t) {
    
    assert(t);
   
	displayDealer(t);
    
    /*Player names, dollar amount line display */
	displayPlayers(t);
    
    /*Current bet display line*/
	displayAllBets(t);

    /*Player hand display line:  Displays the player's hand if already dealt one*/
	displayAllPlayerHands(t);
}

void prompt_noHumanPlayers() {printf("Enter a number of human players between 0 - 4\n");}

int input_noHumanPlayers() {

	int noPlayers;

	scanf_s("%d", &noPlayers);
	return noPlayers;
}  

void prompt_playerName(int playerNo) {printf("Enter player %d's name:\n", playerNo);}

char *input_playerName() {

	static char buffer[BUFFERSIZE];

	scanf_s(" %63s", buffer, 64);
    newlines(1);

	return buffer;
}

void prompt_noCompPlayers(int maxComps) {printf("Enter number of computer players between 0 - %d\n", maxComps);}

int input_noCompPlayers() {
    
	int no_Comps;
	scanf_s(" %d", &no_Comps);

	return no_Comps;
}

void prompt_playerTurn(table *t) {

	assert(t);
    printf("Hit: h\tStay: s\n");
    newlines(1);
    tabs(t->margin);
    spaces(t->buffer);
}

char input_playerTurn() {

	char ans;
	ans = 'd';

	scanf_s(" %c", &ans);
	return ans;
}

/*
 Print a string representing the instance of struct card
 -----------------------------------------------------------------------------------------
 Parameters: struct card *c
 Preconditions: c is not null
 Postconditions: a string representing the card is printed to the console
 */
void printCard(card *c) {
    
    char s[25];
    assert(c);
    strcpy_s(s, sizeof s, c->name);
    printf("%s\tWeight: %d\t%s\n", c->abbr, c->value->weight, c->name);
}

void displayCard(card *c) {
    
    assert(c);
    
    if (c->shown == 1) {
        printf("%s ", c->abbr);
    }
    else printf("XX ");
}

/*
 Loops the printCard function for every struct card in the struct deck.
 -----------------------------------------------------------------------------------------
 Parameters: deck *d
 Preconditions: d is not null
 Postconditions: the printCard function is called on every struct card in the struct deck.
 */
void printDeck(deck *d) {
    
    int i;
    assert(d);
    
    for (i = 0; i < NO_OF_CARDS; i++){
        printCard(d->cards[i]);
    }
}