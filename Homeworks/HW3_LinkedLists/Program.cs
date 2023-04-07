using System;
using System.Collections.Generic;

// DO NOT MODIFY ANY CODE IN THIS FILE
namespace HW3_LinkedLists
{
    class Program
    {
        // Helper method to handle console input and change the console color depending
        // on if we're prompting, reading input, or in normal operation
        static string GetPromptedInput(string prompt)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(prompt + " ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string result = Console.ReadLine().Trim().ToLower();
            Console.ForegroundColor = ConsoleColor.White;
            return result;
        }

        // Creates a test list and runs a user input loop to allow the list to be
        // modified
        static void Main(string[] args)
        {
            // Setup
            Deck myDeck = new Deck();
            Random rand = new Random();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to the Linked List homework!\n");

            // Main user loop
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\n[A]dd, [P]rint, [B]ackwards, [C]lear, [D]eal, [M]ove last, [S]huffle, [Q]uit");
                string input = GetPromptedInput("What would you like to do?");

                Console.WriteLine();

                try
                {
                    switch (input)
                    {
                        // Adds one card of each possible suit & rank to the deck.
                        case "a":
                        case "add":
                            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                            {
                                foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                                {
                                    myDeck.Add(suit, rank);
                                }
                            }
                            break;

                        // Tells the deck to print itself in order.
                        case "p":
                        case "print":
                            myDeck.Print();
                            break;

                        //Tells the deck to print itself in reverse order.
                        case "b":
                        case "backwards":
                            myDeck.PrintReversed();
                            break;

                        // Tells the deck to reset itself to empty.
                        case "c":
                        case "clear":
                            myDeck.Clear();
                            break;

                        // Tells the deck to copy itself into a user - specified # of sub-decks and then prints out the returned List of decks.
                        case "d":
                        case "deal":
                            Console.WriteLine("How many players are there?");
                            int playerCount = -1;
                            if (int.TryParse(Console.ReadLine(), out playerCount)
                                && playerCount > 0)
                            {
                                List<Deck> playerHands = myDeck.DealPlayerHands(playerCount);

                                for (int i = 0; i < playerHands.Count; ++i)
                                {
                                    Console.WriteLine("\nPlayer {0} hand:", i + 1);

                                    playerHands[i].Print();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Sorry that wasn't a vaild number");
                            }
                            break;

                        // Tests removal of a user - specified # of cards from the end of the deck and insertion elsewhere.
                        case "m":
                        case "move last":
                            string response = GetPromptedInput("How many cards do you want to move?");
                            int cards = -1;
                            if (int.TryParse(response, out cards)
                                && cards > 0)
                            {
                                if (myDeck.Count >= 2 + cards)
                                {
                                    Console.WriteLine("Moving the last {0} cards to the front", cards);
                                    myDeck.Move(cards, 0);
                                    myDeck.Print();

                                    Console.WriteLine("Moving the last {0} cards to index 1", cards);
                                    myDeck.Move(cards, 1);
                                    myDeck.Print();
                                }
                                else
                                {
                                    Console.WriteLine("Not enough cards to do this");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Sorry that wasn't a vaild number");
                            }
                            break;

                        // Shuffles the deck by repeatedly moving a random number of cards from the end of the deck to somewhere earlier in the deck.
                        // Don’t bother trying this until you are confident that[M]ove last is working!
                        case "s":
                        case "shuffle":
                            int overhandTimes = rand.Next(100, 1001);
                            Console.WriteLine("Shuffle {0} times", overhandTimes);

                            for (int i = 0; i < overhandTimes; ++i)
                            {
                                // Decide how many cards to move from the end of the deck into the middle somewhere
                                // Don't move more than half the deck at once
                                int cardsToMove = rand.Next(1, myDeck.Count / 2);

                                // We can't move cards into themselves so compute the last possible index we can move before
                                // For example, if the count were 8 and we decide to move 1 card, the new tail card is currently
                                // at index 6.
                                int indexLimt = myDeck.Count - (cardsToMove + 1);

                                if (indexLimt < 2)
                                {
                                    throw new IndexOutOfRangeException("Invalid index: " + indexLimt);
                                }

                                // Get a target index between 0 and the limit
                                int targetIndex = rand.Next(0
                                    , indexLimt + 1);

                                myDeck.Move(cardsToMove, targetIndex);
                            }
                            myDeck.Print();
                            break;

                        // End the user input loop
                        case "q":
                        case "quit":
                            Console.WriteLine("Goodbye");
                            isRunning = false;
                            break;

                        // Any other input is ignored.
                        default:
                            Console.WriteLine("Sorry that was an invalid command.");
                            break;
                    }
                }

                // Main() ONLY handles an IndexOutOfRangeException exception (which your custom
                // linked list must throw when appropriate). Any other exception type will
                // still cause the program to crash.
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("Error handling command \"" + input + "\" - " + e.Message);
                }
            }
        }
    }
}
