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
        private float chargingdelay = 300;
        private float chargeTime = 0.05f;
        private static float chargeOffset = 0;
        private float chargeInc = chargeOffset;
        private bool charging = false;
        private float targetSpeed = 0.01f;
        private float targetTime = 0;
        private float targetRadius = 200;
        public Vector2 origin = new Vector2(1280, 320);


        public List<JogonPart> Body = new List<JogonPart>();
        public List<Fireball> fireballs = new List<Fireball>();
        public Texture2D fireBallTexture;
        bool keyPressed;
        public Jogonhead(Vector2 position, Vector2 velocity, float rotation, float scale, Texture2D texture, float followDist, Texture2D fireballTexture, Sprite target, JogonPart parent) : base(position, velocity, rotation, scale, texture, followDist, parent)
        {
            segment = false;
            this.fireBallTexture = fireballTexture;
            this.target = new Vector2(1280, 320);
        }

        public override void Update(GameTime gameTime)
        {
            targetTime++;
            this.target = new Vector2((float)Math.Cos(targetTime * targetSpeed) * targetRadius + origin.X, (float)Math.Sin(targetTime * targetSpeed) * targetRadius + origin.Y);
            if (keyPressed == false)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    target += new Vector2(100, 10);
                    keyPressed = true;
                    Fireball();
                }
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                keyPressed = false;
            }

            //turning

            chargingdelay--;

            foreach (JogonPart bodypart in Body)
            {
                bodypart.Update(gameTime);
            }
            base.Update(gameTime);

            if (chargingdelay <= 0)
            {
                //Charge();
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