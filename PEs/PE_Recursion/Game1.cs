using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;

namespace PE_Recursion
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        bool showTree = true;
        MouseState mState;
        MouseState prevMState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            //------------------------------------------
            // Testing for the isPalindrome recursive method
            string test1 = "tacocat";
            string test2 = "cat";
            string test3 = "piplup";
            
            System.Diagnostics.Debug.WriteLine(test1 + IsPalindrome(test1, 0, test1.Length - 1));
            System.Diagnostics.Debug.WriteLine(test2 + IsPalindrome(test2, 0, test2.Length - 1));
            System.Diagnostics.Debug.WriteLine(test3 + IsPalindrome(test3, 0, test3.Length - 1));
            //--------------------------------------------------

            // Changing graphics window
            _graphics.PreferredBackBufferWidth = 600;  
            _graphics.PreferredBackBufferHeight = 600; 
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            mState = Mouse.GetState();
            // TODO: Add your drawing code here

            // Starts ShapeBatch
            ShapeBatch.Begin(GraphicsDevice);

            // Checks one press of the mouse, and the current value for show tree. Then flips the value to show the other fractal
            if (showTree == true && mState.LeftButton == ButtonState.Pressed && prevMState.LeftButton == ButtonState.Released)
            {
                showTree = false;
            }
            else if (showTree == false && mState.LeftButton == ButtonState.Pressed && prevMState.LeftButton == ButtonState.Released)
            { 
                showTree = true;
            }

            // Shows the fractal pattern when tree is not showing
            if (!showTree)
            {
                RecursiveFractal(new Vector2(300, 30), 30, 3, 1.5708f); 
            }

            // Shows the tree when the fractal pattern is not showing, and to beigin with
            if (showTree)
            {
                RecursiveTree(new Vector2 (300,570), 100, 1.5708f);
            }

            
            prevMState = mState;

            // Ends ShapeBatch
            ShapeBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Recursive method to check if the input string is a palindrome
        /// </summary>
        /// <param name="phrase"> the string in question </param>
        /// <param name="startIndex"> the first index of the string </param>
        /// <param name="endIndex"> the last index of the string </param>
        /// <returns></returns>
        private bool IsPalindrome(string phrase, int startIndex, int endIndex)
        {
            // If the first and last letter are different, then it isn't a palindrome
            if (phrase[startIndex] != phrase[endIndex])
            {
                return false;
            }
            // If the first index is the same or greater than the last, it must be a palindrome
            else if (startIndex >= endIndex)
            {
                return true;
            }
            // Uses recursion to run through the method with the next indexes
            else if (phrase[startIndex] == phrase[endIndex])
            {
               return IsPalindrome(phrase, startIndex +1, endIndex -1);
            }
            // Make sure all code paths return a value
            else
            {
                return true;
            }
            
        }

        /// <summary>
        /// Creates a tree structure using branching lines
        /// </summary>
        /// <param name="position"> initial position of the start of the line </param>
        /// <param name="length"> total length of the line </param>
        /// <param name="angle"> angle for the line to be drawn at </param>
        private void RecursiveTree(Vector2 position, float length, float angle)
        {
            ShapeBatch.Line(position, length, angle, Color.White);
            
            // Checks if the length of the line is less than 10 units
            if (length < 10)
            {
                return;
            }
            else
            {
                // Creates branches
                RecursiveTree(ShapeBatch.Line(position, length, angle, Color.White), 0.8f * length, angle + 0.785398f);
                RecursiveTree(ShapeBatch.Line(position, length, angle, Color.White), 0.8f * length, angle - 0.785398f);
            }
           
        }

        /// <summary>
        /// Creates a pattern of increasing edged shapes in a uniform triangular array
        /// </summary>
        /// <param name="position"> inital position of the center of the shape </param>
        /// <param name="radius"> size of the shape </param>
        /// <param name="segments"> how many lines the shape is comprised of </param>
        /// <param name="rotation"> at what angle the shape is drawn </param>
        private void RecursiveFractal(Vector2 position, float radius, int segments, float rotation)
        {
            // Uses ShapeBatch.Circle to create the different shapes
            ShapeBatch.Circle(position, radius, segments, rotation, Color.Red);
            
            // When the shapes drawn have more than 13 sides the pattern stops
            if (segments > 13)
            {
                return;
            }
            else
            {
                // Draws shapes with increasing number of sides rotated 45 degrees and shrank by a factor of 0.9
                RecursiveFractal(position + new Vector2 (40, 50), radius * .9f, segments + 1, rotation + 0.785398f);
                RecursiveFractal(position + new Vector2(-40, 50), radius * .9f, segments + 1, rotation - 0.785398f);
                
            }
        }
    }


}