namespace HW1_Game_of_Life
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Game of Life!");

            string userInput = " ";

            // initialize game class
            Game game1 = new Game();

            // While loop for the menu
            while (userInput != "4")
            {
                Console.WriteLine();

                // Initial statement for the menu
                Console.Write("Options: " +
                    "\n1 - Generate a random board" +
                    "\n2 - Display board" +
                    "\n3 - Load initial board from file" +
                    "\n4 - Quit" +
                    "\n\nYour choice: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    // Generate a random board
                    case "1":
                        game1.GenerateBoard();
                        break;

                    // Display currently loaded board
                    case "2":
                        game1.DisplayBoard();
                        string subChoice = " ";

                        while (subChoice != "3")
                        {
                            Console.Write("1-Advance\n" +
                            "2-save current board\n" +
                            "3-main menu?\n\n" +
                            "Your choice: ");
                            subChoice = Console.ReadLine();

                            // Sub menu switch statement
                            switch (subChoice)
                            {
                                // Uses the advance method to generate a new board
                                case "1":
                                    game1.Advance();
                                    Console.WriteLine("Advancement complete\n");
                                    game1.DisplayBoard();
                                    break;

                                // Save the current board to a file
                                case "2":
                                    Console.Write("Filename? ");
                                    game1.SaveGame(Console.ReadLine());
                                    break;

                                default:
                                    break;
                            }
                            Console.WriteLine();
                        }
                        break;
                    
                    // Load board from a file
                    case "3":
                        Console.Write("Filename? "); 
                        game1.LoadBoard(Console.ReadLine());
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine("Goodbye!");

        }// End of main
    }
}