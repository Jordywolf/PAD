using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    class GameObject
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;

        public GameObject(Texture2D objTexture)
        {
            texture = objTexture;
            Reset();
        }

        virtual public void Reset()
        {

        }

        virtual public void Update()
        {

        }

        virtual public void Draw()
        {

        }
    }
}
