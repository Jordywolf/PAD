using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    class JogonPart : GameObject
    {
        protected Vector2 beginPosition;
        float speed = (2 * MathF.PI) / 120;
        float radius = 2f;
        protected Vector2 offset = new Vector2(10, 10);
        private float increase;
        public float delay;
        public JogonPart(Vector2 position, Vector2 velocity, float rotation, float scale, Texture2D texture, float delay) : base(position, velocity, rotation, scale, texture) { this.delay = delay; }

        public override void Update(GameTime gameTime)
        {
            delay--;
            if (delay < 0)
            {
                base.angle += speed;
                velocity.X = MathF.Cos(base.angle) * radius;
                velocity.Y = MathF.Sin(base.angle) * radius;
                increase += 0.1f;

                //base.angleOffset += MathF.Sin(increase) / 10;
                base.Update(gameTime);
            }
        }
    }
}
