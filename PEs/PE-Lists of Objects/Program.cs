namespace PE_Lists_of_Objects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create lists of students for the rosters
            List<Student> students = new List<Student>();
            List<Student> students2 = new List<Student>();
            Roster allStudents = new Roster("All Students", students);
            Roster freshman = new Roster("Freshmen", students2);

            // Variable to keep track of the user's input 
            string userChoice = " ";

            // Main loop of the program
            while (userChoice != "4")
            {
                // Prompt for user with options formatted to look like a menu
                Console.Write("Choose 1 of the following options:" +
                    "\n1 - Add a student " +
                    "\n2 - Change major for a student" +
                    "\n3 - Print the rosters" +
                    "\n4 - Quit" +
                    "\n> ");
                userChoice = Console.ReadLine();
                Console.WriteLine();

                switch (userChoice)
                {
                    // Add a student, if they are a freshman add them to that list too
                    case "1":

                        // Create instance of new student to check their year
                        Student newStudent = allStudents.AddStudent();

                        // Checks if the student is a freshman
                        if (newStudent.Year == 1)
                        {
                            freshman.AddStudent(newStudent);
                        }
                        
                        break;

                    // Change major
                    case "2":

                        // Prompts user to search the lists for the student
                        Console.Write("Whose major would you like to change? ");
                        string userSearch = Console.ReadLine();

                        // Creates instance of the student to change their major
                        Student searchedStudent = allStudents.SearchByName(userSearch);

                        if (students.Contains(searchedStudent))
                        {
                            Console.WriteLine("Student found: " + searchedStudent.ToString());
                            Console.Write("What would you like to change it to? ");
                            string userMajor = Console.ReadLine();
                            searchedStudent.Major = userMajor;
                        }
                        else
                        {
                            Console.WriteLine(userSearch + " not found.");
                        }
                        break;

                    // Print roster
                    case "3":
                        // Prints both the all students and freshmen rosters
                        allStudents.DisplayRoster();
                        Console.WriteLine();
                        freshman.DisplayRoster();
                        break;

                    // Quit
                    default:
                        break;
                }
                Console.WriteLine();
            }

            Console.WriteLine("Goodbye!");
        }
    }
}