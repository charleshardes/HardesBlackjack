//
//  decks.c
//  Console_Cards
//
//  Created by Charles Hardes on 3/25/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//

#include <stdlib.h>
#include <stdio.h>
#include <assert.h>
#include <string.h>
#include <time.h>
#include "cards_globals.h"
#include "cards_structs.h"
#include "cards_suits.h"
#include "cards_values.h"
#include "cards.h"
#include "decks.h"

/***********DECK******************/


/*
 Initialize an instance of struct deck by creating instances of struct card and initializing
 them using global arrays of pointers to structs of type cardValue and cardSuit, respectively.
 Set the cards_left property to the size of the deck.
 -----------------------------------------------------------------------------------------
 Parameters: deck *d
 Preconditions:
 - d is not null
 - global values: NO_OF_CARDS, NO_OF_DECKS, NO_OF_SUITS, NO_OF_CARD_ALUES, and NO_OF_EXTRA_CARDS are
   accurately entered and correspond to the aforementioned global arrays to be filled here
 - Total number of cards in the deck is equal to the # of suits times the # of values + extras
 Postconditions: The deck is initialized and filled with NO_OF_CARDS instances of struct card pointers.
 */
void _initDeck(deck *d){
    
    int h, i, j, k = 0;
    assert(d);
    assert(NO_OF_CARDS == NO_OF_DECKS * ((NO_OF_SUITS * NO_OF_CARD_VALUES) + NO_OF_EXTRA_CARDS));
    
    makeCardSuits(suitArr);//fills the global array of pointers to cardSuit structs
    makeCardValues(valueArr);//fills the global array of pointers to cardValue structs
    if (HI_LO_ACES == 1) {
        makeHiLoAces(hi_loAceArr);/*fills the global array of pointers to separate card structs (so that changing one ace to hi/lo does not change all aces to hi/lo.*/
    }
	#if NO_OF_EXTRA_CARDS > 0
        makeExtraCards(extraCardsArr);
	#endif
    
    /*deck loop*/
    for (h = 0; h < NO_OF_DECKS; h++) {
        
        /*cardSuit loop*/
        for (i = 0; i < NO_OF_SUITS; i++){
            d->suits[i] = suitArr[i];
            /*cardValue loop*/
            for(j = 0; j < NO_OF_CARD_VALUES; j++){
                d->values[i] = valueArr[i];
                d->cards[k] = createCard(valueArr[j], suitArr[i]);
                if ((HI_LO_ACES == 1) && (strcmp(d->cards[k]->value->name, "Ace") == 0)) {
                    d->cards[k]->value = hi_loAceArr[i];
                }
                k++;
            }
        }
		#if NO_OF_EXTRA_CARDS > 0
			for (i = 0; i < NO_OF_EXTRA_CARDS; i++) {
				d->cards[k] = extraCardsArr[i];
			}
		#endif
    }
    d->cards_left = NO_OF_CARDS;
    d->top = d->cards[NO_OF_CARDS - 1];
}

/*
 Create an instance of struct deck. Initialize and fill it, using the inner _initDeck function.
 Return a pointer to the newly created instance of struct deck
 -----------------------------------------------------------------------------------------
 Parameters: none
 Preconditions: none
 Postconditions: a pointer to the newly initilized and filled struct deck is returned.
 -----------------------------------------------------------------------------------------
 */
deck *createDeck(){
    
    struct deck *newDeck = (deck *)malloc(sizeof(deck));
    _initDeck(newDeck);
    return newDeck;
}

/*
 Free the memory allocated to every instance of structs: cardSuit, cardValue, extraCards and 
 card in the suitArr, valueArr, and extraCardsArr. Then, free every struct card and the struct deck itself.
 This function should only be used at the conclusion of the program, to free all memory, not to reshuffle the deck
 -----------------------------------------------------------------------------------------
 Parameters: deck *d
 Preconditions: d is not null
 Postconditions: Everything in the struct deck is freed, as well as the struct deck itself.
 */
void _deleteDeck(deck *d){
    
    int h, i;
    assert(d);
    
    _deleteCardSuits(suitArr);
    _deleteCardValues(valueArr);
    if (HI_LO_ACES == 1) {
        for (h = 0; h < NO_OF_SUITS; h++) {
            _deleteCardValue(hi_loAceArr[h]);
        }
    }
	#if (NO_OF_EXTRA_CARDS > 0)
    _deleteExtraCards(extraCardsArr);
	#endif

    for (i = 0; i < NO_OF_CARDS; i++) {
        _deleteCard(d->cards[i]);
    }
    free(d);
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

/*
 Shuffles any struct deck of any size greater than 0. This funciton is meant to be used to
 shuffle full decks as well as discard piles to be used as partial decks. It returns a deck
 of the same size with randomly shuffled cards.
 -----------------------------------------------------------------------------------------
 Parameters: deck *d
 Preconditions: d is not null, there is at least one card in the struct deck
 Postconditions: a deck of the same size as the parameter is returned with shuffled cards. The
 remaining slots in the deck are NULL until the rest of the cards are returned to the deck.
 NOTE: If this function is being called on a discard pile, the returned value should be assigned
 to the new deck to be used and the table's discard pile attribute cleared immediately after
 calling this function. This function does not take care of that.
 
 */
deck *shuffle(deck *d) {
    
    time_t t;
    int i, n, cardsLeft;
    deck *shuffled;
    assert(d && !isEmpty(d));
    
    /*create, initialize temporary deck to all cards NULL*/
    cardsLeft = d->cards_left;
    shuffled = (deck *)malloc(sizeof(deck));
    clearDeck(shuffled);
    
    /* Intializes random number generator */
    srand((unsigned) time(&t));
    
    /* puts each of the cards from d into a random slot in shuffled */
    for( i = 0 ; i < cardsLeft ; i++ ) {
        n = rand() % cardsLeft;
        while (shuffled->cards[n] != NULL) {
            n++;/*find empty slot*/
            if (n == cardsLeft) {n = 0;}/*loop back to beginning of deck*/
        }
        shuffled->cards[n] = d->cards[i];/*puts card in empty slot*/    }
    
    /*assign shuffled cards back to original deck with rest of cards NULL*/
    for (i = 0; i < NO_OF_CARDS; i++) {
        d->cards[i] = shuffled->cards[i];
    }
    
    d->top = d->cards[cardsLeft - 1];/*sets last card to top card*/
    
    free(shuffled);
    return d;
    
}

card *_popCard(deck *d) {
    card *popped;
    assert(d);
    assert(d->cards_left != 0);
    popped = d->top;
    
    /*Regular condition*/
    if (d->cards_left != 1) {
        d->top = d->cards[d->cards_left - 2];
    }
    /*Condition for popping last card in deck, leaving empty deck*/
    else d->top = NULL;
    d->cards_left--;
    
    return popped;
}

/*(cards[51] is top card in full deck)*/
void _pushCard(deck *d, card *c) {
    assert((d) && (c));
    assert(d->cards_left <= NO_OF_CARDS);
    d->cards_left++;
    d->cards[d->cards_left - 1] = c;
    d->top = c;
}

int isEmpty(deck *d) {
    assert(d);
    if (d->cards_left == 0) {return 1;}
    else return 0;
}

void clearDeck(deck *d) {

	int i = 0;
    assert(d);



    /*make all cards null*/
    for (i = 0; i < NO_OF_CARDS; i++) {
        d->cards[i] = NULL;
    }
    
    d->cards_left = 0;
    d->top = NULL;
}



