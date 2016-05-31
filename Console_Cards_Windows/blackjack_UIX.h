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

void spaces(int s);

void newlines(int n);

void tabs(int t);

void handFeedBack_Display_ALL(table *t);

void CL_handFeedBack_Display(table *t, int player);

void displayDealer(table *t);

void displayPlayer(player *p);

void displayPlayerHand(player *p);

int continueGamePrompt(table *t);

void getBets(table *t);

void displayPlayers(table *t);

void displayBet(int bet);

void displayAllBets(table *t);

#endif