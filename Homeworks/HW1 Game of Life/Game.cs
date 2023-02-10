using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HW1_Game_of_Life
{
    internal class Game
    {
        // -------------------------------------
        // Fields
        // -------------------------------------

        private Cell[,] gameBoard;
        private Cell[,] gameBoard2;
        private Random rng = new Random();
        private string fileName;
        private Cell[,] paddedBoard;

        // -------------------------------------
        // Properties   
        // -------------------------------------
        
        /// <summary>
        /// Get - Set property that allows the user to change
        /// the file name from outside the class
        /// </summary>
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
            gameBoard = new Cell[rng.Next (5,11),rng.Next(10,21)];

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
                    gameBoard[i,j] = new Cell(isAlive);
                }
            }

            // Creates new 2d array of the same length
            gameBoard2 = new Cell[gameBoard.GetLength(0), gameBoard.GetLength(1)];

            // Copies data into the array as a non shallow copy
            Array.Copy(gameBoard, gameBoard2, gameBoard.Length);

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

        /// <summary>
        /// Reads data from a saved file and loads the board
        /// </summary>
        /// <param name="fileName"> Uses a string to search for a file name </param>
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
                int counter1 = 0;

                // Initial line has the bounds of the game board
                lineOfText = reader.ReadLine();

                // Split data into an array of strings
                string[] splitData = lineOfText.Split(',');

                // Create game board using split data
                width = int.Parse(splitData[1]);
                length = int.Parse(splitData[0]);
                gameBoard = new Cell[width, length];

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
                    int counter2 = 0;

                    foreach (char c in lineOfText)
                    {
                        // Add the dead cells to the board
                        if (c == 'x')
                        {
                          gameBoard[counter1, counter2] = cellDead;
                        }
                        // Add the live cells to the board
                        if (c == 'o')
                        {
                            gameBoard[counter1, counter2] = cellAlive;
                        }
                        
                        // Increase the counter
                        counter2++;

                    }
                    
                    // Iterate through the rows
                    counter1++;
                   
                    


                }
                // Closes the stream reader 
                reader.Close();
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            gameBoard2 = gameBoard;

            // Copies data into the array as a non shallow copy
            Array.Copy(gameBoard, gameBoard2, gameBoard.Length);

            // Print confirmation that the game board loaded correctly
            Console.WriteLine("Game board loaded");

        }

        /// <summary>
        /// Writes data from the generated board into a text file
        /// </summary>
        /// <param name="saveFile"> creates or overwrites a file 
        /// with the given string name </param>
        public void SaveGame(string saveFile)
        {
            StreamWriter writer = new StreamWriter("../../../" + saveFile);
            writer.WriteLine(gameBoard.GetLength(1) + "," + gameBoard.GetLength(0));

            writer.WriteLine("@,-");

            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for(int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    writer.Write(gameBoard[i, j].ToString());
                }
                writer.WriteLine();
            }
            writer.Close();
        }

        /// <summary>
        /// Creates an outer board to check through each cell in the game board
        /// </summary>
        public void Advance()
        {
            // Outside array to not cause an index error
            paddedBoard = new Cell[(gameBoard.GetLength(0) + 2), (gameBoard.GetLength(1) + 2)];

            for (int i = 0; i < paddedBoard.GetLength(0); i++)
            {
                for (int j = 0; j < paddedBoard.GetLength(1); j++)
                {
                    paddedBoard[i, j] = new Cell(false);
                }
            }

            // Populate the outside array
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    paddedBoard[i + 1, j + 1] = gameBoard[i,j];
                }
            }

            // Advances the cells based on the rules below
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    gameBoard2[i, j] = UpdateLogic(i, j);
                }
            }
        }

        // RULES FOR THE CELLS:
        // Live cell with fewer than two live neighbors dies
        // Live cell with two or three living neighbors lives
        // Live cell with more than three living neighbors dies
        // Dead cell with three live neighbors lives


        /// <summary>
        /// Iterates through the game board to create a new logic for each cell
        /// based on the rules above
        /// </summary>
        /// <param name="i"> an int from the nested for loop </param>
        /// <param name="j"> an int from the nested for loop </param>
        /// <returns> A cell object thta is either alive or dead 
        /// based on the rules</returns>
        public Cell UpdateLogic(int i, int j)
        {
            // Counter to keep track of how many live cells are around the given cell
            int aliveCount = 0;

            // Creates new cell which will be returned at the end
            Cell update = new Cell(false);

            // Checks the given cell and determines if it is alive
            for (int k = (i-1); k < (i+2); k++)
            {
                for (int l = (j-1); l < (j+2); l++)
                {
                    if (paddedBoard[k+1, l+1].IsAlive == true)
                    {
                        aliveCount++;
                        update.IsAlive = true;
                    }
                }
            }  

            // Uses the rules above to figure out if the cell becomes alive or dead
            switch (aliveCount - 1)
            {
                case 0:
                    update.IsAlive = false;
                    break;

                case 1:                   
                    update.IsAlive = false;
                    break;

                case 2:
                    if (update.IsAlive == false)
                    {
                        update.IsAlive = false;
                    }
                    else
                    {
                        update.IsAlive = true;
                    }
                    break;

                case 3:
                    if (update.IsAlive == false)
                    {
                        update.IsAlive = true;
                    }                   
                    break;

                default:
                    update.IsAlive = false;
                    break;
            }

            // returns the updated cell
            return update;
        }
    } // End of class
}
