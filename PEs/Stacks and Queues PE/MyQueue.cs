using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_and_Queues_PE
{
    internal class MyQueue<T> : IQueue<T>
    {
        List<T> list;

        public MyQueue()
        {
            list = new List<T>();
        }

        /// <summary>
        /// Gets the current count of items in the queue
        /// </summary>
        public int Count
        { 
            get { return list.Count; }
        }


        /// <summary>
        /// Gets whether or not there are items in the queue
        /// </summary>
        public bool IsEmpty
        { 
            get { return list.Count == 0; }
        }

        /// <summary>
        /// Look at and return the front of the queue.
        /// </summary>
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
        /// Adds new data to the end of the queue
        /// </summary>
        /// <param name="item">The data to add</param>
        public void Enqueue(T item)
        { 
            list.Add(item);
        }

        /// <summary>
        /// Removes and returns the data in the front
        /// of the queue.
        /// </summary>
        public T Dequeue()
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
