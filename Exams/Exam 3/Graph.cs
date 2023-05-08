using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_3
{
    /// <summary>
    /// The class is used to set up the adjacency list and walk tyhe guard through the vertices
    /// </summary>
    internal class Graph
    {
        // Fields

        // Dictionary that uses the vertex name as a key and the connected vertices in a list as the value
        private Dictionary<string, List<string>> adjacencyList = new Dictionary<string, List<string>>();

        // Unique vertex names that are visited
        private List<string> visited;

        // Random object for the guard method 
        private Random random = new Random();

        
        // Properties

        /// <summary>
        /// Get property to return the list of visited vertices
        /// </summary>
        public List<string> Visisted { get { return visited; } }

        // Constructors

        /// <summary>
        /// Parameterized constructor that uses the relative file path to create the graph
        /// </summary>
        /// <param name="relativeFile"> a string relating to the relative file path of the text document </param>
        public Graph(string relativeFile) 
        { 
            // NOTE: All exceptions are handled in main

            // Open the file with a stream reader
            StreamReader sr = new StreamReader(relativeFile);

            string lineOfText = " ";

            while (lineOfText != null)
            {
                lineOfText = sr.ReadLine();

                if (lineOfText == null)
                {
                    break;
                }

                // Array to store the data of visited vertices
                string[] splitData = lineOfText.Split(',');

                // Save the first vertex in the line as a variable to use as the key
                string vertexKey = splitData[0];

                visited = new List<string>();

                // Adds visited vertices to the list
                for (int i = 1; i < splitData.Length; i++)
                {
                    visited.Add(splitData[i]);
                }

                // Store the key and value in the dictionary
                adjacencyList.Add(vertexKey, visited);
            }


            // Close the reader
            sr.Close();
        }


        // Methods

        /// <summary>
        /// Returns whether the guard visited all the vertices and if the starting vertex is valid
        /// </summary>
        /// <param name="startingVertex"> the vertex where the guard will begin walking from </param>
        /// <returns></returns>
        public bool Guard(string startingVertex)
        {
            // Check that the starting vertex is in the list 
            if (adjacencyList.ContainsKey(startingVertex) == false)
            {
                Console.WriteLine(startingVertex + " is not a valid vertex. Try again");
                return false;
            }

            // Condition for exiting loop
            bool allVisited = false;

            // Initial message
            Console.WriteLine("Guard starts at vertex: " + startingVertex);

            // Keep track of the current vertex
            string currentVertex = startingVertex;

            // Clears the visited list
            visited.Clear();

            // Create a loop that runs until all vertices have been visited
            while (allVisited == false)
            {
                // if the guard visits a vertex and it's not in the visited list, add the vertex to the list
                if (visited.Contains(currentVertex) == false)
                {
                    visited.Add(currentVertex);

                    // Write out the name of the vertex visited
                    Console.WriteLine($"The guard moves to vertex {currentVertex} for the first time! ****");

                    // When visited has the same number of elements as adjacency list then exit the loop
                    if (visited.Count == adjacencyList.Count) 
                    {
                        Console.WriteLine("\nAll Vertices have been visited!");

                        allVisited = true;
                        break;
                    }
                }
                
                // If the guard moves to a vertex that is already in the list print message
                if (visited.Contains(currentVertex))
                {
                    Console.WriteLine($"The guard moves to vertex {currentVertex} again.");
                }

                // based on the vertex the guard is ar, randomly select one of the connected vertices to visit
                int nextInt = random.Next(0, adjacencyList[currentVertex].Count);

                string nextVertex = adjacencyList[currentVertex][nextInt];

                if (adjacencyList[currentVertex].Contains(nextVertex))
                {
                    currentVertex = nextVertex;
                }
            }

            return true;
        }
    }
}
