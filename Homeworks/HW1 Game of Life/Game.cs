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

        // -------------------------------------
        // Properties   
        // -------------------------------------


        // -------------------------------------
        // Constructors
        // -------------------------------------


        // -------------------------------------
        // Methods
        // -------------------------------------

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


        public void DisplayBoard()
        {
            if (gameBoard.Length == 0)
            {
                Console.WriteLine("No gameboard loaded");
            }
            else if (gameBoard.Length >= 1)
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
        }
    }
}
