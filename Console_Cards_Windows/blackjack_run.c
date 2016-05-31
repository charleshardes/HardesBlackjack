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

	int i, cont;
	table *BJTable;
	deck *BJdeck;
    
	/*get the # of players, players' names, # of comps, create the table, 
	return a pointer to it*/
    BJTable = setTable();

	/*create the blackjack deck, return a pointer to it*/
    BJdeck = createDeck();
    
	/*shuffle the deck*/
    BJdeck = shuffle(BJdeck);
    
	/*Loop through hands; Loop is broken when user chooses to exit and quit program*/
    do {

		/*(re)create and (re)initialize all new hand objects for each player before each turn*/
		setAllHands(BJTable);

		/*Display the table before bets taken*/
        displayTable(BJTable, 0);
        
		/*Deal starting hand to each player and dealer*/
        dealStartingHands(BJTable, BJdeck);

        displayTable(BJTable, 1);
		handFeedBack_Display_ALL(BJTable);
		
        /*Loop through all players' turns*/
        for (i = 0; i < (BJTable->NO_OF_PLAYERS); i++) {

            BJTable->currPlayer = i;
            playerTurn(BJTable, BJTable->players[i], BJdeck);			
        }

		
        
        BJTable->currPlayer = 0;
        
        dealerTurn(BJTable, BJdeck);

        takeScores(BJTable);

        displayTable(BJTable, 1);
		handFeedBack_Display_ALL(BJTable);
        
		cont = continueGamePrompt(BJTable);


        
        
    }while (cont == 1);
    

    _deleteTable(BJTable);
    _deleteDeck(BJdeck);
    
    
    
    
    return 0;
}