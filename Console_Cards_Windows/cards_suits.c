//
//  cards_suits.c
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
#include "cards.h"

/*******SUIT****************/

/*Initialize the cardSuit struct, setting trump and weight to 0
 Convert a string into the name of the suit, set the abbreviation
 to the first letter of the string, changing to lowercase when necessary
 -----------------------------------------------------------------------------------------
 Parameters:
 cardSuit *v
 char *s
 Preconditions: v, s are not null;
 Postconditions:
 v->trump initialized to 0
 v->weight initialized to 0
 v->name set to s
 v->abbr set to first letter of s (lowercase)
 ------------------------------------------------------------------------------------------
 */
void _initCardSuit(cardSuit *v, const char *s){
    
    char temp;
    assert((v) && (s));
    
    v->trump = 0;
    v->weight = 0;
    strcpy_s(v->name, sizeof v->name, s);
    temp = v->name[0];
    if (temp >= 'A') {/*if first letter of s is capital*/
        v->abbr = temp + 'a' - 'A';/*convert to lowercase*/
    }
    else v->abbr = temp;/*set abbr to first letter*/
}

/*Create an instance of the struct cardSuit, pass a pointer to it and its name
 as a string into _initCardSuit() to initialize it, return the pointer to the struct cardSuit
 -----------------------------------------------------------------------------------------
 Parameters: char *s
 Preconditions: s is not null;
 Postconditions: new instance of struct cardSuit created, its pointer is returned
 -----------------------------------------------------------------------------------------
 */
cardSuit *createCardSuit(const char *s){
    
    struct cardSuit *newCardSuit;
    assert(s);
    
    newCardSuit = (cardSuit *) malloc(sizeof(cardSuit));
    _initCardSuit(newCardSuit, s);
    return newCardSuit;
}

/*Free an instance of struct cardSuit
 -----------------------------------------------------------------------------------------
 Parameters: cardSuit *v
 Preconditions: none
 Postconditions: memory allocated struct cardSuit is freed
 -----------------------------------------------------------------------------------------
 */
void _deleteCardSuit(cardSuit *v) {
    
    assert(v);
    
    free(v);
}

/*Fill an empty array of pointers to struct cardSuit with instances of struct cardSuit
 from the static const array of strings: char *suits[NO_OF_SUITS]
 -----------------------------------------------------------------------------------------
 Parameters: cardSuit **s
 Preconditions:  s is not null; (is empty, though)
 -----------------------------------------------------------------------------------------
 */
void makeCardSuits(cardSuit *s[]) {
    
    int i;
    assert(s);
    
    /*create cardSuit and store it in array*/
    for (i = 0; i < NO_OF_SUITS; i++) {
        s[i] = createCardSuit(suits[i]);
    }
}

/*Get rid of the array of cardSuit pointers used to create the deck
 -----------------------------------------------------------------------------------------
 Parameters: cardSuit *s[]
 Preconditions: s is not null
 Postconditions: every element in the array, cardSuit *s[] is freed
 -----------------------------------------------------------------------------------------
 */
void _deleteCardSuits(cardSuit *s[]) {
    
    int i;
    assert(s);
    
    for (i = 0; i < NO_OF_SUITS; i++) {
        _deleteCardSuit(s[i]);
    }
}

void setTrumpSuit(cardSuit *cs){
    
    assert(cs);
    
    cs->trump = 1;
}

void desetTrumpSuit(cardSuit *cs){
    
    assert(cs);
    
    cs->trump = 0;
}

int isTrump(cardSuit *cs){
    
    assert(cs);
    
    return cs->trump;
}

void setSuitWeight(cardSuit *cs, int w){
    
    assert(cs);
    
    cs->weight = w;
}

int compareSuits(cardSuit *cs1, cardSuit *cs2){
    
    assert((cs1) && (cs2));
    
    return strcmp(cs1->name, cs2->name);
    
}
