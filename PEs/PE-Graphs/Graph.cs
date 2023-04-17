using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Graphs
{
    internal class Graph
    {
        // Dictionary field for the graph
        Dictionary<String, List<String>> graph;

        /// <summary>
        /// Default constructor that creates the graph and populates it 
        /// with the rooms and their adjacents
        /// </summary>
        public Graph ()
        {
            graph = new Dictionary<String, List<String>>();

            List<String> billiardList = new List<String>();
            billiardList.Add("DRAWING ROOM");
            graph.Add("BILLIARD ROOM", billiardList);

            List<String> drawingList = new List<String>();
            drawingList.Add("BILLIARD ROOM");
            drawingList.Add("GAME ROOM");
            drawingList.Add("LIBRARY");
            graph.Add("DRAWING ROOM", drawingList);

            List<String> gameList = new List<String>();
            gameList.Add("DRAWING ROOM");
            gameList.Add("LIBRARY");
            graph.Add("GAME ROOM", gameList);

            List<String> libraryList = new List<String>();
            libraryList.Add("GAME ROOM");
            libraryList.Add("DRAWING ROOM");
            libraryList.Add("EXIT");
            graph.Add("LIBRARY", libraryList);
        }

        /// <summary>
        /// Checks that the graph contains the room then gives the list of neighboring rooms
        /// </summary>
        /// <param name="room"> takes the name of a room </param>
        /// <returns> returns the list of adjacent rooms or null </returns>
        public List<String> GetAdjacentList(string room)
        {
            if(graph.ContainsKey(room))
            {
                return graph[room];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Determines if room 2 is directly connected to room 1
        /// </summary>
        /// <param name="room1"> string of room name </param>
        /// <param name="room2"> string of room name </param>
        /// <returns> true if the rooms are connected else false </returns>
        public bool IsConnected(string room1, string room2)
        {
            if (graph[room1].Contains(room2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
