//
//  blackjack_structs.h
//  Console_Cards
//
//  Created by Charles Hardes on 3/28/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//

#ifndef Console_Cards_blackjack_structs_h
#define Console_Cards_blackjack_structs_h

typedef struct hand hand;
typedef struct player player;
typedef struct table table;



struct hand {
    int starting;
    card *cards[22];
    int score;
    int bust;
    int canSplit;
    int hasSplit;
	hand *splitHand;
    int hasBlackjack;
    int cardCount;
    int hiAces;
    int win;
    int lose;
    int push;
    int hasInsurance;
    int insuranceAmt;
	int doubledDown;
	int hasEnded;
	int bet;
};

struct player {
    int dealer;
    int computer;
    char name[20];
    int pos;
    hand *playerHand;
    int chips;
};

struct table {
    player *dealer;
    player *players[4];
    int NO_OF_PLAYERS;
    int NO_OF_COMPS;
    deck *discardPile;
    int currPlayer;
    int spacing;
    int margin;
	int handsAreDealt;
	int hasSplits;
};

#endif
