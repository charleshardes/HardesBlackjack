//
//  blackjack_table.c
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
#include "blackjack_UIX.h"
#include "blackjack.h"


void _initTable(table *t, int NO_OF_PLAYERS, int NO_OF_COMPS) {
    
    int i, j = 0;
    char comp[10], playerNo[2], playerNoPtr[2];
    assert(t);
    
    t->dealer = createPlayer("Dealer",0,1,1);
    for (i = 0; i < NO_OF_PLAYERS - NO_OF_COMPS; i++) {
        t->players[i] = createPlayer(playerArr[i], (i + 1), 0, 0);
        j = i + 1;
    }
    t->NO_OF_PLAYERS = NO_OF_PLAYERS;
    
    for (i = 0; i< NO_OF_COMPS; i++) {
        playerNo[0] = (char)(((int)'0') + i + 1);/*convert int to char*/
        playerNo[1] = '\0';/*make string from char by adding endline character*/
        strcpy_s(playerNoPtr, sizeof playerNoPtr, playerNo);
        strcpy_s(comp, sizeof comp, "Computer");
        strcat_s(comp, sizeof comp, playerNoPtr);
        t->players[j] = createPlayer(comp, (j +1), 0, 1);
        j++;
    }
    t->NO_OF_COMPS = NO_OF_COMPS;
    
    /*create a deck to be pointed to by discardPile*/
    t->discardPile = (deck *)malloc(sizeof(deck));
    
    /*create array of pointers to struct card for discard pile*/
    for (i = 0; i < NO_OF_CARDS; i++) {
        t->discardPile->cards[i] = NULL;
    }
    t->discardPile->cards_left = 0;
    t->discardPile->top = NULL;

	t->currPlayer = 0;
    t->spacing = 0;
    t->margin = (int) (12 - (t->NO_OF_PLAYERS * 2.5));
	t->handsAreDealt = 0;
	t->hasSplits = 0;
}

table *createTable(int NO_OF_PLAYERS, int NO_OF_COMPS) {
    
    table *newTable;
    newTable = (table *)malloc(sizeof(table));
    _initTable(newTable, NO_OF_PLAYERS, NO_OF_COMPS);
    return newTable;
}

void _deleteTable(table *t) {
    
    int i, players;
    assert(t);
    
    players = t->NO_OF_PLAYERS;
    _deletePlayer(t->dealer);
    
    for (i = 0; i < players; i++) {
        _deletePlayer(t->players[i]);
    }
    free(t->discardPile);
    free(t);
}

/*discards all hands to discard pile for new round*/
void clearTable(table *t) {
    
    int i;
	assert(t);
    
    for (i = 0; i < t->NO_OF_PLAYERS; i++) {
        discardHand(t, t->players[i]->playerHand);
    }
    discardHand(t, t->dealer->playerHand);
	t->hasSplits = 0;
}

/*Transfers all cards from the discard pile back into the deck*/
void pileToDeck(table *t, deck *d) {
    
    int i;
    assert ((t) && (d));
    
    for (i = t->discardPile->cards_left - 1; i >= 0; i--) {
        _pushCard(d, t->discardPile->cards[i]);
        t->discardPile->cards[i] = NULL;
        t->discardPile->cards_left--;
    }
}

/*calls the dealCard function once for every non-dealer player at the table*/
void dealToPlayers(table *t, deck *d) {
    
    int i;
    assert((t) && (d));
    
    for (i = 0; i < t->NO_OF_PLAYERS; i++) {
        if (t->players[i]->playerHand->bust) {continue;}
		dealCard(t,d, t->players[i], t->players[i]->playerHand, 1);
    }
}
    


