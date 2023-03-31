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

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            string test1 = "tacocat";
            string test2 = "cat";
            string test3 = "pp";
            System.Diagnostics.Debug.WriteLine(test1 + IsPalindrome(test1, 0, test1.Length - 1));
            System.Diagnostics.Debug.WriteLine(test2 + IsPalindrome(test2, 0, test2.Length - 1));
            System.Diagnostics.Debug.WriteLine(test3 + IsPalindrome(test3, 0, test3.Length - 1));
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private bool IsPalindrome(string phrase, int startIndex, int endIndex)
        {
            if (phrase[startIndex] != phrase[endIndex])
            {
                return false;
            }
            else if (startIndex >= endIndex)
            {
                return true;
            }
            else if (phrase[startIndex] == phrase[endIndex])
            {
               return IsPalindrome(phrase, startIndex +1, endIndex -1);
            }
            else
            {
                return true;
            }
            
        }
    }


}