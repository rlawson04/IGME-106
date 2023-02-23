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

        public int LevelScore
        {
            get { return levelScore; }
        }

        public int TotalScore
        {
            get { return totalScore; }
        }
        // -----------------------------------
        // Constructors
        // -----------------------------------

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

        public override void Update(GameTime gameTime)
        {
            KeyboardState kbState = Keyboard.GetState();

            // Movement of the player
            if (kbState.IsKeyDown(Keys.Up))
            {
                rectangle.Y++;
            }

            if (kbState.IsKeyDown(Keys.Down))
            { 
                rectangle.Y--;
            }

            if (kbState.IsKeyDown(Keys.Left))
            {
                rectangle.X--;
            }

            if (kbState.IsKeyDown(Keys.Right))
            {
                rectangle.X++;
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

        public void Center()
        {
            rectangle.X = windowWidth/2 + 50;
            rectangle.Y = windowHeight/2 + 50;
            
        }
    }
}
