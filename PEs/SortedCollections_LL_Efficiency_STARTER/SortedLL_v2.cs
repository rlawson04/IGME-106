using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedCollections
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

            // TODO: Add a comment here about why allowing a set by index to any sorted collection would be a bad idea without also supporting removal?
            // Allowing a set by index to any sorted collection would be a bad idea without also supporting removal becuase
            // it could result in out of order data therefore not allowing a set ensures the data will be in order
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
            // TODO: Add comments to everything in this method

            // Creates a new node using data
            MyLinkedNode<T> newNode = new MyLinkedNode<T>(newData);

            // If the list is empty, add the node and increase count 
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                count++;
                return;
            }
            
            // If the new data is less than the head it puts it before the head
            if (newData.CompareTo(head.Data) < 0)
            {
                newNode.Next = head;
                head = newNode;
                count++;
                return;
            }

            // If the new data is more than the tail it puts it after the tail
            if (newData.CompareTo(tail.Data) >= 0)
            {
                tail.Next = newNode;
                tail = newNode;
                count++;
                return;
            }

            // TODO: Make sure to explain why we need a loop here, but didn't in the MyLinkedList_v2 Add()

            // The data must go in the middle so it has to be before the tail whose next is null
            MyLinkedNode<T> current = head;
            while(current.Next != null)
            {
                // If the new data is less than the data after the current one, insert the data here 
                if (newData.CompareTo(current.Next.Data) < 0)
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    count++;
                    return;
                }

                // Moves onto the next node
                current = current.Next;
            }

            // Something messed up
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
            while(current.Next != null)
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
