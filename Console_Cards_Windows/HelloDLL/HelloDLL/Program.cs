using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;



namespace HelloDLL {

    

    //public delegate int runIt();

    static class Constants
    {
        public const string dllPath = @"C:\Users\Charles\Documents\GitHub\HardesBlackJack\Console_Cards_Windows\Debug\BlackJackLogic.dll";
        //public const string dllPath = @"C:\Users\Charles Hardes\Source\Repos\HardesBlackJack\Console_Cards_Windows\Debug\BlackJackLogic.dll";
        public const string newInPath = @"C:\Users\Charles\Documents\GitHub\HardesBlackJack\Console_Cards_Windows\HelloDLL\HelloDLL\bin\Debug\newIn.txt";
        public const int NO_OF_CARDS = 52;
        public const int NO_OF_SUITS = 4;
        public const int NO_OF_CARD_VALUES = 13;
    }


    //-----------------------------------TEST STRUCTS------------------------------------------

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct testStruct {
        public int five;
        public int seven;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct charStruct {
        public byte a;
        public byte b;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct stringStruct
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public char[] str1;

        //[MarshalAs(UnmanagedType.LPStr)]
        public IntPtr str2;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct structInStruct
    {
        public IntPtr rts;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct structArray
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public IntPtr[] rts;
    };






    //------------------------------------MARSHALED BJ STRUCTS-------------------------------------------


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct cardValue {

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public char[] name;
        public byte abbr;
        public int weight;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct cardSuit {

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public char[] name;
        public byte abbr;
        public int trump;
        public int weight;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct card {

        public IntPtr suit;
        public IntPtr value;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)]
        public char[] name;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public char[] abbr;
        public int shown;
        public int wildcard;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct deck {

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.NO_OF_CARDS)]
        public IntPtr[] cards;//initialize array of cards ptrs

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.NO_OF_SUITS)]
        public IntPtr[] suits;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.NO_OF_CARD_VALUES)]
        public IntPtr[] values;
        public IntPtr top;

        public int cards_left;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct hand {

        public int starting;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public IntPtr[] cards;

        public int score;
        public int bust;
        public int canSplit;
        public int hasSplit;
        public IntPtr splitHand;
        public int hasBlackjack;
        public int cardCount;
        public int hiAces;
        public int win;
        public int lose;
        public int push;
        public int hasInsurance;
        public int insuranceAmt;
        public int doubledDown;
        public int hasEnded;
        public int bet;
        public int handIndex;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct player {

        public int dealer;
        public int computer;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public char[] name;

        public int pos;
        public IntPtr playerHand;
        public int chips;
        public int handCount;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct table {

        public IntPtr dealer;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public IntPtr[] players;

        public int NO_OF_PLAYERS;
        public int NO_OF_COMPS;
        public IntPtr discardPile;
        public int currPlayer;
        public int spacing;
        public int margin;
        public int handsAreDealt;
        public int hasSplits;
    };


    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 


        /*
        [DllImport(Constants.dllPath)]
        public static extern int Display7MyDLL();

        [DllImport(Constants.dllPath)]
        public static extern int Display8MyDLL();



        [DllImport(Constants.dllPath)]
        public static extern int DLLcreateTable(int a, int b);

        [DllImport(Constants.dllPath)]
        public static extern int readTest();

        [DllImport(Constants.dllPath)]
        public static extern void DLLdisplayBet(int bet);
        */

        [DllImport(Constants.dllPath)]
        public static extern void DLLhideCard(ref card c);

        [DllImport(Constants.dllPath)]
        public static extern int runBlackjack(ref table t);



        //-------------------------------testStruct test calls--------------------------------




        [DllImport(Constants.dllPath)]
        public static extern void testTheTestStruct1();

        [DllImport(Constants.dllPath)]
        public static extern int testTheTestStruct2();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int testTheTestStruct3(testStruct ts);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern testStruct testTheTestStruct4();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void testTheTestStruct5(ref testStruct ts);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr testTheTestStruct6(ref testStruct ts);



        //---------------------------charStruct test calls---------------------------------------------



        [DllImport(Constants.dllPath)]
        public static extern void testTheCharStruct1();

        [DllImport(Constants.dllPath)]
        public static extern char testTheCharStruct2();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void testTheCharStruct3(charStruct cs);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern charStruct testTheCharStruct4();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void testTheCharStruct5(ref charStruct ts);





        //------------------------------stringStruct test calls--------------------------------------




        [DllImport(Constants.dllPath)]
        public static extern void testTheStringStruct1();

        [DllImport(Constants.dllPath)]
        public static extern IntPtr testTheStringStruct2();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void testTheStringStruct3(stringStruct ss);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern stringStruct testTheStringStruct4();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void testTheStringStruct5(ref stringStruct ss);



        //------------------------------------structInStruct Tests-----------------------------------------------

        [DllImport(Constants.dllPath)]
        public static extern void testTheStructInStruct1();

        [DllImport(Constants.dllPath)]
        public static extern int testTheStructInStruct2();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void testTheStructInStruct3(structInStruct sis);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern structInStruct testTheStructInStruct4();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void testTheStructInStruct5(ref structInStruct sis);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr testTheStructInStruct6(ref structInStruct sis);



        //-----------------------------------------structArray Tests-------------------------

        //new shit for gitss

        [DllImport(Constants.dllPath)]
        public static extern void testTheStructArr1();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int testTheStructArr3(structArray sa);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void testTheStructArr5(ref structArray sa);

        //-----------------------------END TEST STRUCT DEFS----------------------------------------------------




        [DllImport(Constants.dllPath, CallingConvention =CallingConvention.Cdecl)]
        public static extern void DLLChangeCardVal(ref cardValue cv);


        //------------------------------------------BJ DEFS----------------------------------

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DLLcreateTable(int NO_OF_PLAYERS, int NO_OF_COMPS);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DLL_initTable(ref table t, int NO_OF_PLAYERS, int NO_OF_COMPS);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DLLSetTable(int NO_OF_PLAYERS, int NO_OF_COMPS, string[] names);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DLLcreateDeck();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DLLshuffle(ref deck d);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DLLcleanUp(ref table t, ref deck d);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DLLsetAllHands(ref table t);


        [STAThread]
        static void Main() {

            int NO_OF_PLAYERS, NO_OF_COMPS;
            table BJtable;
            deck BJdeck, BJdeck2;
            IntPtr d2, d3;
            bool cont = true;
            

            /***********************GAME START*************************
             * initialize GUI stuff, do variable declarations, etc here
             * 
             * 
             * ********************************************************
            


            /*********************** GET PLAYER INPUT FROM FORM*********
             * Present first game form here, get number of human players,
             * number of computer players, names of human players

            ***********************************************************/
            NO_OF_PLAYERS = 4;
            NO_OF_COMPS = 0;
            string[] stringArr = { "Charles", "Theresa", "Charlie", "Nathanael" };


            player[] p = new player[NO_OF_PLAYERS];

            IntPtr t = DLLSetTable(NO_OF_PLAYERS, NO_OF_COMPS, stringArr);

            BJtable = (table)Marshal.PtrToStructure(t, typeof(table));

            for (int i = 0; i < NO_OF_PLAYERS + NO_OF_COMPS; i++) {
               p[i] = (player)Marshal.PtrToStructure(BJtable.players[i], typeof(player));
            }

            IntPtr d = DLLcreateDeck();

            BJdeck = (deck)Marshal.PtrToStructure(d, typeof(deck));

            d2 = DLLshuffle(ref BJdeck);

            BJdeck2 = (deck)Marshal.PtrToStructure(d2, typeof(deck));


            //************************GAME LOOP*************************
            do {

                DLLsetAllHands(ref BJtable);


                cont = false;
            } while (cont == true);










            DLLcleanUp(ref BJtable, ref BJdeck);

            return;




































            //-------------------TESTING testStruct----------------------------------------//

            testTheTestStruct1();

            int val = testTheTestStruct2();

            testStruct ts;
            ts.five = 5;
            ts.seven = 7;

            testTheTestStruct3(ts);

            testStruct ts2 = testTheTestStruct4();

            testTheTestStruct5(ref ts2);

            IntPtr ptr = testTheTestStruct6(ref ts2);
            testStruct ts3 = (testStruct)Marshal.PtrToStructure(ptr, typeof(testStruct));

            //----------------------------TESTING charStruct--------------------------------------//

            testTheCharStruct1();

            char aChar = testTheCharStruct2();

            charStruct cs;
            cs.a = (byte) 'a';
            cs.b = (byte) 'b';

            testTheCharStruct3(cs);

            charStruct cs2 = testTheCharStruct4();

            testTheCharStruct5(ref cs2);


            //----------------------------TESTING stringStruct--------------------------------------//

            testTheStringStruct1();

            IntPtr anIntPtr = testTheStringStruct2();


            string aStr1 = Marshal.PtrToStringAnsi(anIntPtr);

            stringStruct ss;
            string toArr = "abcde";
            ss.str1 = toArr.ToCharArray(0, 5);

            string toArr2 = "defgh";
            ss.str2 = Marshal.StringToHGlobalAnsi(toArr2);

            testTheStringStruct3(ss);

            //stringStruct ss2 = testTheStringStruct4();

            testTheStringStruct5(ref ss);
            string strOut1 = new string(ss.str1);
            string strOut2 = Marshal.PtrToStringAnsi(ss.str2);

            //--------------------------------TESTING STRUCT IN STRUCT------------------------------------------

            testTheStructInStruct1();

            int five = testTheStructInStruct2();

            structInStruct sis1, sis2, sis3, sis4;
            testStruct ts4, ts5;

            ts4.five = 5;
            ts4.seven = 7;

            IntPtr ip = Marshal.AllocHGlobal(Marshal.SizeOf(ts4));
            Marshal.StructureToPtr(ts4, ip, false);

            sis1.rts = ip;
            sis3.rts = ip;

            testTheStructInStruct3(sis1);

            

            //sis2 = testTheStructInStruct4();

            

            testTheStructInStruct5(ref sis3);

            

            IntPtr ip2 = Marshal.AllocHGlobal(Marshal.SizeOf(sis3));

            ip2 = testTheStructInStruct6(ref sis3);

            sis4 = (structInStruct)Marshal.PtrToStructure(ip2, typeof(structInStruct));

            ts5 = (testStruct)Marshal.PtrToStructure(sis4.rts, typeof(testStruct));

            Marshal.FreeHGlobal(ip);
            //Marshal.FreeHGlobal(ip2);



            //------------------------Testing structArray-----------------------------------


            testTheStructArr1();

            structArray sa;
            IntPtr[] tsa = new IntPtr[5];
            testStruct[] TS = new testStruct[5];
            testStruct[] TS2 = new testStruct[5];
            sa.rts = tsa;

            for (int i = 0; i < 5; i++) {

                TS[i].five = 5 + i;
                TS[i].seven = 7 + i;

                sa.rts[i] = Marshal.AllocHGlobal(Marshal.SizeOf(TS[i]));
                Marshal.StructureToPtr(TS[i], sa.rts[i], false);
            }

            five = testTheStructArr3(sa);



            //IntPtr SA = Marshal.AllocHGlobal(Marshal.SizeOf(sa));
            //Marshal.StructureToPtr(sa, SA, false);

            testTheStructArr5(ref sa);

            for (int i = 0; i < 5; i++)
            {
                TS2[i] = (testStruct)Marshal.PtrToStructure(sa.rts[i], typeof(testStruct));
            }


            //---------------------Cleanup-------------------------------------------
            for (int i = 0; i < 5; i++)
            {
                Marshal.FreeHGlobal(sa.rts[i]);
            }





            //runBlackjack(ref t);

            //Marshal.FreeHGlobal(SA);

            //------------------------------------------------------------------------

            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/

            //int output;
            //byte temp = 4;


            /*
            using (FileStream
                F = new FileStream(Constants.newInPath, FileMode.Create)) {

                output = Display7MyDLL();
                output = Display8MyDLL();

                //output -= 5;


                //write temp var to "newIn.txt"
                //F.WriteByte(temp);

                //set seek to the beginning of the file
                //F.Seek(0, SeekOrigin.Begin);

                //make sure the file has been written to and can be read from
                //output = F.ReadByte();

                //call the DLL function readTest to make sure it can also read the file 
                //output = readTest();

                
                runIt R  = new runIt(runBlackjack);
                int returnVal = R();
                

                DLLcreateTable(4, 0);
                runBlackjack();

                F.Close();

                //DLLdisplayBet(700);
            }*/
        }
    }
}
