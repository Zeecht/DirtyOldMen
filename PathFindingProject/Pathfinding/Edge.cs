using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFindingProject
{
    class Edge
    {
        Texture2D image;
        int x;
        int y;
        Rectangle rect;
        Edge parrent;


        public Edge(Rectangle rect, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.Rect = rect;
        }

        public Rectangle Rect { get => rect; set => rect = value; }
        public int X { get => x; }
        public int Y { get => y; }
        public Texture2D Image { get => image; set => image = value; }
        public Edge Parrent { get => parrent; set => parrent = value; }
    }
}
