//
//  blackjack_players.h
//  Console_Cards
//
//  Created by Charles Hardes on 3/28/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//

#ifndef __Console_Cards__blackjack_players__
#define __Console_Cards__blackjack_players__

#include <stdio.h>

void _initPlayer(player *p, int pos, int isDealer, int isComputer);

player *createPlayer(char *name, int pos, int isDealer, int isComputer);

void _deletePlayer(player *p);

void newPlayerHand(player *p);

void displayPlayer(player *p);

void displayPlayerHand(player *p);

#endif /* defined(__Console_Cards__blackjack_players__) */
