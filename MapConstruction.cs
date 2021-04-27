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

    private bool Wconstruct;
    private bool Pconstruct;
    private bool Fconstruct;

    private Color Wcolor;
    private Color Pcolor;
    private Color Fcolor;

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



    public void FloorConstruction(Vector2 floorPosition, Texture2D floorTexture, int width, int height, Color color)
    {
        this.floorTexture = floorTexture;
        this.floorPosition = floorPosition;

        this.width = width;
        this.height = height;

        Fcolor = color;

        Fconstruct = true;
    }

    public void WallConstruction(Vector2 wallPositionT, Vector2 wallPositionD, Vector2 wallPositionL, 
        Vector2 wallPositionR, int width, int height, Texture2D WalltileStr, 
        Texture2D WalltileStrD, Texture2D WalltileL, Texture2D WalltileR, Texture2D WalltileCrnL, 
        Texture2D WalltileCrnR, Texture2D WalltileCrnDL, Texture2D WalltileCrnDR, Color color)
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

        Wcolor = color;

        Wconstruct = true;
    }

    public void PillarSetup(Texture2D pillarTile, int width, int height, Vector2 pillarPosition, Color color)
    {
        this.pillarTile = pillarTile;
        this.pillarPosition = pillarPosition;

        this.width = width;
        this.height = height;

        Pcolor = color;

        Pconstruct = true;
    }

    public void PlayerCollision(Vector2 playerPos, Texture2D playerTextue)
    {
        if (playerPos.Y <= playerTextue.Height) { playerPos.Y = playerTextue.Height; }
        if (playerPos.Y + playerTextue.Height >= height) { playerPos.Y = height - playerTextue.Height; }
        if (playerPos.X <= playerTextue.Width) { playerPos.X = playerTextue.Width; }
        if (playerPos.X + playerTextue.Width >= width) { playerPos.X = width - playerTextue.Width; }
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

    public void DrawFloor(SpriteBatch spriteBatch)
    {
        for (int xMapTile = 0; xMapTile < width / floorTexture.Width; xMapTile++)
        {
            for (int yMapTile = 0; yMapTile < height / floorTexture.Height; yMapTile++)
            {
                floorPosition.X = floorTexture.Width * xMapTile;
                floorPosition.Y = floorTexture.Height * yMapTile;

                //spriteBatch.Begin();
                spriteBatch.Draw(floorTexture, floorPosition, Fcolor);
                //spriteBatch.End();
            }
        }
    }

    public void DrawPillars(SpriteBatch spriteBatch)
    {
        for (int iPillarsX = 1; iPillarsX <= maxPillarsX; iPillarsX++)
        {
            for (int iPillarsY = 1; iPillarsY <= maxPillarsY; iPillarsY++)
            {

                pillarPosition.X = ((width / (maxPillarsX + 1)) * (iPillarsX)) - (pillarTile.Width / 2);
                pillarPosition.Y = ((height / (maxPillarsY + 1)) * (iPillarsY)) - (pillarTile.Height / 2);

                pillars[iPillarsX * iPillarsY].Draw(spriteBatch, pillarPosition, Pcolor);
            }
        }
    }

    public void DrawWalls(SpriteBatch spriteBatch)
    {
        for (int iWalltile = 0; iWalltile < width / WalltileStr.Width; iWalltile++)
        {
            wallPositionT.X = WalltileStr.Width * iWalltile;
            wallPositionD.X = WalltileStrD.Width * iWalltile;

            wallPositionL.Y = WalltileL.Height * iWalltile;
            wallPositionR.Y = WalltileR.Height * iWalltile;

            //spriteBatch.Begin();
            if (iWalltile <= 0)
            {
                spriteBatch.Draw(WalltileCrnL, wallPositionT, Wcolor);
                spriteBatch.Draw(WalltileCrnDL, wallPositionD, Wcolor);
            }

            else if (iWalltile >= (width / WalltileStr.Width) - 1)
            {
                spriteBatch.Draw(WalltileCrnR, wallPositionT, Wcolor);
                spriteBatch.Draw(WalltileCrnDR, wallPositionD, Wcolor);
            }

            else
            {
                spriteBatch.Draw(WalltileStr, wallPositionT, Wcolor);
                spriteBatch.Draw(WalltileStrD, wallPositionD, Wcolor);
                spriteBatch.Draw(WalltileR, wallPositionR, Wcolor);
                spriteBatch.Draw(WalltileL, wallPositionL, Wcolor);
            }
            //spriteBatch.End();
        }
    }



    public void Draw(SpriteBatch spriteBatch)
    {
        if (Fconstruct) { DrawFloor(spriteBatch); }
        if (Pconstruct) { DrawPillars(spriteBatch); }
        if (Wconstruct) { DrawWalls(spriteBatch); }

    }
}

