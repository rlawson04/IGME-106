using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PE_Graph_Searching
{
    internal class Graph
    {
        // Fields for the adjacency matrix, dictionary, and list
        int[,] adjMatrix;
        Dictionary<string, Vertex> vertices;
        List<Vertex> verticesList;

        /// <summary>
        /// Constructor that creates the adjacency matrix
        /// </summary>
        /// <param name="maxVertices"> takes an int as the size of the matrix </param>
        public Graph(int maxVertices) 
        {
            adjMatrix = new int[maxVertices, maxVertices];
            vertices = new Dictionary<string, Vertex>();
            verticesList = new List<Vertex>();
        }

        /// <summary>
        /// Private helper method that returns or creates a vertex
        /// </summary>
        /// <param name="name"> name of the vertex </param>
        /// <returns> a reference to the vertex </returns>
        private Vertex GetVertex(string name)
        {
            // If it exists in the dictionary, return the reference
            if(vertices.ContainsKey(name))
            {
                return vertices[name];
            }
            // If not, create it, add it, and return it
            else
            {
                Vertex newVertex = new Vertex(name);
                vertices.Add(name, newVertex);
                verticesList.Add(newVertex);    
                return newVertex;
            }
        }

        /// <summary>
        /// Gets the vertexes of the two strings and creates a connection between them in the matrix
        /// </summary>
        /// <param name="roomA"> string of first vertex </param>
        /// <param name="roomB"> string of second vertex </param>
        public void AddConnection (string roomA, string roomB)
        {
            
            int index1 = verticesList.IndexOf(GetVertex(roomA));
            int index2 = verticesList.IndexOf(GetVertex(roomB));

            adjMatrix[index1, index2] = 1;
            adjMatrix[index2, index1] = 1;
        }

        /// <summary>
        /// Loops through all vertexes and sets is visited to false
        /// </summary>
        private void Reset()
        {
            foreach(Vertex v in verticesList)
            {
                v.Visited = false;
            }
        }

        /// <summary>
        /// Iterates through the columns that the current vertex is on to find an unvisited vertex
        /// </summary>
        /// <param name="current"> a reference to a vertex </param>
        /// <returns> an adjacent vertex that has not been visited </returns>
        private Vertex GetUnvisitedNeighbor(Vertex current)
        {
            int index = verticesList.IndexOf(current);

            for (int i = 0; i < index; i++)
            {
                if (adjMatrix[index, i] == 1 && verticesList.ElementAt(i).Visited == false)
                {
                    string adjVertex = verticesList.ElementAt(i).Name;

                    vertices[adjVertex].Visited = true;
                    return vertices[adjVertex];
                }
            }

            return null;
            
        }

        /// <summary>
        /// Prints out the graph in a depth first order 
        /// </summary>
        /// <param name="name"></param>
        public void DepthFirst(string name)
        {
            
            // Check that the name exists
            if (vertices.ContainsKey(name) == false)
            {
                Console.WriteLine("Not a valid starting point");
                return;
            }
            else
            {
                // Calls reset and then makes the stack
                Reset();
                Stack<Vertex> stack = new Stack<Vertex>();

                // Initial message
                Console.WriteLine("Starting at Vertex " + name);
                stack.Push(vertices[name]);

                vertices[name].Visited = false;

                // Loops through stack 
                while(stack.Count > 0)
                {
                    Vertex neighbor = GetUnvisitedNeighbor(stack.Peek());

                    if (neighbor != null)
                    {
                        
                        Console.WriteLine("Working on vertex " + neighbor.Name);

                        stack.Push(neighbor);

                        neighbor.Visited = true;
                    }
                    else
                    {
                        stack.Pop();
                    }
                    
                }
            }
        }


        public void ShortestPath(Vertex startingVertex)
        {
            // Reset all algorithm related vertex data
            foreach(Vertex v in verticesList)
            {
                v.Reset();
            }
            
            // The source vertex becomes the first "current" node
            startingVertex.Permanent = true;
            startingVertex.Distance = 0;

            // Sets the staring vertex 
            Vertex currentVertex = startingVertex;
           
            // Setting the distances for the vertices   
            for (int i = 0; i< verticesList.Count; i++)
            {
                Vertex neighbors = GetUnvisitedNeighbor(currentVertex);
                while (neighbors != null)
                {
                    neighbors.Distance = 1;
                    neighbors.Permanent = true;
                    currentVertex = verticesList.ElementAt(i);
                    neighbors = GetUnvisitedNeighbor(currentVertex);
                }
                
            }
            DepthFirst(startingVertex.Name);
                
            


        }

        /// <summary>
        /// Checks the list of vertices for non permanent members
        /// </summary>
        /// <returns> true if there are non permanent members, else false </returns>
        private bool NonPermanent()
        {
            // Checks all vertices
            foreach(Vertex v in verticesList)
            {
                if (v.Permanent == false)
                {
                    return true;
                }    
            }

            // Returns false when all vertices are permanent
            return false;
        }
       
    }
}
