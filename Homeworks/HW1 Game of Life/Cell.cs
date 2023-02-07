﻿using System;
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
        private string alive = "o";
        private string dead = "x";

        // -------------------------------------
        // Properties   
        // -------------------------------------

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public string Alive
        {
            get { return alive; }
            set { alive = value; }
        }
        public string Dead
        {
            get { return dead; }
            set { dead = value; }
        }
        // -------------------------------------
        // Constructors
        // -------------------------------------

        public Cell (bool isAlive)
        {
            this.isAlive = isAlive;
        }

        // -------------------------------------
        // Methods
        // -------------------------------------

        /// <summary>
        /// Overrides the toString method, returning a 0 character 
        /// </summary>
        /// <returns> a string containing the 0 character </returns>
        public override string ToString()
        {
            if (isAlive)
            {
                return Alive;
            }
            else
            {
                return Dead;
            }
        }
    }
}
