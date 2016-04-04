//
//  blackjack_table.h
//  Console_Cards
//
//  Created by Charles Hardes on 3/28/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//

#ifndef __Console_Cards__blackjack_table__
#define __Console_Cards__blackjack_table__

#include <stdio.h>

void _initTable(table *t, int NO_OF_PLAYERS, int NO_OF_COMPS);

table *createTable(int NO_OF_PLAYERS, int NO_OF_COMPS);

void _deleteTable(table *t);

void dealCard(table *t, deck *d, player *p, int shown);

void clearTable(table *t);

void pileToDeck(table *t, deck *d);

void dealToPlayers(table *t, deck *d);

void displayTable(table *t, int dealt);

#endif /* defined(__Console_Cards__blackjack_table__) */
