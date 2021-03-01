using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    class SafeZone1 : Game
    {
        private GraphicsDeviceManager _graphics;
        //private SpriteBatch spriteBatch;
        //private List<Sprite> _sprites;
        public int height = 1080;
        public int width = 1920;
        public Boolean KeyCollected = true;
        public Vector2 SteenPosition,SteenVertPosition = new Vector2(0, 0);
        public Vector2 PlayerPosition = new Vector2(1920/2, 1080);
        public Vector2 RotsPosition = new Vector2(1920 / 3, 1080/ 2.5f);
        public Vector2 position = new Vector2(0, 0);
        public Vector2 PilaarPosition = new Vector2(1590, 200);
        public Vector2 DoorPosition = new Vector2(1920 / 2, 1080 / 100);
        //public Texture2D FonteinTexture, Pilaar, SteenTile, ZandTile, SteenVert, Boom, Rots, Deur, Player, Sleutel;
        
        /*protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Pilaar = Content.Load<Texture2D>("Pilaar");
            FonteinTexture = Content.Load<Texture2D>("Fontein");
            ZandTile = Content.Load<Texture2D>("ZandTile");
            SteenTile = Content.Load<Texture2D>("steen");
            SteenVert = Content.Load<Texture2D>("SteenVert");
            Boom = Content.Load<Texture2D>("Boom");
            Rots = Content.Load<Texture2D>("Rots");
            Deur = Content.Load<Texture2D>("Deur");
            Player = Content.Load<Texture2D>("Player");
            Sleutel = Content.Load<Texture2D>("Sleutel");

            // TODO: use this.Content to load your game content here
        }*/
        public  void NextLevel1()
        {
            if (PlayerPosition.Y > DoorPosition.Y && KeyCollected == true && Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Console.WriteLine(PlayerPosition);
                Exit();
            }
            if (PlayerPosition.Y == PilaarPosition.Y)
            {


                KeyCollected = true;
            }
        }
        public void SafeZoneStone(Texture2D SteenTile, SpriteBatch spriteBatch)
        {
            for (int xSteenTile = 0; xSteenTile < width / SteenTile.Width * 3; xSteenTile++)
            {


                this.SteenPosition.X = SteenTile.Width * xSteenTile / 2;
                this.SteenPosition.Y = SteenTile.Height * 3;
                
                spriteBatch.Draw(SteenTile, SteenPosition, null, Color.White, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
                

            }
        }
        public  void SafeZoneStoneVert(Texture2D SteenVert, SpriteBatch spriteBatch)
        {
            for (int ySteenVert = 0; ySteenVert < height; ySteenVert++)
            {
                this.SteenVertPosition.Y = SteenVert.Height * ySteenVert / 3;
                this.SteenVertPosition.X = width / 2;
                
                spriteBatch.Draw(SteenVert, SteenVertPosition, null, Color.White, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
                

            }
        }

        public  void SafeZone(Texture2D ZandTile, Texture2D Sleutel, SpriteBatch spriteBatch)
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
                        spriteBatch.Draw(Sleutel, new Vector2(1590, 200), Color.White);
                    }

                   

                }
            }
        }
    }

}
