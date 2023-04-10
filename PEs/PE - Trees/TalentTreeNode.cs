using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PE___Trees
{
    internal class TalentTreeNode
    {

        string abilityName;
        bool isLearned;

        /// <summary>
        /// Reference for the left child node
        /// </summary>
        public TalentTreeNode Left { get; set; }

        /// <summary>
        /// Reference for the right child node
        /// </summary>
        public TalentTreeNode Right { get; set; }


        /// <summary>
        /// Parameterized constructor that takes the name of the ability, and whether it has been learned
        /// </summary>
        /// <param name="abilityName"></param>
        /// <param name="isLearned"></param>
        public TalentTreeNode(string abilityName, bool isLearned)
        {
            Left = null;
            Right = null;
            this.abilityName = abilityName;
            this.isLearned = isLearned;
        }

        /// <summary>
        /// Lists all abilities in the tree
        /// </summary>
        public void ListAllAbilities()
        {
            // Prints out all nodes from left to right 
            if (this.Left != null)
            {
                this.Left.ListAllAbilities();
            }

            Console.WriteLine(this.abilityName);

            if (this.Right != null) 
            {
                this.Right.ListAllAbilities();
            }
        }

        /// <summary>
        /// Lists all abilities that are learned
        /// </summary>
        public void ListKnownAbilities()
        {
            // Prints the known ability, and then any children that are learned
            Console.WriteLine("Known ability: " + this.abilityName);

            if (this.Left != null && this.Left.isLearned)
            {
                this.Left.ListKnownAbilities();
            }

            if (this.Right != null && this.Right.isLearned)
            {
                this.Right.ListKnownAbilities();
            }

        }

        /// <summary>
        /// Lists any abilities that have the parent learned
        /// </summary>
        public void ListPossibleAbilities()
        {
            // Prints the next possible ability ignoring the ones learned,
            // and the children of an unlearned ability
            if (this.Right != null && this.isLearned == false)
            {
                Console.WriteLine("Possible ability: " + this.abilityName);
                return;
            }

            if (this.Left != null && this.isLearned == false)
            {
                Console.WriteLine("Possible ability: " + this.abilityName);
                return;
            }

            if (this.Left != null)
            {
                this.Left.ListPossibleAbilities();
            }

            if (this.Right != null)
            {
                this.Right.ListPossibleAbilities();
            }

            if (this.isLearned == false)
            {
                Console.WriteLine("Possible ability: " + this.abilityName);
            }
           
        }
    }
}
