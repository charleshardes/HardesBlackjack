using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCard
{
    public class DealCards
    {
        private int players;
        private string[] hand;

        public string[] Hands

        {
           get { return hand; }
        }



        // Default constructor:
        public DealCards()
        {
            //hand = "N/A";
        }

        // Constructor:
        public DealCards(int players)
        {
            //this.name = name;

            this.hand[0] = "4h";
            this.hand[1] = "qd";
            

        }

        // Printing method:
        public void PrintChild()
        {
            //Console.WriteLine("{0}, {1} years old.", hand, age);
        }

    }
}
