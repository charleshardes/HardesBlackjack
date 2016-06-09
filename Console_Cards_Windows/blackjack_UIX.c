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
#include "blackjack_CLI.h"

/*
Alert line display:
Displays an alert message when player has won, gotten blackjack, busted, lost, pushed
(as determined by the assessHand() function) and prints appropriate number of spaces 
to next player as per algorithms below
*/
void handFeedBack_Display_ALL(table *t) {

	int i;
	assert(t);

	if (!t->handsAreDealt) {return;}/*escape this function if hands not yet dealt*/

    CL_newlines(1);
	CL_tabs(t->margin);

    for (i = 0; i < t->NO_OF_PLAYERS; i++) {
		handFeedBack_Display(t, i);
    }
    CL_newlines(1);

	/*set prompt for next player*/
    //CL_setPrompt(t);
}

void handFeedBack_Display(table *t, int player) {

	if (t->players[player]->playerHand == NULL) {CL_spaces(36);}
	else if (t->players[player]->playerHand->bust) {
        busted_Display(t, player);
    }
    else if (t->players[player]->playerHand->hasBlackjack) {
		blackjack_Display(t, player);
    }
    else if (t->players[player]->playerHand->win) {
        win_Display(t, player);
    }
    else if (t->players[player]->playerHand->lose) {
        lose_Display(t, player);
    }
    else if (t->players[player]->playerHand->push) {
        push_Display(t, player);
    }
    else CL_spaces(36);
}

int continueGamePrompt(table *t) {

	char ans;
	assert(t);

    CL_newlines(2);

	prompt_Continue();

	ans = input_Continue();

    if (ans == 'd') {
        clearTable(t);
		return 1;
    }
    else if (ans == 'q') {return 0;}
    else {
		error_ContinueGame();
		continueGamePrompt(t);
		return 0;
	}
}

void getBets_ALL(table *t) {

	/* position the CL prompt for bets */
	CL_setPrompt(t);

	/*prompt current player for a bet, accepts bet input, and handles errors */
	getBet(t);

    /*exit function, stop recursion if last player*/
    if (t->currPlayer == t->NO_OF_PLAYERS - 1) {
        t->currPlayer = 0;/*reset currPlayer to 0 for next line*/
        return;
    }
    t->currPlayer++;
    
	/* show table with updated bet entered */
    displayTable(t);

    /*Recusively called for players 2 and higher; acts as loop*/
	getBets_ALL(t);

    return;/*extra recursive record exited*/
}

void displayDealer(table *t) {

	/*Dealer display line*/
    CL_newlines(5);
    CL_tabs(9);
    displayPlayer(t->dealer);
    CL_newlines(2);
    CL_tabs(9);

    /*Condition that hand has already been dealt*/
	if (t->handsAreDealt) {
        displayHand(t->dealer->playerHand, t->dealer);
    }
    else CL_newlines(1);
    CL_newlines(6);
}

void displayPlayer(player *p) {
    
    assert(p);
    
	if (p->dealer == 1) {diplayDealerName(p);} /*print "Dealer" to screen at appropriate place */
    else {displayPlayerName(p);}

	/*algorithm to print the number of spaces to next player - characters used in previous player*/
    CL_spaces(30 - strlen(p->name) - (((int) log10((double)p->chips))  + 1));
}

void displayPlayerHand(player *p) {
    
    assert(p);
    if (p->dealer == 1) {return;}
    displayHand(p->playerHand, p);
}

void displayAllPlayerHands(table *t) {

	int i;

	if (!t->handsAreDealt) {return;}
	CL_tabs(t->margin);

	/*Display player's hand and appropriate number of spaces to next player*/
	for (i = 0; i < t->NO_OF_PLAYERS; i++) {/*All conditions eventually return or break loop*/
        
		/* condition for displaying split hands */
		if (t->players[i]->playerHand == NULL) {
			if (i == t->NO_OF_PLAYERS - 1) break;
			CL_spaces(36);
			continue;
		}
        displayPlayerHand(t->players[i]);
        /*Spaces algorithm*/
        if (i < t->NO_OF_PLAYERS - 1) {
            CL_spaces(35 - (t->players[i]->playerHand->cardCount * 2) -
                    (t->players[i]->playerHand->cardCount - 1));
        }/*condition for last player; exit loop*/
        else break;
    }
}

void displayPlayers(table *t) {
	
	int i;
	assert(t);

	CL_tabs(t->margin);
    for (i = 0; i < t->NO_OF_PLAYERS; i++) {
        displayPlayer(t->players[i]);
    }
    CL_newlines(1);

}

void displayAllBets(table *t) {

	int i, bet, isSplit;
	hand *h;
	assert(t);

	CL_tabs(t->margin);
    for (i = 0; i < t->NO_OF_PLAYERS; i++) {
		h = t->players[i]->playerHand;
		isSplit = 0;
		if (h != NULL) {
			bet = h->bet;
			if (h->handIndex) {
				displayHandIndex(h);
				isSplit = 1;
			}
			displayBet(bet);
			if (i == t->NO_OF_PLAYERS - 1) break; 
			else if (isSplit) {
				CL_spaces(23 - ((int)log10((double)bet)  + 1));
			}
			else if (bet > 0) {/*number of spaces to next player algorithm*/
				CL_spaces(27 - ((int)log10((double)bet)  + 1));
			}
			else CL_spaces(26);
		}
		else if (i == t->NO_OF_PLAYERS - 1) break;
		else CL_spaces(36);
    }
	CL_newlines(1);
}

void displayTable(table *t) {
    
	int i, splitsNotDone;
	hand *storeHands[4];

    assert(t);
   
	displayDealer(t);
    
    /*Player names, dollar amount line display */
	displayPlayers(t);
    
    /*Current bet display line*/
	displayAllBets(t);

    /*Player hand display line:  Displays the player's hand if already dealt one*/
	displayAllPlayerHands(t);

	/*Hand feedback diplay line: alerts to show blackjack, bust, win/lose/push*/
	handFeedBack_Display_ALL(t);

	/*If there are hands that are split, a new bet and hand will be displayed underneath
		the parent hand(s) it was split from */


	//displaySplitHands(t);
	//int i;
	//hand *storeHands[4];

	if (!t->hasSplits) return;

	/*store the original playerHand for reversion back when done splitting */
	for (i = 0; i < t->NO_OF_PLAYERS; i++) {
		storeHands[i] = t->players[i]->playerHand;
	}

	splitsNotDone = 0;
	do {
		/* set the playerHand to the next splitHand in the linked list of splitHands */
		for (i = 0; i < t->NO_OF_PLAYERS; i++) {
			t->players[i]->playerHand = t->players[i]->playerHand->splitHand;
			if (t->players[i]->playerHand != NULL) {
				if (t->players[i]->playerHand->splitHand != NULL) {
					splitsNotDone = 1;
				}
			}
		}
		displayAllBets(t);
		displayAllPlayerHands(t);
		handFeedBack_Display_ALL(t);

	} while(splitsNotDone);

	/* revert playerHands to original state */
	for (i = 0; i < t->NO_OF_PLAYERS; i++) {
		t->players[i]->playerHand = storeHands[i];
	}
}

void getBet(table *t) {

	int bet;
	assert(t);

    /*Error handling loop*/
    while (1) {
		
		prompt_betAmount();/*prompts user to enter a bet */
		bet = input_betAmount();/*takes user input*/

		/*break loop if amount is in proper range*/
		if ((bet >= 0) && (bet <= t->players[t->currPlayer]->chips)) break;

		/*Error message and loop back to prompt if bad input*/
		error_inputBet();
    }
	/*set the player's bet attribute according to bet and subtract from chips */
    t->players[t->currPlayer]->playerHand->bet = bet;
    t->players[t->currPlayer]->chips -= bet;
}

