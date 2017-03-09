using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloDLL;
using System.Runtime.InteropServices;

namespace GameState {

    //New Game class to encapsulate Table and Deck conversion classes
    public class Game {

        //Game class constructor
        public Game(int NO_OF_PLAYERS, int NO_OF_COMPS, string[] players) {
            //DeckOld myDeck = new Deck();

            //Deck Struct constructor
            IntPtr dPtr = BJinterface.DLLcreateDeck();
            DeckStruct = (deck)Marshal.PtrToStructure(dPtr, typeof(deck));
            gameDeck = new Deck(dPtr);

            //Table Struct constructor
            IntPtr tPtr = BJinterface.DLLSetTable(NO_OF_PLAYERS, NO_OF_COMPS, players);
            TableStruct = (table)Marshal.PtrToStructure(tPtr, typeof(table));
            gameTable = new Table();

            BJinterface.DLLshuffle(ref DeckStruct);
        }

        //Game class members
        public static deck DeckStruct;
        public static table TableStruct;
        public Deck gameDeck;
        public Table gameTable { 
            get {
                Table T = new Table();

                player dlr = (player)Marshal.PtrToStructure(TableStruct.dealer, typeof(player));
                T.dealer = new Game.Table.Player(ref dlr);
                T.NO_OF_PLAYERS = TableStruct.NO_OF_PLAYERS;
                T.NO_OF_COMPS = TableStruct.NO_OF_COMPS;


                T.discardPile = new Deck(TableStruct.discardPile);
                T.currPlayer = TableStruct.currPlayer;
                T.handsAreDealt = TableStruct.handsAreDealt == 1;
                T.hasSplits = TableStruct.hasSplits == 1;
                //structPtr = TstructPtr;
                T.players = new Game.Table.Player[T.NO_OF_COMPS + T.NO_OF_PLAYERS];

                for (int i = 0; i < T.NO_OF_COMPS + T.NO_OF_PLAYERS; i++) {
                    player newPlyr = (player)Marshal.PtrToStructure(TableStruct.players[i], typeof(player));
                    T.players[i] = new Game.Table.Player(ref newPlyr);
                }
                return T;
            }
            set {
                //TableStruct. = value;
            }
        }

        public class Deck {

            public Card[] cards;
            public Card.Suit[] suits;
            public Card.Value[] values;

            //Deck Constructor
            public Deck(IntPtr DstructPtr) {

                Dstruct = (deck)Marshal.PtrToStructure(DstructPtr, typeof(deck));

                cards = new Card[Constants.NO_OF_CARDS];
                suits = new Card.Suit[Constants.NO_OF_SUITS];
                values = new Card.Value[Constants.NO_OF_CARD_VALUES];


                for (int i = 0; i < Constants.NO_OF_CARDS; i++) {
                    cards[i] = new Game.Deck.Card(Dstruct.cards[i]);
                }
                for (int i = 0; i < Constants.NO_OF_SUITS; i++) {
                    suits[i] = new Game.Deck.Card.Suit(Dstruct.suits[i]);
                }
                for (int i = 0; i < Constants.NO_OF_CARD_VALUES; i++) {
                    values[i] = new Game.Deck.Card.Value(Dstruct.values[i]);
                }
                top = new Game.Deck.Card(Dstruct.top);
                cards_left = Dstruct.cards_left;
                structPtr = DstructPtr;
            }

            public Card top {
                get {
                    return new Game.Deck.Card(Dstruct.top);
                }
                set { }//don't think i need this, the DLL will set the top card appropriately
            }
            public static int cards_left {
                get {
                    return Dstruct.cards_left;
                }
                set {
                    Dstruct.cards_left = value;
                }
            }
            public IntPtr structPtr;
            public static deck Dstruct;

            public class Card {

                //Card constructor
                public Card(IntPtr CstructPtr) {

                    if (CstructPtr == IntPtr.Zero) {
                        suit = null;
                        value = null;
                        name = null;
                        abbr = null;
                        shown = false;
                        wildcard = false;
                        structPtr = CstructPtr;
                        return;
                    }

                    card Cstruct = (card)Marshal.PtrToStructure(CstructPtr, typeof(card));
                    suit = new Suit(Cstruct.suit);
                    value = new Value(Cstruct.value);
                    name = new string(Cstruct.name);
                    abbr = new string(Cstruct.abbr);
                    shown = (Cstruct.shown == 1);
                    wildcard = (Cstruct.wildcard == 1);
                    structPtr = CstructPtr;
                }

                //don't have any idea if this is work the way I intend, but what I'm hoping this does is... if I access the card as part of an array
                //such as in the Deck, I can get the index and pass it into the get accessor which will allow me to get the appropriate struct from that array
                public Card this[int index] {
                    get {
                        
                        return new Card(DeckStruct.cards[index]);
                    }
                }

                public Suit suit;
                public Value value;
                public string name;
                public string abbr;
                public bool shown;
                public bool wildcard;
                public IntPtr structPtr;
                
                public class Suit {
                   
                    //Suit constructor
                    public Suit(IntPtr SstructPtr) {
                        cardSuit Sstruct = (cardSuit)Marshal.PtrToStructure(SstructPtr, typeof(cardSuit));
                        name = new string(Sstruct.name);
                        abbr = (char)Sstruct.abbr;
                        trump = (Sstruct.trump == 1);
                        weight = Sstruct.weight;
                        structPtr = SstructPtr;
                    }// end Suit constructor

                    //Suit class members with accessors
                    public string name { get; }
                    public char abbr { get; }
                    public bool trump { get; set; }
                    public int weight { get; set; }
                    IntPtr structPtr;

                    public void get() {
                        cardSuit cs = (cardSuit)Marshal.PtrToStructure(this.structPtr, typeof(cardSuit));
                        trump = cs.trump == 1;
                        weight = cs.weight;
                    }

                }//end Suit class def

                public class Value {

                    //Value constructor
                    public Value(IntPtr VstructPtr) {

                        cardValue Vstruct = (cardValue)Marshal.PtrToStructure(VstructPtr, typeof(cardValue));
                        name = new string(Vstruct.name);
                        abbr = (char)Vstruct.abbr;
                        weight = Vstruct.weight;
                        structPtr = VstructPtr;
                    }

                    //Value class accessors
                    public string name { get; }
                    public char abbr { get; }
                    public int weight { get; set; }
                    IntPtr structPtr;

                    public void get() {
                        cardValue cv = (cardValue)Marshal.PtrToStructure(this.structPtr, typeof(cardValue));
                        weight = cv.weight;
                    }

                }//end Value class def
            }//end Card class def
        }//end Deck class def



        public class Table {

            public Table() { }
            /*public Table(ref table TableStruct) {
                //table Tstruct = (table)Marshal.PtrToStructure(TstructPtr, typeof(table));
                Tstruct = TableStruct;

                player dlr = (player)Marshal.PtrToStructure(Tstruct.dealer, typeof(player));
                dealer = new Player(ref dlr);
                NO_OF_PLAYERS = Tstruct.NO_OF_PLAYERS;
                NO_OF_COMPS = Tstruct.NO_OF_COMPS;


                discardPile = new Deck(Tstruct.discardPile);
                currPlayer = Tstruct.currPlayer;
                handsAreDealt = Tstruct.handsAreDealt == 1;
                hasSplits = Tstruct.hasSplits == 1;
                //structPtr = TstructPtr;
                players = new Player[NO_OF_COMPS + NO_OF_PLAYERS];
                
                for (int i = 0; i < NO_OF_COMPS + NO_OF_PLAYERS; i++) {
                    player newPlyr = (player)Marshal.PtrToStructure(Tstruct.players[i], typeof(player));
                    players[i] = new Player(ref newPlyr);
                }
            }*/

            public Player dealer;
            public int NO_OF_PLAYERS;
            public int NO_OF_COMPS;
            public Deck discardPile;
            public int currPlayer;
            public bool handsAreDealt;
            public bool hasSplits;
            public Player[] players;
            //IntPtr structPtr;
            public static table Tstruct;

            public class Player {

                public Player(ref player PlayerStruct) {
                    //Pstruct = (player)Marshal.PtrToStructure(PstructPtr, typeof(player));
                    Pstruct = PlayerStruct;

                    dealer = Pstruct.dealer == 1;
                    computer = Pstruct.computer == 1;
                    name = new string(Pstruct.name);
                    pos = Pstruct.pos;

                    hand plyrHand = (hand)Marshal.PtrToStructure(Pstruct.playerHand, typeof(hand));
                    playerHand = new Hand(ref plyrHand);

                    //chips = Pstruct.chips;
                    handCount = Pstruct.handCount;
                }

                private static player Pstruct;
                private bool dealer;
                public bool computer;
                public string name;
                public int pos;
                public Hand playerHand;
                public int chips {
                    get {
                        return BJinterface.getChips(ref Game.TableStruct, pos);
                        //return Pstruct.chips;
                    }
                    set {
                        BJinterface.setChips(ref Game.TableStruct, pos, value);
                    }
                }
                public int handCount;


                public class Hand {

                    //Hand class constructor
                    public Hand(ref hand HandStruct) {

                        Hstruct = HandStruct;
                        //Hstruct = (hand)Marshal.PtrToStructure(HstructPtr, typeof(hand));
                        starting = Hstruct.starting == 1;
                        cardCount = Hstruct.cardCount;
                        
                        for (int i = 0; i < cardCount; i++) {
                            cards[i] = new Deck.Card(Hstruct.cards[i]);
                        }//end Hand class constructor

                        score = Hstruct.score;
                        bust = Hstruct.bust == 1;
                        canSplit = Hstruct.canSplit == 1;
                        hasSplit = Hstruct.hasSplit == 1;
                        if (hasSplit) {
                            hand split = (hand)Marshal.PtrToStructure(Hstruct.splitHand, typeof(hand));
                            splitHand = new Hand(ref split);
                        }
                        hasBlackjack = Hstruct.hasBlackjack == 1;
                        cardCount = Hstruct.cardCount;
                        hiAces = Hstruct.hiAces;
                        win = Hstruct.win == 1;
                        lose = Hstruct.lose == 1;
                        push = Hstruct.push == 1;
                        hasInsurance = Hstruct.hasInsurance == 1;
                        insuranceAmt = Hstruct.insuranceAmt;
                        doubledDown = Hstruct.doubledDown == 1;
                        hasEnded = Hstruct.hasEnded == 1;
                        //bet = Hstruct.bet;
                        handIndex = Hstruct.handIndex;

                    }// end Hand constructor

                    private static hand Hstruct;
                    public bool starting;
                    public Deck.Card[] cards;
                    public int score;
                    public bool bust;
                    public bool canSplit;
                    public bool hasSplit;
                    public Hand splitHand;
                    public bool hasBlackjack;
                    public int cardCount;
                    public int hiAces;
                    public bool win;
                    public bool lose;
                    public bool push;
                    public bool hasInsurance;
                    public int insuranceAmt;
                    public bool doubledDown;
                    public bool hasEnded;
                    public int bet {
                        get { return bet; }
                        set {
                            BJinterface.setBet(ref Game.TableStruct, value);
                        }
                    }
                    public int handIndex;

                }//end Hand class def
            }//end Player class def
        }//end Table class def

        /******************* REDUNDANT, USING DLL DECK STRUCT IN PLACE***********
        public class Deck {
            //private string[] sDeck;
            SortedList<string, int> sDeck = new SortedList<string, int>();
            string sNextCard;
            IList<string> sDeck2 = new List<string>();
            int iCardsInDeck = 52;
            public int CardsInDeck
            {
                set { iCardsInDeck = value; }
                get { return iCardsInDeck; }
            }
            public Deck()
            {
                Shuffle();   
            }
            public IList<string> Shuffle()
            {
                sDeck.Add("sA", 1);
                sDeck.Add("s2", 2);
                sDeck.Add("s3", 3);
                sDeck.Add("s4", 4);
                sDeck.Add("s5", 5);
                sDeck.Add("s6", 6);
                sDeck.Add("s7", 7);
                sDeck.Add("s8", 8);
                sDeck.Add("s9", 9);
                sDeck.Add("st", 10);
                sDeck.Add("sj", 11);
                sDeck.Add("sq", 11);
                sDeck.Add("sk", 11);
                sDeck.Add("hA", 14);
                sDeck.Add("h2", 15);
                sDeck.Add("h3", 16);
                sDeck.Add("h4", 17);
                sDeck.Add("h5", 18);
                sDeck.Add("h6", 19);
                sDeck.Add("h7", 20);
                sDeck.Add("h8", 21);
                sDeck.Add("h9", 22);
                sDeck.Add("ht", 23);
                sDeck.Add("hj", 24);
                sDeck.Add("hq", 25);
                sDeck.Add("hk", 26);
                sDeck.Add("dA", 27);
                sDeck.Add("d2", 28);
                sDeck.Add("d3", 29);
                sDeck.Add("d4", 30);
                sDeck.Add("d5", 31);
                sDeck.Add("d6", 32);
                sDeck.Add("d7", 33);
                sDeck.Add("d8", 34);
                sDeck.Add("d9", 35);
                sDeck.Add("dt", 36);
                sDeck.Add("dj", 37);
                sDeck.Add("dq", 38);
                sDeck.Add("dk", 39);
                sDeck.Add("cA", 40);
                sDeck.Add("c2", 41);
                sDeck.Add("c3", 42);
                sDeck.Add("c4", 43);
                sDeck.Add("c5", 44);
                sDeck.Add("c6", 45);
                sDeck.Add("c7", 46);
                sDeck.Add("c8", 47);
                sDeck.Add("c9", 48);
                sDeck.Add("ct", 49);
                sDeck.Add("cj", 50);
                sDeck.Add("cq", 51);
                sDeck.Add("ck", 52);

                sDeck2.Add("sA");
                sDeck2.Add("s2");
                sDeck2.Add("s3");
                sDeck2.Add("s4");
                sDeck2.Add("s5");
                sDeck2.Add("s6");
                sDeck2.Add("s7");
                sDeck2.Add("s8");
                sDeck2.Add("s9");
                sDeck2.Add("st");
                sDeck2.Add("sj");
                sDeck2.Add("sq");
                sDeck2.Add("sk");
                sDeck2.Add("sA");
                sDeck2.Add("h2");
                sDeck2.Add("h3");
                sDeck2.Add("h4");
                sDeck2.Add("h5");
                sDeck2.Add("h6");
                sDeck2.Add("h7");
                sDeck2.Add("h8");
                sDeck2.Add("h9");
                sDeck2.Add("ht");
                sDeck2.Add("hj");
                sDeck2.Add("hq");
                sDeck2.Add("hk");
                sDeck2.Add("dA");
                sDeck2.Add("d2");
                sDeck2.Add("d3");
                sDeck2.Add("d4");
                sDeck2.Add("d5");
                sDeck2.Add("d6");
                sDeck2.Add("d7");
                sDeck2.Add("d8");
                sDeck2.Add("d9");
                sDeck2.Add("dt");
                sDeck2.Add("dj");
                sDeck2.Add("dq");
                sDeck2.Add("dk");
                sDeck2.Add("cA");
                sDeck2.Add("c2");
                sDeck2.Add("c3");
                sDeck2.Add("c4");
                sDeck2.Add("c5");
                sDeck2.Add("c6");
                sDeck2.Add("c7");
                sDeck2.Add("c8");
                sDeck2.Add("c9");
                sDeck2.Add("ct");
                sDeck2.Add("cj");
                sDeck2.Add("cq");
                sDeck2.Add("ck");
                return sDeck2;
            }
            public string NextCard()
            {
                //Random random = new Random();
                
                int num = RandomNumber.NumberBetween(0, CardsInDeck - 1);
                
                
                
                //if (CardsInDeck > 0)
                //{
                //    num = random.Next(CardsInDeck);
                //}
                //else
                //{
                //num = random.Next(CardsInDeck);
                //}
                
                sNextCard = sDeck2[num];
                sDeck2.Remove(sNextCard);
                iCardsInDeck--;
                return sNextCard;
            }

            internal void Remove(object sNextCard)
            {
                throw new NotImplementedException();
            }
        }//END Deck Class **********************/

        //something something
    } //End Game class def
    
    public class DealCards2
    {
        //private int players;
        //private int position;
        //private string name;
        //private int bet;
        public player[] Players = new player[3];
        public dealer DealerHand = new dealer();
        //private string sDrawcard;
        private string[] sDeck = new string[52];
        //private string NextCard;
        //Deck myDeck = new Deck();
        //private string[] hand = { "", "" };
        //public string[] Hands
        //{ 
        //    get { return hand; }
        //}
        // Default constructor:
        //public DealCards2()
        //{
        //    this.hand[0] = "h7";
        //    this.hand[1] = "dq";
        //} 

            /***************************** REDUNDANT
        public DealCards2(int iplayers, player player1, player player2, player player3, dealer dealer, Game.Deck myDeck)
        {*/
        //    DrawCard DrawCard = new DrawCard();
        //    for (int i = 0; i < iplayers; i++)
        //    {
        //        switch (i)
        //        {
        //            case 0:
        //                this.Players[i] = player1;
        //                this.Players[i].Cards.Add(DrawCard.NewCard(myDeck));
        //                this.Players[i].Cards.Add(DrawCard.NewCard(myDeck));
        //                //this.Players[i].Cards.Add(myDeck.NextCard());
        //                //this.Players[i].Cards.Add(myDeck.NextCard());
        //                //this.Players[i].Name = player1.Name;

        //                break;
        //            case 1:
        //                this.Players[i] = player2;
        //                this.Players[i].Cards.Add(DrawCard.NewCard(myDeck));
        //                this.Players[i].Cards.Add(DrawCard.NewCard(myDeck));
        //                //this.Players[i].Name = player2.Name;
        //                break;
        //            case 2:
        //                this.Players[i] = player3;
        //                this.Players[i].Cards.Add(DrawCard.NewCard(myDeck));
        //                this.Players[i].Cards.Add(DrawCard.NewCard(myDeck));
        //                //Players[i].Cards.Add(
        //                //this.Players[i].Name = player3.Name;
        //                break;
        //        }
        //    }
        //    this.DealerHand = dealer;
        //    this.DealerHand.Cards.Add(DrawCard.NewCard(myDeck));
        //    this.DealerHand.Cards.Add(DrawCard.NewCard(myDeck));
        //}

        //public class DrawCard   
        //{  
        //    private string sDrawCard;
        //    public string Drawcard
        //    {
        //        get { return sDrawCard; }  
        //    }
        //    public string NewCard(Game.Deck myDeck)
        //    {
        //        Random random = new Random();
        //        int num;
        //        if (myDeck.CardsInDeck > 0)
        //        {
        //            num = random.Next(myDeck.CardsInDeck);
        //        }
        //        else
        //        {
        //            myDeck = new Game.Deck();
        //            num = random.Next(myDeck.CardsInDeck);
        //        }

        //        sDrawCard = myDeck.NextCard();
        //        myDeck.Remove(sDrawCard);
        //        myDeck.CardsInDeck--;
        //        return sDrawCard;
        //    }
        //}
        public class Calc
        {
            private int iCCount;
            
            public int CCount(IList<string> sCards)
                 {
                    iCCount = 0;
                int iAces = 0;
                    for (int i = 0; i < sCards.Count; i++)
                    {
                        switch (sCards[i].Substring(1))
                        {
                            case "A":
                                iCCount += 11;
                            iAces ++;
                                //if (iCCount > 21)
                                //{
                                //    iCCount -= 10;
                                //}
                                break;
                            case "t":
                            case "j":
                            case "q":
                            case "k":
                                iCCount += 10;
                                break;
                            default:
                                string c = sCards[i].Substring(1);
                                iCCount += int.Parse(c);
                                break;
                        }
                    };
                    if (iCCount > 21)
                    {// Check for aces
                        if (iAces > 0)
                        {
                            iCCount -= 10;
                            if (iAces > 1 & iCCount > 21)
                            {
                                iCCount -= 10;
                            }
                                if (iAces > 2 & iCCount > 21)
                                {
                                    iCCount -= 10;
                                }
                                    if (iAces > 3 & iCCount > 21)
                                    {
                                        iCCount -= 10;
                                    }
                        }
                    }
                    return iCCount;
                }          
        }//End Calc
        public class player
        {
            private int ipostion;
            private string sName;
            //private string[] sCards = new string[7];
            IList<string> sCards = new List<string>();
            private int iBet;
            private int iCount;
            private int iChipBalance;

            public IList<string> Cards
            {
                get { return sCards; }
                //set { sCards = value; }
            }
            public int Position
            {
                get { return ipostion; }
                set { ipostion = value; }
            }
            public string Name
            {
                get { return sName; }
                set { sName = value; }
            }
            public int Bet
            {
                get { return iBet; }
                set
                {   iBet = value;
                    iChipBalance -= iBet;
                }
            }
            public int Count
            { get
                {   Calc myCalc = new Calc();
                    iCount = myCalc.CCount(sCards);
                    return iCount;
                }
            }  
            public int ChipBalance
            {
                get { return iChipBalance; }
                set { iChipBalance = value; }
            }  
            public int CalcResult(int DealerCount)
            {
                Boolean push = Convert.ToBoolean(DealerCount == iCount);
                Boolean win = Convert.ToBoolean(DealerCount < iCount);
                Boolean lose = Convert.ToBoolean(DealerCount > iCount);
                Boolean DealerBust = Convert.ToBoolean(DealerCount > 21);
                Boolean PlayerBust = Convert.ToBoolean(iCount > 21);

                if (PlayerBust)
                {
                    return iChipBalance;
                }
                else if (DealerBust)
                {
                    return (iChipBalance += (iBet * 2));
                }
                else if (win)
                {
                    return (iChipBalance += (iBet * 2));
                }
                else if (lose)
                {
                    return iChipBalance;
                }
                else //push
                {
                    return (iChipBalance += iBet);
                }
            }
        }
        public class dealer
        {
            IList<string> sCards = new List<string>();
            private int iCount;
            public IList<string> Cards
            {
                get { return sCards; }
            }
            public int Count
            { get
                {   Calc myCalc = new Calc();
                    iCount = myCalc.CCount(sCards);
                    return iCount;
                }
            }
        }//End Dealer   
    } //End DealCards2

    public class RandomNumber
    {   //Copied from website http://chilembwe.com/captnemo/node/26

        private static readonly System.Security.Cryptography.RNGCryptoServiceProvider _seed = new System.Security.Cryptography.RNGCryptoServiceProvider();
        public static int NumberBetween(int minimum, int maximum)
        {
            byte[] randomNumber = new byte[1];

            _seed.GetBytes(randomNumber);

            double asciiValue = Convert.ToDouble(randomNumber[0]);

            double multiplier = Math.Max(0, (asciiValue / 255d) - 0.00000000001d);

            // adding one to the range, to allow for rounding 
            int range = maximum - minimum + 1;

            double randomValue = Math.Floor(multiplier * range); // rounds to ensure within range

            return (int)(minimum + randomValue); // adds minvalue to randomvalue(0 to max)
        }
    } // END RandomNumber
} //End TestCard2

