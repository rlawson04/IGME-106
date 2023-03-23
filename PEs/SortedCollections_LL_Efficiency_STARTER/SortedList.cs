using System;
using System.Collections.Generic;

namespace SortedCollections
{
    /// <summary>
    /// Implements a sorted collection using a C# List under the hood.
    /// Supplied by Prof. Mesh.
    /// DO NOT MODIFY THIS CODE
    /// </summary>
    /// <typeparam name="T">The type on comparable data stored in this collection</typeparam>
    class SortedList<T> : ISortedCollection<T> where T : IComparable
    {
        /// <summary>
        /// Underlying List to manage the data
        /// </summary>
        private List<T> myData = new List<T>();

        /// <summary>
        /// Gets the current number of items in the collection
        /// </summary>
        public int Count
        {
            get
            {
                return myData.Count;
            }
        }

        /// <summary>
        /// Gets whether or not there are items in the collection
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return Count == 0;
            }
        }

        /// <summary>
        /// Indexer to allow retrieval of a specific element in the
        /// sorted collection (but NOT setting it since that could result in
        /// out of order data!)
        /// </summary>
        /// <returns>The data at index i</returns>
        /// <throws>An IndexOutOfRangeException for invalid indices</throws>
        public T this[int i]
        {
            get
            {
                return myData[i];
            }
        }

        /// <summary>
        /// Adds the given new data to the collection using CompareTo
        /// to determine where the newData fits.
        /// 
        /// newData.CompareTo(element) returns < 0 when the newData
        /// is less than the element
        /// </summary>
        public void Add(T newData)
        {
            // If the list is empty or the data is bigger than the max value, just add and return
            if (Count == 0 || newData.CompareTo(Max()) >= 0)
            {
                myData.Add(newData);
                return;
            }

            // For every index, i, in the underlying List:
            for (int i = 0; i < myData.Count; i++)
            {
                // If the newData to add is < the data at index i
                if (newData.CompareTo(myData[i]) < 0)
                {
                    // Insert the data at index i
                    myData.Insert(i, newData);

                    // Break out of the loop
                    return;
                }
            }

            // if we make it this far, something bad happened
            throw new InvalidOperationException("The sorted LL add is broken...");
        }

        /// <summary>
        /// Removes all data from the collection
        /// </summary>
        public void Clear()
        {
            myData.Clear();
        }

        /// <summary>
        /// Returns true if the data is already in this collection
        /// by using CompareTo to determine if the data matches an element
        /// 
        /// data.CompareTo(element) returns 0 if they are equal
        /// </summary>
        public bool Contains(T data)
        {
            foreach (T element in myData)
            {
                if (data.CompareTo(element) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Return the smallest value
        /// (or the default for the type if the list is empty)
        /// </summary>
        public T Min()
        {
            if (!IsEmpty)
                return myData[0];
            else
                return default(T);
        }

        /// <summary>
        /// Return the largest value
        /// (or the default for the type if the list is empty)
        /// </summary>
        public T Max()
        {
            if (!IsEmpty)
                return myData[Count-1];
            else
                return default(T);
        }
    }
}

