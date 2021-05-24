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
        public int Attackstate = 3;

        private float chargeTimer = 0;
        private float chargingdelay = 500;
        private bool charging = true;

        private bool playsound = true;
        private SoundEffect chargeSound;

        private float angleoffset = 0;
        private int fireTimer;
        private int fireTimerMax = 200;
        private float angleincrease = 0;

        private int Segments = 25;
        private float health = 10;
        private SpriteGameObject target;
        private JogonPart jogonBodyPart;
        public GameObjectList Body = new GameObjectList();
        public GameObjectList fireballs = new GameObjectList();
        public string fireBallTexture;
        public bool reached;
        bool keyPressed;
        private String[] jogonBodyParts = { "Jogon_BodyS", "Jogon_BodyArms", "Jogon_Vleugels" };
        private SpriteSheet arms = new SpriteSheet("Jogon_ArmsAni",1);
        Player player;

        public Jogonhead(Vector2 position, float velocity, String texture, float followDist, string fireballTexture, SpriteGameObject target, SoundEffect aSound, float depth) : base(position, velocity, texture, followDist, target, depth)
        {
            localPosition = position;
            this.fireBallTexture = fireballTexture;
            chargeSound = aSound;
            Constructbody();
        }


        public void Constructbody()
        {
            for (int i = 0; i < Segments; i++)
            {
                if (i == 0) { jogonBodyPart = new JogonPart(new Vector2(this.localPosition.X,this.localPosition.Y), 70, jogonBodyParts[0], 10, this, 0.9f); }
                else if(i == (int)(Segments/10)) { jogonBodyPart = new JogonPart(new Vector2(this.localPosition.X, this.localPosition.Y), 70, jogonBodyParts[1], 10, target, 0.9f); jogonBodyPart.scale = 2f; }
                else if (i == (int)(Segments / 2.5)) { jogonBodyPart = new JogonPart(new Vector2(this.localPosition.X, this.localPosition.Y), 70, jogonBodyParts[2], 10, target, 0.9f); jogonBodyPart.scale = 1.5f; }
                else if (i == (int)(Segments/1.5)) { jogonBodyPart = new JogonPart(new Vector2(this.localPosition.X, this.localPosition.Y), 70, jogonBodyParts[1], 10, target, 0.9f); jogonBodyPart.scale = 2f; }
                else  { jogonBodyPart = new JogonPart(new Vector2(this.localPosition.X, this.localPosition.Y), 70, jogonBodyParts[0], 10, target, 0.9f); }
                Body.AddChild(jogonBodyPart);
                target = jogonBodyPart;
            }
        }
        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
            foreach (JogonPart jogonpart in Body.children)
            {
                jogonpart._followSpeed = this._followSpeed*1.99f;
            }
            foreach (Fireball ball in fireballs.children)
            {
                ball.scale -= 0.01f;
                if (ball.scale < 0.1f) { ball.Visible = false; }
                if (ball.scale > 0.1f) { ball.Visible = true; }
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
                    fireTimerMax = 150;
                    _followSpeed = 40;
                    if (fireTimer >= fireTimerMax)
                    {

                            for (int i = 1; i <= random.Next(15,25)+1; i++)
                        {
                            angleincrease += 5f*i;
                            angleoffset =  (MathF.PI/180) * (360/MathF.Cos(i));
                            Fireball();
                            fireTimer = 0;
                            if (angleincrease > 45) { angleincrease = 0; }
                        }
                        foreach (Fireball ball in fireballs.children)
                        {
                            ball.scale = 2.5f;
                        }
                    }
                    else { fireTimer++; }
                    break;
                case 3:
                    chargingdelay--;
                    if (chargingdelay == 30)
                    {
                        if (playsound)
                        {
                            chargeSound.Play(volume: 1.0f, pitch: 0.0f, pan: 0.0f);
                            playsound = false;
                        }
                    }
                    if (chargingdelay <= 0)
                    {
                        Charge();
                    }
                    if (fireTimer >= fireTimerMax)
                    {
                        for (int i = 0; i <= random.Next(15,25); i++)
                        {
                            angleoffset = (MathF.PI / 180) * (MathF.Cos(i)*10);
                            if (angleoffset > 45 || angleoffset < -45) { angleoffset = 0; }
                            Fireball();
                            fireTimer = 0;

                        }
                        foreach (Fireball ball in fireballs.children)
                        {
                            ball.scale = 2.5f;
                            ball.Speed = 650;
                        }
                    }
                    else { fireTimer++; }

                    break;

            }



            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                keyPressed = false;
            }

            // store current positon and rotation as previous for all following parts
            /*if (updateDelay <= 0)
            {
                (Body.children[Body.children.Count-1] as JogonPart).SetNextpostition(localPosition, new Vector2(0,0));
                updateDelay = 1;
            }
            updateDelay--;
            */

        }
        public void Charge()
        {

            if (chargeTimer < MathF.PI)
            {
                chargeTimer += 0.02f;
                _followSpeed += (float)(3 * MathF.Sin(chargeTimer));

            }
            else if (chargeTimer > MathF.PI)
            {
                _followSpeed = 70;
                chargeTimer = 0;
                chargingdelay = random.Next(450,560);
                playsound = true;
            }


        }

        public void Fireball()
        {
            //fireballOffset = new Vector2(-this.sprite.Width / 2, this.sprite.Height / 2);
            fireballs.AddChild(new Fireball(this.localPosition, "fireball", this.Angle + angleoffset));
            foreach (Fireball ball in fireballs.children)
            {

                if (ball.IsObjectOffScreen(ball))
                {
                    ball.Visible = false;
                }
            }
        }
    }
}