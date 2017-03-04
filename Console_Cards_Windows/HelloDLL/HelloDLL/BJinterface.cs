using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Dlltest;



namespace HelloDLL {

    

    //public delegate int runIt();

    public static class Constants
    {
        public const string dllPath = @"C:\Users\Charles\Documents\GitHub\HardesBlackJack\Console_Cards_Windows\Debug\BlackJackLogic.dll";
        //public const string dllPath = @"C:\Users\Charles Hardes\Source\Repos\HardesBlackJack\Console_Cards_Windows\Debug\BlackJackLogic.dll";
        public const string newInPath = @"C:\Users\Charles\Documents\GitHub\HardesBlackJack\Console_Cards_Windows\HelloDLL\HelloDLL\bin\Debug\newIn.txt";
        public const int NO_OF_CARDS = 52;
        public const int NO_OF_SUITS = 4;
        public const int NO_OF_CARD_VALUES = 13;
    }


    






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


    public static class BJinterface {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
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

        public static IntPtr setTable(int NO_OF_PLAYERS, int NO_OF_COMPS, string[] stringArr) {

            table BJtable;

            player[] p = new player[NO_OF_PLAYERS];

            IntPtr t = DLLSetTable(NO_OF_PLAYERS, NO_OF_COMPS, stringArr);

            BJtable = (table)Marshal.PtrToStructure(t, typeof(table));

            for (int i = 0; i < NO_OF_PLAYERS + NO_OF_COMPS; i++) {
                p[i] = (player)Marshal.PtrToStructure(BJtable.players[i], typeof(player));
            }

            return t;
        }

        public static IntPtr createDeck() {

            IntPtr d = DLLcreateDeck();

            deck BJdeck = (deck)Marshal.PtrToStructure(d, typeof(deck));

            (card)Marshal.PtrToStructure(Dstruct.cards[i], typeof(card));

            IntPtr d2 = DLLshuffle(ref BJdeck);

            deck BJdeck2 = (deck)Marshal.PtrToStructure(d2, typeof(deck));

            return d2;
        }

        public static void setHands(table t) {


            DLLsetAllHands(ref t);
        }

        [STAThread]
        static void Main() {

            Dlltest.Program.RunAllTests();

            int five = 5;

            five += 5;

            IntPtr t = DLLSetTable(1, 0, null);

        }
    }
}
