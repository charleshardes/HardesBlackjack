//
//  cards_values.c
//  Console_Cards
//
//  Created by Charles Hardes on 3/23/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//

#include <stdlib.h>
#include <stdio.h>
#include <assert.h>
#include <string.h>
#include "cards_globals.h"
#include "cards_structs.h"
#include "cards_suits.h"
#include "cards.h"
#include "cards_values.h"

/*Initialize the cardValue struct
 Convert a string into the name of the card's value, set the abbreviation
 to the capital first letter of the string parameter, name, or numeral for numbered values (0 - 10)
 Set the weight to the parameter, "value"
 -----------------------------------------------------------------------------------------
 Parameters:
 cardValue *cv
 const char *name
 const int value
 Preconditions:
 cv is not null
 name is not null
 Postconditions:
 cv->name is set to name
 cv->abbr is set to first char of name or numeric for 1-9
 cv->weight is set to value
 -----------------------------------------------------------------------------------------
 */
void _initCardValue(cardValue *cv, const char *name, const int value) {
    
    assert((cv != NULL) && (name != NULL));
    
    strcpy(cv->name, name);
    cv->weight = value;
    
    /*if the card is a ten, its abbreviation is 'T'*/
    if (strcmp(name, "Ten") == 0) {
        cv->abbr = 'T';
    }
    /*if number card, cast numberic value to char for abbr*/
    else if (value < 10) {
        cv->abbr = (char)(((int)'0') + value);/*source: http://stackoverflow.com/questions/1114741/how-to-convert-int-to-char-c*/
    }
    /*if face card of ace, card abbr is first letter of cardname*/
    else cv->abbr = name[0];
}

/*Create an instance of the struct cardValue, pass a pointer to it and its name
 as a string into _initCardSuit() to initialize it, return the pointer to the struct cardSuit
 -----------------------------------------------------------------------------------------
 Parameters:
 const char *name,
 const int value
 Preconditions: name is not null
 Postconditions:
 an instance of struct cardValue is created and filled with new values,
 a pointer to it is returned
 -----------------------------------------------------------------------------------------
 */
cardValue *cardValueCreate(const char *name, const int value) {
    
    
    cardValue *newCardValue = (cardValue *)malloc(sizeof(cardValue));
    assert(name);
    
    _initCardValue(newCardValue, name, value);
    return newCardValue;
}

int isHiAce(card *c) {
    assert(c);
    if (!(strcmp(c->value->name, "Ace") == 0)) {
        return 0;
    }
    
    if (c->value->weight == 11) {return 1;}
    else if (c->value->weight == 1) {return 0;}
    else exit(0);
}

void setHiAce(card *c) {
    assert (c);
    assert(strcmp(c->value->name, "Ace") == 0);
    
    c->value->weight = 11;
}

void setLoAce(card *c) {
    assert(c);
    assert(strcmp(c->value->name, "Ace") == 0);
    
    c->value->weight = 1;
}

/*Free an instance of struct cardValue
 -----------------------------------------------------------------------------------------
 Parameters: cardValue *cv
 Preconditions: cv is not null
 Postconditions: the strut cardValue pointed to by cv is freed
 -----------------------------------------------------------------------------------------
 */
void _deleteCardValue(cardValue *cv) {
    
    assert(cv);
    
    free(cv);
}

/*Fill the passed array of pointers to struct cardValue with pointers from newly created
 instances of struct cardValue using the inner cardValueCreate function
 -----------------------------------------------------------------------------------------
 Parameters: cardValue *cv[]
 Preconditions: cv is  not null
 Postconditions: the array is filled with
 -----------------------------------------------------------------------------------------
 */
void makeCardValues(cardValue *cv[]){
    
    int i;
    assert(cv);
    
    for(i = 0; i < NO_OF_CARD_VALUES; i++) {
        cv[i] = cardValueCreate(values[i], weights[i]);
    }
}

void makeHiLoAces(cardValue *cv[]) {
    int i, j;;
    assert(cv);
    for (i = 0; i < NO_OF_SUITS; i++) {
        for (j = 0; j < NO_OF_CARD_VALUES; j++) {
            if (strcmp(values[j], "Ace") == 0) {break;}
        }
        cv[i] = cardValueCreate(values[j], weights[j]);
    }
}

/*
 Delete every element of an array of cardValue pointers using a loop and the
 inner _deleteCardValues function
 -----------------------------------------------------------------------------------------
 Parameters: *cv[]
 Preconditions: cv is not null
 Postconditions: every instance of struct cardValue is freed in the array
 -----------------------------------------------------------------------------------------
 */
void _deleteCardValues(cardValue *cv[]){
    
    int i;
    assert(cv);
    
    for (i = 0; i < NO_OF_CARD_VALUES; i++){
        _deleteCardValue(cv[i]);
    }
}
