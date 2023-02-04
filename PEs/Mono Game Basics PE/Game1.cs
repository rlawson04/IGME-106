using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace Mono_Game_Basics_PE
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;
        private Vector2 _position;
        private Rectangle _bounds;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 600;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _position = Vector2.Zero;
            base.Initialize();
            _bounds = new Rectangle((_graphics.PreferredBackBufferWidth/2 - _texture.Width/4),
                _graphics.PreferredBackBufferHeight/2 - _texture.Height/4 ,
                _texture.Width/2, _texture.Height/2);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _texture = this.Content.Load<Texture2D>("Crab");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            if (_position.X < _texture.Width)
            {
                _position.X++;
            }
            if (_position.Y < _texture.Height)
            {
                _position.Y++;
            }

            
                
            
            // todo: add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGoldenrod);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_texture, _position, Color.White);
            _spriteBatch.Draw(_texture, _bounds, Color.AliceBlue);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}