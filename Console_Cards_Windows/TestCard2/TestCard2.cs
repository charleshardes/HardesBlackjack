using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCard2
{
    public class DealCards2
    {
        //private int players;
        //private int position;
        //private string name;
        //private int bet;
        public player[] Players = new player[3];
        public dealer DealerHand = new dealer();
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

        public DealCards2(int iplayers, player player1, player player2, player player3)
        {
            for (int i = 0; i < iplayers; i++)
            {
                switch (i)
                {
                    case 0:
                        this.Players[i] = player1;
                        this.Players[i].Cards[0] = "d4";
                        this.Players[i].Cards[1] = "sk";
                        //this.Players[i].Name = player1.Name;

                        break;
                    case 1:
                        this.Players[i] = player2;
                        this.Players[i].Cards[0] = "c9";
                        this.Players[i].Cards[1] = "dj";
                        //this.Players[i].Name = player2.Name;
                        break;
                    case 2:
                        this.Players[i]=player3;
                        this.Players[i].Cards[0] = "h8";
                        this.Players[i].Cards[1] = "sA";
                        //this.Players[i].Name = player3.Name;
                        break;
                }
            }
            DealerHand.Cards[0] = "ck";
            DealerHand.Cards[1] = "s2";
        }          
    }
    public class player
    {
        private int ipostion;
        private string sName;
        private string[] sCards = new string [7];
        
        private int iBet;

        

        public string[] Cards
        {
            get { return sCards; }
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
    }
    
public class dealer
    {
        private string[] sCards = { "", "", "", "", "", "", "" };
        public string[] Cards
        {
            get { return sCards; }
        }
        public dealer()
        {
            
        }
    }


}
