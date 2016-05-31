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

void handFeedBack_Display_ALL(table *t) {

	    /*Alert line display:
     Displays an alert message when player has won, gotten blackjack, busted, lost, pushed
     (as determined by the assessHand() function) and prints appropriate number of spaces 
     to next player as per algorithms below*/

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
    displayTable(t, 0);
    return;/*extra recursive record exited*/
}