//
//  cards_structs.h
//  Blackjack
//
//  Created by Charles Har#des on 3/18/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//

#ifndef cards_structs_h
#define cards_structs_h

#include "cards_globals.h"

typedef struct card card;
typedef struct cardSuit cardSuit;
typedef struct cardValue cardValue;
typedef struct deck deck;

struct cardValue{
    char name[10];
    char abbr;
    int weight;
};

struct cardSuit{
    char name[10];
    char abbr;
    int trump;
    int weight;
};

struct card{
    cardSuit *suit;
    cardValue *value;
    char name[25];
    char abbr[3];
    int shown;
    int wildcard;
};

struct deck{
    card *cards[NO_OF_CARDS];/*initialize array of cards ptrs*/
    cardSuit *suits[NO_OF_SUITS];
    cardValue *values[NO_OF_CARD_VALUES];
    card *top;
    int cards_left;
};

#endif
