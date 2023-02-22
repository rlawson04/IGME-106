using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HW_2_MonoGame
{
    abstract class GameObject
    {
        // -----------------------------------
        // Fields
        // -----------------------------------

        protected Texture2D texture;
        protected Rectangle rectangle;

        // -----------------------------------
        // Properties
        // -----------------------------------

        public Texture2D Texture
        {
            get { return texture; }
        }

        public Rectangle Rectangle
        {
            get { return rectangle; }
        }

        // -----------------------------------
        // Constructors
        // -----------------------------------

        protected GameObject (Texture2D texture, Rectangle rectangle)
        {
            this.texture = texture;
            this.rectangle = rectangle;
        }

        // -----------------------------------
        // Methods
        // -----------------------------------

        public virtual void Draw (SpriteBatch sb)
        {
            sb.Draw(texture, rectangle, Color.White);
        }

        public abstract void Update (GameTime gameTime);
    }
}
