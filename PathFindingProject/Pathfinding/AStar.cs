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




        public void Update(GameTime gameTime)
        {
            if (started == false)
            {
                t = new Thread(() => AstarPathfinding(Grid.GridPoints.ElementAt(38)));
                t.Start();

                started = true;
            }
            
        }



        /// <summary>
        /// Returns the Hx number
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        /// <returns></returns>
        public int HeuristicCalculator(Edge startPoint, Edge endPoint)
        {
            int _return = 2*(Math.Abs(startPoint.X - endPoint.X) + (Math.Abs(startPoint.Y - endPoint.Y)));
            return _return;
        }
    }
}
