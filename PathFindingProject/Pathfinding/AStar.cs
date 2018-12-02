using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PathFindingProject
{
    partial class AStar
    {
        




        

        public void Update(GameTime gameTime)
        {
            
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
