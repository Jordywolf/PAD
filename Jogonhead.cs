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
        private Random random = new Random();
        private int Attackstate = 2;

        private float chargeTimer = 0;
        private float chargingdelay = 500;
        private bool charging = true;

        private SoundEffect chargeSound;

        private float angleoffset = 0;
        private int fireTimer;
        private int fireTimerMax = 500;
        private float angleincrease = 0;

        private int Segments = 15;
        private float health = 10;
        private SpriteGameObject target;
        private JogonPart jogonBodyPart;
        public GameObjectList Body = new GameObjectList();
        public GameObjectList fireballs = new GameObjectList();
        public string fireBallTexture;
        public bool reached;
        bool keyPressed;

        Player player;

        public Jogonhead(Vector2 position, float velocity, String texture, float followDist, string fireballTexture, SpriteGameObject target,  SoundEffect aSound, float depth ) : base(position, velocity, texture, followDist, target, depth)
        {
            depth = 1f;
            localPosition = position;
            this.fireBallTexture = fireballTexture;
            chargeSound = aSound;
            Constructbody();
        }


        public void Constructbody()
        {
            for (int i = 0; i < Segments; i++)
            {
                if (i == 0) { jogonBodyPart = new JogonPart(new Vector2(100, 100), 70, "Jogon_BodyS", 10, this, 0.9f); }
                else { jogonBodyPart = new JogonPart(new Vector2(100, 100), 70, "Jogon_BodyS", 10, target,0.9f); }
                Body.AddChild(jogonBodyPart);
                target = jogonBodyPart;
            }
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (JogonPart epic in Body.children)
            {
                epic._followSpeed = this._followSpeed * 1.99f;
            }
            switch (Attackstate)
            {
                case 1:
                    chargingdelay--;
                    if (chargingdelay <= 0)
                    {
                        Charge();
                    }
                    break;
                case 2:
                    if (fireTimer >= fireTimerMax)
                    {
                        
                        for (int i = 1; i < 4; i++)
                        {
                            angleincrease += 1f;
                            angleoffset =  (MathF.PI/180) * ((angleincrease+10)*(i%3));
                            Fireball();
                            fireTimer = 0;
                            if (angleincrease > 35) { angleincrease = 0; }
                        }
                    }
                    else { fireTimer++; }
                    break;
                case 3:

                    break;

            }



            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                keyPressed = false;
            }



        }

        public void Charge()
        {
            
            chargeSound.Play();

                if (chargeTimer < MathF.PI)
                {
                    chargeTimer += 0.02f;
                    _followSpeed += (float) (4 * MathF.Sin(chargeTimer));

                }
                else if(chargeTimer > MathF.PI)
                {
                    _followSpeed = 70;
                    chargeTimer = 0;
                    chargingdelay = 500;
                }
            
        }

        public void Fireball()
        {
            //fireballOffset = new Vector2(-this.sprite.Width / 2, this.sprite.Height / 2);
            fireballs.AddChild(new Fireball(this.localPosition,"fireball",this.Angle + angleoffset));
            foreach(Fireball ball in fireballs.children)
            {
                if (ball.IsObjectOffScreen(ball))
                {
                    ball.Visible = false;
                }
            }
        }
    }
}