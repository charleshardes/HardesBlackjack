//
//  blackjack_players.c
//  Console_Cards
//
//  Created by Charles Hardes on 3/28/15.
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
#include "decks.h"
#include "cards_test.h"
#include "blackjack_globals.h"
#include "blackjack_structs.h"
#include "blackjack_hands.h"
#include "blackjack_players.h"

player *createPlayer(char *name, int pos, int isDealer, int isComputer) {
    player *newPlayer;
    assert(((isDealer == 1) || (isDealer == 0)) && ((isComputer == 1) || (isComputer == 0)));
    
    newPlayer = (player *)malloc(sizeof(player));
    strcpy_s(newPlayer->name, sizeof newPlayer->name, name);
    _initPlayer(newPlayer, pos, isDealer, isComputer);
    return newPlayer;
}

void _initPlayer(player *p, int pos, int isDealer, int isComputer) {
    hand *newHand;
    assert(p);
    assert(((isDealer == 1) || (isDealer == 0)) && ((isComputer == 1) || (isComputer == 0)));
    
    p->dealer = isDealer;
    p->computer = isComputer;
    newHand = createHand();
    p->playerHand = newHand;
    p->pos = pos;
    p->chips = STARTING_CHIPS;
	p->bet = 0;
}

void _deletePlayer(player *p) {
    assert(p);
    _deleteHand(p->playerHand);
    free(p);
}

/*THINK THIS IS REDUNDANT...DELETE IF COMPILES/RUNS
void newPlayerHand(player *p) {
    assert(p);
    setNewHand(p->playerHand);
}
*/

void displayPlayer(player *p) {
    
    assert(p);
    
    if (p->dealer == 1) {
        printf("%s", p->name);
    }
    else {
        printf("%s     $%d", p->name, p->chips);
    }
}

void displayPlayerHand(player *p) {
    
    assert(p);
    if (p->dealer == 1) {return;}
    displayHand(p->playerHand, p);
}