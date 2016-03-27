//
//  cards_globals.h
//  Console_Cards
//
//  Created by Charles Hardes on 3/21/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//


#ifndef Console_Cards_cards_globals_h
#define Console_Cards_cards_globals_h

/*the following global variables must be set according to desired card/deck specifications*/
static const int NO_OF_DECKS =          1;
static const int NO_OF_SUITS =          4;
static const int NO_OF_CARD_VALUES =    13;
static const int NO_OF_EXTRA_CARDS =    0;
static const int HI_LO_ACES =           1;/* Can aces be both hi or lo? 1 = yes; 0 = no */
static const int NO_OF_CARDS =          NO_OF_DECKS * ((NO_OF_CARD_VALUES * NO_OF_SUITS) + NO_OF_EXTRA_CARDS);

/*Names of card suits must be hard coded here
 Number of suits must be equal to NO_OF_SUITS
 */
static const char *suits[NO_OF_SUITS] =

{
    "Hearts",
    "Spades",
    "Diamonds",
    "Clubs"
};

/*Names of card values must be hard coded here.
 The number of card values must be equal to NO_OF_CARD_VALUES
 */
static const char *values[NO_OF_CARD_VALUES] =

{
    "Two",
    "Three",
    "Four",
    "Five",
    "Six",
    "Seven",
    "Eight",
    "Nine",
    "Ten",
    "Jack",
    "Queen",
    "King",
    "Ace"
};


/*The weight (or value) of card values must be hard coded here.
 The number of card value weights must be equal to NO_OF_CARD_VALUES
 */
static const int weights[NO_OF_CARD_VALUES] =

{
    2,
    3,
    4,
    5,
    6,
    7,
    8,
    9,
    10,
    10,
    10,
    10,
    11
};


/*Enter any irregular cards here i.e. Jokers*/
static const char *extraCards[NO_OF_EXTRA_CARDS] =

{
    /*"J1",
     "J2"*/
};


#endif
