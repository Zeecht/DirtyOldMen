using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFindingProject
{
    class Graph
    {

        List<Nodes> nodeList = new List<Nodes>();

        public void AddNode(Nodes node)
        {
            nodeList.Add(node);
        }

        public Nodes GetNode(int nodeID)
        {
            foreach (var i in nodeList)
            {
                if (i.ID1.Equals(nodeID))
                {
                    return i;
                }
            }
            return null;
        }
    }
}
