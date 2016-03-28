CFLAGS = -Wall -fpic

playblackjack: blackjack_test.o blackjack.o blackjack_table.o blackjack_players.o blackjack_hands.o decks.o cards.o cards_suits.o cards_values.o
	gcc -o playblackjack blackjack_test.o blackjack.o blackjack_table.o blackjack_players.o blackjack_hands.o decks.o cards.o cards_suits.o cards_values.o $(CFLAGS)

blackjack_test.o: blackjack_test.h blackjack_test.c
	gcc -c blackjack_test.c $(CFLAGS)

blackjack.o: blackjack.h blackjack.c
	gcc -c blackjack.c $(CFLAGS)

blackjack_table.o: blackjack_table.h blackjack_table.c cards_structs.h
	gcc -c blackjack_table.c $(CFLAGS)

blackjack_players.o: blackjack_players.h blackjack_players.c
	gcc -c blackjack_players.c $(CFLAGS)

blackjack_hands.o: blackjack_hands.h blackjack_hands.c
	gcc -c blackjack_hands.c $(CFLAGS)

decks.o: decks.h decks.c
	gcc -c decks.c $(CFLAGS)

cards.o: cards.h cards.c
	gcc -c cards.c $(CFLAGS)

cards_suits.o: cards_suits.h cards_suits.c
	gcc -c cards_suits.c $(CFLAGS)

cards_values.o: cards_values.h cards_values.c
	gcc -c cards_values.c $(CFLAGS)

clean: 
	rm -f *.o *.gcno playblackjack
 
