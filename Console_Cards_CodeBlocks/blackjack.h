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

void spaces(int s);

void newlines(int n);

void tabs(int t);

int getPlayers();

void dealStartingHands(table *t, deck *d);

void playerTurn(table *t, player *p, deck *d);

void dealerTurn(table *t, deck *d);

void takeScores(table *t);

int getComps(int maxComps);

#endif /* defined(__Console_Cards__blackjack__) */
