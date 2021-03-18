using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BaseProject
{
    class SafeZone2 : Game
    {
        //private SpriteBatch spriteBatch;
        //private List<Sprite> _sprites;
        public int height = 1080;
        public int width = 1920;
        public int Velocity = 1;
        public Boolean KeyCollected = true;
        public Vector2 TileSz2Pos,SteenVertPosition = new Vector2(0, 0);
        public Vector2 TileSz3Pos = new Vector2(400, 400);
        public Vector2 PlayerPosition = new Vector2(1920 / 2, 1080);
        public Vector2 RotsPosition = new Vector2(1920 / 3, 1080 / 2.5f);
        public Vector2 position = new Vector2(0, 0);
        public Vector2 PilaarPosition = new Vector2(1590, 200);
        public Vector2 DoorPosition = new Vector2(1920 / 2, 1080 / 100);

        public void NextLevel2()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && Game1.menuchoice == 7)
            {
                Game1.menuchoice = 8;
            }
            if (PlayerPosition.Y == PilaarPosition.Y)
            {
                KeyCollected = false;
            }
        }
        public void SafeZonePlatForm(Texture2D TileSz2, SpriteBatch spriteBatch)
        {
            for (int xTileSz2 = 0; xTileSz2 < width / TileSz2.Width * 3; xTileSz2++)
            {
                this.TileSz2Pos.X = TileSz2.Width * xTileSz2 / 4;
                this.TileSz2Pos.Y = TileSz2.Height * 3;

                spriteBatch.Draw(TileSz2, TileSz2Pos, null, Color.White, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            }
        }
        

        public void SafeZone(Texture2D TileSz2, SpriteBatch spriteBatch)
        {
            for (int xTileSz2 = 0; xTileSz2 < width  / TileSz2.Width ; xTileSz2++)
            {
                for (int yTileSz2 = 0; yTileSz2 < height / TileSz2.Height +20; yTileSz2++)
                {
                    this.TileSz2Pos.X = TileSz2.Width * xTileSz2;
                    this.TileSz2Pos.Y = TileSz2.Height * yTileSz2 * 7.8f ;
                    
                    spriteBatch.Draw(TileSz2, TileSz2Pos, Color.White);
                }
            }
        }
        public void MovingPlatForm(Texture2D TileSz3, SpriteBatch spriteBatch)
        {
            for (int xTileSz3 = 0; xTileSz3 < 5; xTileSz3++)
            {
                for (int yTileSz3 = 0; yTileSz3 < 4  ; yTileSz3++)
                {
                    this.TileSz3Pos.Y = TileSz3.Height * yTileSz3 + 80;
                    this.TileSz3Pos.X = TileSz3.Height * xTileSz3 + 500;
                    if (yTileSz3 < 4 && TileSz3Pos.Y < height)
                    {
                        this.TileSz3Pos.Y --;

                        spriteBatch.Draw(TileSz3, this.TileSz3Pos, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        //spriteBatch.Draw(TileSz3, TileSz3Pos, Color.White);
                    }

                }
            }
        }
    }
}
