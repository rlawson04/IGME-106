using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HW3_LinkedLists
{
    // DO NOT MODIFY THIS FILE EXCEPT WHERE MARKED
    // NO NEW class fields/properties!
    class Deck
    {
        // Each Deck is effectively a doubly linked list of Card objects that it manages
        // via references to the head and tail (top and bottom) cards + a field to track
        // the current # of cards
        private Card head;
        private Card tail;
        private int count;

        /// <summary>
        /// Returns the current number of Cards
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Implement an indexer property for the list that correctly gets and sets 
        /// data in the node at a specific index. If the index is invalid, throw 
        /// an IndexOutOfRangeException exception. 
        /// </summary>
        public Card this[int index]
        {
            get
            {
                // Throws exception for invalid index
                if(index>=Count)
                {
                    throw new IndexOutOfRangeException();
                }

                Card current = head;
                for(int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                return current; 
            }

            set
            {
                // Throws exception for invalid index
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                Card current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                current.Previous = value;
                
            }
        }

        /// <summary>
        /// Add a new Card object (with the specified suit and rank) to the end of the list. 
        /// Increment the count and update the head and/or tail when you add the card.
        /// </summary>
        public void Add(CardSuit suit, CardRank rank)
        {
            // Creates a new node for the card given the passed information
            Card newNode = new Card(suit, rank);

            // Sets the next and previous to null
            newNode.Next = null;
            newNode.Previous = null;

            // Check that there is an element in the list
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                // Increase count
                count++;
            }
            // If not, use a temp card to loop through and find the end,
            // then add the card to the end of the list
            else
            {
                Card temp = new Card(suit, rank);
                temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }

                // Set temp next to new node and new node's previous to head
                temp.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;

                // Increase count
                count++;
            }
        }


        /// <summary>
        /// This method should utilize the “next” field of each node to print 
        /// out all of the cards in order.  This will help to test if all of 
        /// your “arrows” point to the correct “boxes”.
        /// </summary>
        public void Print()
        {
            Card temp = head;
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(temp);
                temp = temp.Next;
            }
            
        }

        /// <summary>
        /// This method should utilize the “previous” field of each node to 
        /// print out all of the data in reverse order.  This will help to 
        /// test if all of your “arrows” point to the correct “boxes”.
        /// </summary>
        public void PrintReversed()
        {
            Card temp = tail;
            for (int  i = 0; i < Count; ++i)
            {
                Console.WriteLine(temp);
                temp = temp.Previous;
            }
        }

        /// <summary>
        /// This method will clear the list.  Update the count attribute, 
        /// as well as the head and tail.
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        /// <summary>
        /// This method returns a deck for each player that represents the cards 
        /// in that player’s hand. All the cards in the deck need to be dealt out 
        /// to the players. All players do not need to have the same number of 
        /// cards.
        /// 
        /// Hint: Remember that while, after dealing cards in real life, the full deck
        ///         is split among the players into N smaller decks, but the total
        ///         number of cards remains the same and no cards are repeated. This
        ///         is NOT what will happen here. In order to preserve the links in the
        ///         main deck, your deal will COPY the cards as it adds them to each
        ///         player's deck!
        /// </summary>
        public List<Deck> DealPlayerHands(int playerCount)
        {
            Random rng = new Random();
            List<Deck> Decks = new List<Deck>();

            for (int i = 0; i < playerCount; i++)
            { 
                Deck deck = new Deck();

                for (int j = 0; j < Count/playerCount; j++)
                {
                    deck.Add(this[rng.Next(0, Count)].Suit, this[rng.Next(0, Count)].Rank);
                }

                Decks.Add(deck);
            }

            return Decks; 
        }

        /// <summary>
        /// This method will remove a number of cards from the end of the list and 
        /// insert them back into the list before a certain index. This method only 
        /// has to worry about moving one group of cards in the deck. The main program 
        /// will repeatedly call this method to shuffle the entire deck.  The first 
        /// parameter is the number of cards to be removed from the end of the list. 
        /// The second parameter is the new index of the first card in the 
        /// group of cards that were moved in the list.
        /// 
        /// Notes:
        ///     - You can assume valid parameters will be give for the size of the deck.
        ///     - If you leverage your this[] get indexer, there's no need for loops here.
        /// </summary>
        public void Move(int cardsToMove, int targetIndex)
        {
            
        }
    }
}
