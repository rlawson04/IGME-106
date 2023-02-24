using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq.Expressions;
using System.Xml;

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
        private FileStream fs = new FileStream("../../../Highscore.txt", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

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
            // Content to be loaded and initialized in the program
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

            // Current keyboard state to check against the previous state 
            KeyboardState kbState = Keyboard.GetState();

            switch(currentState)
            {
                case GameState.Menu:

                    // Uses a stream reader to load the high score 
                    LoadHighScore();

                    // Changes state when enter key is pressed
                    if (SingleKeyPress(Keys.Enter, kbState))
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

                    // Updates the total score after the level is completed
                    // or if the user ran out of time
                    if (collectibles.Count == 0)
                    {
                        Player.TotalScore += Player.LevelScore;
                        NextLevel();
                    }
                    else if (timer <= 0)
                    {
                        Player.TotalScore+=Player.LevelScore;
                    }
     
                    break;

                case GameState.GameOver:

                    // Returns to Main menu when enter is pressed
                    if (SingleKeyPress(Keys.Enter, kbState))
                    {
                        currentState = GameState.Menu;
                    }

                    // Takes the players total score and
                    // sets the new highscore if the current highscore is lower
                    if (Player.TotalScore > highScore)
                    {
                        highScore = Player.TotalScore;
                        RecordHighScore();
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
                    // Draws the main menu with the Title, high score, and info to start
                case GameState.Menu:
                    _spriteBatch.DrawString(mainFont, $"Title " +
                        $"\nCurrent High Score: {highScore}" +
                        $"\nPress ENTER to begin: ",
                        new Vector2(10, 10), Color.Black);
                    break;

                    // Draws all the collectibles in the list as well as the statistics including
                    // the current level, score, time left, collectibles left, and the high score
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
                        $"\nCollectibles left {collectibles.Count}" +
                        $"\nHigh Score {highScore}", new Vector2(10, 10),
                        Color.Black);
                    break;

                    // Draws a string to display the final level, score,
                    // and directions to go back to the main menu
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

        /// <summary>
        /// Sets up the next level by generating new objects and reseting the timer and score
        /// </summary>
        private void NextLevel()
        {
            int width = _graphics.GraphicsDevice.Viewport.Width;
            int height = _graphics.GraphicsDevice.Viewport.Height;
            currentLevel++;
            timer = 15.0;
            Player.LevelScore = 0;
            Player.Center();

            // Clears the collectibles list
            if (collectibles != null)
            {
                collectibles.Clear();
            }

            //Creates a random amount of objects of the collectible class
            for (int i = 0; i < rng.Next(10 + currentLevel, 10 + currentLevel *3); i++)
            {
                //Texture2D texture, Rectangle rectangle, bool active
                collectibleTarget = new Collectible(texture2,
                    new Rectangle(rng.Next(0, width - 20),rng.Next(0,height - 20), 75,75), true);
                collectibles.Add(collectibleTarget);
                
            }
        }

        /// <summary>
        /// Sets the score to 0 and generates the next level
        /// </summary>
        private void ResetGame()
        {
            if(currentState == GameState.Menu)
            {
                currentLevel = 0;
                Player.TotalScore = 0;
                NextLevel();
            }
        }

        /// <summary>
        /// Checks if there is a single key pressed by leveraging two keyboard states
        /// </summary>
        /// <param name="key"> takes in a key from the keys enum </param>
        /// <param name="kbState"> takes in a state of the keyboard state enum </param>
        /// <returns></returns>
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

        /// <summary>
        /// Uses a stream Writer to record the new high score
        /// </summary>
        private void RecordHighScore()
        {
            using (StreamWriter writer = new StreamWriter("../../../Highscore"))
            {
                writer.Write(highScore);
                writer.Close();
            }
                   
        }

        /// <summary>
        /// Uses a stream Reader to read in the file with the current highscore
        /// </summary>
        private void LoadHighScore()
        {
            try
            {
                using (StreamReader reader = new StreamReader("../../../Highscore"))
                {
                    highScore = int.Parse(reader.ReadLine());
                    reader.Close();
                }
            }
            catch { }
        }
        
    }
}