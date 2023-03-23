using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedCollections
{
    /// <summary>
    /// A singly linked list implemented with tracking of the head AND tail nodes.
    /// Supplied by Prof. Mesh.
    /// DO NOT MODIFY THIS CODE
    /// </summary>
    /// <typeparam name="T">The type of data the LL will store</typeparam>
    class MyLinkedList_v2<T> : ILinkedList<T> where T : IComparable
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
                if (tail != null)
                {
                    return tail.Data;
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
                for(int i=0; i<index; i++)
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
            if(Count == 0 && index == 0)
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
            // TODO: Add comments to everything in this method
            // TODO: This method is also broken. Figure out why and fix it without adding a loop!

            // Creates new node using the data
            MyLinkedNode<T> newNode = new MyLinkedNode<T>(data);

            // Find if the head is empty
            if(head == null)
            {
                // Makes new head and tail using the node
                head = newNode;
                tail = newNode;
            }
            else
            {
                // If head exists, the new node becomes the tail
                tail.Next = newNode;
                tail = newNode;
            }

            // Increases the count since a new element is added
            count++;
        }

        /// <summary>
        /// Find the node containing the data and remove it
        /// </summary>
        public bool Remove(T data)
        {
            // TODO: Add comments to everything in this method
            // TODO: This method is also broken. Figure out why and fix it without adding a loop!

            // If there is a head, and the data is at the head
            if (head != null && head.Data.CompareTo(data) == 0)
            {
                // Change the heads reference to the next head reduce the count, and return true
                head = head.Next;
                count--;
                return true;
            }

            // Loops until there are no more nodes or the node before the one wanted is found
            MyLinkedNode<T> previous = head;
            while (previous != null && previous.Next != null && previous.Next.Data.CompareTo(data) != 0)
            {
                previous = previous.Next;
            }

            // If the correct node before the wanted one is found
            if(previous != null && previous.Next != null && previous.Next.Data.CompareTo(data) == 0)
            {
                // If the last element would be removed, update the tail
                if (previous.Next == tail)
                {
                    tail = previous;
                }

                // Makes the previous node's next equal to the node after the one wanted
                previous.Next = previous.Next.Next;

                // Lower count and return true
                count--;
                return true;
            }
            else
            {
                // return that the data couldn't be removed
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
            tail = null;
        }

    }
}
