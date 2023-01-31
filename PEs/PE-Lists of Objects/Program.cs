using System.Reflection.PortableExecutable;

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

            // Lists to split saved data from the txt file into
            List<string>studentNames = new List<string>();
            List<string>studentMajors = new List<string>();
            List<int> studentYears = new List<int>();
            
            // Make a string for the text file 
            string fileName = "AllStudents.txt";


            // Fill lists with students from the all students text file
            using (StreamReader reader = new StreamReader("../../../" + fileName))
            {
                string lineOfText = " ";

                // Reads the file until null is found
                while (lineOfText != null)
                {
                    lineOfText = reader.ReadLine();

                    if (lineOfText == null)
                    {
                        break;
                    }

                    // Split data into an array of strings
                    string[] splitData = lineOfText.Split('-');

                    // Adds all the student's names into the list  
                    for (int i = 0; i < splitData.Length; i += 3)
                    {
                        studentNames.Add(splitData[i]);
                    }

                    // Adds all the student's names into the list  
                    for (int j = 2; j < splitData.Length; j += 3)
                    {
                        studentMajors.Add(splitData[j]);
                    }

                    // Adds all the students years into the list 
                    for (int k = 1; k < splitData.Length; k += 3)
                    {
                        string studentYear = splitData[k].Remove(0, 5);
                        
                        studentYears.Add(int.Parse(studentYear));
                    }

                }
            }

            if (studentYears.Count > 0)
            {
                for (int l = 0; l < studentNames.Count; l++)
                {
                    Student txtStudent = new Student(studentNames.ElementAt(l),
                        studentMajors.ElementAt(l), studentYears.ElementAt(l));
                    if (txtStudent.Year == 1)
                    {
                        freshman.AddStudent(txtStudent);
                        allStudents.AddStudent(txtStudent);
                    }
                    else
                    {
                        allStudents.AddStudent(txtStudent);
                    }
                }
            }

            // Variable to keep track of the user's input 
            string userChoice = " ";

            Console.WriteLine();

            // Main loop of the program
            while (userChoice != "5")
            {
                // Prompt for user with options formatted to look like a menu
                Console.Write("Choose 1 of the following options:" +
                    "\n1 - Add a student " +
                    "\n2 - Change major for a student" +
                    "\n3 - Print the rosters" +
                    "\n4 - Save" +
                    "\n5 - Quit" +
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

                    case "4":
                        // Checks if allStudents has members
                        if (students.Count > 0)
                        {
                            // Prompts user if they want to overwrite data
                            Console.WriteLine("Would you like to overwrite the data?");
                            string userAnswer = Console.ReadLine().Trim().ToUpper();

                            // Overwrites the data
                            if (userAnswer == "YES")
                            {
                                // Save all the students to a txt file
                                StreamWriter writer = new StreamWriter("../../../" + fileName);

                                // Overwrites information with all the new names and damages
                                for (int j = 0; j < students.Count; j++)
                                {
                                    writer.WriteLine(students.ElementAt(j));
                                }
                                // When done with the file, close it
                                writer.Close();
                                Console.WriteLine("Roster saved!");
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            // Save all the students to a txt file
                            StreamWriter writer = new StreamWriter("../../../" + fileName);

                            // Overwrites information with all the new names and damages
                            for (int j = 0; j < students.Count; j++)
                            {
                                writer.WriteLine(students.ElementAt(j));
                            }
                            // When done with the file, close it
                            writer.Close();
                            Console.WriteLine("Roster saved!");
                        }
                        
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