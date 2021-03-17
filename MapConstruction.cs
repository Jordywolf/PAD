using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class MapConstruction
{
    public int maxPillarsY = 2;
    public int maxPillarsX = 2;
    public int maxPillars;
    private Texture2D aTexture;
    private Texture2D floorTexture;
    private Vector2 floorPosition;
    public Vector2 pillarPosition;
    public Texture2D pillarTile;

    public Vector2 wallPositionT;
    public Vector2 wallPositionD;
    public Vector2 wallPositionL;
    public Vector2 wallPositionR;
    public Texture2D WalltileStr;
    public Texture2D WalltileStrD;
    public Texture2D WalltileL;
    public Texture2D WalltileR;
    public Texture2D WalltileCrnL;
    public Texture2D WalltileCrnR;
    public Texture2D WalltileCrnDL;
    public Texture2D WalltileCrnDR;

    private int width;
    private int height;

    public bool check;

    public List<Pillar> pillars = new List<Pillar>();

    public MapConstruction(Texture2D pilTexture)
    {
        aTexture = pilTexture;

        maxPillars = maxPillarsX * maxPillarsY;

        for (int iPillars = 0; iPillars <= maxPillars; iPillars++)
        {
            Pillar pillar = new Pillar(new Vector2(0, 0), aTexture);
            pillars.Add(pillar);
        }
    }

    public void FloorConstruction(Vector2 floorPosition, Texture2D floorTexture, int width, int height)
    {
        this.floorTexture = floorTexture;
        this.floorPosition = floorPosition;

        this.width = width;
        this.height = height;
    }

    public void WallConstruction(Vector2 wallPositionT, Vector2 wallPositionD, Vector2 wallPositionL, 
        Vector2 wallPositionR, int width, int height, Texture2D WalltileStr, 
        Texture2D WalltileStrD, Texture2D WalltileL, Texture2D WalltileR, Texture2D WalltileCrnL, 
        Texture2D WalltileCrnR, Texture2D WalltileCrnDL, Texture2D WalltileCrnDR)
    {
        this.wallPositionT = wallPositionT;
        this.wallPositionD = wallPositionD;
        this.wallPositionL = wallPositionL;
        this.wallPositionR = wallPositionR;
        this.WalltileStr = WalltileStr;
        this.WalltileStrD = WalltileStrD;
        this.WalltileL = WalltileL;
        this.WalltileR = WalltileR;
        this.WalltileCrnL = WalltileCrnL;
        this.WalltileCrnR = WalltileCrnR;
        this.WalltileCrnDL = WalltileCrnDL;
        this.WalltileCrnDR = WalltileCrnDR;
    }

    public void PillarSetup(Texture2D pillarTile, int width, int height, Vector2 pillarPosition)
    {
        this.pillarTile = pillarTile;
        this.pillarPosition = pillarPosition;

        this.width = width;
        this.height = height;

    }

    public bool Collision(Vector2 objPos, Rectangle objRectangle)
    {
        return (objPos.Y <= objRectangle.Height || objPos.Y + objRectangle.Height >= height
            || objPos.X <= objRectangle.Width || objPos.X + objRectangle.Width >= width);
    }

    public bool Collision(Vector2 objPos, Texture2D objTexture)
    {
        return (objPos.Y <= objTexture.Height || objPos.Y + objTexture.Height >= height
            || objPos.X <= objTexture.Width || objPos.X + objTexture.Width >= width);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        //to build the floor
        for (int xMapTile = 0; xMapTile < width / floorTexture.Width; xMapTile++)
        {
            for (int yMapTile = 0; yMapTile < height / floorTexture.Height; yMapTile++)
            {
                floorPosition.X = floorTexture.Width * xMapTile;
                floorPosition.Y = floorTexture.Height * yMapTile;

                //spriteBatch.Begin();
                spriteBatch.Draw(floorTexture, floorPosition, Color.White);
                //spriteBatch.End();
            }
        }

        //to build the pillars
        for (int iPillarsX = 1; iPillarsX <= maxPillarsX; iPillarsX++)
        {
            for (int iPillarsY = 1; iPillarsY <= maxPillarsY; iPillarsY++)
            {

                pillarPosition.X = ((width / (maxPillarsX + 1)) * (iPillarsX)) - (pillarTile.Width / 2);
                pillarPosition.Y = ((height / (maxPillarsY + 1)) * (iPillarsY)) - (pillarTile.Height / 2);

                pillars[iPillarsX * iPillarsY].Draw(spriteBatch, pillarPosition);
            }
        }

        for (int iWalltile = 0; iWalltile < width / WalltileStr.Width; iWalltile++)
        {
            wallPositionT.X = WalltileStr.Width * iWalltile;
            wallPositionD.X = WalltileStrD.Width * iWalltile;

            wallPositionL.Y = WalltileL.Height * iWalltile;
            wallPositionR.Y = WalltileR.Height * iWalltile;

            //spriteBatch.Begin();
            if (iWalltile <= 0)
            {
                spriteBatch.Draw(WalltileCrnL, wallPositionT, Color.White);
                spriteBatch.Draw(WalltileCrnDL, wallPositionD, Color.White);
            }

            else if (iWalltile >= (width / WalltileStr.Width) - 1)
            {
                spriteBatch.Draw(WalltileCrnR, wallPositionT, Color.White);
                spriteBatch.Draw(WalltileCrnDR, wallPositionD, Color.White);
            }

            else
            {
                spriteBatch.Draw(WalltileStr, wallPositionT, Color.White);
                spriteBatch.Draw(WalltileStrD, wallPositionD, Color.White);
                spriteBatch.Draw(WalltileR, wallPositionR, Color.White);
                spriteBatch.Draw(WalltileL, wallPositionL, Color.White);
            }
            //spriteBatch.End();
        }
    }
}

