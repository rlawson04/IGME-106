using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedCollections
{
	/// <summary>
	/// Holds a single piece of data in a tree,
	/// along with up to two child nodes
	/// DO NOT MODIFY THIS CODE EXCEPT WHERE MARKED WITH "TODO"
	/// </summary>
	/// <typeparam name="T">The type on comparable data stored in this collection</typeparam>
	class MySearchTreeNode<T> where T : IComparable
    {
		/// <summary>
		/// Gets or sets the data of this node
		/// </summary>
		public T Data { get; set; }

		/// <summary>
		/// Gets or sets this node's left child
		/// </summary>
		public MySearchTreeNode<T> Left { get; set; }

		/// <summary>
		/// Gets or sets this node's right child
		/// </summary>
		public MySearchTreeNode<T> Right { get; set; }

		/// <summary>
		/// Creates a node with the specified data
		/// </summary>
		/// <param name="data">The data to store in this node</param>
		public MySearchTreeNode(T data)
		{
			Data = data;
			Left = null;
			Right = null;
		}
	}
}
