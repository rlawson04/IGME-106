using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2_Part2
{
    /*----------------------------------------------------------------
      * This class represents a single playing card from a 52 card deck
      * 
      * suit: a value from 0 - 3
      * 0 = diamonds, 1 = clubs, 2 = hearts, 3 = spades
      * 
      * value: a value from 1 - 13
      * 1 = ace, 2 - 10  = face value, 11 = jack, 12 = queen, 13 = king
      * 
      * DO NOT ALTER ANY CODE IN THIS CLASS!
      * Prof. Bierre
      -----------------------------------------------------------------*/
    internal class Card
    {
        // fields
        private int suit; // suit of the card (0 - 3)
        private int value; // value of the card (1 - 13)
        private string[] suits = { "Diamonds", "Clubs", "Hearts", "Spades" };

        // constructor
        public Card(int suit, int value)
        {
            this.suit = suit;
            this.value = value;
        }

        // ToString override
        public override string ToString()
        {
            string text = "";
            switch (value)
            {
                case 1:
                    text += "Ace of " + suits[suit];
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    text += value + " of " + suits[suit];
                    break;
                case 11:
                    text += "Jack of " + suits[suit];
                    break;
                case 12:
                    text += "Queen of " + suits[suit];
                    break;
                case 13:
                    text += "King of " + suits[suit];
                    break;
            }
            return text;
        }
    }
}
