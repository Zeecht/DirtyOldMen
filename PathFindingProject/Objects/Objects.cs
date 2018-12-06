using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PathFindingProject
{
    class Objects : IObjects
    {
        string[] lines = File.ReadAllLines("MapGenerator.txt");
        List<string> c = new List<string>();

        public virtual void LoadContent(ContentManager content)
        {
                foreach (string s in lines)
                {
                    
                    string[] t = s.Split(',');
                    foreach (string str in t)
                    {
                        c.Add(str);
                    }
                    
                }
            int counter = 0;
            foreach (string w in c)
            {
                var e = Grid.GridPoints.ElementAt(counter);
                Texture2D image;
                int l;
                int.TryParse(w, out l);
                if (l == 1)
                {
                    image = content.Load<Texture2D>("House");
                }
                else if (l == 2)
                {
                    image = content.Load<Texture2D>("TreeHouse");
                }
                else if (l == 3)
                {
                    image = content.Load<Texture2D>("Key");
                }
                else if (l == 4)
                {
                    image = content.Load<Texture2D>("Sten");
                    Lists.BlockedList.Add(e);
                }
                else if (l == 5)
                {
                    image = content.Load<Texture2D>("Tree");
                    Lists.BlockedList.Add(e);
                    
                }
                else
                {
                    image = content.Load<Texture2D>("Grid");
                }
                e.Image = image;
                counter++;
            }
        }

        public virtual void UnloadContent()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
