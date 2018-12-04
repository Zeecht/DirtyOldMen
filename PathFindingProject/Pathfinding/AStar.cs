using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PathFindingProject
{
    partial class AStar
    {
        bool started=false;
        Thread t;


        public void runPathfinder1()
        {
            if (started == false)
            {
                BlockedBlocks();
                t = new Thread(() => AstarPathfinding(Grid.GridPoints.ElementAt(38)));
                t.IsBackground = true;
                t.Start();

                started = true;
            }
        }

        public void RunPathFinder2()
        {
            if (started == false)
            {
                BlockedBlocks();
                t = new Thread(() => GetRoute(Grid.GridPoints.ElementAt(38)));
                t.IsBackground = true;
                t.Start();

                started = true;
            }
        }

        public void Update(GameTime gameTime)
        {
            //if (started == false)
            //{
            //    BlockedBlocks();
            //    t = new Thread(() => AstarPathfinding(Grid.GridPoints.ElementAt(38)));
            //    t.IsBackground = true;
            //    t.Start();

            //    started = true;
            //}
            
        }

        public void BlockedBlocks()
        {
            for (int i = 24; i <= 94; i+=10)
            {
                Lists.BlockedList.Add(Grid.GridPoints.ElementAt(i));
            }
        }



        /// <summary>
        /// Returns the Hx number
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        /// <returns></returns>
        public int HeuristicCalculator(Cell startPoint, Cell endPoint)
        {
            int _return = (Math.Abs(startPoint.Rect.X - endPoint.Rect.X) + (Math.Abs(startPoint.Rect.Y - endPoint.Rect.Y)));
            return _return;
        }
    }
}
