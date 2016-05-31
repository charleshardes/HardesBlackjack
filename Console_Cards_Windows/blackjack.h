//
//  blackjack.h
//  Console_Cards
//
//  Created by Charles Hardes on 3/28/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//

#ifndef __Console_Cards__blackjack__
#define __Console_Cards__blackjack__

#include <stdio.h>

char playerArr[4][10];

table *setTable();

int getPlayers();

void dealCard(table *t, deck *d, player *p, int shown);

void dealStartingHands(table *t, deck *d);

void playerTurn(table *t, player *p, deck *d);

void dealerTurn(table *t, deck *d);

void takeScores(table *t);

int getComps(int maxComps);

#endif /* defined(__Console_Cards__blackjack__) */
