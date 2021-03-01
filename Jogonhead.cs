using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    class Jogonhead : JogonPart
    {
        private Point Mousepos;
        private Vector2 mainTarget;
        public static float speed = 0.1f;
        private Vector2 acceliartion = new Vector2(0.02f, 0.05f);
        private float chargingdelay = 300;

        private float chargeTime = 0.05f;
        private static float chargeOffset = 0;
        private float chargeInc = chargeOffset;
        private bool charging = false;

        public List<JogonPart> Body = new List<JogonPart>();
        public List<Fireball> fireballs = new List<Fireball>();
        public Texture2D fireBallTexture;
        public Jogonhead(Vector2 position, Vector2 velocity, float rotation, float scale, Texture2D texture, float followDist, Texture2D fireballTexture) : base(position, velocity, rotation, scale, texture, followDist)
        {
            segment = false;
            this.fireBallTexture = fireballTexture;
        }

        public override void Update(GameTime gameTime)
        {
            chargingdelay--;
            Mousepos = Mouse.GetState().Position;
            mainTarget = new Vector2(Mousepos.X / 2, Mousepos.Y / 2);

            totalangle = MathF.Atan2(target.Y * _followSpeed, target.X * _followSpeed) - MathF.PI / 2;
            target = mainTarget - this.position;
            float dx = (mainTarget.X - this.position.X);
            float dy = (mainTarget.Y - this.position.Y);
            float dist = MathF.Sqrt(dx * dx + dy * dy);
            target.Normalize();

            if (dist > _minDistanceBetweenSegments)
            {
                this.position += target * _followSpeed;
            }
            foreach (JogonPart bodypart in Body)
            {
                bodypart.Update(gameTime);
            }
            base.Update(gameTime);
            if (chargingdelay <= 0)
            {
                Charge();
            }
        }

        public void Charge()
        {
            if (charging)
            {
                if (chargeInc <= MathF.PI * 2 + chargeOffset)
                {
                    chargeInc += chargeTime;
                    _followSpeed += (-MathF.Cos(chargeInc)) * (chargeTime * 9.5f);
                }
                else { chargeInc = chargeOffset; chargingdelay = 300; chargeTime = 0.05f; _followSpeed = 4; charging = false; }
            }
            else
            {
                _followSpeed = 10;
                charging = true;
            }
        }

        public void Fireball()
        {
            //fireball zooi
            fireballs.Add(new Fireball(position, Vector2.Zero, 0, 1, fireBallTexture));
            for (int i = 0; i < fireballs.Count; i++)
            {
                if (fireballs[i].IsObjectOffScreen(fireballs[i]))
                {
                    fireballs.RemoveAt(i);
                }
            }
            return;
        }
        public override void Draw(SpriteBatch myspriteBatch)
        {

            foreach (JogonPart bodypart in Body)
            {
                bodypart.Draw(myspriteBatch);
            }
            base.Draw(myspriteBatch);

        }
    }
}
