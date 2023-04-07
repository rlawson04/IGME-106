using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE___Trees
{
    internal class TalentTreeNode
    {

        string abilityName;
        bool isLearned;

        /// <summary>
        /// Parameterized constructor that takes the name of the ability, and whether it has been learned
        /// </summary>
        /// <param name="abilityName"></param>
        /// <param name="isLearned"></param>
        public TalentTreeNode(string abilityName, bool isLearned)
        {
            this.abilityName = abilityName;
            this.isLearned = isLearned;
        }
    }
}
