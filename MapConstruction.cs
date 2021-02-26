using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class MapConstruction
{
    public MapConstruction()
    {

    }

    public void FloorConstruction(Vector2 floorPosition, Texture2D floorTexture, SpriteBatch spriteBatch, int width, int height)
    {
        for (int xMapTile = 0; xMapTile < width / floorTexture.Width; xMapTile++)
        {
            for (int yMapTile = 0; yMapTile < height / floorTexture.Height; yMapTile++)
            {
                floorPosition.X = floorTexture.Width * xMapTile;
                floorPosition.Y = floorTexture.Height * yMapTile;

                spriteBatch.Begin();
                spriteBatch.Draw(floorTexture, floorPosition, Color.White);
                spriteBatch.End();
            }
        }
    }

    public void WallConstruction(Vector2 wallPositionT, Vector2 wallPositionD, Vector2 wallPositionL, Vector2 wallPositionR, SpriteBatch spriteBatch, int width, int height, Texture2D WalltileStr, Texture2D WalltileStrD, Texture2D WalltileL, Texture2D WalltileR, Texture2D WalltileCrnL, Texture2D WalltileCrnR, Texture2D WalltileCrnDL, Texture2D WalltileCrnDR)
    {
        for (int iWalltile = 0; iWalltile < width / WalltileStr.Width; iWalltile++)
        {
            wallPositionT.X = WalltileStr.Width * iWalltile;
            wallPositionD.X = WalltileStrD.Width * iWalltile;

            wallPositionL.Y = WalltileL.Height * iWalltile;
            wallPositionR.Y = WalltileR.Height * iWalltile;

            spriteBatch.Begin();

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

            spriteBatch.End();
        }
    }

}

