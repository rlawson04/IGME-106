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

			// *********************
			// Put your code between here...

			string userInput = " ";
			string doubleWord = " ";
			bool isDouble = false;

			while (userInput != "Q")
			{
				
                Console.Write("Do you want to search the LIST (L), DICTIONARY (D), or QUIT (Q)?\n> ");
                userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "L":
                        for(int i = 0; i < wordList.Count; i++)
						{
							doubleWord = wordList[i] + wordList[i];

                            if (wordList.Contains(doubleWord))
							{
								Console.WriteLine(doubleWord);
							}
							
						}
                        Console.WriteLine();
                        break;

                    case "D":
						Console.WriteLine("CHECKING DICTIONARY");
                        Console.WriteLine();
                        break;

					case "Q":
						break;

                    default:
                        Console.WriteLine("Sorry, could you enter either the letter 'D', 'L', or 'Q'?");
                        Console.Write("Do you want to search the LIST (L) or DICTIONARY (D)?\n> ");
                        userInput = Console.ReadLine().ToUpper();
                        break;
                }
            }

			Console.WriteLine("Thank you for searching!");
			


			// ...and here.
			// *********************

		}
	}
}
