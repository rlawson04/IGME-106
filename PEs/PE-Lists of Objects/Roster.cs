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
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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
    }
}
