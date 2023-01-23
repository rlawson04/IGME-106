using System.Security.Cryptography.X509Certificates;

namespace RBL_OORefactoring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create instance of random variable to use throughout
            Random rng = new Random();
            
            // Find out how many players the user actually wants
            Console.Write("Enter number of players (up to 10): ");
            
            // TryParse until acceptable integer answer between 1-10
            int number;
            bool sucess = int.TryParse(Console.ReadLine(), out number);
            while (!sucess || number < 1 || number > 10)
            {
                Console.Write("Enter number of players (up to 10): ");
                sucess = int.TryParse(Console.ReadLine(), out number);
            }
            Console.WriteLine();

            // Variable to keep track of the number of players for iteration through array
            int numPlayers = number;

            // Create array to add player objects to
            Player[] players = new Player[numPlayers];

            // Get the names of all the players
            for (int i = 0; i < numPlayers; i++)
            {
                Console.Write($"Enter player {i+1}'s name: ");
                string name = Console.ReadLine().Trim().ToUpper();

                // Take the given name and create player instance
                Player player = new Player(name, rng.Next(101));

                // Add player to array
                players[i] = player;
            }
            Console.WriteLine();
            
            // Prints each player with their score
            for (int i = 0; i < numPlayers; i++)
            {
                Console.WriteLine($"Player {players[i].Name}," +
                    $" has a score of {players[i].Score}");
            }
            Console.WriteLine();

            // Variable to find out the winner
            string hiScore = players[0].Name;

            // Checks players score against the one below it
            for (int i = 0; i < numPlayers -1; i++)
            {
                if(players[i+1].Score > players[i].Score)
                {
                    hiScore = players[i+1].Name;
                }
            }

            // Print winner
            Console.WriteLine("The winner is {0}!", hiScore);
        }
    }
}