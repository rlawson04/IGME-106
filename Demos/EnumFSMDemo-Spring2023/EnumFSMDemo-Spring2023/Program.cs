namespace EnumFSMDemo_Spring2023
{
    // enumeration is useable by all classes in the namespace if we define it here
    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    };
    internal class Program
    {
        static void Main(string[] args)
        {
            // define the direction a character is looking
            Direction look = Direction.Left;

            // loop to get user input
            while(true)
            {
                // get a direction from the user
                Console.Write("W,A,S,D or Q to quit: ");
                string dir = Console.ReadLine().ToUpper();

                // set the look direction
                switch(dir)
                {
                    case "W": look = Direction.Up;
                        break;
                    case "A":
                        look = Direction.Left;
                        break;
                    case "S":
                        look = Direction.Down;
                        break;
                    case "D":
                        look = Direction.Right;
                        break;
                    case "Q":
                        Environment.Exit(0); // exit program on quit
                        break;
                    default:
                        Console.WriteLine("Invalid entry, use W,A,S,D or Q");
                        break;
                }

                // use conditions to check the look state
                if(look == Direction.Up)
                {
                    Console.WriteLine("You are looking up.");
                }

                // could use enumeration values with a switch
                switch(look)
                {
                    case Direction.Up: Console.WriteLine("up"); break;
                    case Direction.Down: Console.WriteLine("down"); break;
                    case Direction.Left: Console.WriteLine("left"); break;
                    case Direction.Right: Console.WriteLine("right"); break;
                }

                // output the name and the number
                Console.WriteLine(look);
                Console.WriteLine((int)look);
            }
        }
    }
}