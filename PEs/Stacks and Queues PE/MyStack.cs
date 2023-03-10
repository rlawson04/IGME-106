using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_and_Queues_PE
{
    internal class MyStack<T> : IStack<T> 
    {
        
        // List of type T
        private List<T> list;
        
        public MyStack()
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
        /// Checks whether there are elements in the list
        /// </summary>
        public bool IsEmpty
        {
            get { return list.Count == 0; }
        }

        /// <summary>
        /// Looks at and returns the top of the stack
        /// </summary>
        /// <returns> the top of the stack or null/ default T </returns>
        public T Peek()
        {
            if (list.Count == 0)
            {
                return default(T);
            }
            else
            {
                
                return list[0]; 
            }
        }

        /// <summary>
        /// Adds new data to the top of the stack
        /// </summary>
        /// <param name="item"> The data to add </param>
        public void Push(T item)
        { 
            list.Insert(0,item);            
        }

        /// <summary>
        /// Removes and returns the data on top of the stack
        /// </summary>
        /// <returns> Data on top of the stack or null/ default T </returns>
        public T Pop()
        { 
            if (list.Count == 0)
            {
                return default(T);
            }
            else
            {
                list.RemoveAt(0);
                return list[0];
            }
            
        }
    }
}
