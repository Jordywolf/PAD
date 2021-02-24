using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    class Fireball : GameObject 
    {
        Vector2 SpawnPosition;
        public Fireball(Texture2D objTexture) 
            : base (objTexture)
        {
            texture = Content.Load<Texture2D>(objTexture);
            position = SpawnPosition = new Vector2(0, 0);
        }

        public void Update(GameTime gameTime)
        {
            Vector2 Target = new Vector2(200, 300);
            Vector2 TargetPosition = SpawnPosition + Target;
            position = Vector2.Lerp(SpawnPosition, TargetPosition, (float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        virtual public void Draw()
        {

        }
    }
}
