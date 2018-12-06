using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PathFindingProject
{
    partial class AStar
    {
        bool started=false;
        Thread t;
        int counterAstar= 0;
        int counterDFS = 0;


        public void Update(GameTime gameTime)
        {
            var k = Keyboard.GetState();
            AStarStarter(k);
            DFSStarter(k);
        }


        public void AStarStarter(KeyboardState k)
        {
            //Starts AstarAlgorythm
            if (k.IsKeyDown(Keys.F1) && started == false)
            {
                if (counterAstar == 0)
                {
                    started = true;
                    t = new Thread(() => AstarPathfinding(Grid.GridPoints.ElementAt(88)));
                    t.Start();
                    counterAstar++;
                }
            }
        }

        public void DFSStarter(KeyboardState k)
        {
            if (k.IsKeyDown(Keys.F2) && started == false)
            {
                if (counterDFS == 0)
                {
                    started = true;
                    t = new Thread(() => Start(Grid.GridPoints.ElementAt(88)));
                    t.Start();
                    counterDFS++;
                }
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
            int _return = (Math.Abs(startPoint.Rect.X - endPoint.Rect.X) + (Math.Abs(startPoint.Rect.Y - endPoint.Rect.Y)));
            return _return;


            int dx = Math.Abs(startPoint.X - endPoint.X);
            int dy = Math.Abs(startPoint.Y - endPoint.Y);
            int D = (int)Math.Sqrt(dx * dx + dy * dy);
            return D*2;
        }
    }
}
