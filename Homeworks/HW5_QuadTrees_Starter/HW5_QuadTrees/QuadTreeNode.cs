﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

// DO NOT MODIFY EXCEPT WHERE MARKED WITH "TODO"
namespace HW5_QuadTrees
{
    class QuadTreeNode
    {
        // The maximum number of objects in a quad
        // before a subdivision occurs
        private const int MaxObjectsBeforeSubdivide = 3;

        // The game objects held at this level of the tree
        private List<GameObject> objects;

        // This quad's rectangle area
        private Rectangle rect;

        // This quad's divisions
        private QuadTreeNode[] divisions;

        /// <summary>
        /// The divisions of this quad
        /// </summary>
        public QuadTreeNode[] Divisions { get { return divisions; } }

        /// <summary>
        /// This quad's rectangle
        /// </summary>
        public Rectangle Rectangle { get { return rect; } }

        /// <summary>
        /// The game objects inside this quad
        /// </summary>
        public List<GameObject> GameObjects { get { return objects; } }

        /// <summary>
        /// Creates a new Quad Tree
        /// </summary>
        /// <param name="x">This quad's x position</param>
        /// <param name="y">This quad's y position</param>
        /// <param name="width">This quad's width</param>
        /// <param name="height">This quad's height</param>
        public QuadTreeNode(int x, int y, int width, int height)
        {
            // Save the rectangle
            rect = new Rectangle(x, y, width, height);

            // Create the object list
            objects = new List<GameObject>();

            // No divisions yet
            divisions = null;
        }

        /// <summary>
        /// Adds a game object to the quad.  If the quad has too many
        /// objects in it, and hasn't been divided already, it should
        /// be divided
        /// </summary>
        /// <param name="gameObj">The object to add</param>
        public void AddObject(GameObject gameObj)
        {
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: ADD YOUR CODE FOR ACTIVITY ONE HERE

            // For debugging purposes, it might be useful to print out some information inside the 
            // AddObject() method to determine where(and if) the object is being added.

            // This method takes one parameter: the new game object to add to the tree.  

            // The first thing to check is whether or not the object’s rectangle even fits into 
            // this quad. Use the Rectangle class’s Contains() method to see if one rectangle is 
            // completely contained within another.

            // If the game object doesn’t fit inside this quad, it simply shouldn’t be added and you’re done.  

            // If it does fit, you will need to determine where it should be added. The object could be 
            // added to this quad’s game object list, or it could be added to one of the subdivisions’ 
            // lists (if there are any subdivisions yet). Make this decision based on which of these 
            // quads contains the object being added. 

            // You may need to divide at this point. You should think about what conditions would 
            // warrant a division.  You only want to subdivide (by calling the Divide() method) 
            // when those conditions are met, and you should only ever do it once per quad node.  

            // If the object could fit inside a subdivision, call AddObject() on that quad tree node.

            // Once a division occurs, game objects can still be added to this quad’s list since 
            // the object might not fit into any of the subdivisions.
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // Check that the game object fits inside the Quad Tree Node Rectangle
            if(rect.Contains(gameObj.Rectangle))
            {
                
                // Adds the object to the list if the count is lower than 3 and no divide has been called
                if(GameObjects.Count < 3 && divisions != null)
                {
                    GameObjects.Add(gameObj);
                }
                
                // Call a divide if there are enough objects in the list and only call it once
                if (GameObjects.Count == 3 && divisions == null)
                {
                    // Checks and adds the objects to the divisions if they fit
                    Divide();

                    // Otherwise adds them to this quad
                    foreach (GameObject gObj in GameObjects)
                    {
                        objects.Add(gObj);
                    }
                }

                
                
            }
            // If it isn't contained, nothing happens
            else
            {
                return;
            }
        }

        /// <summary>
        /// Divides this quad into 4 smaller quads.  Moves any game objects
        /// that are completely contained within the new smaller quads into
        /// those quads and removes them from this one.
        /// </summary>
        public void Divide()
        {
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: ADD YOUR CODE FOR ACTIVITY ONE HERE
            // Make an array of 4 QuadTreeNodes
            // Create 4 subdivisions
            // Move objects from this node down into the subdivision they fit into 
            // (leave objects that cross boundaries here)
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            QuadTreeNode newNode1 = new QuadTreeNode(rect.X, rect.Y, rect.Width/4, rect.Height/4);
            QuadTreeNode newNode2 = new QuadTreeNode(rect.X + rect.Width/4, rect.Y, rect.Width / 4, rect.Height / 4);
            QuadTreeNode newNode3 = new QuadTreeNode(rect.X, rect.Y + rect.Height/4, rect.Width / 4, rect.Height / 4);
            QuadTreeNode newNode4 = new QuadTreeNode(rect.X + rect.Width / 4, rect.Y + rect.Height / 4, rect.Width / 4, rect.Height / 4);

            // Array of 4 Quad tree nodes
            divisions = new QuadTreeNode[4];
            divisions[0] = newNode1;
            divisions[1] = newNode2;
            divisions[2] = newNode3;
            divisions[3] = newNode4;

            // Moving objects fully contained by the subdivisions
            foreach (QuadTreeNode node in divisions)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i >= GameObjects.Count)
                    {
                        return;
                    }
                    else if (node.Rectangle.Contains(GameObjects[i].Rectangle))
                    {
                        node.objects.Add(GameObjects[i]);
                        GameObjects.Remove(GameObjects[i]);
                    }
                }                
            }
        }

        /// <summary>
        /// Recursively populates a list with all of the rectangles in this
        /// quad and any subdivision quads.  Use the "AddRange" method of
        /// the list class to add the elements from one list to another.
        /// </summary>
        /// <returns>A list of rectangles</returns>
        public List<Rectangle> GetAllRectangles()
        {
            List<Rectangle> rects = new List<Rectangle>();

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: ADD YOUR CODE FOR ACTIVITY TWO HERE
            // If there are subdivisions in this quad, first add this node's rectangle to the rects list
            // Then iteratively get all rectangles from each division. 
            // Add each one to this list of rectangles. 
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            
            // Add this nodes rectangle to the list
            rects.Add(rect);

            // Adds all the objects rectangles from the current level of the tree
            foreach(GameObject obj in objects)
            {
                rects.Add(obj.Rectangle);
            }

            // Recursively call the method to get all the divisions rectangles
            if (divisions != null)
            {
                foreach (QuadTreeNode node in divisions)
                {
                    node.GetAllRectangles();
                }
            }

            return rects;
        }

        /// <summary>
        /// A possibly recursive method that returns the
        /// smallest quad that contains the specified rectangle
        /// </summary>
        /// <param name="rect">The rectangle to check</param>
        /// <returns>The smallest quad that contains the rectangle</returns>
        public QuadTreeNode GetContainingQuad(Rectangle rect)
        {
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: ADD YOUR CODE FOR ACTIVITY TWO HERE
            // If the rectangle param fits inside me and I have children...
            // Check each of my children and see if it fits in them
            // And if so, then call this again
            // If I don't have children or none of my children has the rectangle, it must be me
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


            QuadTreeNode Node = new QuadTreeNode(rect.X, rect.Y, rect.Width, rect.Height);

            // Recursively call the method to get all the divisions containing quad
            if (divisions != null)
            {
                foreach (QuadTreeNode node in divisions)
                {
                    node.GetContainingQuad(rect);
                }
            }

            // If this quad contains the rectangle, return the quad
            if (this.rect.Contains(rect))
            {
                return Node;
            }

            // Return null if this quad doesn't completely contain
            // the rectangle that was passed in
            return null;
        }
    }
}
