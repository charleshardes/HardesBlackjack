//
//  decks.h
//  Console_Cards
//
//  Created by Charles Hardes on 3/25/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//

#ifndef __Console_Cards__decks__
#define __Console_Cards__decks__

/*
 Initialize an instance of struct deck by creating instances of struct card and initializing
 them using global arrays of pointers to structs of type cardValue and cardSuit, respectively.
 Set the cards_eft property to the size of the deck.
 */
void _initDeck(deck *d);

/*
 Create an instance of struct deck. Initialize and fill it, using the inner _initDeck function.
 Return a pointer to the newly created instance of struct deck
 */
deck *createDeck();

/*
 Loops the printCard function for every struct card in the struct deck.
 */
void printDeck(deck *d);

/*
 Free the memory allocated to every struct card in the struct deck. Then, free the struct deck.
 */
void _deleteDeck(deck *d);

deck *shuffle(deck *d);

card *_popCard(deck *d);

void _pushCard(deck *d, card *c);

int isEmpty(deck *d);

void clearDeck(deck *d);

#endif /* defined(__Console_Cards__decks__) */
