//
//  cards_test.c
//  Console_Cards
//
//  Created by Charles Hardes on 3/22/15.
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


/*******************MAIN*********************/

int main(int argc, const char * argv[]) {
    // insert code here...
    
    char *trump = "false";
	deck *Standard, *shuffled, *reshuffled;
	card *popper;
    
    printf("Hello, World!\n");
    printf("welcome to BLACK JIGGITY JACK, JACK!\n\n\n");
    
	Standard = createDeck();
    printDeck(Standard);
    
    setTrumpSuit(suitArr[3]);
    
    if (isTrump(Standard->cards[1]->suit)) {trump = "true";}
    
    
    printf("\nHearts are trump:  %s\n", trump);
    
    if (isTrump(Standard->cards[51]->suit)) {trump = "true";}
    else trump = "false";
    printf("Clubs are trump:  %s\n", trump);
    
    desetTrumpSuit(suitArr[3]);
    
    printf("\ndesetting trump suit\n");
    
    if (isTrump(Standard->cards[51]->suit)) {trump = "true";}
    else trump = "false";
    printf("Clubs are trump:  %s\n", trump);
    
    printf("\nFirst Ace is: %s\tvalue: %d\nSecond Ace is: %s\tvalue: %d\n",
           Standard->cards[12]->name, Standard->cards[12]->value->weight,
           Standard->cards[25]->name, Standard->cards[25]->value->weight);
    setLoAce(Standard->cards[12]);
    printf("Changing first ace to lo.\n");
    printf("\nFirst Ace is: %s\tvalue: %d\nSecond Ace is: %s\tvalue: %d\n",
           Standard->cards[12]->name, Standard->cards[12]->value->weight,
           Standard->cards[25]->name, Standard->cards[25]->value->weight);
    setLoAce(Standard->cards[12]);
    printf("Is first ace hi? %d\tIs second ace hi? %d\n", isHiAce(Standard->cards[12]), isHiAce(Standard->cards[25]));
    isHiAce(Standard->cards[25]);
    
    setHiAce(Standard->cards[12]);
    printf("Is first ace hi? %d\tIs second ace hi? %d\n", isHiAce(Standard->cards[12]), isHiAce(Standard->cards[25]));

    shuffled = shuffle(Standard);
    reshuffled = shuffle(shuffled);
    printDeck(reshuffled);
    
    popper = _popCard(reshuffled);
    printf("first card from the top: \n\t%s\n", popper->name);
    popper = _popCard(reshuffled);
    printf("second card from the top: \n\t%s\n", popper->name);
    _deleteDeck(reshuffled);
    
    return 0;
}