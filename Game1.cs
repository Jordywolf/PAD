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
        public Boolean KeyCollected = true;
        public Vector2 SteenPosition,SteenVertPosition = new Vector2(0, 0);
        public Vector2 PlayerPosition = new Vector2(1920/2, 1080);
        public Vector2 RotsPosition = new Vector2(1920 / 3, 1080/ 2.5f);
        public Vector2 position = new Vector2(0, 0);
        public Vector2 PilaarPosition = new Vector2(1590, 200);
        public Vector2 DoorPosition = new Vector2(1920 / 2, 1080 / 100);
        public Texture2D FonteinTexture, Pilaar, SteenTile, ZandTile, SteenVert, Boom, Rots, Deur, Player, Sleutel;
       
        SafeZone1 safeZone = new SafeZone1();
        
        
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
            Sleutel = Content.Load<Texture2D>("Sleutel");
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
                    Position = PlayerPosition,
                    color = Color.Blue,
                    Speed = 5f,
                },

                new Sprite(Rots){
                Position = RotsPosition,
                },
                new Sprite(Deur)
                {
                    Position = new Vector2(width/2, height/ 100)
                },
                new Sprite(Boom)
                {
                    Position = new Vector2(width/4, height/1.5f)
                },
                new Sprite(Pilaar)
                {
                    Position = PilaarPosition
                },
                new Sprite(FonteinTexture)
                {
                    Position = new Vector2(200,75)
                }
            };
            
            // TODO: use this.Content to load your game content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            foreach (var sprite in _sprites)
                sprite.Update(gameTime, _sprites);
 
            // TODO: Add your update logic here
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
            //foreach (JogonPart part in JogonDragon)
            _graphics.PreferredBackBufferWidth = width;
            _graphics.PreferredBackBufferHeight = height;
            _graphics.ApplyChanges();
            safeZone.SafeZone( ZandTile,  Sleutel, spriteBatch);
            safeZone.SafeZoneStone(SteenTile, spriteBatch);
            safeZone.SafeZoneStoneVert(SteenVert, spriteBatch);
            safeZone.NextLevel1();
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
