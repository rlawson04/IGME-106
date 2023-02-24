using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace HW_2_MonoGame
{
    enum GameState
    {
        Menu,
        Game,
        GameOver
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameState currentState;
        private Player Player;
        private List<Collectible> collectibles;
        private int currentLevel;
        private double timer;
        private KeyboardState prevKBState;
        private SpriteFont mainFont;
        private Texture2D texture;
        private Texture2D texture2;
        private Random rng = new Random();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            int width = _graphics.GraphicsDevice.Viewport.Width;
            int height = _graphics.GraphicsDevice.Viewport.Height;
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = this.Content.Load<Texture2D>("Pikachu");
            texture2 = this.Content.Load<Texture2D>("Pokeball");
            mainFont = this.Content.Load<SpriteFont>("MainFont");
            Player = new Player(texture, new Rectangle(0, 0, 100, 100), 0, 0, width, height);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState kbState = Keyboard.GetState();

            switch(currentState)
            {
                case GameState.Menu:
                    if (kbState.IsKeyDown(Keys.Enter) && prevKBState.IsKeyUp(Keys.Enter))
                    {
                        currentState = GameState.Game;
                    }
                    break;

                case GameState.Game:
                    if (timer <= 0)
                    {
                        currentState = GameState.GameOver;
                    }
                    break;

                case GameState.GameOver:
                    if (kbState.IsKeyDown(Keys.Enter) && prevKBState.IsKeyUp(Keys.Enter))
                    {
                        currentState = GameState.Menu;
                    }
                    break;
            }

            base.Update(gameTime);
            prevKBState = kbState;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            switch (currentState)
            {
                case GameState.Menu:
                    _spriteBatch.DrawString(mainFont, "Title \nPress ENTER to begin: ",
                        new Vector2(10, 10), Color.Black);
                    break;

                case GameState.Game:
                    _spriteBatch.DrawString(mainFont, $"Current level {currentLevel}" +
                        $" \n{Player.LevelScore} \n{timer}", new Vector2(10, 10), Color.Black);
                    break;

                case GameState.GameOver:
                    _spriteBatch.DrawString(mainFont, $"Final Level {currentLevel} \nFinal Score" +
                        $" {Player.TotalScore} \nPress ENTER to return to the Main Menu",
                        new Vector2(10, 10), Color.Black);
                    break;
            }

            _spriteBatch.End(); 

            base.Draw(gameTime);
        }
    }
}