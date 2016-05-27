//
//  cards.c
//  Blackjack
//
//  Created by Charles Hardes on 3/18/15.
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

/*******************CARD**************************/


/*
 Create an instance of struct card, passing in pointers to struct cardValue and struct cardSuit,
 which will then be initialized as the newCard's properties newCard->cardValue and newCard->suit
 using the inner _initCard function
 -----------------------------------------------------------------------------------------
 Parameters:
    struct cardValue *cv
    struct cardSuit *s
 Preconditions: cv and s are not null
 Postconditions: a pointer to the newly created instance of struct card is returned
 -----------------------------------------------------------------------------------------
 */
card *createCard(cardValue *cv, cardSuit *s){
    
    card *newCard;
    assert((cv) && (s));
    
    newCard = (card*)malloc(sizeof(card));
    _initCard(newCard, cv, s);
    return newCard;
}

/*
 Initialize a struct card with pointers to structs cardValue and cardSuit, setting the cardValue
 and cardSuit properties of the struct card, respectively. Also, set the full name of the card to
 a string concatenated with the cardValue name + " of " + cardSuit name, and the abbreviation is
 similarly created by concatenating the two characters corresponding to cardValue and cardSuit.
 Set the shown and wildcard properties to 0
 -----------------------------------------------------------------------------------------
 Parameters:
    struct card *c
    struct cardValue *cv
    struct cardSuit *s
 Preconditions: c, cv, and s are not null
 Postconditions: an instance of struct card is initialized with structs cardValue and cardSuit
 */
void _initCard(card *c, cardValue *cv, cardSuit *s){
    
    char of[20] = " of ";
    char value[20], suits[20];
    assert((c) && (cv) && (s));
    
    c->suit = (cardSuit *)malloc(sizeof(cardSuit *));
    c->suit = s;
    c->value = (cardValue *)malloc(sizeof(cardValue *));
    c->value = cv;
    
    /*concatenate strings to form card name i.e. "Three of Hearts" stackoverflow.com/questions/1114741/how-to-convert-int-to-char-c */
    strcpy_s(value, sizeof value, c->value->name);
    strcpy_s(suits, sizeof suits, c->suit->name);
    strcat_s(value, sizeof value, of);
    strcat_s(value, sizeof value, suits);
    strcpy_s(c->name, sizeof c->name, value);
    
    /*set the two characters of abbr to value abbreviation, cardSuit abbreviation
     i.e. 9d = "Nine of Diamonds"*/
    c->abbr[0] = cv->abbr;
    c->abbr[1] = s->abbr;
	c->abbr[2] = '\0';
    
    c->shown = 0;
    c->wildcard = 0;
}

/*algorithm for irregular card creation; may need adjusting in certain cases
 -currently set to create Jokers*/

#if NO_OF_EXTRA_CARDS != 0
void makeExtraCards(card *c[]) {
    
    int i;
    for (i = 0; i < NO_OF_EXTRA_CARDS; i++) {
        c[i] = (card *)malloc(sizeof(card));
        strcpy_s(c[i]->name, extraCards[i]);
        c[i]->abbr[0] = extraCards[i][0];
        c[i]->abbr[1] = '\0';
        c[i]->suit = (cardSuit *)malloc(sizeof(cardSuit));
        strcpy_s(c[i]->suit->name, "");
        c[i]->suit->abbr = '\0';
        c[i]->suit->trump = 0;
        c[i]->suit->weight = 0;
        c[i]->value = (cardValue *)malloc(sizeof(cardValue));
        c[i]->value->abbr = '\0';
        strcpy_s(c[i]->value->name, "");
        c[i]->value->weight = 0;
        c[i]->wildcard = 1;
    }
}

void _deleteExtraCards() {
    int i;
    assert(NO_OF_EXTRA_CARDS > 0);
    for (i = 0; i < NO_OF_EXTRA_CARDS; i++) {
        _deleteCardSuit(extraCardsArr[i]->suit);
        _deleteCardValue(extraCardsArr[i]->value);
        _deleteCard(extraCardsArr[i]);
    }
}
#endif

/*
 Print a string representing the instance of struct card
 -----------------------------------------------------------------------------------------
 Parameters: struct card *c
 Preconditions: c is not null
 Postconditions: a string representing the card is printed to the console
 */
void printCard(card *c) {
    
    char s[25];
    assert(c);
    strcpy_s(s, sizeof s, c->name);
    printf("%s\tWeight: %d\t%s\n", c->abbr, c->value->weight, c->name);
}

void displayCard(card *c) {
    
    assert(c);
    
    if (c->shown == 1) {
        printf("%s", c->abbr);
    }
    else printf("XX");
}

void showCard(card *c) {
    
    assert(c);
    
    c->shown = 1;
}

void hideCard(card *c) {
    
    assert(c);
    
    c->shown = 0;
}

/*
 Free an instance of struct card
 -----------------------------------------------------------------------------------------
 Parameters: struct card *c
 Preconditions: c is not null
 Postconditions: the memory pointed to by the struct card pointer is freed
 -----------------------------------------------------------------------------------------
 */
void _deleteCard(card *c){
    
    assert(c);
    free(c);
}
