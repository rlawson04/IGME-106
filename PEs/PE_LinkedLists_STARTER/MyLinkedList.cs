using System;
using System.Diagnostics.Metrics;

namespace PE_LinkedLists
{
    /// <summary>
    /// A custom linked list.
    /// </summary>
    /// <typeparam name="T">This list is NOT sorted, but it requires types to implement IComparable
    /// so that later we can wrap this and make a custom sorted LL</typeparam>
    class MyLinkedList<T> where T : IComparable
    {
        // *******************************************************************************
        // DO NOT CHANGE/ADD TO THE CLASS FIELDS!
        // *******************************************************************************

        // Don't want to lose the chain of nodes, so track the head of the chain
        private MyLinkedNode<T> head = null;

        // *******************************************************************************
        // Properties and indexers
        // *******************************************************************************

        /// <summary>
        /// Auto-properties automatically create backing fields for us. In this case,
        /// it it only allows the underlying field for the count to be set within this
        /// class.
        /// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Add an indexer that allows get and set access to the data within 
        /// an existing node by index. For both get & set, make sure to throw an 
        /// IndexOutOfRangeException if the index given is out of range based on 
        /// the current count of the list.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                // TODO: Implement the get for the indexer
                // Check the index

                // Start at the head

                // Hop down the chain index # of times

                // Return the data where we stopped

                // Throws an exception if the index is larger or equal to the count
                if(index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                
                // Keeps track to iterate through
                MyLinkedNode<T> currentNode = head;
                
                // iteration to find which data the index wants
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
                                
                // Returns the node once it is found at the given index
                return currentNode.Data;
                   
                
                
                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            }
            set
            {
                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                // TODO: Implement the set for the indexer
                // Check the index

                // Start at the head

                // Hop down the chain index # of times

                // Set the data where we stopped

                // Throws an exception if the index is larger or equal to the count
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                // Keeps track to iterate through
                MyLinkedNode<T> currentNode = head;

                // iteration to find which data the index wants
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                // If the current node is not null, it sets the data to the value
                if (currentNode != null)
                {
                    currentNode.Data = value;
                }
                            
                
                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            }
        }

        /// <summary>
        /// Add a new node with given data to the END of the list
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Implement the Add method
            // Adding to an empty list, set the head

            // Adding to the end of a non - empty list!
            // We need to find the end first - and we have to start at head to do that

            // Hop down the chain of nodes until we hit the end (i.e. the node with no next)

            // Now make that last node refer to the new one

            // No matter how we added, update the count

            // New node to add
            MyLinkedNode<T> newNode = new MyLinkedNode<T>(data); 

            // If empty list, adds node as new head
            if (head == null)
            {
                head = newNode;
                Count++;
                return;
            }

            // Checks current node and iterates through the nodes
            MyLinkedNode<T> currentNode = head;
            while(currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            // Once it finds a null node, it makes a new node at the end
            currentNode.Next = newNode;
            Count++;
            
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Look for the node with a specific piece of data and remove it
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Remove(T data)
        {
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Implement the Remove method
            // Quit if nothing to remove

            // If the data is at the head, change head to reference head's Next, 
            // reduce the count, and return true

            // If it's after head (anywhere after head), we have to search for it

            // Hop down the chain checking if we found what to remove as we go

                // We actually want to check if we're removing the node AFTER the one
                // we're currently on.

            // If we got this far, we didn't find anything to remove

            // Bool to keep track of the return value
            bool check = false;

            // Node to keep track of the current node when iterating
            MyLinkedNode<T> currentNode = head;

            // When the data is referenced to the head
            if (head.Data.CompareTo(data) == 0)
            {
                head = head.Next;
                Count--;
                check = true;
            }

            // When it is any other value in the list
            else 
            {
                // Iterates through and finds the index then skips over it
                // by setting its next to the next of the next
                for (var i = 0; i < Count; i++)
                {
                    if (currentNode.Next.Data.CompareTo(data) == 0)
                    {

                        currentNode.Next = currentNode.Next.Next;
                        Count--;
                        check = true;
                        break;
                    }

                    currentNode = currentNode.Next;
                }
            }
            
            // Returns the bool from above
            return check;
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Clear the LL by abandoning all the nodes
        /// </summary>
        public void Clear()
        {
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Implement the Clear method. You do NOT need a loop here!!!

            // Resets the head and the count
            head = null;
            Count = 0;
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }
    }
}
