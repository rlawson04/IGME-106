using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Lists_of_Objects
{
    internal class Roster
    {
        //-----------------------------
        // Fields
        //-----------------------------

        private string name;
        private List<Student> students = new List <Student>();

        //-----------------------------
        // Properties 
        //-----------------------------

        /// <summary>
        /// Get only property that gives the roster's name
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Get only property that gives the list of students
        /// </summary>
        public List<Student> Students
        {
            get { return students; }
        }
        
        //-----------------------------
        // Constructors
        //-----------------------------

        /// <summary>
        /// Parameterized constructor that takes the roster's name and list of students
        /// </summary>
        /// <param name="name"> takes in a string </param>
        /// <param name="students"> takes in a list of objects of the student class </param>
        public Roster(string name, List<Student> students)
        {
            this.name = name;
            this.students = students;
        }

        //-----------------------------
        // Methods
        //-----------------------------

        /// <summary>
        /// Searches the list of students given their name
        /// </summary>
        /// <param name="name"> takes in the name of a student object </param>
        /// <returns> a student with the matching name from the list or null </returns>
        public Student SearchByName(string name)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (name == students[i].Name)
                        
                {
                    return students[i];
                }
            }
            return null;
        }
        
        /// <summary>
        /// Adds the student to the list of students if it is not already in it
        /// </summary>
        /// <param name="s"> takes a student object </param>
        public void AddStudent(Student s)
        {
            if (!students.Contains(s))
            { 
                students.Add(s);
                Console.WriteLine($"Added {s} to the {name} roster.");
            }
        }

        
        public Student AddStudent()
        {
            Console.Write("What is the student's name? ");
            string newName = Console.ReadLine();

            Console.Write("What is the student's major? ");
            string newMajor = Console.ReadLine();

            Console.Write("What is the student's year? ");
            int newYear = int.Parse(Console.ReadLine());

            Student newS = new Student(newName, newMajor, newYear);

            if (!students.Contains(newS))
            {
                students.Add(newS);
                Console.WriteLine($"{newName} was added to the {name} roster.");
            }
            else
            {
                Console.WriteLine($"{newName} is already in the {name} roster.");   
            }

            return newS;
        }

        /// <summary>
        /// Prints out all students on the roster along with their information
        /// </summary>
        public void DisplayRoster()
        {
            Console.WriteLine($"{name} has {students.Count()} students:");

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i].ToString());
            }
        }
    }
}
