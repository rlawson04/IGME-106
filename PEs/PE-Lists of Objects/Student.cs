using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Lists_of_Objects
{
    internal class Student
    {
        //-----------------------------
        // Fields
        //-----------------------------

        private string name;
        private string major;
        private int year;

        //-----------------------------
        // Properties 
        //-----------------------------

        /// <summary>
        /// Get only property that gives the student's name
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Get only property that gives the student's major
        /// </summary>
        public string Major
        {
            get { return major; }
        }

        /// <summary>
        /// Get only property that gives the student's year
        /// </summary>
        public int Year
        {
            get { return year; }
        }

        //-----------------------------
        // Constructors
        //-----------------------------

        /// <summary>
        /// Parameterized constructor that takes the students name, major, and year
        /// </summary>
        /// <param name="name"> takes in a string </param>
        /// <param name="major"> takes in a string </param>
        /// <param name="year"> takes in an int </param>
        public Student(string name, string major, int year)
        {
            this.name = name;
            this.major = major;
            this.year = year;
        }

        //-----------------------------
        // Methods
        //-----------------------------

        public override string ToString()
        {
            return $"{name} - Year {year} - {major}";
        }
    }
}
