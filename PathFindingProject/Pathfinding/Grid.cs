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
    class Grid : IObject
    {
        Texture2D image;
        Rectangle rect;
        static List<Cell> gridPoints;

        int amountOfBoxesX;
        int amountOfBoxesY;

        int screenSizeX;
        int screenSizeY;

        static Cell check;

        public static List<Cell> GridPoints { get => gridPoints; set => gridPoints = value; }
        public static Cell Check { get => check; set => check = value; }

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
            Check = gridPoints.ElementAt(90);
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



        public List<Cell> CreateGrid()
        {
            gridPoints = new List<Cell>();
            var sizeX = screenSizeX / amountOfBoxesX;
            var sizeY = screenSizeY / amountOfBoxesY;

            for (int y = 0; y < amountOfBoxesY; y++)
            {
                for (int x = 0; x < amountOfBoxesX; x++)
                {
                    gridPoints.Add(new Cell(GetRect(sizeY*y, sizeX*x),x ,y ));
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
