using System;
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
    abstract class Object : IObject
    {
      

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public virtual void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public virtual void UnloadContent()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
