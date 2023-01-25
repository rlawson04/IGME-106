namespace PE_Lists_of_Objects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student shiro = new Student("shiro", "GDD", 1);
            Console.WriteLine(shiro.ToString());

            List<Student> students = new List<Student>();

            Roster allStudents = new Roster("All Students", students);
            Roster freshman = new Roster("Freshmen", students);

            string userChoice = " ";

            while (userChoice != "4")
            {
                Console.Write("Choose 1 of the following options:" +
                    "\n1 - Add a student " +
                    "\n2 - Change major for a student" +
                    "\n3 - Print the rosters" +
                    "\n4 - Quit" +
                    "\n>");
                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    // Add a student
                    case "1":

                        break;

                    // Change major
                    case "2":

                        break;

                    // Print roster
                    case "3":

                        break;

                    // Quit
                    default:
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}