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
    t->buffer = 0;
    t->margin = 0;
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


/*discards all hands to discard pile for new round*/
void clearTable(table *t) {
    
    int i;
	assert(t);
    
    for (i = 0; i < t->NO_OF_PLAYERS; i++) {
        discardHand(t, t->players[i]->playerHand);
        t->players[i]->bet = 0;
    }
    discardHand(t, t->dealer->playerHand);
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
        dealCard(t,d, t->players[i], 1);
    }
}
    
void displayTable(table *t, int dealt) {
    
    int i, line1Tabs, promptBuffer, bet;
    assert(t);
    
    /*Dealer display line*/
    newlines(5);
    tabs(9);
    displayPlayer(t->dealer);
    newlines(2);
    tabs(9);
    /*Condition that hand has already been dealt*/
    if (dealt) {
        displayHand(t->dealer->playerHand, t->dealer);
    }
    else newlines(1);
    newlines(6);
    
    /*Player name line display */
    line1Tabs = (int) (12 - (t->NO_OF_PLAYERS * 2.5));
    tabs(line1Tabs);
    for (i = 0; i < t->NO_OF_PLAYERS; i++) {
        displayPlayer(t->players[i]);
        
        /*algorithm to print the number of spaces to next player - characters used in previous player*/
        spaces(30 - strlen(t->players[i]->name) - (((int) log10((double)t->players[i]->chips))  + 1));
    }
    newlines(1);
    
    /*Current bet display line*/
    tabs(line1Tabs);
    for (i = 0; i < t->NO_OF_PLAYERS; i++) {
        printf("Bet:    $%d", t->players[i]->bet);
        
        /*number of spaces to next player algorithm*/
        if (t->players[i]->bet > 0) {
            spaces(27 - ((int)log10((double)t->players[i]->bet)  + 1));
        }
        else spaces(26);
    }
    newlines(1);
    
    /*Player hand or bet prompt display line:
     Displays the player's hand if already dealt one or a prompt to enter the bet amount
     if a hand not yet dealt to player.*/
    tabs(line1Tabs);
    i = 0;
    while (1) {/*All conditions eventually return or break loop*/
        
        /*Display player's hand and appropriate number of spaces to next player*/
        if (dealt) {
            displayPlayerHand(t->players[i]);
            /*Spaces algorithm*/
            if (i < t->NO_OF_PLAYERS - 1) {
                spaces(36 - (t->players[i]->playerHand->cardCount * 2) -
                       (t->players[i]->playerHand->cardCount - 1));
                i++;
            }/*condition for last player; exit loop*/
            else break;
        }
        /* The bet prompt line:
         Prints a prompt for player to enter the desired bet amount. Once entered, 
         displayTable() is called recursively to display the amount entered for the 
         player and to move on to next player.*/
        else {

            spaces(36 * t->currPlayer);
            printf("Enter bet amount: ");
            /*Error handling loop*/
            while (1) {
                scanf_s(" %d", &bet);
                if ((bet >= 0) && (bet <= 1000)) break;/*break loop if in range*/
                /*Error message*/
                printf("\nERROR: Bet must be between $1 - $1000\nEnter bet amount: ");
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
    }
    
    /*Alert line display:
     Displays an alert message when player has won, gotten blackjack, busted, lost, pushed
     (as determined by the assessHand() function) and prints appropriate number of spaces 
     to next player as per algorithms below*/
    newlines(1);
    tabs(line1Tabs);
    for (i = 0; i < t->NO_OF_PLAYERS; i++) {
        if (t->players[i]->playerHand->bust) {
            printf("BUSTED! ($%d-)", t->players[i]->bet);
            spaces(23 - (int)log10((double)t->players[i]->bet));
        }
        else if (t->players[i]->playerHand->hasBlackjack) {
            printf("BLACKJACK! ($%d+)", (int)((t->players[i]->bet * 3) / 2));
            spaces(20 - (int)log10((double)((t->players[i]->bet * 3) / 2)));
        }
        else if (t->players[i]->playerHand->win) {
            printf("WIN ($%d+)", t->players[i]->bet * 2);
            spaces(27 - (int)log10((double)(t->players[i]->bet * 2)));
        }
        else if (t->players[i]->playerHand->lose) {
            printf("LOSE ($%d-)", t->players[i]->bet);
            spaces(26 - (int)log10((double)t->players[i]->bet));
        }
        else if (t->players[i]->playerHand->push) {
            printf("PUSH ($0+)");
            spaces(26);
        }
        else spaces(36);
    }
    newlines(1);
    tabs(line1Tabs);
    promptBuffer = 36 * t->currPlayer;
    spaces(promptBuffer);
    t->buffer = promptBuffer;
    t->margin = line1Tabs;
    
}

