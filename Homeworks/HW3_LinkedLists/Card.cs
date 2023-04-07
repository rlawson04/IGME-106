using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_LinkedLists
{
    // Define the possible card suits
    //
    // NOTE: FOR DEBUGGING ONLY
    // You may want to comment out all but "Clubs" in CardSuit.
    // It will make the desk smaller and easier to see what is
    // happening.
    enum CardSuit
    {
        Hearts,
        Spades,
        Diamonds,
        Clubs
    }

    // Define the possible ranks, in order
    enum CardRank
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    // DO NOT MODIFY ANY CODE IN THIS CLASS
    class Card
    {
        // Cards store and manage 4 fields:
        // - The card suit & rank
        // - References to the previous and next cards in the Deck

        // Conveniently, C# has a shortcut for creating a property backed by a 
        // field - auto-implemented properties.
        // See https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
        public CardSuit Suit { get; set; }
        public CardRank Rank { get; set; }
        public Card Previous { get; set; }
        public Card Next { get; set; }

        // Constructor to create a new Card
        public Card(CardSuit suit, CardRank rank)
        {
            Suit = suit;
            Rank = rank;
            Previous = null;
            Next = null;
        }

        // Return a string representation of the card
        public override string ToString()
        {
            // While the fact that enums auto convert to strings of the same name
            // is awesome, Five of Spades is a little harder to read than "5 of Spades"
            // so do a bit of manual conversion when printing.
            string rankStr = "?";

            switch(Rank)
            {
                case CardRank.Ace:
                case CardRank.Jack:
                case CardRank.Queen:
                case CardRank.King:
                    rankStr = Rank.ToString();
                    break;

                default:
                    rankStr = ((int)Rank + 1).ToString(); // leverage the enum value to find the card value
                    break;
            }

            return rankStr + " of " + Suit;
        }
    }
}
