using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedCollections_LL_Efficiency
{
    /// <summary>
    /// Implements a sorted collection by managing the LL nodes itself.
    /// Supplied by Prof. Mesh.
    /// DO NOT MODIFY THIS CODE
    /// </summary>
    /// <typeparam name="T">The type on comparable data stored in this collection</typeparam>
    class SortedLL_v2<T> : ISortedCollection<T> where T : IComparable
    {
        // Singly LL managed via head and tail + count
        private MyLinkedNode<T> head = null;
        private MyLinkedNode<T> tail = null;
        private int count = 0;

        /// <summary>
        /// Gets the current number of items in the collection
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Gets whether or not there are items in the collection
        /// </summary>
        public bool IsEmpty
        {
            get { return count == 0; }
        }

        /// <summary>
        /// Return the smallest value
        /// (or the default for the type if the list is empty)
        /// </summary>
        public T Min()
        {
            if (head != null)
            {
                return head.Data;
            }
            return default(T);
        }

        /// <summary>
        /// Return the largest value
        /// (or the default for the type if the list is empty)
        /// </summary>
        public T Max()
        {
            if (tail != null)
            {
                return tail.Data;
            }
            return default(T);
        }

        /// <summary>
        /// Indexer to allow retrieval of a specific element in the
        /// sorted collection (but NOT setting it since that could result in
        /// out of order data!)
        /// </summary>
        /// <returns>The data at index i</returns>
        /// <throws>An IndexOutOfRangeException for invalid indices</throws>
        public T this[int index]
        {
            get
            {
                // Ensure the index is valid. If not, throw an exception.
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid for list with count {1}", index, Count));
                }

                // Starting at the head, loop until we have a reference
                // to the node in at the given index
                MyLinkedNode<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                // Return the data at that node
                return current.Data;
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
            // Create a new node
            MyLinkedNode<T> newNode = new MyLinkedNode<T>(newData);

            // If the LL is empty, just add and return
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                count++;
                return;
            }

            // If the new data is smaller than head
            // no need to search for where to put it
            if (newData.CompareTo(head.Data) < 0)
            {
                newNode.Next = head;
                head = newNode;
                count++;
                return;
            }

            // If the new data is bigger than tail
            // no need to search for where to put it
            if (newData.CompareTo(tail.Data) >= 0)
            {
                tail.Next = newNode;
                tail = newNode;
                count++;
                return;
            }

            // If we made it this far, it's going in the middle somewhere...
            // Starting at the head, loop while we still have nodes left
            MyLinkedNode<T> current = head;
            while (current.Next != null)
            {
                // if the new data is less than the node after current
                // we've found where to insert
                if (newData.CompareTo(current.Next.Data) < 0)
                {
                    // Set the new node to refer to current's next
                    newNode.Next = current.Next;

                    // set current to refer to the new node
                    current.Next = newNode;

                    // and we're done - update the count and return
                    count++;
                    return;
                }

                // Move onto the next node
                current = current.Next;
            }

            // if we make it this far, something bad happened
            throw new InvalidOperationException("The sorted LL add is broken...");

        }

        /// <summary>
        /// Removes all data from the collection
        /// </summary>
        public void Clear()
        {
            count = 0;
            head = null;
            tail = null;
        }

        /// <summary>
        /// Returns true if the data is already in this collection
        /// by using CompareTo to determine if the data matches an element
        /// 
        /// data.CompareTo(element) returns 0 if they are equal
        /// </summary>
        public bool Contains(T data)
        {
            MyLinkedNode<T> current = head;
            while (current.Next != null)
            {
                if (current.Data.CompareTo(data) == 0)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

    }
}
