using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine;

namespace BaseProject
{
    class HealthBar : SpriteGameObject
    {
        public Vector2 HBposition;
        public Texture2D HBbeginRTexture;
        public Texture2D HBbeginLTexture;
        public Texture2D HBmiddleTexture;
        public Texture2D HBhealthTexture;

        public float MaxHealthLength = 1;
        public float MaxBarLength;

        public HealthBar(Vector2 position, Texture2D HBbeginRTexture, Texture2D HBbeginLTexture, Texture2D HBmiddleTexture, Texture2D HBhealthTexture) : base("healthBarMiddle", 0, 0)
        {
            this.HBposition = position;
            this.HBbeginRTexture = HBbeginRTexture;
            this.HBbeginLTexture = HBbeginLTexture;
            this.HBmiddleTexture = HBmiddleTexture;
            this.HBhealthTexture = HBhealthTexture;
            MaxBarLength = MaxHealthLength;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            float healthbarWidth = 20;
            spriteBatch.Draw(HBhealthTexture, new Vector2(Game1.width / 2 - HBhealthTexture.Width * ((healthbarWidth + 1) / 2), 30), null, Color.White, 0f, Vector2.Zero, new Vector2((healthbarWidth + 1) * MaxHealthLength, 1), SpriteEffects.None, 0f);
            spriteBatch.Draw(HBbeginLTexture, new Vector2(Game1.width / 2 - HBhealthTexture.Width * (healthbarWidth / 2) - HBbeginLTexture.Width, 30), null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
            spriteBatch.Draw(HBbeginRTexture, new Vector2(Game1.width / 2 + HBhealthTexture.Width * (healthbarWidth / 2), 30), null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
            spriteBatch.Draw(HBmiddleTexture, new Vector2(Game1.width / 2 - HBhealthTexture.Width * (healthbarWidth / 2), 30), null, Color.White, 0f, Vector2.Zero, new Vector2(healthbarWidth, 1), SpriteEffects.None, 0f);
        }
    }
}

