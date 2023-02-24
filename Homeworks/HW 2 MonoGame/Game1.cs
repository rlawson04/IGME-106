using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace HW_2_MonoGame
{
    interface Idamagable
    {
        string Name { get; set; }
    }
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
        private Collectible collectibleTarget;
        private List<Collectible> collectibles;
        private int currentLevel;
        private double timer;
        private KeyboardState prevKBState;
        private SpriteFont mainFont;
        private Texture2D texture;
        private Texture2D texture2;
        private Random rng = new Random();
        private int highScore;

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
            collectibles = new List<Collectible>();
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
                    
                    if(SingleKeyPress(Keys.Enter, kbState))
                    {
                        ResetGame();
                        currentState = GameState.Game;
                    }
                    break;

                case GameState.Game:
                    // Ends game if time runs out
                    if (timer <= 0)
                    {
                        currentState = GameState.GameOver;
                    }

                    // Handles movement for the player 
                    Player.Update(gameTime);

                    // Checks collision for each collectible
                    foreach (Collectible c in collectibles)
                    {
                        if (c.CheckCollision(Player) == true && c.Active)
                        {
                            c.Active = false;
                            Player.LevelScore++;
                        }
                    }

                    // Removes the collectible after it has collided
                    for(int i = 0; i < collectibles.Count; i++)
                    {
                        if(collectibles[i].Active==false)
                        {
                            collectibles.Remove(collectibles[i]);
                        }
                    }
                    

                    // Updates timer using the game time
                    timer -= gameTime.ElapsedGameTime.TotalSeconds;

                    if (collectibles.Count == 0)
                    {
                        Player.TotalScore += Player.LevelScore;
                        NextLevel();
                    }
                    break;

                case GameState.GameOver:

                    // Returns to Main menu when enter is pressed
                    if (SingleKeyPress(Keys.Enter, kbState))
                    {
                        currentState = GameState.Menu;
                    }
                    if (Player.TotalScore > highScore)
                    {
                        highScore = Player.TotalScore;
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
                    _spriteBatch.DrawString(mainFont, $"Title " +
                        $"\n Current High Score: {highScore}" +
                        $"\nPress ENTER to begin: ",
                        new Vector2(10, 10), Color.Black);
                    break;

                case GameState.Game:
                    

                    _spriteBatch.Draw(Player.Texture, Player.Rectangle, Color.White);

                    foreach (Collectible c in collectibles)
                    {
                        if (c.Active)
                        {
                            _spriteBatch.Draw(c.Texture, c.Rectangle, Color.White);
                        }
                    }

                    _spriteBatch.DrawString(mainFont, $"Current level {currentLevel}" +
                        $" \nScore {Player.LevelScore} \nTime Left {Math.Round(timer, 2)}" +
                        $"\nCollectibles left {collectibles.Count}", new Vector2(10, 10),
                        Color.Black);
                    break;

                case GameState.GameOver:
                    _spriteBatch.DrawString(mainFont, $"Final Level {currentLevel} " +
                        $"\nFinal Score {Player.TotalScore}" +
                        $" \nPress ENTER to return to the Main Menu",
                        new Vector2(200, 200), Color.Black);
                    break;
            }

            _spriteBatch.End(); 

            base.Draw(gameTime);
        }

        private void NextLevel()
        {
            int width = _graphics.GraphicsDevice.Viewport.Width;
            int height = _graphics.GraphicsDevice.Viewport.Height;
            currentLevel++;
            timer = 10.0;
            Player.LevelScore = 0;
            Player.Center();

            if (collectibles != null)
            {
                collectibles.Clear();
            }

            for (int i = 0; i < rng.Next(10 + currentLevel, 10 + currentLevel *3); i++)
            {
                //Texture2D texture, Rectangle rectangle, bool active
                collectibleTarget = new Collectible(texture2,
                    new Rectangle(rng.Next(0, width - 20),rng.Next(0,height - 20), 75,75), true);
                collectibles.Add(collectibleTarget);
                
            }
        }

        private void ResetGame()
        {
            if(currentState == GameState.Menu)
            {
                currentLevel = 0;
                Player.TotalScore = 0;
                NextLevel();
            }
        }

        private bool SingleKeyPress(Keys key, KeyboardState kbState)
        {
            kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(key) && prevKBState.IsKeyUp(key))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void HighScore()
        {
            
            highScore = 0;
        }
    }
}