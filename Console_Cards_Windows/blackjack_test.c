//
//  blackjack_test.c
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
#include "blackjack_table.h"
#include "blackjack.h"
#include "blackjack_test.h"

int no_Comps, no_Human_Players, no_Total_Players, i, cont;
char ans;
player *me, *dealer;
table *firstTable;
deck *BJdeck;

int main(int argc, const char * argv[]) {
    
    no_Human_Players = getPlayers();
    no_Comps = getComps(4 - no_Human_Players);
    no_Total_Players = no_Human_Players + no_Comps;
    
    firstTable = createTable(no_Total_Players, no_Comps);
    BJdeck = createDeck();
    
    me = firstTable->players[0];
    dealer = firstTable->dealer;
    
    BJdeck = shuffle(BJdeck);
    BJdeck = shuffle(BJdeck);
    
    do {
        for (i = 0; i < no_Total_Players; i++) {
            newPlayerHand(firstTable->players[i]);
        }
        newPlayerHand(firstTable->dealer);

        displayTable(firstTable, 0);
        
        dealStartingHands(firstTable, BJdeck);

        displayTable(firstTable, 1);
        
        for (i = 0; i < no_Total_Players; i++) {
            firstTable->currPlayer = i;
            playerTurn(firstTable, firstTable->players[i], BJdeck);
        }
        
        firstTable->currPlayer = 0;
        
        dealerTurn(firstTable, BJdeck);
        takeScores(firstTable);
        displayTable(firstTable, 1);
        
        newlines(2);
        printf("Deal: d; Quit: q\n");
        ans = getchar();
        ans = getchar();
        if (ans == 'd') {
            cont = 1;
            clearTable(firstTable);
        }
        else if (ans == 'q') {cont = 0;}
        else printf("ERROR");
        
        
    }while (cont == 1);
    

    _deleteTable(firstTable);
    _deleteDeck(BJdeck);
    
    
    
    
    return 0;
}