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

void CL_spaces(int s);

void CL_newlines(int n);

void CL_tabs(int t);

void CL_setPrompt(table *t);

void handFeedBack_Display_ALL(table *t);

void CL_handFeedBack_Display(table *t, int player);

void displayDealer(table *t);

void displayPlayer(player *p);

void displayPlayerHand(player *p);

void displayAllPlayerHands(table *t);

int continueGamePrompt(table *t);

void getBets(table *t);

void displayPlayers(table *t);

void displayBet(int bet);

void displayAllBets(table *t);

void displayTable(table *t);

void prompt_noHumanPlayers();

int input_noHumanPlayers();

void prompt_playerName(int playerNo);

char *input_playerName();

void prompt_noCompPlayers(int maxComps);

int input_noCompPlayers();

void prompt_playerTurn(table *t);

char input_playerTurn();

void printCard(card *c);

void displayCard(card *c);

void printDeck(deck *d);

#endif