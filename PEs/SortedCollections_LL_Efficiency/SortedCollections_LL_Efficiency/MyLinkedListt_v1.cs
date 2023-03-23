using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedCollections_LL_Efficiency
{
    /// <summary>
    /// A singly linked list implemented with tracking of the head only.
    /// Supplied by Prof. Mesh.
    /// DO NOT MODIFY THIS CODE
    /// </summary>
    /// <typeparam name="T">The type of data the LL will store</typeparam>
    class MyLinkedList_v1<T> : IList<T> where T : IComparable
    {
        // Singly LLs manage 2 fields: current count and a reference to the head
        private MyLinkedNode<T> head = null;
        private int count = 0;

        /// <summary>
        /// Gets the current number of items in the collection
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        ///  Return the first element
        /// </summary>
        public T First
        {
            get
            {
                if (head != null)
                {
                    return head.Data;
                }
                return default(T);
            }
        }

        /// <summary>
        /// Return the last element
        /// </summary>
        public T Last
        {
            get
            {
                if (head != null)
                {
                    MyLinkedNode<T> current = head;
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }
                    return current.Data;
                }
                return default(T);
            }
        }

        /// <summary>
        /// Indexer to allow get/set of a specific element in the LL
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

            set
            {
                // Ensure the index is valid. If not, throw an exception.
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid for list with count {1}", index, Count));
                }

                // Starting at the head, loop until we have a reference
                // to the node at the given index
                MyLinkedNode<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                // Set the data at that node to the value given
                current.Data = value;
            }
        }

        /// <summary>
        /// Insert the data before a given index
        /// </summary>
        /// <param name="index">The index of the element to insert the data before</param>
        /// <param name="newData">The data to insert</param>
        public void Insert(int index, T newData)
        {
            // If the LL is empty and the insertion index is 0, treat it as an Add
            if (Count == 0 && index == 0)
            {
                this.Add(newData);
            }

            // Ensure the index is valid. If not, throw an exception.
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(String.Format("Index {0} is invalid for list with count {1}", index, Count));
            }

            // Create a new node
            MyLinkedNode<T> newNode = new MyLinkedNode<T>(newData);

            // If inserting at index 0, then make the new node refer to the current
            // head and then update the head
            if (index == 0)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                // Starting at the head, loop until we have a reference
                // to the node BEFORE the given index
                MyLinkedNode<T> current = head;
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }

                // Create a new node and set it to refer to the one at the index
                newNode.Next = current.Next;

                // Set the node before the index to refer to the new node
                current.Next = newNode;
            }

            // Update the count
            count++;
        }

        /// <summary>
        /// Adds the given new data to the end of the list
        /// </summary>
        public void Add(T data)
        {
            // Create a new node
            MyLinkedNode<T> newNode = new MyLinkedNode<T>(data);

            // Find out if the list is empty
            if (head == null)
            {
                // If so, make the new node our head
                head = newNode;
            }
            else
            {
                // If not, find the last node and then set it's Next to our new node
                MyLinkedNode<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }

            // Increment the count
            count++;
        }

        /// <summary>
        /// Find the node containing the data and remove it
        /// </summary>
        public bool Remove(T data)
        {
            // If the data is at the head, change head to reference head's Next, reduce the count, and return true
            if (head != null && head.Data.CompareTo(data) == 0)
            {
                head = head.Next;
                count--;
                return true;
            }

            // Loop until we run out of nodes or find the one before the one we want
            MyLinkedNode<T> previous = head;
            while (previous != null && previous.Next != null && previous.Next.Data.CompareTo(data) != 0)
            {
                previous = previous.Next;
            }

            // Did we find it?
            if (previous != null && previous.Next != null && previous.Next.Data.CompareTo(data) == 0)
            {
                // Set the previous node's Next to the the node AFTER the one we were looking for, reduce the count & return true
                previous.Next = previous.Next.Next;
                count--;
                return true;
            }
            else
            {
                // If not, return that we couldn't remove the data
                return false;
            }
        }

        /// <summary>
        /// Removes all data from the collection
        /// </summary>
        public void Clear()
        {
            count = 0;
            head = null;
        }

    }
}
