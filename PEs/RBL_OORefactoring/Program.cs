namespace RBL_OORefactoring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Keep track of a name and score of a bunch of players
            string p1Name = "tbd";
            string p2Name = "tbd";
            string p3Name = "tbd";
            string p4Name = "tbd";
            string p5Name = "tbd";
            int p1Score = 0;
            int p2Score = 0;
            int p3Score = 0;
            int p4Score = 0;
            int p5Score = 0;
            // Find out how many players the user actually wants
            Console.Write("Enter number of players (up to 5): ");
            string numPlayersString = Console.ReadLine();
            int numPlayers = int.Parse(numPlayersString);
            // Get the names
            Console.WriteLine();
            for (int i = 0; i < numPlayers; i++)
            {
                Console.Write("Enter player {0}'s name: ", i);
                string name = Console.ReadLine().Trim().ToUpper();
                switch (i)
                {
                    case 0:
                        p1Name = name;
                        break;
                    case 1:
                        p2Name = name;
                        break;
                    case 2:
                        p3Name = name;
                        break;
                    case 3:
                        p4Name = name;
                        break;
                    case 4:
                        p5Name = name;
                        break;
                    default:
                        Console.WriteLine("Uh oh...");
                        break;
                }
            }
            // Randomly set the scores of the players
            for (int i = 0; i < numPlayers; i++)
            {
                Random rng = new Random();
            switch (i)
                {
                    case 0:
                        p1Score = rng.Next(101);
                        break;
                    case 1:
                        p2Score = rng.Next(101);
                        break;
                    case 2:
                        p3Score = rng.Next(101);
                        break;
                    case 3:
                        p4Score = rng.Next(101);
                        break;
                    case 4:
                        p5Score = rng.Next(101);
                        break;
                    default:
                        Console.WriteLine("Uh oh...");
                        break;
                }
            }
            // Print the player info
            Console.WriteLine();
            Console.WriteLine("Player 1, {0}, has a score of {1}",
            p1Name, p1Score);
            Console.WriteLine("Player 2, {0}, has a score of {1}",
            p2Name, p2Score);
            Console.WriteLine("Player 3, {0}, has a score of {1}",
            p3Name, p3Score);
            Console.WriteLine("Player 4, {0}, has a score of {1}",
            p4Name, p4Score);
            Console.WriteLine("Player 5, {0}, has a score of {1}",
            p5Name, p5Score);
            // Print the winner
            string winnerName = "no one";
            if (numPlayers > 0)
            {
                winnerName = p1Name;
            }
            if (numPlayers > 1)
            {
                if (p2Score > p1Score)
                {
                    winnerName = p2Name;
                }
            }
            if (numPlayers > 2)
            {
                if (p3Score > p1Score && p3Score > p2Score)
            {
                    winnerName = p3Name;
                }
            }
            if (numPlayers > 3)
            {
                if (p4Score > p1Score && p4Score > p2Score && p4Score > p3Score)
                {
                    winnerName = p4Name;
                }
            }
            if (numPlayers > 4)
            {
                if (p5Score > p1Score && p5Score > p2Score && p5Score > p3Score && p5Score > p4Score)
                {
                    winnerName = p5Name;
                }
            }
            if (numPlayers > 5)
            {
                Console.WriteLine("Uh oh...");
            }
            Console.WriteLine("The winner is {0}!", winnerName);
        }
    }
}