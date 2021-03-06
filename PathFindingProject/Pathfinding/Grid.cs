﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PathFindingProject
{
    class Grid : IObjects
    {
        Texture2D image;
        Rectangle rect;
        static List<Edge> gridPoints;


        int amountOfBoxesX;
        int amountOfBoxesY;

        int screenSizeX;
        int screenSizeY;

        static Edge check;

        public static List<Edge> GridPoints { get => gridPoints; set => gridPoints = value; }
        public static Edge Check { get => check; set => check = value; }

        public Grid(int amountOfBoxesX, int amountOfBoxesY, int screenSizeX, int screenSizeY)
        {
            this.amountOfBoxesX = amountOfBoxesX;
            this.amountOfBoxesY = amountOfBoxesY;
            this.screenSizeX = screenSizeX;
            this.screenSizeY = screenSizeY;
        }

        public void LoadContent(ContentManager content)
        {

            CreateGrid();
            //StartPunkt
            Check = gridPoints.ElementAt(81);
        }

        public void UnloadContent()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var i in gridPoints)
            {
                if (i.Image.Name == "Grid")
                {
                    spriteBatch.Draw(i.Image, i.Rect, Color.Transparent);
                }
                else
                {
                    spriteBatch.Draw(i.Image, i.Rect, Color.White);
                }
            }
            
        }



        public List<Edge> CreateGrid()
        {
            gridPoints = new List<Edge>();
            var sizeX = screenSizeX / amountOfBoxesX;
            var sizeY = screenSizeY / amountOfBoxesY;
            int dsfID = 0;

            for (int y = 0; y < amountOfBoxesY; y++)
            {
                for (int x = 0; x < amountOfBoxesX; x++)
                {
                    gridPoints.Add(new Edge(GetRect(sizeY*y, sizeX*x),x ,y ,image));
                    AStar.graph.AddNode(new Nodes(dsfID, GetRect(sizeY * y, sizeX * x)));
                    dsfID++;
                }
            }

            
            
            if (gridPoints.Count != 0)
            {
                return gridPoints;
            }
            return null;
        }


        public Rectangle GetRect(int y,int x)
        {

            return new Rectangle(x, y, screenSizeX/amountOfBoxesX, screenSizeY/amountOfBoxesY);
        }
    }
}
