extern "C" {
#include<assert.h>
#include<string.h>




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

		strcpy_s(ss.str1, "abcd");
		ss.str2 = "defgh";
	}

	__declspec(dllexport) char *testTheStringStruct2() {
		struct stringStruct ss;


		strcpy_s(ss.str1, "abcd");
		ss.str2 = "efgh";


		return _strdup(ss.str1);
	}

	__declspec(dllexport) void testTheStringStruct3(struct stringStruct ss) {

		assert(strcmp(ss.str1, "abcde") == 0);
		assert(strcmp(ss.str2, "defgh") == 0);
	}

	__declspec(dllexport) struct stringStruct testTheStringStruct4() {

		struct stringStruct ss;

		strcpy_s(ss.str1, "abcd");
		ss.str2 = "defgh";

		return ss;
	}

	__declspec(dllexport) void testTheStringStruct5(struct stringStruct *ss) {


		strcpy_s(ss->str1, "ABCDE");
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



