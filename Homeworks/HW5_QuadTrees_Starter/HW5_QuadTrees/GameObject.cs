using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// DO NOT MODIFY ANYTHING IN THIS FILE!
namespace HW5_QuadTrees
{
    class GameObject
    {
        // The game object's rectangle
        private Rectangle rect;

        // This object's color
        private Color color;

        /// <summary>
        /// This game object's rectangle
        /// </summary>
        public Rectangle Rectangle { get { return rect; } }

        /// <summary>
        /// This object's color
        /// </summary>
        public Color Color { get { return color; } }

        /// <summary>
        /// Creates a new game object
        /// </summary>
        /// <param name="rect">The rectangle for this game object</param>
        /// <param name="color">The color of this object</param>
        public GameObject(Rectangle rect, Color color)
        {
            this.rect = rect;
            this.color = color;
        }
    }
}
