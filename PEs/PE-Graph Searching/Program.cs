namespace PE_Graph_Searching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Main statements from PE

            Graph myGraph = new Graph(5);
            myGraph.AddConnection("Billiards Room", "Drawing Room");
            myGraph.AddConnection("Drawing Room", "Game Room");
            myGraph.AddConnection("Drawing Room", "Library");
            myGraph.AddConnection("Game Room", "Library");
            myGraph.AddConnection("Library", "Exit");

            myGraph.DepthFirst("Invisible Room");
            Console.WriteLine();

            myGraph.DepthFirst("Drawing Room");
            Console.WriteLine();

            myGraph.DepthFirst("Exit");
            Console.WriteLine();

            // Test Dijkstra's
            Vertex startingVertex = new Vertex("Billiards Room");
            myGraph.ShortestPath(startingVertex);
        }
    }
}