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
        Vector2 TargetPosition;
        private float Timer;
        private float Speed = 300;
        private bool alive;
        public Fireball(Vector2 position, Vector2 velocity, float rotation, float scale, Texture2D texture) : base(position, velocity, rotation, scale, texture)
        {
            Reset();
        }

        override public void Reset()
        {
            Timer = 0;
            alive = true;
            SpawnPosition = position;
            TargetPosition = new Vector2(50, 32); // hier komt de target te staat wss dus de player
            angle = (float)Math.Atan2(TargetPosition.Y, TargetPosition.X);
        }

        override public void Update(GameTime gameTime)
        {
            if (alive)
            {
                Vector2 LerpTarget = SpawnPosition + TargetPosition;
                float distance = Vector2.Distance(SpawnPosition, LerpTarget);
                Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                position = Vector2.Lerp(SpawnPosition, LerpTarget, Timer * Speed / distance);
            }
            else
            {
                position = new Vector2(-100, -100);
            }
        }

        public override void Draw(SpriteBatch myspriteBatch)
        {
            if (alive)
            {
                base.Draw(myspriteBatch);
            }
        }
    }
}
