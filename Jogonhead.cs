using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Engine;

namespace BaseProject
{
    class Jogonhead : JogonPart
    {
        private float chargingdelay = 1000;
        private float chargeTime = 0.1f;
        private static float chargeOffset = 0;
        private float chargeInc = chargeOffset;
        private bool charging = false;
        public Vector2 origin = new Vector2(1280, 320);
        private Vector2 fireballOffset = new Vector2(20, 10);
        private SoundEffect chargeSound;

        private int fireTimer;
        private int fireTimerMax = 90;

        public GameObjectList Body1 = new GameObjectList();
        public List<JogonPart> Body = new List<JogonPart>();
        public List<Fireball> fireballs = new List<Fireball>();
        public string fireBallTexture;
        public bool reached;
        bool keyPressed;

        Player player;

        public Jogonhead(Vector2 position, float velocity, String texture, float followDist, string fireballTexture, SpriteGameObject target,  SoundEffect aSound) : base(position, velocity, texture, followDist, target)
        {
            localPosition = position;
            this.fireBallTexture = fireballTexture;
            chargeSound = aSound;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (fireTimer >= fireTimerMax)
            {
                Fireball();
                fireTimer = 0;
            } else { fireTimer++; }

            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                keyPressed = false;
            }
            chargingdelay--;

            if (chargingdelay <= 0)
            {
                charging = true;
                _followSpeed = 200;
                Charge();

            }
        }

        public void Charge()
        {
            
            chargeSound.Play();
            if (charging)
            {
                if (chargeInc <= MathF.PI * 2)
                {
                    chargeInc+= 0.1f;
                    _followSpeed = (float) (35 * -Math.Cos(2*MathF.PI*(chargeInc+2)));
                }
                else
                {
                    chargingdelay = 2000;
                    chargeTime = 0.1f;
                    _followSpeed = 70;
                    charging = false;
                }
            }
            else
            {
                _followSpeed = 50;
                charging = true;
            }
            
        }

        public void Fireball()
        {
            fireballOffset = -new Vector2(-this.sprite.Width / 2, this.sprite.Height / 2);
            fireballOffset.Normalize();
            //fireball zooi  
            fireballs.Add(new Fireball(this.localPosition + fireballOffset, fireBallTexture, target));
            for (int i = 0; i < fireballs.Count; i++)
            {
                if (fireballs[i].IsObjectOffScreen(fireballs[i]))
                {
                    fireballs.RemoveAt(i);
                }
            }
        }
    }
}