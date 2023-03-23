using System;

namespace SortedCollections
{
    /// <summary>
    /// Store the data for a specific node in a LL + a reference to the
    /// next node in the list.
    /// Supplied by Prof. Mesh.
    /// DO NOT MODIFY THIS CODE
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyLinkedNode<T> where T: IComparable
    {
        // Nodes contain 2 pieces of data: the data for the node and a reference to
        // the next node in the list. Create public get/set properties for these
        // so that the main LL class can manage them.
        public T Data { get; set; }
        public MyLinkedNode<T> Next { get; set; }

        // We also want a constructor that takes data and
        // sets Next to null
        public MyLinkedNode(T data)
        {
            Data = data;
            Next = null; // it would be by default, but let's be explicit
        }

        // ToString should just return the data
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
