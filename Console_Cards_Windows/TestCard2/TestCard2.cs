using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCard2
{
    public class Game
    { 
        public Game()
        {
            Deck myDeck = new Deck();
        }
        public class Deck
        {
            //private string[] sDeck;
            SortedList<string, int> sDeck = new SortedList<string, int>();
            string sNextCard;
            IList<string> sDeck2 = new List<string>();
            int CardsInDeck = 52;
            public Deck()
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
            }
            public string NextCard()
            {
                Random random = new Random();
                int num = random.Next(1, CardsInDeck);
                sNextCard = sDeck2[num];
                sDeck2.Remove(sNextCard);
                CardsInDeck--;
                return sNextCard;
            }
        }
    } //End Game
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

        public DealCards2(int iplayers, player player1, player player2, player player3, dealer dealer, Game.Deck myDeck)
        {
            for (int i = 0; i < iplayers; i++)
            {
                switch (i)
                {
                    case 0:
                        this.Players[i] = player1;
                        this.Players[i].Cards.Add(myDeck.NextCard());
                        this.Players[i].Cards.Add(myDeck.NextCard());
                        //this.Players[i].Name = player1.Name;

                        break;
                    case 1:
                        this.Players[i] = player2;
                        this.Players[i].Cards.Add(myDeck.NextCard());
                        this.Players[i].Cards.Add(myDeck.NextCard());
                        //this.Players[i].Name = player2.Name;
                        break;
                    case 2:
                        this.Players[i] = player3;
                        this.Players[i].Cards.Add(myDeck.NextCard());
                        this.Players[i].Cards.Add(myDeck.NextCard());
                        //this.Players[i].Name = player3.Name;
                        break;
                }
            }
            this.DealerHand = dealer;
            this.DealerHand.Cards.Add(myDeck.NextCard());
            this.DealerHand.Cards.Add(myDeck.NextCard());
        }

        public class DrawCard   
        {  
            private string sDrawCard = "";
            public string Drawcard
            {
                get { return sDrawCard; }  
            }
            public DrawCard(Game.Deck myDeck, player myPlayer)
            {
                sDrawCard = myDeck.NextCard();
                int NumCards = myPlayer.Cards.Count;
                myPlayer.Cards[NumCards] = sDrawCard;
            }
         }
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
                set { iBet = value; }
            }
            public int Count
            { get
                {   Calc myCalc = new Calc();
                    iCount = myCalc.CCount(sCards);
                    return iCount;
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

