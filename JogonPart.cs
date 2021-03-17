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
        public Vector2 target;
        public float _minDistanceBetweenSegments = 4;
        public float _followSpeed = 70;
        protected float _followRange = 1f;
        public JogonPart Parent;
        protected bool segment = true;
        public bool reached = false;
        protected int Movingstate = 0;
        public Vector2 moveDir;

        public JogonPart(Vector2 position, Vector2 velocity, float rotation, float scale, Texture2D texture, float followDist, JogonPart Parent) : base(position, velocity, rotation, scale, texture) { _minDistanceBetweenSegments = followDist; }

        public override void Update(GameTime gameTime)
        {
            if (segment)
            {
                target = Parent.position;
                _followSpeed = Parent._followSpeed - 0.1f;
            }

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            moveDir = target - this.position;
            moveDir.Normalize();
            totalangle = MathF.Atan2(target.Y - this.position.Y, target.X - this.position.X) - MathF.PI / 2;

            if (Movingstate == 0)
            {
                if (!isInRange(this.position, target, _followRange))
                {
                    Movingstate = 1;
                }
            }
            else if (Movingstate == 1)
            {
                if (isInRange(this.position, target, _followRange))
                {
                    Movingstate = 0;
                }

                this.position += moveDir * _followSpeed * dt;
            }
        }
        protected bool isInRange(Vector2 V1, Vector2 V2, float range)
        {
            float dx = V2.X - V1.X;
            float dy = V2.Y - V2.Y;
            return MathF.Sqrt((dx * dx) + (dy * dy)) < range;
        }

        public override void Draw(SpriteBatch myspriteBatch)
        {
            base.Draw(myspriteBatch);
        }
    }
}
