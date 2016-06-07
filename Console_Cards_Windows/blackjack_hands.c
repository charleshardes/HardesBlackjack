//
//  blackjack_hands.c
//  Console_Cards
//
//  Created by Charles Hardes on 3/28/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//
#include <stdlib.h>
#include <stdio.h>
#include <assert.h>
#include <string.h>
#include "cards_globals.h"
#include "cards_structs.h"
#include "cards_suits.h"
#include "cards_values.h"
#include "cards.h"
#include "decks.h"
#include "cards_test.h"
#include "blackjack_globals.h"
#include "blackjack_structs.h"
#include "blackjack_players.h"
#include "blackjack_hands.h"
#include "blackjack_UIX.h"
#include "blackjack_CLI.h"

void _initHand(hand *h) {
    
	int i;
    assert(h);
    
    h->starting = NO_CARDS_START;
    h->score = 0;
    h->bust = 0;
    h->hasBlackjack = 0;
    h->cardCount = 0;
    h->hiAces = 0;
    h->win = 0;
    h->lose = 0;
    h->push = 0;
    h->splitHand = NULL;
    h->canSplit = 0;
    h->hasSplit = 0;
    h->hasInsurance = 0;
    h->insuranceAmt = 0;
	h->doubledDown = 0;
	h->hasEnded = 0;
	for (i = 0; i < MAX_CARDS_IN_HAND; i++) {
		h->cards[i] = NULL;
	}
}

hand *createHand() {
    
    hand *newHand;
    
    newHand = (hand *)malloc(sizeof(hand));
    _initHand(newHand);
    return newHand;
}

void setNewHand(hand *h) {
    
    assert(h);
    
    _initHand(h);
}

void setAllHands(table *t) {

	int i;

	/*create hand structs for each player*/
	for (i = 0; i < (t->NO_OF_PLAYERS); i++) {
		setNewHand(t->players[i]->playerHand);
    }

	/*create hand struct for dealer*/
	setNewHand(t->dealer->playerHand);

	/*reset handsAreDealt attribute back to false*/
	t->handsAreDealt = 0;
}

void _deleteHand(hand *h) {
    assert(h);
	h = NULL;
    free(h);
}

int isPair(hand *h) {
    assert(h);
    if (h->cardCount == h->starting) {
        if(strcmp(h->cards[0]->value->name, h->cards[1]->value->name) == 0) {
            return 1;
        }
    }
    return 0;
}

void assessHand(hand *h, int stayed) {
    
    int sum, i;
    assert(h);
    assert(h->cardCount >= h->starting);
    
    sum = 0;
    /*add up all card values*/
    for (i = 0; i < h->cardCount; i++) {
        sum += h->cards[i]->value->weight;
    }
    /*when starting hand is dealt, check for pairs and blackjack*/
    if (h->cardCount == h->starting) {
        
        /*condition that starting hand is a pair*/
        if (isPair(h)) {
            h->canSplit = 1;
        }
		else h->canSplit = 0;

        /*determine if player has blackjack*/
        if (sum == 21) {
            h->hasBlackjack = 1;
        }
    }
    /*determine if player has busted*/
    else if (sum > 21) {
        
        /*determine if player has a high ace that must be turned into low ace*/
        if (h->hiAces > 0) {
            i = 0;
            while (!isHiAce(h->cards[i])){
                i++;
            }
            setLoAce(h->cards[i]);
            h->hiAces--;
            assessHand(h, stayed);/*RECURSION!*/
            return;
        }
        h->bust = 1;
    }

	/*determine if the hand is now over*/
	if ((stayed) || (h->hasBlackjack) || (h->bust) || (h->doubledDown)) {h->hasEnded = 1;}

    h->score = sum;
}

void displayHand(hand *h, player *p) {
    
    int i;
    assert(h);
    
	for (i = 0; i < h->cardCount; i++) {
        displayCard(h->cards[i]);
    }
}

/*Takes every hand on the table including the dealer's and calls discardHand() to assign all 
 card pointers on the table to the discard pile*/
void discardHand(table *t, hand *h) {
    
    int i, cardCount;
    assert(h);

	/*if the hand has been split, the split hands must be discarded and also deleted */
	if (h->splitHand != NULL) {
		do {h->splitHand = h->splitHand->splitHand;} while (h->splitHand != NULL);
		discardHand(t, h->splitHand);
		_deleteHand(h->splitHand);
		discardHand(t, h);
		return;
	}

    /*If function is called on an empty hand, should not produce an error; just do nothing and return*/
    if (!h->cardCount) return;
    
    /*for every card in hand, push its pointer into discardPile, make its slot in h->cards null, decrease cardcount*/
    cardCount = h->cardCount;
    for (i = 0; i < cardCount; i++) {
        _pushCard(t->discardPile, h->cards[i]);
        h->cards[i] = NULL;
        h->cardCount--;
      
        /*If hand is split, recursively call function on the split hand(s)*/
/*        if (h->hasSplit) {
            discardHand(t, h->split);
        }*/
    }
    /*reset all hand properties*/
    _initHand(h);
}

