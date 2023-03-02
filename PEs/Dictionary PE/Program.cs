using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryVsList_Starter
{
	class Program
	{
		static void Main(string[] args)
		{
			// Creates a new file reader, which loads a file of words
			// into both a list and a dictionary
			PracticeExerciseFileReader reader = new PracticeExerciseFileReader();

			// Get the two data structures needed for the exercise
			List<String> wordList = reader.WordList;
			Dictionary<String, bool> wordDictionary = reader.WordDictionary;

			//**************************************************************************

			string userInput = " ";
			string doubleWord = " ";
			string userWord = " ";
			System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();

			// Main loop that asks user for input until Q is given
			while (userInput != "Q")
			{
				// Main menu prompt
                Console.Write("Do you want to search the LIST (L), DICTIONARY (D), or QUIT (Q)?\n> ");
                userInput = Console.ReadLine().ToUpper();

				// Switch to handle user input
                switch (userInput)
                {
					// Uses a list to search through the list of words for any words
					// made up of two smaller repeated words
                    case "L":
                        watch.Reset();
                        watch.Start();

						// Searching through the list
                        for(int i = 0; i < wordList.Count; i++)
						{
							doubleWord = wordList[i] + wordList[i];

                            if (wordList.Contains(doubleWord))
							{
								Console.WriteLine(doubleWord);
							}
							
						}
						watch.Stop();

						// Reporting how long it took
						Console.WriteLine("List search took " + watch.Elapsed.TotalSeconds
							+ "seconds");
                        Console.WriteLine();
                        break;

                    // Uses a dictionary to search through the list of words for any words
                    // made up of two smaller repeated words and then asks user for a word
					// which is then searched through the list and returns if it is or isn't a double
                    case "D":
						watch.Reset();
						watch.Start();

						// Searching through the dictionary
						for(int i = 0; i<wordList.Count; i++)
						{
                            doubleWord = wordList[i] + wordList[i];
							if(wordDictionary.ContainsKey(doubleWord))
							{
                                Console.WriteLine(doubleWord);
								wordDictionary[doubleWord] = true;
                            }
                            
						}
						watch.Stop();

						// Reporting how long it took
                        Console.WriteLine("Dictionary search took " + watch.Elapsed.TotalSeconds
                            + "seconds");
                        Console.WriteLine();

						// Searching using user input
						while (userWord != "quit")
						{
                            Console.Write("Which word would you like to check?\n>");
                            userWord = Console.ReadLine();

							if (wordDictionary.ContainsKey(userWord))
							{
								if (wordDictionary[userWord] == true)
								{
									Console.WriteLine("The word IS a double!\n");
								}
								else
								{
									Console.WriteLine("The word IS NOT a double\n");
								}
							}
							else
							{
								Console.WriteLine("The word is not in the list\n");
							}
                        }

						Console.WriteLine();
                        break;

					// Quits from the loop
					case "Q":
						break;

					// In case user enters something besides the prompted values
                    default:
                        Console.WriteLine("Sorry, could you enter either the letter 'D', 'L', or 'Q'?");
                        Console.Write("Do you want to search the LIST (L) or DICTIONARY (D)?\n> ");
                        userInput = Console.ReadLine().ToUpper();
                        break;
                }
            }

			Console.WriteLine("Thank you for searching!");

			// *************************************************************************
		}
	}
}
