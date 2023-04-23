using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// DO NOT MODIFY ANYTHING IN THIS FILE!
namespace HW5_QuadTrees
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        // MonoGame Basics
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        // Mouse related
        private Rectangle mouseRect;
        private QuadTreeNode mouseQuad;

        // The quad tree's root node
        private QuadTreeNode rootNode;

        // A list of game objects
        private List<GameObject> gameObjects;

        // Random number generator
        private Random rng;

        // A color used to flash game objects
        private Color flash;

        private const int NumGameObjects = 50;
        private const int MinGameObjectSize = 5;
        private const int MaxGameObjectSize = 15;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            // Set up the game object list
            gameObjects = new List<GameObject>();

            // Make the random object
            rng = new Random();

            // Set up the mouse rectangle
            mouseRect = new Rectangle(0, 0, 20, 20);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Create the quad tree
            rootNode = new QuadTreeNode(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            // Create a bunch of randomly placed game objects
            for (int i = 0; i < NumGameObjects; i++)
            {
                // Choose a random size
                int size = rng.Next(MinGameObjectSize, MaxGameObjectSize);

                // Choose x and y values (with a buffer around the border of the window)
                int x = rng.Next(size, GraphicsDevice.Viewport.Width - size);
                int y = rng.Next(size, GraphicsDevice.Viewport.Height - size);
                Color color = new Color(
                    (float)Math.Max(rng.NextDouble(), 0.25f),
                    (float)Math.Max(rng.NextDouble(), 0.25f),
                    (float)Math.Max(rng.NextDouble(), 0.25f),
                    1.0f);

                // Make the game object
                GameObject gameObj = new GameObject(new Rectangle(x, y, size, size), color);

                // Add it to the list and the quad tree
                gameObjects.Add(gameObj);
                rootNode.AddObject(gameObj);
            }
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Change the flash number
            float lvl = (float)Math.Sin(gameTime.TotalGameTime.TotalSeconds * 10) * 0.5f + 0.5f;
            flash = new Color(lvl,lvl,lvl);

            // Update the mouse rectangle
            MouseState mState = Mouse.GetState();
            mouseRect.X = mState.X;
            mouseRect.Y = mState.Y;

            // Get the quad that the mouse rectangle is in
            mouseQuad = rootNode.GetContainingQuad(mouseRect);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Clear the screen
            GraphicsDevice.Clear(Color.Black);

            // Start the SHAPE batch
            ShapeBatch.Begin(GraphicsDevice);

            // Is the mouse inside of a quad?
            if (mouseQuad != null)
            {
                // Outline the quad in red
                ShapeBatch.Box(mouseQuad.Rectangle, Color.CornflowerBlue);
            }

            // Get all the quad tree rectangles and draw them
            List<Rectangle> rects = rootNode.GetAllRectangles();
            foreach (Rectangle rect in rects)
            {
                ShapeBatch.BoxOutline(rect, Color.White);
            }

            // Draw all of the objects
            foreach (GameObject gameObj in gameObjects)
            {
                ShapeBatch.Box(gameObj.Rectangle, gameObj.Color);
            }

            // Flash any objects in the current quad
            if (mouseQuad != null)
            {
                // Flash the quad's objects
                foreach (GameObject gameObj in mouseQuad.GameObjects)
                {
                    ShapeBatch.Box(gameObj.Rectangle, flash);
                    ShapeBatch.BoxOutline(gameObj.Rectangle, Color.White);
                }
            }

            // Draw the mouse rectangle
            ShapeBatch.Box(mouseRect, Color.White);

            // End the SHAPE batch
            ShapeBatch.End();

            base.Draw(gameTime);
        }
    }
}
