using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Graph_Searching
{
    internal class Vertex
    {
        // Fields for name and visited 
        private string name;
        private bool visited;
        private int distance;
        private bool permanent;


        /// <summary>
        /// Get property for the name of the vertex
        /// </summary>
        public string Name
        { 
            get { return name; } 
        }

        /// <summary>
        /// Get and set property for the bool visited of the vertex
        /// </summary>
        public bool Visited
        { 
            get { return visited; }
            set { visited = value; }
        }

        /// <summary>
        /// Get and set property for the distance between vertexes
        /// </summary>
        public int Distance
        { 
            get { return distance; } 
            set { distance = value; } 
        }

        /// <summary>
        /// Get and set property for the permanent bool
        /// </summary>
        public bool Permanent
        {
            get { return permanent; }
            set { permanent = value; }
        }
        /// <summary>
        /// Parameterized constructor that takes the name of the vertex and sets visited to false
        /// </summary>
        /// <param name="name"> takes a string to make the name of the vertex</param>
        public Vertex(string name)
        {
            this.name = name;
            visited = false;
        }

        public void Reset()
        {
            this.Visited = false;
            this.distance = int.MaxValue;
            this.permanent = false;
        }
    }
}
