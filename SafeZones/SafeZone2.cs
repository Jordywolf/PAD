using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    class SafeZone2 : Game
    {
        private GraphicsDeviceManager _graphics;
        //private SpriteBatch spriteBatch;
        //private List<Sprite> _sprites;
        public int height = 1080;
        public int width = 1920;
        public Boolean KeyCollected = true;
        public Vector2 TileSz2, SteenVertPosition = new Vector2(0, 0);
        public Vector2 PlayerPosition = new Vector2(1920 / 2, 1080);
        public Vector2 RotsPosition = new Vector2(1920 / 3, 1080 / 2.5f);
        public Vector2 position = new Vector2(0, 0);
        public Vector2 PilaarPosition = new Vector2(1590, 200);
        public Vector2 DoorPosition = new Vector2(1920 / 2, 1080 / 100);
        //public Texture2D FonteinTexture, Pilaar, SteenTile, ZandTile, SteenVert, Boom, Rots, Deur, Player, Sleutel;

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


                this.TileSz2.X = TileSz2.Width * xTileSz2 / 4;
                this.TileSz2.Y = TileSz2.Height * 3;
                //this.TileSz2.Y = TileSz2.Height * 3;

                spriteBatch.Draw(TileSz2, this.TileSz2, null, Color.White, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);


            }
        }
        

        public void SafeZone(Texture2D TileSz2, Texture2D Sleutel, SpriteBatch spriteBatch)
        {

            //GraphicsDevice.Clear(Color.BlueViolet);
            for (int xTileSz2 = 0; xTileSz2 < width / TileSz2.Width + 25; xTileSz2++)
            {
                for (int yTileSz2 = 0; yTileSz2 < height / TileSz2.Height + 20; yTileSz2++)
                {




                    this.position.X = TileSz2.Width * xTileSz2;
                    this.position.Y = TileSz2.Height * yTileSz2;

                    spriteBatch.Draw(TileSz2, this.TileSz2, null, Color.White, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);



                }
            }
        }
        public void MovingPlatForm(Texture2D TileSz2, SpriteBatch spriteBatch)
        {
            for (int yTileSz2 = 0; yTileSz2 < height ; yTileSz2++)
            {
                this.SteenVertPosition.Y = TileSz2.Height / 3;
                this.SteenVertPosition.X = TileSz2.Width * 2;

                spriteBatch.Draw(TileSz2, SteenVertPosition, null, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);


            }
        }
        private void MovePlatForm()
        {
            
             
        }
    }

}
