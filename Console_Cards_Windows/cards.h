//
//  structs.h
//  Blackjack
//
//  Created by Charles Hardes on 3/18/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//

#ifndef cards_h
#define cards_h

/*The following arrays of structs are initialized according to the above global constants:
 NO_OF_SUITS, NO_OF_CARD_VALUES, AND NO_OF_CARDS and their structs will be filled according to the
 hard coded suits[], values[], and weights[] arrays as defined in "cards_globals.h".
 */
cardSuit *suitArr[NO_OF_SUITS];
cardValue *valueArr[NO_OF_CARD_VALUES];
card *cardArr[NO_OF_CARDS];
cardValue *hi_loAceArr[NO_OF_SUITS];
#if NO_OF_EXTRA_CARDS != 0
card *extraCardsArr[NO_OF_EXTRA_CARDS];
#endif

/*
 Initialize a struct card with pointers to structs cardValue and cardSuit, setting the cardValue
 and cardSuit properties of the struct card, respectively. Also, set the full name of the card to
 a string concatenated with the cardValue name + " of " + cardSuit name, and the abbreviation is
 similarly created by concatenating the two characters corresponding to cardValue and cardSuit.
 Set the shown and wildcard properties to 0
 */
void _initCard(card *c, cardValue *cv, cardSuit *s);

/*
 Create an instance of struct card, passing in pointers to struct cardValue and struct cardSuit,
 which will then be initialized as the newCard's properties newCard->cardValue and newCard->suit
 using the inner _initCard function
 */
card *createCard(cardValue *cv, cardSuit *s);

void makeExtraCards(card *c[]);

void _deleteExtraCards();

void showCard(card *c);

void hideCard(card *c);

/*
 Free an instance of struct card
 */
void _deleteCard(card *c);



#endif
