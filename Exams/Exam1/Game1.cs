﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

enum State
{
    Title,
    Edit,
    Done
}

namespace Exam1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private State currentState = State.Title;
        private SpriteFont defaultFont;
        private Texture2D texture;
        private int ducks;
        private KeyboardState prevKBState;
        private MouseState mState = Mouse.GetState();
        

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
            defaultFont = Content.Load<SpriteFont>("defaultFont");
            texture = Content.Load<Texture2D>("ducky");
           
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState kbstate = Keyboard.GetState();
            

            switch (currentState)
            {
                case State.Title:
                    if (kbstate.IsKeyDown(Keys.Space) && prevKBState.IsKeyDown(Keys.Space))
                    {
                        currentState = State.Edit;
                    }
                    break;

                case State.Edit:
                    if (kbstate.IsKeyDown(Keys.Space) && prevKBState.IsKeyUp(Keys.Space))
                    {
                        currentState = State.Done;
                    }
                    
                    break;

                case State.Done:
                    if (kbstate.IsKeyDown(Keys.Space) && prevKBState.IsKeyUp(Keys.Space))
                    {
                        currentState = State.Title;
                    }
                    break;
            }

            base.Update(gameTime);

            prevKBState = kbstate;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Aqua);

            _spriteBatch.Begin();

            switch (currentState)
            {
                case State.Title:
                    _spriteBatch.DrawString(defaultFont, "Reilly Lawson - Section 1", new Vector2(10,10), Color.Black);
                    break;

                case State.Edit:
                    _spriteBatch.DrawString(defaultFont, $"{ducks}", new Vector2(10, 10), Color.Black);

                    while (ducks < 6)
                    {
                        if (mState.LeftButton == ButtonState.Pressed)
                        {
                            _spriteBatch.Draw(texture, new Vector2(mState.X, mState.Y), Color.White);
                            ducks++;
                        }
                    }

                    break;

                case State.Done:

                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}