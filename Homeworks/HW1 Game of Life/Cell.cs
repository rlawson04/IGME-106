using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_Game_of_Life
{
    internal class Cell
    {
        // -------------------------------------
        // Fields
        // -------------------------------------

        private bool isAlive = false;
        private string alive = "@";
        private string dead = "-";

        // -------------------------------------
        // Properties   
        // -------------------------------------

        /// <summary>
        /// Get - set property to determine if the cell is alive or not
        /// </summary>
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        /// <summary>
        /// Get - set property to determine if the cell is alive 
        /// </summary>
        public string Alive
        {
            get { return alive; }
            set { alive = value; }
        }

        /// <summary>
        /// Get - set property to determine if the cell is dead
        /// </summary>
        public string Dead
        {
            get { return dead; }
            set { dead = value; }
        }
        // -------------------------------------
        // Constructors
        // -------------------------------------

        /// <summary>
        /// Basic constructor for the cell class to have a dead or alive value
        /// </summary>
        /// <param name="isAlive"> a bool to determine if the cell is alive </param>
        public Cell (bool isAlive)
        {
            this.isAlive = isAlive;
        }

        // -------------------------------------
        // Methods
        // -------------------------------------

        /// <summary>
        /// Overrides the toString method, returning a @ or - character 
        /// </summary>
        /// <returns> a string containing the @ or - character </returns>
        public override string ToString()
        {
            if (isAlive)
            {
                return alive;
            }
            else
            {
                return dead;
            }
        }
    }
}
