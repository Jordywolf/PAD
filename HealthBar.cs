using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine;

namespace BaseProject
{
    class HealthBar : GameObjectList
    {

        public static int MaxHealthLength = 30;
        public int maxHealth = MaxHealthLength;
        public static int MaxBarLength = 29;
        public int CurrentHealth = MaxHealthLength;

        SpriteGameObject HBbegin;
        SpriteGameObject HBend;
        SpriteGameObject HBmid;
        SpriteGameObject HBhealth;

        GameObjectList healthBarStructure;
        GameObjectList health;

        TextGameObject test;

        public HealthBar(String bossName) : base()
        {
            healthBarStructure = new GameObjectList();
            children.Add(healthBarStructure);

            health = new GameObjectList();
            children.Add(health);

            test = new TextGameObject("Eightbit", 1, Color.Black);
            children.Add(test);

            test.scale = 2;
            test.Text = bossName;
            test.LocalPosition = new Vector2(Game1.width / 2 - 200, Game1.height / 15);

            for (int i = 0; i <= MaxBarLength; i++)
            {
                if (i == 0)
                {
                    HBbegin = new SpriteGameObject("healthBarEndL", 1);
                    healthBarStructure.AddChild(HBbegin);
                }

                else if (i > 0 && i < MaxBarLength)
                {
                    HBmid = new SpriteGameObject("healthBarMiddleBorder", 1);
                    healthBarStructure.AddChild(HBmid);
                }

                else if (i == MaxBarLength)
                {
                    HBend = new SpriteGameObject("healthBarEnd", 1);
                    healthBarStructure.AddChild(HBend);
                }

                healthBarStructure.children[i].LocalPosition = new Vector2(i * 32, this.localPosition.Y);
            }

            for (int q = 0; q < MaxHealthLength; q++)
            {
                HBhealth = new SpriteGameObject("healthBarMiddle", 0.95f);
                health.AddChild(HBhealth);
                health.children[q].LocalPosition = new Vector2(q * 32, this.localPosition.Y);
            }
        }

        public void Hit(int damage)
        {
            CurrentHealth -= damage;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            for (int q = 0; q < MaxHealthLength; q++)
            {
                if (q < CurrentHealth)
                {
                    health.children[q].LocalPosition = new Vector2(q * 32, this.localPosition.Y);
                }
                else
                {
                    health.children[q].Visible = false;
                }
            }
        }

        /* public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
         {
             float healthbarWidth = 20;
             spriteBatch.Draw(HBhealthTexture, new Vector2(Game1.width / 2 - HBhealthTexture.Width * ((healthbarWidth + 1) / 2), 30), null, Color.White, 0f, Vector2.Zero, new Vector2((healthbarWidth + 1) * MaxHealthLength, 1), SpriteEffects.None, 0f);
             spriteBatch.Draw(HBbeginLTexture, new Vector2(Game1.width / 2 - HBhealthTexture.Width * (healthbarWidth / 2) - HBbeginLTexture.Width, 30), null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
             spriteBatch.Draw(HBbeginRTexture, new Vector2(Game1.width / 2 + HBhealthTexture.Width * (healthbarWidth / 2), 30), null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
             spriteBatch.Draw(HBmiddleTexture, new Vector2(Game1.width / 2 - HBhealthTexture.Width * (healthbarWidth / 2), 30), null, Color.White, 0f, Vector2.Zero, new Vector2(healthbarWidth, 1), SpriteEffects.None, 0f);
         }*/
    }
}

