//
//  main.c
//  Blackjack
//
//  Created by Charles Hardes on 3/18/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//

#include <stdio.h>
#include <stdlib.h>
#include "cards_structs.h"
#include "cards.h"



int main(int argc, const char * argv[]) {
    // insert code here...
    printf("Hello, World!\n");
    printf("welcome to BLACK JIGGITY JACK, JACK!\n\n\n");
    
    deck *Standard = createDeck();
    printDeck(Standard);
    _deleteDeck(Standard);
    
    return 0;
}
