//
//  blackjack_run.c
//  Console_Cards
//
//  Created by Charles Hardes on 3/28/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//
//  This is the main driver for HardesBlackJack
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
#include "blackjack_table.h"
#include "blackjack.h"
#include "blackjack_UIX.h"
#include "blackjack_run.h"


int main(int argc, const char * argv[]) {

	int cont, i;/* boolean 1 or 0 (True/False) variable used only for determining whether 
			 user has chosen to continue (deal again) or quit the program*/
	table *BJTable;/* pointer to main BlackJack Table object created and used in the program */
	deck *BJdeck;/*   pointer to main BlackJack Deck object created and used in the program */
    
	/*get the # of players, players' names, # of comps, create the table, 
	return a pointer to it*/
    BJTable = setTable();

	/*create the blackjack deck, return a pointer to it*/
    BJdeck = createDeck();
    
	/*shuffle the deck*/
    BJdeck = shuffle(BJdeck);
    
	/*Main game driver loops through playing blackjack hands against the dealer until loop is 
	broken when user chooses not to deal again, but to exit and quit program*/
    do {

		/*(re)create and (re)initialize all new hand objects for each player before each turn*/
		setAllHands(BJTable);

		/*Display the table before bets taken*/
        displayTable(BJTable);

		/*Take bets from all players*/
		getBets_ALL(BJTable);
        
		/*Deal starting hand to each player and dealer*/
        dealStartingHands(BJTable, BJdeck);


		/*************** FOR SPLIT TESTING PURPOSES ONLY ***************************/
		
		for (i = 0; i < BJTable->NO_OF_PLAYERS; i++) {
			BJTable->players[i]->playerHand->canSplit = 1;
		}

		/***************************************************************************/


		/*Show players their dealt hands and feedback if they have blackjack*/
        displayTable(BJTable);
		//handFeedBack_Display_ALL(BJTable);

		/*Each player plays their hand*/
		playerTurn_ALL(BJTable, BJdeck);
        
		/*Dealer plays their hand*/
        dealerTurn(BJTable, BJdeck);

		/*Player scores are computed, compared against dealer's*/
        takeScores(BJTable);

		/*Show final results of the hand with feedback of win/loss/push*/
        displayTable(BJTable);
		//handFeedBack_Display_ALL(BJTable);
        
		/*Prompt to deal again or quit the game/program*/
		cont = continueGamePrompt(BJTable);

    }while (cont == 1);/*Driver loop continues until user quits*/
    
	/*After quitting the game, clean up: delete and free up all allocated memory
	Then, exit program*/
	cleanUp(BJTable, BJdeck);
  
    return 0;/*exit program with successfull return value*/
}