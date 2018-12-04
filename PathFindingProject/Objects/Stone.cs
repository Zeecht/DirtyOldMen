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
    class Stone : Object
    {
        Texture2D image;
        Rectangle rect;


        public override void LoadContent(ContentManager content)
        {
            image = content.Load<Texture2D>("Sten");
            rect = new Rectangle(0, 500, 120, 90);
        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(image, rect, Color.White);


        }
    }
}
