using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2_Part2
{
    /// <summary>
    /// Represents a deck of playing cards using the card class
    /// </summary>
    internal class Deck
    {
        // List of card objects to hold the 52 cards
        private List<Card> cardList = new List<Card>();

        // Random number generator
        private Random random = new Random();

        /// <summary>
        /// Constructor for the deck that adds all 52 cards to the cardList
        /// </summary>
        public Deck()
        {
            // Loops through each of the 52 cards using their suit and value
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    cardList.Add(new Card(i, j));
                }
            }
        }

        /// <summary>
        /// Randomly creates a stack of cards from the list
        /// </summary>
        /// <returns> A cardstack full of cards randomly selected from the list </returns>
        public CardStack<Card> Shuffle()
        {
            // Stack of type Card to return at the end
            CardStack<Card> stack = new CardStack<Card>();

            // Randomly selects a card from the list, then adds it to the stack and removes it from the list
            while (cardList.Count > 0)
            {
                int cardFromList = random.Next(cardList.Count);

                stack.Push(cardList[cardFromList]);
                cardList.RemoveAt(cardFromList);
            }

            // Returns the stack with all the cards in it
            return stack;
        }
    }
}
