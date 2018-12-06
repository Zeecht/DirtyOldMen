using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFindingProject
{
    class Nodes
    {
        int ID;
        int ParrentID;
        Rectangle rect;

        List<Edges> edgeList = new List<Edges>();


        public Nodes(int iD, Rectangle rect)
        {
            ID1 = iD;
            this.Rect = rect;
        }


        public List<Edges> EdgeList { get => edgeList; set => edgeList = value; }
        public int ID1 { get => ID; set => ID = value; }
        public int ParrentID1 { get => ParrentID; set => ParrentID = value; }
        public Rectangle Rect { get => rect; set => rect = value; }
    }
}
