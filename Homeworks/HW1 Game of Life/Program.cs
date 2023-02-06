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
                    case "1":
                        game1.GenerateBoard();
                        break;

                    case "2":
                        game1.DisplayBoard();
                        break;

                    case "3":
                        Console.WriteLine("Will implement load in activity 2.");
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}