using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HW_2_MonoGame
{
    internal class Collectible : GameObject
    {
        // -----------------------------------
        // Fields
        // -----------------------------------

        private bool active = true;

        // -----------------------------------
        // Properties
        // -----------------------------------

        /// <summary>
        /// Get and set property to check if the collectible is active or not
        /// </summary>
        public bool Active
        {
            get { return active; }

            set { active = value; }
        }

        // -----------------------------------
        // Constructors
        // -----------------------------------

        /// <summary>
        /// parameterized constructor for the collectible class that leverages the gameobject base
        /// </summary>
        /// <param name="texture"> takes in a 2D texture from the content folder </param>
        /// <param name="rectangle"> takes in a rectangle </param>
        /// <param name="active"> takes in a bool that checks if it is active </param>
        public Collectible(Texture2D texture, Rectangle rectangle, bool active)
            : base(texture, rectangle)
        {
            this.active = active;
        }

        // -----------------------------------
        // Methods
        // -----------------------------------

        /// <summary>
        /// Uses the intersects method of the rectangle to check collision
        /// </summary>
        /// <param name="check"> takes in a child of the game object base </param>
        /// <returns> bool meaning if the objects are colliding </returns>
        public bool CheckCollision(GameObject check)
        {
            bool collision = false;

            if (check.Rectangle.Intersects(rectangle))
            {
                collision = true;
            }


            return collision;
        }

        /// <summary>
        /// Checks if the collectible is active and then draws it
        /// </summary>
        /// <param name="sb"> takes in a spritebatch object </param>
        public override void Draw(SpriteBatch sb)
        {
            if (active)
            {
                base.Draw(sb);
            }
        }

        /// <summary>
        /// Does nothing but is required to inherit from the game object
        /// </summary>
        /// <param name="gameTime"> takes in a game time object </param>
        public override void Update(GameTime gameTime)
        {
        }
    }
}
