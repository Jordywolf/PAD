using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace BaseProject
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private List<Sprite> _sprites;
        //private JogonPart jogonHead;
       // private JogonPart jogonHS;
        //private int Segments = 4;
        public int height = 1080;
        public int width = 1920;
        public Vector2 SteenPosition,SteenVertPosition,PlayerPosition = new Vector2(0, 0);
        public Vector2 position = new Vector2(0, 0);
        public Texture2D FonteinTexture, Pilaar, SteenTile, ZandTile,SteenVert,Boom,Rots,Deur,Player;
        
        
        //public Texture2D jogonHeadTexture;
        //public Texture2D jogonHSTexture;
        //public Texture2D jogonBodyTexture;
       // List<JogonPart> JogonDragon = new List<JogonPart>();


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            //jogonHead = new JogonPart(new Vector2(100, 50), new Vector2(0, 0), jogonHeadTexture,0);
            //jogonHS = new JogonPart(new Vector2(100, 50), new Vector2(0, 0), jogonHSTexture,1);
            //JogonDragon.Add(jogonHead);
            //for (int i = 0; i < Segments; i++)
            {
                //JogonDragon.Add(new JogonPart(new Vector2(100, 50), new Vector2(0, 0), jogonBodyTexture, i*10));
            }
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //jogonBodyTexture = Content.Load<Texture2D>("jogon_BodySegment");
            //jogonHeadTexture = Content.Load<Texture2D>("JogonHead2");
            //jogonHSTexture = Content.Load<Texture2D>("Jogon_HeadSegment");
            Pilaar = Content.Load<Texture2D>("Pilaar");
            FonteinTexture = Content.Load<Texture2D>("Fontein");
            ZandTile = Content.Load<Texture2D>("ZandTile");
            SteenTile = Content.Load<Texture2D>("steen");
            SteenVert = Content.Load<Texture2D>("SteenVert");
            Boom = Content.Load<Texture2D>("Boom");
            Rots = Content.Load<Texture2D>("Rots");
            Deur = Content.Load<Texture2D>("Deur");
            Player = Content.Load<Texture2D>("Player");
            _sprites = new List<Sprite>()
            {
                new Player(Player)
                {
                    Input = new  Input()
                    {
                        Left = Keys.A,
                        Right = Keys.D,
                        Up = Keys.W,
                        Down = Keys.S,
                    },
                    Position = new Vector2(100,100),
                    color = Color.Blue,
                    Speed = 5f,
                },

                new Player(Player)
                {
                    Input = new  Input()
                    {
                        Left = Keys.Left,
                        Right = Keys.Right,
                        Up = Keys.Up,
                        Down = Keys.Down,
                    },
                    Position = new Vector2(100,100),
                    color = Color.Red,
                    Speed = 5f,
                },
                new Sprite(Rots){
                Position = new Vector2(width/3,height/2.5f),
                },
                new Sprite(Deur)
                {
                    Position = new Vector2(width/2, height -100)
                },
                new Sprite(Boom)
                {
                    Position = new Vector2(width/4, height/1.5f)
                },
                new Sprite(Pilaar)
                {
                    Position = new Vector2(1590,200)
                },
                new Sprite(FonteinTexture)
                {
                    Position = new Vector2(200,75)
                }
            };
            
            // TODO: use this.Content to load your game content here
        }
        public void SafeZoneStone()
       {
            for (int xSteenTile = 0; xSteenTile < width / SteenTile.Width *3 ; xSteenTile++)
            {
                
             
                   this.SteenPosition.X = SteenTile.Width * xSteenTile / 2;
                    this.SteenPosition.Y = SteenTile.Height *3;
                   spriteBatch.Draw(SteenTile, SteenPosition, null, Color.White, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
              
                
            }
        }
        public void SafeZoneStoneVert()
        {
           for (int ySteenVert = 0; ySteenVert < height ; ySteenVert++)
            {
              this.SteenVertPosition.Y = SteenVert.Height * ySteenVert /3;
                this.SteenVertPosition.X = width / 2;
         
            spriteBatch.Draw(SteenVert, SteenVertPosition, null, Color.White, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
         

            }
        }
        public void SafeZone()
        {
            //this.position = FloorPosition;
            GraphicsDevice.Clear(Color.BlueViolet);
            for (int xZandTile = 0; xZandTile < width / ZandTile.Width +25; xZandTile++)
            {
                for (int yZandTile = 0; yZandTile < height / ZandTile.Height + 20; yZandTile++)
                {
                    
                    


                            this.position.X = ZandTile.Width * xZandTile;
                            this.position.Y = ZandTile.Height * yZandTile;
                         //   spriteBatch.Begin();
                            spriteBatch.Draw(ZandTile, position, Color.White);
                        //spriteBatch.End();
                    
               }
            }
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            foreach (var sprite in _sprites)
                sprite.Update(gameTime, _sprites);
            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                this.PlayerPosition.X += 3;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                this.PlayerPosition.X -= 3;
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && this.PlayerPosition.Y != height)
                this.PlayerPosition.Y -= 3;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                this.PlayerPosition.Y += 3;
                base.Update(gameTime);
            //foreach (JogonPart part in JogonDragon)
            {
                //part.Update();
            }
           // jogonHS.Update();
           // jogonHead.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            
            spriteBatch.Begin();
            SafeZone();
            SafeZoneStoneVert();
            SafeZoneStone();
            //foreach (JogonPart part in JogonDragon)
            _graphics.PreferredBackBufferWidth = width;
            _graphics.PreferredBackBufferHeight = height;
            _graphics.ApplyChanges();
            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);
            spriteBatch.End();
            
            //part.Draw(_spriteBatch);

            


            //jogonHS.Draw(_spriteBatch);
            //jogonHead.Draw(_spriteBatch);


            // TODO: Add your drawing code here

            base.Draw(gameTime);
            

        }
    
    }
    // test jordi branch
}
