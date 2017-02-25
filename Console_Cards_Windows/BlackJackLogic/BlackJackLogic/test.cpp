extern "C" {

#include <stdlib.h>
#include <stdio.h>
#include <assert.h>
#include <string.h>
#include <direct.h>
#include <Windows.h>
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
#if ( UIX == 0 )
#include "blackjack_CLI.h"
#elif ( UIX == 1 )
#include "blackjack_GUI.h"
#endif
#include "blackjack_run.h"

/*	__declspec(dllexport) table *setTable() {

		int no_Comps, no_Human_Players, no_Total_Players;

		no_Human_Players = getPlayers();
		no_Comps = getComps(4 - no_Human_Players);
		no_Total_Players = no_Human_Players + no_Comps;

		return createTable(no_Total_Players, no_Comps);
	}
*/

	//-----------------------------------------TEST STRUCTS-----------------------------------




	struct testStruct {
		int five;
		int seven;
	};

	struct charStruct {
		char a;
		char b;
	};

	struct stringStruct {
		char str1[6];
		char *str2;
	};

	struct structInStruct {
		testStruct *rts;
	};

	struct structArray {
		testStruct *rts[5];
	};

	__declspec(dllexport) void testTheTestStruct1() {
		struct testStruct ts;

		ts.five = 5;
		ts.seven = 7;
	}

	__declspec(dllexport) int testTheTestStruct2() {
		struct testStruct ts;

		ts.five = 5;
		ts.seven = 7;

		return ts.five;
	}

	__declspec(dllexport) void testTheTestStruct3(struct testStruct ts) {

		assert(ts.five == 5);
		assert(ts.seven == 7);
	}

	__declspec(dllexport) struct testStruct testTheTestStruct4() {

		struct testStruct ts;

		ts.five = 5;
		ts.seven = 7;

		return ts;
	}

	__declspec(dllexport) void testTheTestStruct5(struct testStruct *ts) {

		ts;

		ts->five = 6;
		ts->seven = 8;

	}

	__declspec(dllexport) testStruct *testTheTestStruct6(struct testStruct *ts) {

		ts;

		ts->five = 7;
		ts->seven = 9;

		return ts;
	}




	//---------------------------char Struct tests--------------------------------------------

	__declspec(dllexport) void testTheCharStruct1() {
		struct charStruct cs;

		cs.a = 'a';
		cs.b = 'b';
	}

	__declspec(dllexport) char testTheCharStruct2() {
		struct charStruct cs;

		cs.a = 'a';
		cs.b = 'b';

		return cs.a;
	}

	__declspec(dllexport) void testTheCharStruct3(struct charStruct cs) {

		assert(cs.a == 'a');
		assert(cs.b == 'b');
	}

	__declspec(dllexport) struct charStruct testTheCharStruct4() {

		struct charStruct cs;

		cs.a = 'a';
		cs.b = 'b';

		return cs;
	}

	__declspec(dllexport) void testTheCharStruct5(struct charStruct *cs) {


		cs->a = 'c';
		cs->b = 'd';

	}




	//-------------------------stringStruct tests-----------------------------------------------






	__declspec(dllexport) void testTheStringStruct1() {
		struct stringStruct ss;

		strcpy(ss.str1, "abcd");
		ss.str2 = "defgh";
	}

	__declspec(dllexport) char *testTheStringStruct2() {
		struct stringStruct ss;


		strcpy(ss.str1, "abcd");
		ss.str2 = "efgh";


		return _strdup(ss.str1);
	}

	__declspec(dllexport) void testTheStringStruct3(struct stringStruct ss) {

		assert(strcmp(ss.str1, "abcde") == 0);
		assert(strcmp(ss.str2, "defgh") == 0);
	}

	__declspec(dllexport) struct stringStruct testTheStringStruct4() {

		struct stringStruct ss;

		strcpy(ss.str1, "abcd");
		ss.str2 = "defgh";

		return ss;
	}

	__declspec(dllexport) void testTheStringStruct5(struct stringStruct *ss) {


		strcpy(ss->str1, "ABCDE");
		ss->str2 = "DEFGH";

	}



	//-------------------------------------structInStruct tests-----------------------------------

	/*
	struct structInStruct {
		testStruct *rts;
	};
	*/

	__declspec(dllexport) void testTheStructInStruct1() {
		structInStruct sis;
		testStruct ts;

		ts.five = 5;
		ts.seven = 7;

		sis.rts = &ts;

		sis.rts->five = 6;
		sis.rts->seven = 8;
	}

	__declspec(dllexport) int testTheStructInStruct2() {

		structInStruct sis;
		testStruct ts;

		sis.rts = &ts;

		sis.rts->five = 6;
		sis.rts->seven = 8;

		return sis.rts->five;
	}

	__declspec(dllexport) void testTheStructInStruct3(struct structInStruct sis) {

		if (sis.rts->five == 5) {
			//do something here;
		}
		else {
			//do something here
		}

		if (sis.rts->seven == 7) {
			//do something here;
		}
		else {
			//do something here
		}
	}

	__declspec(dllexport) struct structInStruct testTheStructInStruct4() {

		structInStruct sis;
		testStruct ts;

		sis.rts = &ts;

		sis.rts->five = 5;
		sis.rts->seven = 7;

		return sis;
	}

	__declspec(dllexport) void testTheStructInStruct5(struct structInStruct *sis) {


		sis->rts->five = 6;
		sis->rts->seven = 8;
	}

	__declspec(dllexport) structInStruct *testTheStructInStruct6(struct structInStruct *sis) {

		sis->rts->five = 7;
		sis->rts->seven = 9;

		return sis;
	}


	//----------------------------------------------- structArray tests------------------------
	/*
	struct structArray {
		testStruct rts[5];
	};
	*/
	__declspec(dllexport) void testTheStructArr1() {
		structArray sa;
		testStruct ts[5];

		for (int i = 0; i < 5; i++) {
			sa.rts[i] = &ts[i];

			sa.rts[i]->five = 5 + i;
			sa.rts[i]->seven = 7 + i;
		}

	}


	__declspec(dllexport) int testTheStructArr3(struct structArray sa) {

		if (sa.rts[0]->five == 5) {
			return 1;
		}
		else {
			return 0;
		}
	}



	__declspec(dllexport) void testTheStructArr5(struct structArray *sa) {


		sa->rts[0]->five = 4;
		sa->rts[0]->seven = 6;
	}

/*
	__declspec(dllexport) structInStruct *testTheStructInStruct6(struct structInStruct *sis) {

		sis->rts->five = 7;
		sis->rts->seven = 9;

		return sis;
	}




*/
	//----------------------------------------------END TEST STRUCT PROTOTYPES---------------------------------------










	__declspec(dllexport) table *DLLcreateTable(int NO_OF_PLAYERS, int NO_OF_COMPS) {

		table *newTable;
		newTable = (table *)malloc(sizeof(table));
		_initTable(newTable, NO_OF_PLAYERS, NO_OF_COMPS);
		return newTable;
	}

	__declspec(dllexport) void DLLtestTable(table *t) {
		assert(t);
	}

	__declspec(dllexport) int Display7MyDLL() {
		return 7;
	}

	__declspec(dllexport) void DLLhideCard(card *c) {

		assert(c);

		c->shown = 0;
	}

	__declspec(dllexport) void DLLChangeCardVal(cardValue *cv) {

		assert(cv);

		cv->abbr = '6';
		cv->weight = 6;
	}

/*	__declspec(dllexport) int runBlackjack() {
		int a;
		int b;
		int c;
		a = 5;
		b = 7;
		c = a * b;

		return c;
	}
*/
	__declspec(dllexport) int Display8MyDLL() {
		return 8;
	}

	__declspec(dllexport) int readTest() {

		FILE *fp1, *fp2, *fpTest;
		int returnInt;
		char *buffer;

		buffer = _getcwd(NULL, 0);

		fpTest = fopen("testFile.txt", "w+");
		if (fpTest == NULL) {
			printf("Error: %d (%s)\n", errno, strerror(errno));
		}
		else { fclose(fpTest); }


		fp1 = freopen("newIn.txt", "r", stdin);
		fp2 = freopen("newOut.txt", "w", stdout);




		returnInt = fgetc(fp1);

		fclose(fp1);
		fclose(fp2);

		return returnInt;
	}

	__declspec(dllexport) void DLLdisplayBet(int bet) { printf("Bet:    $%d", bet); }


#if ( 1 )
	//
	//  blackjack_run.c
	//  Console_Cards
	//
	//  Created by Charles Hardes on 3/28/15.
	//  Copyright (c) 2015 Charles Hardes. All rights reserved.
	//
	//  This is the main driver for HardesBlackJack
	//

	__declspec(dllexport) void runBlackjack() {

		int cont;/* boolean 1 or 0 (True/False) variable used only for determining whether
				 user has chosen to continue (deal again) or quit the program*/
		table *BJTable;/* pointer to main BlackJack Table object created and used in the program */
		deck *BJdeck;/*   pointer to main BlackJack Deck object created and used in the program */
		//FILE *fp;

		/*for communication between a DLL made from this program and another program*/
		//fp = freopen("newIn.txt", "r", stdin);

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

		} while (cont == 1);/*Driver loop continues until user quits*/

		/*After quitting the game, clean up: delete and free up all allocated memory
		Then, exit program*/
		cleanUp(BJTable, BJdeck);

		//for C# integration cleanup
		//fclose(fp);

	}
#endif
}