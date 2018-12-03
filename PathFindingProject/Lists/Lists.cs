using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFindingProject
{
    class Lists
    {
        static List<Cell> openList = new List<Cell>();
        static List<Cell> closedList = new List<Cell>();
        static List<Cell> blockedList = new List<Cell>();




        public static List<Cell> OpenList { get => openList; set => openList = value; }
        public static List<Cell> ClosedList { get => closedList; set => closedList = value; }
        public static List<Cell> BlockedList { get => blockedList; set => blockedList = value; }
    }
}
