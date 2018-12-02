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
    interface IObject
    {
        void LoadContent(ContentManager content);
        void UnloadContent();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
