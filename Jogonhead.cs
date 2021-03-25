using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace BaseProject
{
    class Jogonhead : JogonPart
    {
        private float chargingdelay = 1000;
        private float chargeTime = 0.1f;
        private static float chargeOffset = 0;
        private float chargeInc = chargeOffset;
        private bool charging = false;
        private float targetSpeed = 0.01f;
        private float targetTime = 0;
        private float targetRadius = 200;
        public Vector2 origin = new Vector2(1280, 320);
        private Vector2 fireballOffset = new Vector2(20, 10);
        private SoundEffect chargeSound;

        private int fireTimer;
        private int fireTimerMax = 90;

        public List<JogonPart> Body = new List<JogonPart>();
        public List<Fireball> fireballs = new List<Fireball>();
        public Texture2D fireBallTexture;
        bool keyPressed;

        Player player;

        public Jogonhead(Vector2 position, Vector2 velocity, float rotation, float scale, Texture2D texture, float followDist, Texture2D fireballTexture, Player target, JogonPart parent, SoundEffect aSound) : base(position, velocity, rotation, scale, texture, followDist, parent)
        {
            this.player = target;
            segment = false;
            this.fireBallTexture = fireballTexture;
            this.target = new Vector2(1280, 320);
            chargeSound = aSound;
            _followRange = 10f;
        }

        public override void Update(GameTime gameTime)
        {
            targetTime++;
            this.target = new Vector2((float)Math.Cos(targetTime * targetSpeed) * targetRadius + origin.X, (float)Math.Sin(targetTime * targetSpeed) * targetRadius + origin.Y);
            if (fireTimer >= fireTimerMax)
            {
                Fireball();
                fireTimer = 0;
            } else { fireTimer++; }

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
                charging = true;
                _followSpeed = 200;
                chargingdelay = 2000;
                Charge();

            }
        }

        public void Charge()
        {
            chargeSound.Play();
            if (charging)
            {
                if (chargeInc <= MathF.PI * 2 + chargeOffset)
                {
                    chargeInc += chargeTime;
                    _followSpeed += (-MathF.Cos(chargeInc)) * (chargeTime * 15f);
                }
                else { chargeInc = chargeOffset; chargingdelay = 2000; chargeTime = 0.1f; _followSpeed = 50; charging = false; }
            }
            else
            {
                _followSpeed = 50;
                charging = true;
            }
        }

        public void Fireball()
        {
            fireballOffset = -new Vector2(-this.texture.Width / 2, this.texture.Height / 2);
            fireballOffset.Normalize();
            //fireball zooi
            fireballs.Add(new Fireball(this.position + fireballOffset, Vector2.Zero, 0, 1, fireBallTexture, player));
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