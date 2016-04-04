//
//  cards_suits.h
//  Console_Cards
//
//  Created by Charles Hardes on 3/23/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//

#ifndef __Console_Cards__cards_suits__
#define __Console_Cards__cards_suits__

/*Initialize the cardSuit struct, setting trump and weight to 0
 Convert a string into the name of the suit, set the abbreviation
 to the first letter of the string, changing to lowercase when necessary
 */
void _initCardSuit(cardSuit *v, const char *s);


/*Create an instance of the struct cardSuit, pass a pointer to it and its name
 as a string into _initCardSuit() to initialize it, return the pointer to the struct cardSuit
 */
cardSuit *createCardSuit(const char *s);


/*Free an instance of struct cardSuit
 */
void _deleteCardSuit(cardSuit *v);


/*Fill an empty array of pointers to struct cardSuit with instances of struct cardSuit
 from the static const array of strings: char *suits[NO_OF_SUITS]
 */
void makeCardSuits(cardSuit *s[]);


/*Get rid of the array of cardSuit pointers used to create the deck
 */
void _deleteCardSuits(cardSuit *s[]);


void setTrumpSuit(cardSuit *cs);


void desetTrumpSuit(cardSuit *cs);


int isTrump(cardSuit *cs);


void setSuitWeight(cardSuit *cs, int w);


int compareSuits(cardSuit *cs1, cardSuit *cs2);



#endif /* defined(__Console_Cards__cards_suits__) */
