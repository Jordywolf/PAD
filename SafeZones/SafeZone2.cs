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
        public int height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        public int width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        public float Speed = 10000f;
        public Boolean KeyCollected = true;
        public Vector2 TileSz2Pos,SteenVertPosition = new Vector2(0, 0);
        public Vector2 TileSz3Pos = new Vector2(400, 400);
        public Vector2 PlayerPosition = new Vector2(1920 / 2, 1080);
        public Vector2 RotsPosition = new Vector2(1920 / 3.5f, 1080 / 5f);
        public Vector2 position = new Vector2(0, 0);
        public Vector2 PilaarPosition = new Vector2(1590, 200);
        public Vector2 DoorPosition = new Vector2(1920 / 3,0);
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


                this.TileSz2Pos.X = TileSz2.Width * xTileSz2 / 4;
                this.TileSz2Pos.Y = TileSz2.Height * 3;
                //this.TileSz2.Y = TileSz2.Height * 3;

                spriteBatch.Draw(TileSz2, TileSz2Pos, null, Color.White, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);


            }
        }
        

        public void SafeZone(Texture2D TileSz2, Texture2D Deur, SpriteBatch spriteBatch)
        {

            //GraphicsDevice.Clear(Color.BlueViolet);
            for (int xTileSz2 = 0; xTileSz2 < width  / TileSz2.Width ; xTileSz2++)
            {
                for (int yTileSz2 = 0; yTileSz2 < height / TileSz2.Height +20; yTileSz2++)
                {




                    this.TileSz2Pos.X = TileSz2.Width * xTileSz2;
                    this.TileSz2Pos.Y = TileSz2.Height * yTileSz2 * 7.8f ;

                    //spriteBatch.Draw(TileSz2, this.TileSz2Pos, null, Color.White, 0f, Vector2.Zero, 0.99f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(TileSz2, TileSz2Pos, Color.White);
                    spriteBatch.Draw(Deur, DoorPosition, Color.White);

                }
            }
        }
        public void MovingPlatForm(Texture2D TileSz3, Texture2D FonteinTexture , SpriteBatch spriteBatch)
        {
            for (int xTileSz3 = 0; xTileSz3 < 5; xTileSz3++)
            {
                for (int yTileSz3 = 0; yTileSz3 < 4  ; yTileSz3++)
                {
                    this.TileSz3Pos.Y = TileSz3.Height * yTileSz3 + 200; 
                    this.TileSz3Pos.X = TileSz3.Height * xTileSz3 + 500;
                   Speed++;
                    


                    spriteBatch.Draw(TileSz3,TileSz3Pos, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        spriteBatch.Draw(FonteinTexture, RotsPosition, null, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
                        //spriteBatch.Draw(TileSz3, TileSz3Pos, Color.White);
                    

                }
            
            }

        }


        public void NextLevel1()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && Game1.menuchoice == 10)
            {
                Game1.menuchoice = 11;

            }
            
        }
        private void MovePlatForm()
        {

        }

    }

}
