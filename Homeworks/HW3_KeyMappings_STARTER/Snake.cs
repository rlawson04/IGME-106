using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HW3_KeyMappings
{
    /// <summary>
    /// Runs a game of Snake that can be reset.
    /// DO NOT MODIFY ANYTHING IN THIS FILE
    /// </summary>
    class Snake
    {
        // Constants
        private const float PixelsPerMS = 0.25f;
        private const int Width = 5;

        // Keep track of the current snake info: direction, head, 
        // and the "lines" that make up the trail
        private Direction direction;
        private Rectangle head;
        private List<Rectangle> lines;

        // Use a hidden rectangle to note the window size (makes it 
        // easier to tell when the head leaves the window)
        private Rectangle window;

        // The current control scheme and the previous keyboard state
        private Dictionary<Keys, Direction> controls;
        private KeyboardState prevKBState;

        // Auto-property to track if the snake is currently alive (playable)
        public bool IsAlive { get; private set; }

        /// <summary>
        /// Create a new snake game that fits in the given square window size
        /// </summary>
        public Snake(int windowSize)
        {
            // Build the window boundaries to keep the head within bounds
            window = new Rectangle(Width, Width, windowSize - 2 * Width, windowSize - 2 * Width);

            // Reset the snake's info, but also default to *not* running since we 
            // don't have a control scheme yet!
            Reset();
            IsAlive = false;
        }

        /// <summary>
        /// Update the control scheme to use when detecting direction changes
        /// </summary>
        public void SetControls(Dictionary<Keys, Direction> controls)
        {
            this.controls = controls;
        }

        /// <summary>
        /// Reset the snake's head position, clear the trail, and start playing
        /// </summary>
        public void Reset()
        {
            this.head =
                new Rectangle(
                    window.X + window.Width / 2 - Width / 2,
                    window.Y + window.Height / 2 - Width / 2,
                    Width, Width
                );
            this.direction = Direction.Right;
            this.lines = new List<Rectangle>();
            IsAlive = true;
        }

        /// <summary>
        /// If running, check for direction changes, update the head & add trail lines as needed.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            if (IsAlive)
            {
                KeyboardState kbState = Keyboard.GetState();

                // Check for direction changes based on the current controls (if multiple
                // keys are pressed, this will only use the last one checked)
                foreach (Keys key in controls.Keys)
                {
                    if (kbState.IsKeyDown(key) && prevKBState.IsKeyUp(key))
                    {
                        direction = controls[key];
                    }
                }

                // Update the head position based on direction and elapsed time
                int offset = (int)(PixelsPerMS * gameTime.ElapsedGameTime.TotalMilliseconds);

                switch (direction)
                {
                    case Direction.Right:
                        this.lines.Add(new Rectangle(head.X, head.Y, offset, Width));
                        head.X += offset;
                        break;
                    case Direction.Left:
                        this.lines.Add(new Rectangle(head.X - offset + Width, head.Y, offset, Width));
                        head.X -= offset;
                        break;
                    case Direction.Down:
                        this.lines.Add(new Rectangle(head.X, head.Y, Width, offset));
                        head.Y += offset;
                        break;
                    case Direction.Up:
                        this.lines.Add(new Rectangle(head.X, head.Y - offset + Width, Width, offset));
                        head.Y -= offset;
                        break;
                }

                // Make sure the head is still in the window
                IsAlive = head.Intersects(window);

                // Make sure the head didn't cross the body anywhere
                foreach (Rectangle line in lines)
                {
                    IsAlive = IsAlive && !head.Intersects(line);
                    if (!IsAlive)
                        break;
                }
            }
        }

        /// <summary>
        /// Draw the head and trail
        /// </summary>
        public void Draw()
        {
            foreach (Rectangle box in lines)
            {
                ShapeBatch.Box(box, Color.Gray);
            }
            ShapeBatch.Box(head, Color.Red);
        }

    }
}
