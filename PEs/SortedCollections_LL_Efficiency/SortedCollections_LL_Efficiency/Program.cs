using System;
using System.Collections.Generic;

/// <summary>
/// Program class with complete Main() and helper methods supplied by Prof. Mesh.
/// DO NOT MODIFY THIS CODE
/// </summary>
namespace SortedCollections_LL_Efficiency
{
    public delegate void AddMethod(int data);
    public delegate void InsertMethod(int index, int data);
    public delegate void ClearMethod();

    class Program
    {
        static void Main(string[] args)
        {
            // Rng to use everywhere
            Random rng = new Random();

            // Test the custom linked list
            MyLinkedList_v1<int> numbersLL_v1 = new MyLinkedList_v1<int>();
            MyLinkedList_v2<int> numbersLL_v2 = new MyLinkedList_v2<int>();
            TestLinkedList(numbersLL_v1);
            TestLinkedList(numbersLL_v2);

            // Tests of the various sorted collections available with different data types:
            List<ISortedCollection<int>> sortedIntCollections = new List<ISortedCollection<int>>();
            sortedIntCollections.Add(new SortedList<int>());
            sortedIntCollections.Add(new SortedLL_v1<int>());
            sortedIntCollections.Add(new SortedLL_v2<int>());
            TestIntCollections(sortedIntCollections);

            List<ISortedCollection<string>> sortedStringCollections = new List<ISortedCollection<string>>();
            sortedStringCollections.Add(new SortedList<string>());
            sortedStringCollections.Add(new SortedLL_v1<string>());
            sortedStringCollections.Add(new SortedLL_v2<string>());
            TestStringCollections(sortedStringCollections);

            List<ISortedCollection<Player>> sortedPlayersCollections = new List<ISortedCollection<Player>>();
            sortedPlayersCollections.Add(new SortedList<Player>());
            sortedPlayersCollections.Add(new SortedLL_v1<Player>());
            sortedPlayersCollections.Add(new SortedLL_v2<Player>());
            TestPlayerCollections(sortedPlayersCollections);

            // Time trials of unsorted collections
            Console.WriteLine("\n" + "".PadLeft(40, '-'));
            List<int> numbersList = new List<int>();
            Console.WriteLine("\n*** Time Trials - Unsorted, Add ***");
            AddTimeTrials(rng, "\nC# List", numbersList.Add, numbersList.Clear);
            AddTimeTrials(rng, "\nMyLinkedList w/o tail", numbersLL_v1.Add, numbersLL_v1.Clear);
            AddTimeTrials(rng, "\nMyLinkedList w/ tail", numbersLL_v2.Add, numbersLL_v2.Clear);

            // Time trials of adding to a sorted collection.
            Console.WriteLine("\n" + "".PadLeft(40, '-'));
            Console.WriteLine("*** Time Trials - Sorted ***");
            AddTimeTrials(rng, "\nSortedList", sortedIntCollections[0].Add, sortedIntCollections[0].Clear, 1000);
            AddTimeTrials(rng, "\nSortedLL", sortedIntCollections[1].Add, sortedIntCollections[1].Clear, 1000);
            AddTimeTrials(rng, "\nSortedLL - Improved", sortedIntCollections[2].Add, sortedIntCollections[2].Clear, 1000);
            Console.WriteLine("\n" + "".PadLeft(40, '-'));

        }

        /// <summary>
        /// Test the custom Linked List with ints
        /// </summary>
        private static void TestLinkedList(IList<int> linkedList)
        {
            Console.WriteLine("\n" + "".PadLeft(40, '-'));
            Console.WriteLine("\n*** Testing: " + linkedList.GetType());

            // Clear to be safe
            linkedList.Clear();
            Console.WriteLine($"\n{linkedList.Count} elements - First: {linkedList.First} Last: {linkedList.Last}");

            // Add 5 numbers
            Console.Write("Adding data: ");
            for (int i = 1; i <= 5; i++)
            {
                Console.Write(i + " ");
                linkedList.Add(i);
            }
            Console.WriteLine($"\n{linkedList.Count} elements - First: {linkedList.First} Last: {linkedList.Last}");

            // Remove the head
            linkedList.Remove(1);
            Console.WriteLine($"\nRemoved 1\n{linkedList.Count} elements -  First: {linkedList.First} Last: {linkedList.Last}");

            // Remove the tail
            linkedList.Remove(5);
            Console.WriteLine($"\nRemoved 5\n{linkedList.Count} elements -  First: {linkedList.First} Last: {linkedList.Last}");

            // Add to the end
            linkedList.Add(6);
            Console.WriteLine($"\nAdded 6 to the end\n{linkedList.Count} elements -  First: {linkedList.First} Last: {linkedList.Last}");

            // Insert at the beginning
            linkedList.Insert(0, 7);
            Console.WriteLine($"\nInsert 7 before index 0\n{linkedList.Count} elements -  First: {linkedList.First} Last: {linkedList.Last}");

            // Insert into 2nd loc
            linkedList.Insert(1, 8);
            Console.WriteLine($"\nInsert 8 before index 1\n{linkedList.Count} elements -  First: {linkedList.First} Last: {linkedList.Last}");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write($" {linkedList[i]}");
            }

            Console.WriteLine();

        }


        /// <summary>
        /// Make sure everything still works when storing sorted ints
        /// </summary>
        private static void TestIntCollections(List<ISortedCollection<int>> collections)
        {
            Console.WriteLine("\n" + "".PadLeft(40, '-'));
            foreach (ISortedCollection<int> c in collections)
            {
                Console.WriteLine("\n*** Testing: " + c.GetType());

                // clear first to be safe
                c.Clear();

                // Print a summary of the empty sorted collection
                Console.WriteLine(
                    "The sorted collection has {0} elements and thus IsEmpty returns {1}:",
                    c.Count,
                    c.IsEmpty);
                PrintSortedCollection(c);
                Console.WriteLine(
                    "\nThe min and max are {0} and {1}.",
                    c.Min(),
                    c.Max());

                // Add 25 unsorted numbers
                int[] data = new int[] { 26, 39, 59, 78, 59, 93, 81, 58, 12, 42, 31, 91, 38, 14, 37, 83, 69, 95, 57, 58, 82, 53, 8, 40, 17 };
                for (int i = 0; i < data.Length; i++)
                {
                    c.Add(data[i]);
                }

                // Print a summary of the sorted collection
                Console.WriteLine(
                    "The sorted collection has {0} elements and thus IsEmpty returns {1}:",
                    c.Count,
                    c.IsEmpty);
                PrintSortedCollection(c);
                Console.WriteLine(
                    "\nThe min and max are {0} and {1}.",
                    c.Min(),
                    c.Max());

                // And test the other methods
                if (c.Contains(42))
                {
                    Console.WriteLine("\nWe also snuck the meaning of life.");
                }

                if (!c.Contains(106))
                {
                    Console.WriteLine("\nBut not our course number.");
                }
            }

        }


        /// <summary>
        /// Test storing sorted strings
        /// </summary>
        private static void TestStringCollections(List<ISortedCollection<string>> collections)
        {
            Console.WriteLine("\n" + "".PadLeft(40, '-'));
            foreach (ISortedCollection<string> c in collections)
            {
                Console.WriteLine("\n*** Testing: " + c.GetType());

                Console.WriteLine("The sortedStrings list has {0} elements so IsEmpty is {1}",
                    c.Count, c.IsEmpty);

                c.Add("Pax");
                c.Add("Shiro");
                c.Add("Lacy");
                c.Add("Aiden");

                Console.WriteLine("\nThe sortedStrings list now has {0} elements so IsEmpty is {1}",
                    c.Count, c.IsEmpty);
                PrintSortedCollection(c);

                Console.WriteLine(
                    "\nThe min and max are {0} and {1}.",
                    c.Min(),
                    c.Max());
            }
        }

        /// <summary>
        /// Test storing sorted objects
        /// </summary>
        private static void TestPlayerCollections(List<ISortedCollection<Player>> collections)
        {
            Console.WriteLine("\n" + "".PadLeft(40, '-'));
            foreach (ISortedCollection<Player> c in collections)
            {
                Console.WriteLine("\n*** Testing: " + c.GetType());

                Console.WriteLine("The sortedPlayers list has {0} elements so IsEmpty is {1}",
                    c.Count, c.IsEmpty);

                Console.WriteLine(
                    "\nThe lowest score belongs to: {0}\nThe highest score belongs to: {1}\n",
                    c.Min(),
                    c.Max());

                c.Add(new Player("Pax", 2));
                c.Add(new Player("Aiden", 17));
                c.Add(new Player("Lacy", 1));
                c.Add(new Player("Shiro", 4));

                Console.WriteLine("Does the list contain Pax? {0}", c.Contains(new Player("Pax", 0)));
                Console.WriteLine("Does the list contain a player with a score of 4? {0}", c.Contains(new Player("???", 4)));
                Console.WriteLine("Does the list contain a player with a score of 5? {0}", c.Contains(new Player("???", 5)));

                Console.WriteLine("\nThe sortedPlayers list now has {0} elements so IsEmpty is {1}",
                    c.Count, c.IsEmpty);
                PrintSortedCollection(c);

                Console.WriteLine(
                    "\nThe lowest score belongs to: {0}\nThe highest score belongs to: {1}\n",
                    c.Min(),
                    c.Max());
            }
        }

        /// <summary>
        /// Print everything in the sorted collection
        /// </summary>
        private static void PrintSortedCollection<T>(ISortedCollection<T> collection) where T : IComparable
        {
            for (int i = 0; i < collection.Count; i++)
            {
                Console.WriteLine(" - " + collection[i]);
            }
        }

        /// <summary>
        /// Use a given random number generator to run time trials of adding elements
        /// into a collection given the add and clear methods (so we don't need to know
        /// what kind of collection we're working with)
        /// </summary>
        private static void AddTimeTrials(Random rng, string label, AddMethod addMethod, ClearMethod clearMethod, int maxData = 50000)
        {
            Console.WriteLine(label + " - adding:");
            Console.WriteLine("\t# \tAvg\tMin\tMax\tTotal");

            int step = maxData / 10;
            for (int dataSize = step; dataSize <= maxData; dataSize += step)
            {
                // Start with an empty collection and reset the data tracking
                clearMethod();
                double minMS = double.MaxValue;
                double maxMS = double.MinValue;
                double totalMs = 0;

                // Run add the correct # of times
                for (int i = 0; i < dataSize; i++)
                {
                    DateTime start = DateTime.Now; // Start time
                    addMethod(rng.Next(dataSize + 1));
                    double ms = (DateTime.Now - start).TotalMilliseconds; // Elapsed time

                    // Update data tracking
                    totalMs += ms;
                    if (ms < minMS)
                        minMS = ms;
                    if (ms > maxMS)
                        maxMS = ms;

                }

                // Output results
                Console.WriteLine("\t{0}\t{1:F4}\t{2:F4}\t{3:F4}\t{4:F4}", dataSize, totalMs / dataSize, minMS, maxMS, totalMs);

                // quit early if things are taking a long time
                if (totalMs / dataSize > 10)
                {
                    break;
                }
            }
        }

    }
}