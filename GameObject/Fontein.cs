using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    class Fontein : Engine.GameObjectList
    {
        Engine.SpriteGameObject FonteinTexture;
        public Fontein()
        {
            FonteinTexture = new Engine.SpriteGameObject("Fontein",0,0);
            this.AddChild(FonteinTexture);
            FonteinTexture.Position = new Vector2(0, 0);
        }
    }
}
