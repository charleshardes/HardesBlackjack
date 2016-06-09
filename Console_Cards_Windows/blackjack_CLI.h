//
//  blackjack_GUI.h
//  Console_Cards
//
//  Created by Charles Hardes on 3/28/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//

#ifndef __Console_Cards__blackjack_CLI__
#define __Console_Cards__blackjack_CLI__

#include <stdio.h>

void CL_spaces(int s);

void CL_newlines(int n);

void CL_tabs(int t);

void CL_setPrompt(table *t);

void displayBet(int bet);

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

void busted_Display(table *t, int player);

void blackjack_Display(table *t, int player);

void win_Display(table *t, int player);

void lose_Display(table *t, int player);

void push_Display(table *t, int player);

void prompt_Continue();

char input_Continue();

void error_ContinueGame();

void prompt_betAmount();

int input_betAmount();

void error_inputBet();

void diplayDealerName(player *p);

void displayPlayerName(player *p);

void prompt_HitStay();

void prompt_DoubleDown();

void prompt_Split();

char input_Split();

void displayHandIndex(hand *h);

#endif