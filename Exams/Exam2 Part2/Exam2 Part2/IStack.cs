using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2_Part2
{
    // interface for a stack
    internal interface IStack<T>
    {
        // check to see if there is data in the stack (false) or
        // if it's empty (true).
        bool isEmpty();

        // push an item onto the stack
        void Push(T item);

        // pop the top off of the stack
        T Pop();

        // clear the stack by removing all items
        // from the underlying data structure
        void Clear();
    }
}
