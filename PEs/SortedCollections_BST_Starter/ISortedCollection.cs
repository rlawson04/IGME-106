using System;

/// <summary>
/// ISortedCollection interface 
/// Supplied by Prof. Mesh.
/// DO NOT MODIFY THIS CODE
/// </summary>
namespace SortedCollections
{
    /// <summary>
    /// Defines common operations required for a sorted collection of ANY type
    /// that has a CompareTo method -- by requiring T to implement the IComparable
    /// interface - https://docs.microsoft.com/en-us/dotnet/api/system.icomparable 
    /// </summary>
    interface ISortedCollection<T> where T : IComparable
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
        /// Adds the given new data to the collection using CompareTo
        /// to determine where the newData fits.
        /// 
        /// newData.CompareTo(element) returns < 0 when the newData
        /// is less than the element
        /// </summary>
        void Add(T newData);

        /// <summary>
        /// Removes all data from the collection
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns true if the data is already in this collection
        /// by using CompareTo to determine if the data matches an element
        /// 
        /// data.CompareTo(element) returns 0 if they are equal
        /// </summary>
        bool Contains(T data);

        /// <summary>
        /// Return the smallest value
        /// (or the default for the type if the collection is empty)
        /// </summary>
        T Min();

        /// <summary>
        /// Return the largest value
        /// (or the default for the type if the collection is empty)
        /// </summary>
        T Max();

        /// <summary>
        /// Print all the data in the collection
        /// </summary>
        void Print();
    }
}
