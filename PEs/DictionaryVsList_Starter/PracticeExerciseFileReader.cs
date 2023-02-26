﻿using System;
using System.Collections.Generic;
using System.IO;


namespace DictionaryVsList_Starter
{
    // DO NOT MODIFY ANYTHING EXCEPT THE BLOCK MARKED
    // WITH **** and "REPLACE THIS"
    class PracticeExerciseFileReader
	{
		// Fields to hold data and stream reader
		private List<String> wordList;
		private Dictionary<String, bool> wordDictionary;

		/// <summary>
		/// Gets the list of words that have been read in
		/// </summary>
		public List<string> WordList { get { return wordList; } }

		/// <summary>
		/// Gets the dictionary of words that have been read in
		/// </summary>
		public Dictionary<String, bool> WordDictionary { get { return wordDictionary; } }

		/// <summary>
		/// Loads words from an external file
		/// </summary>
		public PracticeExerciseFileReader()
		{
            // Create the data structures
            wordList = new List<string>();
            wordDictionary = new Dictionary<string, bool>();

            // Initialize the StreamReader
            StreamReader reader = null;

            try
            {
                // Open the file and read it into both the list and dictionary
                reader = new StreamReader("..\\..\\words.txt");

                // Loop through the file, one line at a time
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    // Add the line to both the list and the dictionary
                    // ***************************************************************************
                    wordList.Add(line);
                    wordDictionary.Add(line, false);
                    // ***************************************************************************
                }
            }
            catch (Exception e)
			{
				Console.WriteLine("Error loading word list: " + e.Message + "\n");
				Console.WriteLine("If you ran this program with Ctrl+F5 (or 'Start without Debugging'), try running it with F5 instead (or vice versa)");
			}
            finally
            {
                // Ensure that we can close the file, as long
                // as it was actually opened in the first place
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
	}
}
