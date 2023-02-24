using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HW_2_MonoGame
{
    internal class Player : GameObject
    {
        // -----------------------------------
        // Fields
        // -----------------------------------

        protected int levelScore;
        protected int totalScore;
        protected int windowWidth;
        protected int windowHeight;

        // -----------------------------------
        // Properties
        // -----------------------------------

        /// <summary>
        /// Get and set method to keep track of the players level score
        /// </summary>
        public int LevelScore
        {
            get { return levelScore; }
            set { levelScore = value; }
        }

        /// <summary>
        /// Get and set method to keep track of the players total score
        /// </summary>
        public int TotalScore
        {
            get { return totalScore; }
            set { totalScore = value; }
        }
        // -----------------------------------
        // Constructors
        // -----------------------------------

        /// <summary>
        /// parameterized constructor that leverages the base class
        /// </summary>
        /// <param name="texture"> 2D texture from content folder </param>
        /// <param name="rectangle"> takes in a rectangle </param>
        /// <param name="levelScore"> takes in the players initial level score </param>
        /// <param name="totalScore"> takes in the players initial total score</param>
        /// <param name="windowWidth"> takes in the width of the window to check colision </param>
        /// <param name="windowHeight"> take in the height of the window to check colision</param>
        public Player(Texture2D texture, Rectangle rectangle, int levelScore,
            int totalScore, int windowWidth, int windowHeight) 
            : base(texture, rectangle)
        {
            this.levelScore = levelScore;
            this.totalScore = totalScore;
            this.windowWidth = windowWidth; 
            this.windowHeight = windowHeight;
        }

        // -----------------------------------
        // Methods
        // -----------------------------------

        /// <summary>
        /// Updates the player in real time, handling movement and screen wrapping
        /// </summary>
        /// <param name="gameTime"> takes in the game time to update </param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState kbState = Keyboard.GetState();

            // Movement of the player
            if (kbState.IsKeyDown(Keys.Up))
            {
                rectangle.Y-=5;
            }

            if (kbState.IsKeyDown(Keys.Down))
            { 
                rectangle.Y+=5;
            }

            if (kbState.IsKeyDown(Keys.Left))
            {
                rectangle.X-=5;
            }

            if (kbState.IsKeyDown(Keys.Right))
            {
                rectangle.X+=5;
            }

            // Making the player wrap around the window
            if (rectangle.Y < 0)
            {
                rectangle.Y = windowHeight;
            }

            if (rectangle.X < 0)
            {
                rectangle.X = windowWidth;
            }

            if (rectangle.Y > windowHeight)
            {
                rectangle.Y = 0;
            }

            if (rectangle.X > windowWidth)
            {
                rectangle.X = 0;
            }
        }

        /// <summary>
        /// Moves the player back to the center of the screen
        /// </summary>
        public void Center()
        {
            rectangle.X = windowWidth/2 + 50;
            rectangle.Y = windowHeight/2 + 50;
            
        }
    }
}
