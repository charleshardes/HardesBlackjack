//
//  blackjack_hands.h
//  Console_Cards
//
//  Created by Charles Hardes on 3/28/15.
//  Copyright (c) 2015 Charles Hardes. All rights reserved.
//

#ifndef __Console_Cards__blackjack_hands__
#define __Console_Cards__blackjack_hands__

#include <stdio.h>

void _initHand(hand *h);

hand *createHand();

void setNewHand(hand *h);

void _deleteHand(hand *h);

int isPair(hand *h);

/*int isBlackJack(hand *h);*/

void assessHand(hand *h);

void displayHand(hand *h, player *p);

void discardHand(table *t, hand *h);

#endif /* defined(__Console_Cards__blackjack_hands__) */
