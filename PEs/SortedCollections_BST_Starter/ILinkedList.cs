using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedCollections
{
    interface ILinkedList<T>
    {
        /// <summary>
        /// Gets the current number of items in the collection
        /// </summary>
        int Count { get; }

        /// <summary>
        ///  Return the first element
        /// </summary>
        T First { get; }

        /// <summary>
        /// Return the last element
        /// </summary>
        T Last { get; }

        /// <summary>
        /// Indexer to allow get/set of a specific element in the LL
        /// </summary>
        /// <returns>The data at index i</returns>
        /// <throws>An IndexOutOfRangeException for invalid indices</throws>
        T this[int index] { get; set; }

        /// <summary>
        /// Insert the data before a given index
        /// </summary>
        /// <param name="index">The index of the element to insert the data before</param>
        /// <param name="newData">The data to insert</param>
        void Insert(int index, T newData);

        /// <summary>
        /// Adds the given new data to the end of the list
        /// </summary>
        void Add(T data);

        /// <summary>
        /// Find the node containing the data and remove it
        /// </summary>
        bool Remove(T data);

        /// <summary>
        /// Removes all data from the collection
        /// </summary>
        void Clear();
    }
}
