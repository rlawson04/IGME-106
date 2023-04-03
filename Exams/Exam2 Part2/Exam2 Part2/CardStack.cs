using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2_Part2
{
    /// <summary>
    /// Class that inherits from the IStack interface to keep a stack of the cards
    /// </summary>
    internal class CardStack<T> : IStack<T>
    {
        // Underlying list of type T
        private List<T> list;

        /// <summary>
        /// Public constructor of the CardStack Class
        /// </summary>
        public CardStack()
        {
            list = new List<T>();
        }

        /// <summary>
        /// Returns the count of the list
        /// </summary>
        public int Count
        {
            get { return list.Count; }
        }

        /// <summary>
        /// check to see if there is data in the stack (false) or
        /// if it's empty (true).
        /// </summary>
        public bool isEmpty()
        { 
            if (list.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// push an item onto the stack
        /// </summary>
        /// <param name="item"> The data to add </param>
        public void Push(T item)
        {
            list.Insert(0, item);
        }

        /// <summary>
        /// pop the top off of the stack
        /// </summary>
        /// <returns> Data on top of the stack or null/ default T </returns>
        public T Pop()
        {
            // If no items are in the list return default
            if (list.Count == 0)
            {
                return default(T);
            }
            else
            {
                list.RemoveAt(0);

                // After removing the item, return the top of the list or default if the list is now empty
                if (list.Count > 0)
                {
                    return list[0];
                }
                else
                {
                    return default(T);
                }
                
            }

        }

        /// <summary>
        /// clear the stack by removing all items
        /// from the underlying data structure
        /// </summary>
        public void Clear()
        {
            list.Clear();
        }
    }
}
