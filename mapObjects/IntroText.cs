using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Engine;

namespace BaseProject.mapObjects
{
    class IntroText : TextGameObject
    {
        public IntroText(String text, String font, Color color, Vector2 position) : base(font, 1, color)
        {
            Text = text;
            localPosition = position;
        }
    }
}
