using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class FloorTile : Engine.SpriteGameObject
{
    /// <summary>
    /// deze class is een licht aangepaste versie van een spritegameobject waarbij je gelijk de positi kan aanpassen en de depth is al bepaald
    /// </summary>
    /// <param name="assetname"></param>
    /// <param name="position"></param>
    public FloorTile(String assetname, Vector2 position) : base(assetname, 0.4f)
    {
        this.localPosition = position;
    }
}

