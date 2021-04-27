using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    class HealthBar : Engine.GameObject
    {
        public Vector2 HBposition;
        public Texture2D HBbeginRTexture;
        public Texture2D HBbeginLTexture;
        public Texture2D HBmiddleTexture;
        public Texture2D HBhealthTexture;

        public float MaxHealthLength = 1;
        public float MaxBarLength;

        /*
        public HealthBar(Vector2 position, Texture2D HBbeginRTexture, Texture2D HBbeginLTexture, Texture2D HBmiddleTexture, Texture2D HBhealthTexture) : base(position, new Vector2(0, 0), 0.0f, 1, HBbeginRTexture)
        {
            this.HBposition = position;
            this.HBbeginRTexture = HBbeginRTexture;
            this.HBbeginLTexture = HBbeginLTexture;
            this.HBmiddleTexture = HBmiddleTexture;
            this.HBhealthTexture = HBhealthTexture;
            MaxBarLength = MaxHealthLength;
        }
        */
    }
}

