using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    class HealthBar : GameObject
    {
        public Vector2 HBposition;
        public Texture2D HBbeginRTexture;
        public Texture2D HBbeginLTexture;
        public Texture2D HBmiddleTexture;
        public Texture2D HBhealthTexture;

        public float MaxHealthLength = 1;
        public float MaxBarLength;

        public HealthBar(Vector2 position, Texture2D HBbeginRTexture, Texture2D HBbeginLTexture, Texture2D HBmiddleTexture, Texture2D HBhealthTexture) : base(position, new Vector2(0, 0), 0.0f, 1, HBbeginRTexture)
        {
            this.HBposition = position;
            this.HBbeginRTexture = HBbeginRTexture;
            this.HBbeginLTexture = HBbeginLTexture;
            this.HBmiddleTexture = HBmiddleTexture;
            this.HBhealthTexture = HBhealthTexture;
            MaxBarLength = MaxHealthLength;
        }

        public override void Draw(SpriteBatch myspriteBatch)
        {
            float healthbarWidth = 20;
            myspriteBatch.Draw(HBhealthTexture, new Vector2(GameEnvironment.Screen.X / 2 - HBhealthTexture.Width * ((healthbarWidth + 1) / 2), 30), null, Color.White, 0f, Vector2.Zero, new Vector2((healthbarWidth + 1) * MaxHealthLength, 1), SpriteEffects.None, 0f);
            myspriteBatch.Draw(HBbeginLTexture, new Vector2(GameEnvironment.Screen.X / 2 - HBhealthTexture.Width * (healthbarWidth / 2) - HBbeginLTexture.Width, 30), null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
            myspriteBatch.Draw(HBbeginRTexture, new Vector2(GameEnvironment.Screen.X / 2 + HBhealthTexture.Width * (healthbarWidth / 2), 30), null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
            myspriteBatch.Draw(HBmiddleTexture, new Vector2(GameEnvironment.Screen.X / 2 - HBhealthTexture.Width * (healthbarWidth / 2), 30), null, Color.White, 0f, Vector2.Zero, new Vector2(healthbarWidth, 1), SpriteEffects.None, 0f);
        }
    }
}

