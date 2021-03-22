using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    class SafeZone1
    {
        //private SpriteBatch spriteBatch;
        //private List<Sprite> _sprites;
        public int height = 400;
        public int width = 1920;
        public Boolean KeyCollected = true;
        public Vector2 SteenPosition, SteenVertPosition = new Vector2(0, 0);
        public Vector2 PlayerPosition = new Vector2(1920 / 2, 1080);
        public Vector2 RotsPosition = new Vector2(1920 / 3, 1080 / 2.5f);
        public Vector2 position = new Vector2(0, 0);
        public Vector2 PilaarPosition = new Vector2(1590, 200);
        public Vector2 DoorPosition = new Vector2(1920 / 2, 1080 / 100);
        //public Texture2D FonteinTexture, Pilaar, SteenTile, ZandTile, SteenVert, Boom, Rots, Deur, Player, Sleutel;

        public void NextLevel1()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && Game1.menuchoice == 7)
            {
                Game1.menuchoice = 8;
                GameEnvironment.SwitchTo(7);
            }
            if (PlayerPosition.Y == PilaarPosition.Y)
            {
                KeyCollected = false;
            }
        }
        public void SafeZoneStone(Texture2D SteenTile, SpriteBatch spriteBatch)
        {
            for (int xSteenTile = 0; xSteenTile < width / SteenTile.Width * 2; xSteenTile++)
            {
                this.SteenPosition.X = SteenTile.Width * xSteenTile / 2;
                this.SteenPosition.Y = SteenTile.Height * 2;

                spriteBatch.Draw(SteenTile, SteenPosition, null, Color.White, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            }
        }
        public void SafeZoneStoneVert(Texture2D SteenVert, SpriteBatch spriteBatch)
        {
            for (int ySteenVert = 0; ySteenVert < height; ySteenVert++)
            {
                this.SteenVertPosition.Y = SteenVert.Height * ySteenVert / 2;
                this.SteenVertPosition.X = width / 3;

                spriteBatch.Draw(SteenVert, SteenVertPosition, null, Color.White, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            }
        }

        public void SafeZone(Texture2D ZandTile, Texture2D Sleutel, SpriteBatch spriteBatch)
        {
            //GraphicsDevice.Clear(Color.BlueViolet);
            for (int xZandTile = 0; xZandTile < width / ZandTile.Width + 25; xZandTile++)
            {
                for (int yZandTile = 0; yZandTile < height / ZandTile.Height + 20; yZandTile++)
                {
                    this.position.X = ZandTile.Width * xZandTile;
                    this.position.Y = ZandTile.Height * yZandTile;

                    spriteBatch.Draw(ZandTile, position, Color.White);
                    if (KeyCollected == true)
                    {
                        spriteBatch.Draw(Sleutel, new Vector2(990, 200), Color.White);
                    }
                }
            }
        }
    }

}
