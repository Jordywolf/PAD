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
        private float Timer;
        public Fireball(Vector2 position, Vector2 velocity, float rotation, float scale, Texture2D texture) : base(position, velocity, rotation, scale, texture)
        {
            Timer = 0;
            SpawnPosition = new Vector2(position.X, position.Y);
            Vector2 Target = new Vector2(500, 100);
            angle = (float)Math.Atan2(Target.Y, Target.X);
        }

        override public void Update(GameTime gameTime)
        {
            Vector2 Target = new Vector2(500, 100);
            Vector2 TargetPosition = SpawnPosition + Target;
            Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            position = Vector2.Lerp(SpawnPosition, TargetPosition, Timer * 1);
        }
    }
}
