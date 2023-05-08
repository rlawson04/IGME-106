namespace Exam_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = " ";
            Console.WriteLine("Path to the data file?");
            userInput = Console.ReadLine();

            // Test that the user input the file path correctly
            try
            {
                Graph dataGraph = new Graph(userInput);

                Console.Write("\nEnter the starting vertex: ");
                userInput = Console.ReadLine().ToUpper();

                while (dataGraph.Guard(userInput) == false)
                {
                    Console.Write("\nEnter the starting vertex: ");
                    userInput = Console.ReadLine().ToUpper();
                }

                Console.WriteLine("\n\nList of all vertices visited: ");
                Console.WriteLine();

                foreach (string s in dataGraph.Visisted)
                {
                    Console.WriteLine("The guard visited " + s);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            
        }
    }
}