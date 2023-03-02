using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PE_Sorted_List
{
    internal class SortedList : ISortedCollection
    {
        //----------------------------------------
        // Fields
        //----------------------------------------
        private List<int> ints;

        //----------------------------------------
        // Constructor
        //----------------------------------------

        /// <summary>
        /// Default constructor to initialize the list on integers in a public capacity
        /// </summary>
        public SortedList()
        {
            ints = new List<int>();           
        }

        //----------------------------------------
        // Properties
        //----------------------------------------

        /// <summary>
        /// Calls the int.Count method on the list and returns it to the program
        /// </summary>
        public int Count
        {
            get { return ints.Count; }
        }

        /// <summary>
        /// Checks if the list has any values in it
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (ints.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //----------------------------------------
        // Methods
        //----------------------------------------

        
        /// <summary>
        /// Adds the given number to the list once it finds a value less than the iterated index,
        /// If no value is less than it, it is the max and gets added to the end of the list
        /// </summary>
        /// <param name="newData"> A passed int that will be sorted into the list </param>
        public void Add(int newData)
        {
            bool added = false;

            // Makes sure that there is a number in the list so no error is caused at ints.count
            if (ints.Count == 0)
            {    
            }
            else
            {
                for (int i = 0; i < ints.Count; i++)
                {
                    if (newData < ints[i])
                    {
                        ints.Insert(i, newData);
                        added = true;
                        break;
                    }
                }
            }

            // Adds the number onto the end if it is the first or greatest value
            if(added == false)
            {
                ints.Add(newData);
            }

        }

        /// <summary>
        /// Checks if the input integer is in the list or not through brute iteration
        /// </summary>
        /// <param name="data"> takes in an integer value to check </param>
        /// <returns></returns>
        public bool Contains(int data)
        {
            bool contain = false;
            for (int i = 0; i <ints.Count; i++)
            {
                if (ints[i] == data)
                {
                    contain = true;
                }
            }
            return contain;
        }

        /// <summary>
        /// Calls the clear method on the list
        /// </summary>
        public void Clear()
        {
            ints.Clear();
        }

        /// <summary>
        /// Prints each number onto a new line
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < ints.Count; i++)
            {
                Console.WriteLine(ints[i]); 
            }
        }

        /// <summary>
        /// Checks if the list has any values in it 
        /// </summary>
        /// <returns> The smallest value in the list or -2 billion </returns>
        public int Min()
        {
            if (ints.Count == 0)
            {
                return int.MinValue;
            }
            else
            {
                return ints[0];
            }
        }

        /// <summary>
        /// Checks if the list has any values in it 
        /// </summary>
        /// <returns> The largest value in the list or 2 billion </returns>
        public int Max()
        {
            if (ints.Count == 0)
            {
                return int.MaxValue;
            }
            else
            {
                return ints[ints.Count-1];
            }
        }
    }
}
