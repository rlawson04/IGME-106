namespace PE_Sorted_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new SortedList, save a reference to it as an ISortedCollection
            // and add some random values to it
            const int MaxScore = 100;
            ISortedCollection sortedData = new SortedList();
            Random rng = new Random();
            int numsToAdd = rng.Next(10);
            for (int i = 0; i < numsToAdd; i++)
            {
                sortedData.Add(rng.Next(MaxScore + 1));
            }

            // Print a summary of the sorted collection
            Console.WriteLine(
            "The sorted collection has {0} elements and thus IsEmpty returns {1}:",
            sortedData.Count,
            sortedData.IsEmpty);
            sortedData.Print();
            Console.WriteLine(
            "\nThe min and max are {0} and {1}.",
            sortedData.Min(),
            sortedData.Max());

            // And test the other methods
            sortedData.Add(42);
            if (sortedData.Contains(42))
            {
                Console.WriteLine("\nWe also snuck the meaning of life.");
            }
            if (!sortedData.Contains(MaxScore))
            {
                Console.WriteLine("\nBut not the maximum possible score.");
            }
            Console.WriteLine("\nLet's sort multiples of 5.");
            sortedData.Clear();
            sortedData.Add(15);
            sortedData.Add(20);
            sortedData.Add(5);
            sortedData.Add(10);
            sortedData.Print();

        }
    }
}