namespace PE_Graphs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variables for the program
            Graph graph = new Graph();
            bool escaped = false;
            string currentRoom = "DRAWING ROOM";
            string userInput = " ";

            while (!escaped)
            {
                // string to print adjacent rooms
                string adjacentRooms = " ";

                // Main message
                Console.WriteLine($"You are currently in {currentRoom}");
                
                // Creates adjacent room string to print
                foreach(string s in graph.GetAdjacentList(currentRoom))
                {
                    adjacentRooms += s + ", ";
                }

                // Rest of main message
                Console.WriteLine($"Nearby are: {adjacentRooms}");
                Console.WriteLine("Where would you like to go?");

                // Takes and sanitizes user input
                userInput = Console.ReadLine().ToUpper();
                Console.WriteLine();

                // Make sure the input room is connected to the current room
                if (graph.IsConnected(currentRoom, userInput))
                {
                    currentRoom = userInput;
                }
                else while (!graph.IsConnected(currentRoom, userInput))
                {
                    Console.WriteLine("Sorry, that is not an adjacent room");
                    Console.WriteLine("Where would you like to go?");

                    userInput = Console.ReadLine().ToUpper();
                    Console.WriteLine();

                        if (graph.IsConnected(currentRoom, userInput))
                        {
                            currentRoom = userInput;
                            break;
                        }
                }

                // When the user navigates to the exit, end the loop
                if (currentRoom == "EXIT")
                {
                    escaped = true;
                    break;
                }
            }

            // print exit message
            Console.WriteLine("You have escaped!");
        }
    }
}