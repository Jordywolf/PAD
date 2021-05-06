using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class FloorTile : Engine.SpriteGameObject
{

    public FloorTile(String assetname, Vector2 position) : base(assetname, 0.5f)
    {
        this.localPosition = position;
    }
}

