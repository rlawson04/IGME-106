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
            gameBoard = new string[10,20];

            // Fill 2D array with Cell object
            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 20; j++)
                {
                    gameBoard[i,j] = new Cell().ToString();
                }
            }

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
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        Console.Write(gameBoard[i, j].ToString());
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
