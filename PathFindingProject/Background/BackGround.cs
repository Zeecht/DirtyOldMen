using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using Microsoft.Xna.Framework.Content;

namespace PathFindingProject
{
    class BackGround
    {
        Texture2D image;
        Rectangle rect;



         public void LoadContent(ContentManager content)
         {
            image = content.Load<Texture2D>("images");
            rect = new Rectangle(0, 0, 800, 600);
         }


        public void Update(GameTime gameTime)
        {

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, rect,Color.White);
        }
    }
}
