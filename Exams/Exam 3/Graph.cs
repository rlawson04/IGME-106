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
        private List<string> visited = new List<string>();

        // Random object for the guard method 
        private Random random = new Random();

        
        // Properties

        /// <summary>
        /// Get property to return the list of visited vertices
        /// </summary>
        public List<string> Visisted { get { return visited; } }

        // Constructors

        public Graph(string relativeFile) 
        { 
            // NOTE: All exceptions are handled in main

            // Open the file with a stream reader
            StreamReader sr = new StreamReader(relativeFile);

            string lineOfText = " ";

            while (lineOfText != null)
            {
                lineOfText = sr.ReadLine();

                if (lineOfText != null)
                {
                    break;
                }

                // Array to store the data of visited vertices
                string[] splitData = lineOfText.Split(',');

                // Save the first vertex in the line as a variable to use as the key
                string vertexKey = splitData[0];

                // Clears the list of visited vertices so multiple lines don't add up
                visited.Clear();

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
    }
}
