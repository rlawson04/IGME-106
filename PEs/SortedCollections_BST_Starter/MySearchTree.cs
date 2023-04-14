using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedCollections
{
    /// <summary>
    /// Tree-centric binary search tree
    /// DO NOT MODIFY THIS CODE EXCEPT WHERE MARKED WITH "TODO"
    /// </summary>
    /// <typeparam name="T">The type on comparable data stored in this collection</typeparam>
    class MySearchTree<T> : ISortedCollection<T> where T : IComparable
    {
        /// <summary>
        /// Store the root if this tree
        /// </summary>
        private MySearchTreeNode<T> root;

        /// <summary>
        /// Gets the current number of items in the collection
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets whether or not there are items in the collection
        /// </summary>
        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Public methods that run the private ones by always starting at the root
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// Adds the given new data to the tree by calling the private Add method
        /// to add recursively starting at the root
        /// </summary>
        public void Add(T newData)
        {
            if (root != null)
            {
                // Add the new data starting at the root node if it already exists
                Add(newData, root);
            }
            else
            {
                // Otherwise, use this data to create a root node
                root = new MySearchTreeNode<T>(newData);
            }

            // Always increment the count
            Count++;
        }

        /// <summary>
        /// Removes all data from the collection
        /// </summary>
        public void Clear()
        {
            root = null;
            Count = 0;
        }

        /// <summary>
        /// Returns true if the data is already in this tree
        /// 
        /// data.CompareTo(element) returns 0 if they are equal
        /// </summary>
        public bool Contains(T data)
        {
            if(IsEmpty)
            {
                return default;
            }
            else
            {
                return Contains(data, root);
            }
        }

        /// <summary>
        /// Return the smallest value
        /// (or the default for the type if the tree is empty)
        /// </summary>
        public T Min()
        {
            if (IsEmpty)
            {
                return default;
            }
            else
            {
                return Min(root);
            }
        }

        /// <summary>
        /// Return the largest value
        /// (or the default for the type if the tree is empty)
        /// </summary>
        public T Max()
        {
            if (IsEmpty)
            {
                return default;
            }
            else
            {
                return Max(root);
            }
        }

        /// <summary>
        /// Print all the data in the tree
        /// </summary>
        public void Print()
        {
            if (!IsEmpty)
            {
                Print(root);
            }
        }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Private recursive methods that run starting at a given node
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// Adds the given new data to the tree by calling the private Add method
        /// to add recursively starting at the root
        /// 
        /// newData.CompareTo(node.Data) returns < 0 when the newData
        /// is less than the node's data
        /// </summary>
        private void Add(T newData, MySearchTreeNode<T> node)
        {
            // TODO: Implement this!
        }

        /// <summary>
        /// Returns true if the data is already in the subtree starting at the given node
        /// 
        /// data.CompareTo(node.Data) returns 0 if they are equal
        /// data.CompareTo(node.Data) returns < 0 when the data is less than the node's data
        /// </summary>
        private bool Contains(T data, MySearchTreeNode<T> node)
        {
            // TODO: Implement this!
        }

        /// <summary>
        /// Return the smallest value in the subtree starting at the given node
        /// </summary>
        private T Min(MySearchTreeNode<T> node)
        {
            // TODO: Implement this!
        }

        /// <summary>
        /// Return the largest value in the subtree starting at the given node
        /// </summary>
        private T Max(MySearchTreeNode<T> node)
        {
            // TODO: Implement this!
        }

        /// <summary>
        /// Print all the data in the tree
        /// </summary>
        private void Print(MySearchTreeNode<T> node)
        {
            // TODO: Implement this!
        }



    }
}
