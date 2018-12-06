using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFindingProject
{
    class Lists
    {
        static List<Edge> openList = new List<Edge>();
        static List<Edge> closedList = new List<Edge>();
        static List<Edge> blockedList = new List<Edge>();
        static List<Nodes> dfsList = new List<Nodes>();

        public static List<Edge> OpenList { get => openList; set => openList = value; }
        public static List<Edge> ClosedList { get => closedList; set => closedList = value; }
        public static List<Edge> BlockedList { get => blockedList; set => blockedList = value; }
        public static List<Nodes> DfsList { get => dfsList; set => dfsList = value; }
    }
}
