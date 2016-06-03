//
//  blackjack.h
//  Console_Cards
//
//  Created by Charles Hardes on 3/28/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//

#ifndef __Console_Cards__blackjack_UIX__
#define __Console_Cards__blackjack_UIX__

#include <stdio.h>

void handFeedBack_Display_ALL(table *t);

void handFeedBack_Display(table *t, int player);

void displayDealer(table *t);

void displayPlayer(player *p);

void displayPlayerHand(player *p);

void displayAllPlayerHands(table *t);

int continueGamePrompt(table *t);

void getBets_ALL(table *t);

void displayPlayers(table *t);

void displayAllBets(table *t);

void displayTable(table *t);

void getBet(table *t);



#endif