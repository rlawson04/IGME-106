using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PE_MG_Buttons
{
    /// <summary>
    /// The raindrop class acts similarly to the button however it is only used to be drawn
    /// </summary>
    internal class Raindrop
    {
        // Fields
        private Texture2D raindrop;
        private Rectangle position;

        /// <summary>
        /// Parameterized constructor to make a raindrop 
        /// </summary>
        /// <param name="texture"> Takes in a loaded texture from content </param>
        public Raindrop(Texture2D texture, Rectangle position)
        {
            this.raindrop = texture;
            this.position = position;
        }

        /// <summary>
        /// Draws the raindrop in the given position
        /// </summary>
        /// <param name="spriteBatch"> a variable of the spriteBatch type </param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the button itself
            spriteBatch.Draw(raindrop, position, Color.White);

            
        }
    }
}
