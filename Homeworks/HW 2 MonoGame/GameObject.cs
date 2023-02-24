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

        /// <summary>
        /// Get method that returns the texture of the inherited object
        /// </summary>
        public Texture2D Texture
        {
            get { return texture; }
        }

        /// <summary>
        /// Get method that returns the rectangle of the inherited object
        /// </summary>
        public Rectangle Rectangle
        {
            get { return rectangle; }
        }

        // -----------------------------------
        // Constructors
        // -----------------------------------

        /// <summary>
        /// Parameterized constructor for the game object base class
        /// </summary>
        /// <param name="texture"> takes in a 2D texture </param>
        /// <param name="rectangle"> takes in a rectangle </param>
        protected GameObject (Texture2D texture, Rectangle rectangle)
        {
            this.texture = texture;
            this.rectangle = rectangle;
        }

        // -----------------------------------
        // Methods
        // -----------------------------------

        /// <summary>
        /// Draws the given spritebatch using the texture and rectangle
        /// </summary>
        /// <param name="sb"></param>
        public virtual void Draw (SpriteBatch sb)
        {
            sb.Draw(texture, rectangle, Color.White);
        }

        /// <summary>
        /// abstract method for the child classes to inherit
        /// </summary>
        /// <param name="gameTime"> pass in the game time </param>
        public abstract void Update (GameTime gameTime);
    }
}
