//
//  cards_values.h
//  Console_Cards
//
//  Created by Charles Hardes on 3/23/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//

#ifndef __Console_Cards__cards_values__
#define __Console_Cards__cards_values__

/*Initialize the cardValue struct
 Convert a string into the name of the card's value, set the abbreviation
 to the capital first letter of the string parameter, name, or numeral for numbered values (0 - 10)
 Set the weight to the parameter, "value"
 */
void _initCardValue(cardValue *cv, const char *name, const int value);


/*Create an instance of the struct cardValue, pass a pointer to it and its name
 as a string into _initCardSuit() to initialize it, return the pointer to the struct cardSuit
 cardValue *cardValueCreate(const char *name, const int value);
 */
cardValue *cardValueCreate(const char *name, const int value);


/*Free an instance of struct cardValue
 */
void _deleteCardValue(cardValue *cv);


/*Fill the passed array of pointers to struct cardValue with pointers from newly created
 instances of struct cardValue using the inner cardValueCreate function
 */
void makeCardValues(cardValue **cv);

void makeHiLoAces(cardValue *cv[]);

void setHiAce(card *c);

void setLoAce(card *c);

int isHiAce(card *c);

/*
 Delete every element of an array of cardValue pointers using a loop and the
 inner _deleteCardValues function
 */
void _deleteCardValues(cardValue *cv[]);



#endif /* defined(__Console_Cards__cards_values__) */
