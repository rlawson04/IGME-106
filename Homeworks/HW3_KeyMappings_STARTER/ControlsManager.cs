﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

/// <summary>
/// ONLY MODIFY WHERE MARKED WITH "TODO"
/// Use View -> Task List to get a summary of all TODOs in the project
/// </summary>
namespace HW3_KeyMappings
{
    /// <summary>
    /// The possible directions that keys will map to
    /// </summary>
    public enum Direction
    {
        Up, Down, Left, Right
    }

    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    // TODO: Step 1.1: Define a public delegate "ControlsUpdateDelegate" that matches the signature for the Snake's SetControls method
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    /// <summary>
    /// Loads and stores possible directional control mappings for a game.
    /// Tracks the current control scheme and allows it to be changed based on custom buttons.
    /// </summary>
    class ControlsManager
    {
        // The available control schemes
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // TODO: Step 1.2.a: Define a field "schemes" that is a Dictionary that scheme names to Dictionaries of Keys -> Direction
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Rectangles to use as buttons to pick a control scheme
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // TODO: Step 1.2.b: Define a Dictionary field, "buttons", that maps Rectangles to scheme names
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // The previous mouse state for detecting clicks while updating
        private MouseState prevMState;

        // The event to trigger when the control scheme changes
        public event ControlsUpdateDelegate OnControlsUpdate;

        // The current control scheme
        public string CurrentScheme { get; private set; }

        /// <summary>
        /// Create a new controls manager with available schemes loaded from the 
        /// ControlSchemes.txt file in the Content folder
        /// </summary>
        public ControlsManager()
        {
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Step 2.1: Initialize the schemes and buttons data structures
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // Load the control schemes
            StreamReader input = null;
            try
            {
                input = new StreamReader("Content/ControlSchemes.txt");

                string line = null;
                while ((line = input.ReadLine()) != null)
                {
                    string[] segments = line.Split(',');
                    string scheme = segments[0];
                    Direction dir = (Direction)Enum.Parse(typeof(Direction), segments[1]);
                    Keys control = (Keys)Enum.Parse(typeof(Keys), segments[2]);

                    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    // TODO: Step 2.2.a: If this is a new scheme, add new entry into the schemes dictionary
                    // TODO: Step 2.2.b: Add a mapping from control -> dir for the scheme for this line
                    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Uh oh: " + e.Message);
            }
            finally
            {
                if(input != null)
                {
                    input.Close();
                }
            }

            // Build buttons for displaying them
            int x = 40;
            int y = 70;
            int buttonSize = 100;
            foreach (string scheme in schemes.Keys)
            {
                Rectangle button = new Rectangle(x, y, buttonSize, buttonSize);
                buttons[button] = scheme;
                x += (int)(buttonSize * 1.1);
            }
        }

        /// <summary>
        /// Draw buttons for each possible control scheme
        /// </summary>
        public void DrawButtons()
        {
            foreach (Rectangle box in buttons.Keys)
            {
                Color color = Color.White;
                if (buttons[box] == CurrentScheme)
                {
                    color = Color.PaleGreen;
                }
                ShapeBatch.Box(box, color);
            }
        }

        /// <summary>
        /// Overlay text to match each button 
        /// (assumes that DrawButtons was already called)
        /// </summary>
        public void DrawButtonText(SpriteBatch spriteBatch, SpriteFont font)
        {
            foreach (Rectangle box in buttons.Keys)
            {
                spriteBatch.DrawString(font, SchemeInfo(buttons[box]), new Vector2(box.X + 5, box.Y + 5), Color.Black);
            }
        }

        /// <summary>
        /// Check if there was a mouse click in one of the scheme buttons and update
        /// the current scheme accordingly
        /// </summary>
        public void Update()
        {
            MouseState mState = Mouse.GetState();
            if (mState.LeftButton == ButtonState.Released && prevMState.LeftButton == ButtonState.Pressed)
            {
                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                // TODO: Step 3.1.a: Check each button rectangle in the buttons dictionary to see if it was the one clicked
                // TODO: Step 3.1.b: If the button was clicked, look up the associated scheme name, update CurrentScheme, and trigger the OnControlsUpdate event with the associated controls dictionary.
                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            }
            prevMState = mState;
        }

        /// <summary>
        /// Helper method to get a string with info about a specific control scheme
        /// </summary>
        private string SchemeInfo(string scheme)
        {
            string result = scheme;
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Step 3.2: Build the result string for display on the buttons by
            // by adding each key --> direction mapping (but in the correct format to
            // match the sample button text)
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            return result;
        }

    }
}
