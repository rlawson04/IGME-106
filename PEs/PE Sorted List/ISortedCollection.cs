using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Sorted_List
{
    internal interface ISortedCollection
    {
        /// <summary>
        /// Gets the current number of items in the collection
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets whether or not there are items in the collection
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Adds the given new data to the collection
        /// </summary>
        void Add(int newData);

        /// <summary>
        /// Removes all data from the collection
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns true if the data is already in this collection
        /// </summary>
        bool Contains(int data);

        /// <summary>
        /// Return the smallest value (or MinValue if the list is empty)
        /// </summary>
        int Min();

        /// <summary>
        /// Return the largest value (or MaxValue if the list is empty)
        /// </summary>
        int Max();

        /// <summary>
        /// Prints all the data, sorted, to the console.
        /// </summary>
        void Print();
    

    }
}
