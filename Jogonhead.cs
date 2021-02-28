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

        private float chargeTime = 0.1f;
        private static float chargeOffset = 0;
        private float chargeInc = chargeOffset;

        public List<JogonPart> Body = new List<JogonPart>();
        public Jogonhead(Vector2 position, Vector2 velocity, Texture2D texture, float followDist) : base(position, velocity, texture, followDist)
        {
            segment = false;
        }

        public override void Update()
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
                bodypart.Update();
            }
            base.Update();
            if (chargingdelay <= 0)
            {
                Charge();
            }
        }

        public void Charge()
        {
            if (chargeInc <= MathF.PI*2 + chargeOffset)
            {
                chargeInc += chargeTime;
                _followSpeed += (-MathF.Cos(chargeInc))*(chargeTime*3.8f);
            }
            else { chargeInc = chargeOffset; chargingdelay = 300; chargeTime = 0.1f; }
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
