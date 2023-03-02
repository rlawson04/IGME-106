using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace PE_MG_Buttons
{
    public class Game1 : Game
    {
        // Fields created by the MG template
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // The list of buttons and setup for random bg color
        private SpriteFont font;
        private List<Button> buttons = new List<Button>();
        private Color bgColor = Color.White;
        private Random rng = new Random();

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // TODO: ADD Your new fields here!
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private int numberOfLeftClicks;
        private Texture2D raindrop;
        private List<Raindrop> raindrops = new List<Raindrop>();
        private int numberOfRightClicks;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("buttonFont");

            raindrop = Content.Load<Texture2D>("Rain drop");

            // Create a few 100x200 buttons down the left side
            buttons.Add(new Button(
                    _graphics.GraphicsDevice,
                    new Rectangle(10, 40, 200, 100),
                    "Random BG",
                    font,
                    Color.Purple));
            buttons[0].OnButtonLeftClick += this.RandomizeBackground;
            buttons[0].OnButtonRightClick += this.RandomizeBackground;
            buttons[0].OnButtonLeftClick += this.LeftButtonClicked;
            buttons[0].OnButtonRightClick += this.RightButtonClicked;

            buttons.Add(new Button(
                    _graphics.GraphicsDevice,
                    new Rectangle(10, 150, 200, 100),
                    "Snow",
                    font,
                    Color.Green));
            buttons[1].OnButtonLeftClick += this.SnowButton;
            buttons[1].OnButtonRightClick += this.SnowButton;
            buttons[1].OnButtonLeftClick += this.LeftButtonClicked;
            buttons[1].OnButtonRightClick += this.RightButtonClicked;

            buttons.Add(new Button(
                    _graphics.GraphicsDevice,
                    new Rectangle(10, 260, 200, 100),
                    "Rain",
                    font,
                    Color.Red));
            buttons[2].OnButtonLeftClick += this.RainButton;
            buttons[2].OnButtonRightClick += this.RainButton;
            buttons[2].OnButtonLeftClick += this.LeftButtonClicked;
            buttons[2].OnButtonRightClick += this.RightButtonClicked;
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Add your additional button setup code here!
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        // There is no need to add anything to Game1's Update method!
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Button b in buttons)
            {
                b.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(bgColor);

            _spriteBatch.Begin();

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Add your additional drawing code here!
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            _spriteBatch.DrawString(font, $"# of button clicks: Left - {numberOfLeftClicks}," +
                $" Right - {numberOfRightClicks}", new Vector2(10, 10), Color.Black);

            // Draws in any raindrops
            foreach (Raindrop r in raindrops)
            {
                r.Draw(_spriteBatch);
            }

            // Draw the buttons last.
            foreach (Button b in buttons)
            {
                b.Draw(_spriteBatch);
            }

            
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        // #################################################################################
        // Button click handlers!
        // #################################################################################

        /// <summary>
        /// LEAVE THIS ONE ALONE
        /// Randomizes the saved background color
        /// </summary>
        public void RandomizeBackground()
        {
            bgColor = new Color(rng.Next(0, 256), rng.Next(0, 256), rng.Next(0, 256));
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // TODO: Add your new button click handlers here!
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// Increments whenever left button clicked is called
        /// </summary>
        public void LeftButtonClicked()
        { 
            numberOfLeftClicks++;
            
        }

        /// <summary>
        /// Increments whenever right button clicked is called
        /// </summary>
        public void RightButtonClicked()
        {
            numberOfRightClicks++;

        }

        /// <summary>
        /// Changes background to white
        /// </summary>
        public void SnowButton()
        {
            bgColor = Color.White;
        }

        /// <summary>
        /// Creates a new raindrop and adds it to the list
        /// </summary>
        public void RainButton()
        {
            raindrops.Add(new Raindrop(raindrop, 
                new Rectangle(rng.Next(0, 600),
                rng.Next(0, 300), 
                rng.Next(100, 200), 
                rng.Next(100, 200))));
            
        }
    }
}
