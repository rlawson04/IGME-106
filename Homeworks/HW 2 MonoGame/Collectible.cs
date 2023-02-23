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

        public bool Active
        {
            get { return active; }

            set { active = value; }
        }

        // -----------------------------------
        // Constructors
        // -----------------------------------

        public Collectible(Texture2D texture, Rectangle rectangle, bool active)
            : base(texture, rectangle)
        {
            this.active = active;
        }

        // -----------------------------------
        // Methods
        // -----------------------------------

        public bool CheckCollision(GameObject check)
        {
            bool collision = false;

            if (check.Rectangle.Intersects(rectangle))
            {
                collision = true;
            }


            return collision;
        }

        public override void Draw(SpriteBatch sb)
        {
            if (active)
            {
                base.Draw(sb);
            }
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
