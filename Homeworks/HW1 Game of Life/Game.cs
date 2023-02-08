using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_Game_of_Life
{
    internal class Game
    {
        // -------------------------------------
        // Fields
        // -------------------------------------

        private string[,] gameBoard;
        private Random rng = new Random();
        private string fileName;

        // -------------------------------------
        // Properties   
        // -------------------------------------
        
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        

        // -------------------------------------
        // Constructors
        // -------------------------------------


        // -------------------------------------
        // Methods
        // -------------------------------------

        /// <summary>
        /// Creates a board of varying size and fills it with Cell objects
        /// </summary>
        public void GenerateBoard()
        {
            // Create 2D array for game board
            gameBoard = new string[rng.Next (5,11),rng.Next(10,21)];

            // Iterate through each row and column
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for(int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    // Determines if the cell is alive
                    bool isAlive = false;

                    // 30% chance the cell is alive
                    if (rng.Next(1,11) <  7)
                    {
                        isAlive = true;
                    }

                    // Fill 2D array with Cell object 
                    gameBoard[i,j] = new Cell(isAlive).ToString();
                }
            }

            // Print size of the board, width x height
            Console.WriteLine($"A {gameBoard.GetLength(0)}x{gameBoard.GetLength(1)}" +
                $" board was generated");
        }

        /// <summary>
        /// Displays the currently loaded board to the console
        /// </summary>
        public void DisplayBoard()
        {
                for (int i = 0; i < gameBoard.GetLength(0); i++)
                {
                    for (int j = 0; j < gameBoard.GetLength(1); j++)
                    {
                        Console.Write(gameBoard[i, j].ToString());
                    }
                    Console.WriteLine();
                }
            
        }

        public void LoadBoard(string fileName)
        {
            try
            {
                // Open the stream reader using the user file name
                StreamReader reader = new StreamReader("../../../" + fileName);
                
                // Variables to be used in the method
                string lineOfText = " ";
                int length = 0;
                int width = 0;
                bool isAlive;
                int counter2 = 0;

                // Initial line has the bounds of the game board
                lineOfText = reader.ReadLine();

                // Split data into an array of strings
                string[] splitData = lineOfText.Split(',');

                // Create game board using split data
                width = int.Parse(splitData[0]);
                length = int.Parse(splitData[1]);
                gameBoard = new string[width, length];

                // Next line has the proper icons for the cells
                lineOfText = reader.ReadLine();
                splitData = lineOfText.Split(',');

                // Create a cell to represent the live cells
                isAlive = true;
                Cell cellAlive = new Cell(isAlive);

                // Create a cell to represent the dead cells
                isAlive = false;
                Cell cellDead = new Cell(isAlive);

                // Use the split data and the alive/dead properties to set the values
                cellAlive.Alive = splitData[0];
                cellDead.Dead = splitData[1];
                
                // Read the rest of the lines of the file
                while (lineOfText != null)
                {
                    lineOfText = reader.ReadLine();

                    // Make sure not to throw an error
                    if (lineOfText == null)
                    {
                        break;
                    }

                    // Iterates through the rows of the game board
                    // and resets every new line
                    int counter1 = 0;

                    foreach (char c in lineOfText)
                    {
                        // Add the dead cells to the board
                        if (c == 'x')
                        {
                          gameBoard[counter1, counter2] = cellDead.ToString();
                        }
                        // Add the live cells to the board
                        else if (c == 'o')
                        {
                            gameBoard[counter1, counter2] = cellAlive.ToString();
                        }
                        
                        // Increase the counter
                        counter1++;

                    }
                    
                    // Iterate through the columns
                    counter2++;
                   
                    


                }
                // Closes the stream reader 
                reader.Close();
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Print confirmation that the game board loaded correctly
            Console.WriteLine("Game board loaded");

        }

        public void SaveGame(string saveFile)
        {
            StreamWriter writer = new StreamWriter("../../../" + saveFile);
            writer.WriteLine(gameBoard.GetLength(0) + "," + gameBoard.GetLength(1));
            
            if (gameBoard[0,0] == "o" || gameBoard[0, 0] == "@" )
            {
                writer.WriteLine(gameBoard[0, 0]);
            }

            int length = 0;
            int width = 0;
            if (gameBoard[length, width] != "x" || gameBoard[length, width] != "-")
            {
                length++;
                width++;
            }
            else
            {

            }


            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for(int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    writer.WriteLine(gameBoard[i, j]);
                }
            }
        }

    } // End of class
}
