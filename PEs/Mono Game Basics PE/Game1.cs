using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace Mono_Game_Basics_PE
{
    enum GameStates
    {
        MainMenu,
        Bounce,
        UserControl
    }
    public class Game1 : Game
    {
        private GameStates currentState = GameStates.MainMenu;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;
        private Vector2 _position;
        private Rectangle _bounds;
        private bool _hitTest = false;
        private int _movementSpeed = 1;
        private SpriteFont labelFont;
        private SpriteFont bounceFont;
        private int bounces = 0;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Makes mouse visible
            IsMouseVisible = true;

            // Sets screen size
            _graphics.PreferredBackBufferWidth = 600;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

        }

        protected override void Initialize()
        {
            // Sets initial position of the images
            _position = Vector2.Zero;
            base.Initialize();
            _bounds = new Rectangle((_graphics.PreferredBackBufferWidth/2 - _texture.Width/4),
                _graphics.PreferredBackBufferHeight/2 - _texture.Height/4 ,
                _texture.Width/2, _texture.Height/2);
        }

        protected override void LoadContent()
        {
            // Loads the content from the folder
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _texture = this.Content.Load<Texture2D>("Crab");
            labelFont = Content.Load<SpriteFont>("labelFont");
            bounceFont = Content.Load<SpriteFont>("bounceFont");
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Get current device states
            KeyboardState kbState = Keyboard.GetState();
            MouseState mState = Mouse.GetState();

            // Changes the current state by calling the methods created below
            switch(currentState)
            {
                case GameStates.MainMenu:
                    ProcessMainMenu(kbState);
                    break;
                case GameStates.Bounce:
                    ProcessBounceMode(kbState, mState);
                    break;
                case GameStates.UserControl:
                    ProcessUserMode(kbState, mState);
                    break;
                default:
                    break;
            
            }

            
            // Moves the image diagonally until it "hits" the edge of the screen
            if (_hitTest == false)
            {
                _position.X++;
                _position.Y++;
                if (_position.X >= _texture.Width)
                {
                    _hitTest = true;
                    bounces++;
                }
            }

            // Moves the image diagonally until it "hits" the edge of the screen
            if (_hitTest == true)
            {
                _position.X--;
                _position.Y--;
                if (_position.X <= 0)
                {
                    _hitTest = false;
                    bounces++;
                }
            }
            
            ProcessInput();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Changes the background color
            GraphicsDevice.Clear(Color.DarkGoldenrod);

            // Starts drawing
            _spriteBatch.Begin();

            switch (currentState)
            {
                case GameStates.MainMenu:
                    _spriteBatch.DrawString(bounceFont,
                        "Welcome to Reilly's MonoGame demo\n" +
                        "Press B to see some bouncing.\n" +
                        "Press U to control the image yourself.",
                        new Vector2(10, 500), Color.Black);
                    break;

                case GameStates.Bounce:
                    _spriteBatch.Draw(_texture, _position, Color.White);

                    // Creates text keeping track of the number of bounces
                    _spriteBatch.DrawString(bounceFont,
                        $"{bounces}",
                        new Vector2(_bounds.X, _bounds.Y), Color.Black);

                    _spriteBatch.DrawString(bounceFont,
                        "Press M to go back to the main menu.\n" +
                        "Click the right mouse button to reset.",
                        new Vector2(10,500), Color.Black);
                    break;

                case GameStates.UserControl:
                    _spriteBatch.Draw(_texture, _bounds, Color.PowderBlue);

                    // Creates text describing the location and speed
                    _spriteBatch.DrawString(labelFont,
                        $"Speed: {_movementSpeed} Position :({_bounds.X},{_bounds.Y})",
                        new Vector2(30, 30), Color.Black);

                    _spriteBatch.DrawString(bounceFont,
                        "Press M to go back to the main menu.\n" +
                        "Click the right mouse button to reset.",
                        new Vector2(10, 500), Color.Black);
                    break;
            }
            
            // Stops drawing
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Processes keyboard and mouse inputs which affect the images and text
        /// </summary>
        private void ProcessInput()
        {
            // Two states for the keyboard and mouse
            KeyboardState state = Keyboard.GetState();
            MouseState mstate = Mouse.GetState();
               
            // Changes movement speed when the space bar is held down
            if (state.IsKeyDown(Keys.Space))
            {
                _movementSpeed++;
            }

            // Moves the center image based on each of the four inputs
            if (state.IsKeyDown(Keys.W) == true)
            {
                _bounds.Y -= _movementSpeed;
            }
            if (state.IsKeyDown(Keys.A) == true)
            {
                _bounds.X -= _movementSpeed;
            }
            if (state.IsKeyDown(Keys.S) == true)
            {
                _bounds.Y += _movementSpeed;
            }
            if (state.IsKeyDown(Keys.D) == true)
            {
                _bounds.X += _movementSpeed;
            }

            
            
        }

        /// <summary>
        /// Checks if "U" or "B" is being pressed and then changes the game state
        /// </summary>
        /// <param name="kbState"></param>
        private void ProcessMainMenu(KeyboardState kbState)
        {
            if (kbState.IsKeyDown (Keys.B))
            {
                currentState = GameStates.Bounce;
            }
            else if (kbState.IsKeyDown (Keys.U))
            {
                currentState = GameStates.UserControl;
            }
        }

        /// <summary>
        /// Checks if "M" is being pressed and then changes the game state
        /// </summary>
        /// <param name="kbState"> the current keyboard state </param>
        /// <param name="mState"> the current mouse state </param>
        private void ProcessBounceMode(KeyboardState kbState, MouseState mState)
        {
            if (kbState.IsKeyDown(Keys.M))
            {
                currentState = GameStates.MainMenu;
            }

            // Resets image locations, and text when the mouse right button is pressed
            if (mState.RightButton == ButtonState.Pressed)
            {
                bounces = 0;
                _movementSpeed = 1;
                _position.X = 0;
                _position.Y = 0;
                _bounds.X = _graphics.PreferredBackBufferWidth / 2 - _texture.Width / 4;
                _bounds.Y = _graphics.PreferredBackBufferHeight / 2 - _texture.Height / 4;
            }
        }

        /// <summary>
        /// Checks if "M" is being pressed and then changes the game state
        /// </summary>
        /// <param name="kbState"> the current keyboard state </param>
        /// <param name="mState"> the current mouse state </param>
        private void ProcessUserMode(KeyboardState kbState, MouseState mState)
        {
            if (kbState.IsKeyDown(Keys.M))
            {
                currentState = GameStates.MainMenu;
            }

            // Resets image locations, and text when the mouse right button is pressed
            if (mState.RightButton == ButtonState.Pressed)
            {
                bounces = 0;
                _movementSpeed = 1;
                _position.X = 0;
                _position.Y = 0;
                _bounds.X = _graphics.PreferredBackBufferWidth / 2 - _texture.Width / 4;
                _bounds.Y = _graphics.PreferredBackBufferHeight / 2 - _texture.Height / 4;
            }
        }
    }
}