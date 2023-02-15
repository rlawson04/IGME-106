using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace PE_MarioWalking
{

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        // The Mario to draw depending on the current state
        private Mario mario;
        private KeyboardState prevKBState;

        // Constructor
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            prevKBState = Keyboard.GetState();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Sets up the mario location
            Vector2 marioLoc = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);

            // Load the single spritesheet and create a new Mario object
            Texture2D spriteSheet = Content.Load<Texture2D>("Mario");

            mario = new Mario(spriteSheet, marioLoc, MarioState.FaceRight);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Handles animation for you
            mario.UpdateAnimation(gameTime);

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
            // PRACTICE EXERCISE: Add your finite state machine code (switch statement) here!
            // - Be sure to check the finite state machine's state first
            // - Then check for specific transitions inside each state (may require keyboard input)
            // - Update Mario's state as needed

           
            KeyboardState keyboardState = Keyboard.GetState();
            
            // Switch that hamdles the FSM changing Mario's states based on user input
            switch (mario.State)
            {
                // If he is facing left, he can transition to walking left, facing right, and crouching left
                case MarioState.FaceLeft:
                    if (keyboardState.IsKeyDown(Keys.Left) && prevKBState.IsKeyUp(Keys.Left))
                    {
                        mario.State = MarioState.WalkLeft;

                    }
                    if (keyboardState.IsKeyDown(Keys.Right))
                    {
                        mario.State = MarioState.FaceRight;
                       
                    }
                    if (keyboardState.IsKeyDown(Keys.Down) && prevKBState.IsKeyUp(Keys.Down))
                    {
                        mario.State = MarioState.CrouchLeft;
                    }
                    break;

                // If he is facing right, he can transition to walking right, facing left, and crouching right
                case MarioState.FaceRight:
                    if (keyboardState.IsKeyDown(Keys.Right) && prevKBState.IsKeyUp(Keys.Right))
                    {
                        mario.State = MarioState.WalkRight;
                        
                    }
                    if (keyboardState.IsKeyDown(Keys.Left))
                    {
                        mario.State = MarioState.FaceLeft;

                    }
                    if (keyboardState.IsKeyDown(Keys.Down) && prevKBState.IsKeyUp(Keys.Down))
                    {
                        mario.State = MarioState.CrouchRight;
                    }
                    break;

                // While the down key is being pressed he stays crouched and then transitions back to standing
                case MarioState.CrouchRight:
                    if (keyboardState.IsKeyDown(Keys.Down))
                    {
                        
                    }
                    else
                    {
                        mario.State = MarioState.FaceRight;
                    }
                    break;

                // While the down key is being pressed he stays crouched and then transitions back to standing
                case MarioState.CrouchLeft:
                    if (keyboardState.IsKeyDown(Keys.Down))
                    {

                    }
                    else
                    {
                        mario.State = MarioState.FaceLeft;
                    }
                    break;
                   
                // While walking he moves 3 pixels per frame and then if the key is no longer being pressed,
                // he transitions back to standing 
                case MarioState.WalkLeft:
                    if (keyboardState.IsKeyDown(Keys.Left))
                    { 
                        mario.X -= 3;
                    }
                    else
                    {
                        mario.State = MarioState.FaceLeft;
                    }
                    break;

                // While walking he moves 3 pixels per frame and then if the key is no longer being pressed,
                // he transitions back to standing
                case MarioState.WalkRight:
                    if (keyboardState.IsKeyDown(Keys.Right))
                    {
                        mario.X += 3;
                    }
                    else
                    {
                        mario.State = MarioState.FaceRight;
                    }
                    break;

                
            }
            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
           
            base.Update(gameTime);

            // Checks previous keyboard state so that they can't transition to walking from standing the other way
            prevKBState = keyboardState;
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Begin the sprite batch
            _spriteBatch.Begin();

            mario.Draw(_spriteBatch);

            // End the sprite batch
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
