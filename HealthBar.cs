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

        public int MaxHealthLength = 100;
        public int MaxBarLength;

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
            for (int iLength = 0; iLength < MaxHealthLength; iLength++)
            {
                HBposition.X = 640 - (MaxHealthLength * HBhealthTexture.Width / 2) + HBmiddleTexture.Width * iLength;

                myspriteBatch.Draw(HBhealthTexture, HBposition, null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
            }

            for (int iBar = 0; iBar < MaxBarLength; iBar++)
            {
                HBposition.X = 640 - (MaxBarLength * HBhealthTexture.Width / 2) + HBmiddleTexture.Width * iBar;

                if (iBar <= 0)
                {

                    myspriteBatch.Draw(HBbeginLTexture, HBposition, null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }
                else if (iBar >= MaxBarLength-1)
                {
                    myspriteBatch.Draw(HBbeginRTexture, HBposition, null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }
                else
                {
                    myspriteBatch.Draw(HBmiddleTexture, HBposition, null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }
            }
        }

    }
}

