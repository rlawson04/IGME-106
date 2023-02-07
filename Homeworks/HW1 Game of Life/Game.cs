using System;
using System.Collections.Generic;
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
                StreamReader reader = new StreamReader("../../../" + fileName);
                string lineOfText = " ";
                int length = 0;
                int width = 0;
                bool isAlive;

                lineOfText = reader.ReadLine();
                // Split data into an array of strings
                string[] splitData = lineOfText.Split(',');


                width = int.Parse(splitData[0]);
                length = int.Parse(splitData[1]);
                gameBoard = new string[width, length];

                lineOfText = reader.ReadLine();
                splitData = lineOfText.Split(',');

                splitData[0] = new Cell(isAlive = true).ToString();
                splitData[1] = new Cell(isAlive = false).ToString();

                while (lineOfText != null)
                {
                    lineOfText = reader.ReadLine();

                    if (lineOfText == null)
                    {
                        break;
                    }
                    int deadCells = 0;
                    int liveCells = 0;
                    foreach (char c in lineOfText)
                    {
                        if (c == 'x')
                        {
                            deadCells++;
                        }
                        if (c == 'o')
                        {
                            liveCells++;
                        }
                    }
                    
                    // Split data into an array of strings
                    splitData = lineOfText.Split();
                   
                    for (int i = 0; i < length; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            //gameBoard[i,j] = 
                        }
                    }


                }
                reader.Close();
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    } // End of class
}
