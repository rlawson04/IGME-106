using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBL_OORefactoring
{
    /// <summary>
    /// Base class that will take in a string and int
    /// to store information about a player
    /// </summary>
    internal class Player
    {
        //-------------------------------------
        // Fields
        //-------------------------------------

        private int score;
        private string name;


        //-------------------------------------
        // Properties
        //-------------------------------------

        /// <summary>
        /// Get only property to return the score of the player
        /// </summary>
        public int Score
        {
            get { return score; }
        }

        /// <summary>
        /// Get only property to return the name of the player
        /// </summary>
        public string Name
        {
            get { return name; }
        }


        //-------------------------------------
        // Constructors
        //-------------------------------------

        /// <summary>
        /// Parameterized constructor that takes name and score
        /// </summary>
        /// <param name="name"> takes in a string </param>
        /// <param name="score"> takes in an int </param>
        public Player(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        //-------------------------------------
        // Methods
        //-------------------------------------
    }
}
