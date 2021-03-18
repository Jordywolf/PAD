using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Jogonhead Jogon;
        private JogonPart jogonBodyPart;
        private JogonPart parentSegment;

        public Texture2D PillarV2_Torch;
        public Texture2D Floortile;
        public Texture2D WalltileStr;
        public Texture2D WalltileCrnL;
        public Texture2D WalltileCrnR;
        public Texture2D WalltileStrD;
        public Texture2D WalltileCrnDL;
        public Texture2D WalltileCrnDR;
        public Texture2D WalltileL;
        public Texture2D WalltileR;
        public Texture2D PillarTile;

        public int width = 64 * 20;
        public int height = 64 * 10;

        public Vector2 playerPos;

        MapConstruction mapConstruction;

        private int Segments = 15;


        public Texture2D jogonHeadTexture;
        public Texture2D jogonHSTexture;
        public Texture2D jogonBodyTexture;
        public Texture2D fireBallTexture;

        List<JogonPart> JogonDragon = new List<JogonPart>();


        public Texture2D texture;
        public Texture2D texture2;
        public Texture2D texture3;
        public Texture2D texture4;
        public Texture2D texture5;
        public Texture2D texture6;
        public Texture2D texture7;
        public Texture2D texture8;
        public Texture2D texture9;
        public Texture2D texture10;
        public Texture2D texture11;
        public Texture2D texture12;
        public Texture2D texture13;
        public SpriteFont font;
        public static int menuchoice;
        public static int framecount;
        public static int startframe;



        private SpriteBatch spriteBatch;
        private Player player;
        private List<Sprite> _sprites;
        //private JogonPart jogonHead;
       // private JogonPart jogonHS;
        //private int Segments = 4;
       
        public Boolean KeyCollected;
        public Vector2 SteenPosition,SteenVertPosition = new Vector2(0, 0);
        public Vector2 PlayerPosition = new Vector2(1920/2, 1080);
        public Vector2 RotsPosition = new Vector2(1920 / 3, 1080/ 2.5f);
        public Vector2 position = new Vector2(0, 0);
        public Vector2 PilaarPosition = new Vector2(1590, 200);
        public Vector2 DoorPosition = new Vector2(1920 / 2, 1080 / 100);
        public Texture2D FonteinTexture, Pilaar, SteenTile, ZandTile, SteenVert, Boom, Rots, Deur, Player, Sleutel,TileSz2,TileSz3;
       
        SafeZone1 safeZone = new SafeZone1();
        SafeZone2 safeZone2 = new SafeZone2();

        
        
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
            base.Initialize();
            Jogon = new Jogonhead(new Vector2(50, 400), new Vector2(0, 0), 0, 1.5f, jogonHeadTexture, 10, fireBallTexture,player);
            parentSegment = Jogon;
            for (int i = 0; i < Segments; i++)
            {
                if (i == 0) { jogonBodyPart = new JogonPart(parentSegment.position, new Vector2(0, 0), 0, 1.5f, jogonBodyTexture, 0.1f); }
                else { jogonBodyPart = new JogonPart(parentSegment.position, new Vector2(0, 0), 0, 1.5f, jogonBodyTexture, 5); }
                jogonBodyPart.Parent = parentSegment;
                Jogon.Body.Add(jogonBodyPart);
                parentSegment = jogonBodyPart;
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
            TileSz2 = Content.Load<Texture2D>("TileSz2");
            TileSz3 = Content.Load<Texture2D>("TileSz3");
            player = new Player(Player, PlayerPosition)
            {
                Input = new Input()
                {
                    Left = Keys.Left,
                    Right = Keys.Right,
                    Up = Keys.Up,
                    Down = Keys.Down,
                },
                Position = PlayerPosition,
                color = Color.Blue,
                Speed = 15f,
            };
            _sprites = new List<Sprite>()
            {

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
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            jogonBodyTexture = Content.Load<Texture2D>("jogon_BodyS");
            jogonHeadTexture = Content.Load<Texture2D>("JogonHead");
            jogonHSTexture = Content.Load<Texture2D>("Jogon_HoofdS");
            PillarV2_Torch = Content.Load<Texture2D>("PAD_Jg_PillarV2_Torch");
            Floortile = Content.Load<Texture2D>("PAD_Jg_Floortile1");
            WalltileStr = Content.Load<Texture2D>("PAD_Jg_walltileStraight");
            WalltileCrnL = Content.Load<Texture2D>("PAD_Jg_walltileCornerL");
            WalltileCrnR = Content.Load<Texture2D>("PAD_Jg_walltileCornerR");
            WalltileStrD = Content.Load<Texture2D>("PAD_Jg_walltileStraightD");
            WalltileCrnDL = Content.Load<Texture2D>("PAD_Jg_walltileCornerDL");
            WalltileCrnDR = Content.Load<Texture2D>("PAD_Jg_walltileCornerDR");
            WalltileL = Content.Load<Texture2D>("PAD_Jg_walltileL");
            WalltileR = Content.Load<Texture2D>("PAD_Jg_walltileR");
            PillarTile = Content.Load<Texture2D>("PAD_Jg_PillarV2_Standard");
            fireBallTexture = Content.Load<Texture2D>("Fireball");
            texture = Content.Load<Texture2D>("HomeScreen");
            texture2 = Content.Load<Texture2D>("MenuStartGame");
            texture3 = Content.Load<Texture2D>("MenuCredits");
            texture4 = Content.Load<Texture2D>("MenuStartGameSelected");
            texture5 = Content.Load<Texture2D>("MenuCreditsSelected");
            texture6 = Content.Load<Texture2D>("CreditScreen");
            texture7 = Content.Load<Texture2D>("MenuBack");
            texture8 = Content.Load<Texture2D>("MenuBackSelected");
            texture9 = Content.Load<Texture2D>("SecondStart");
            texture10 = Content.Load<Texture2D>("MenuNewGame");
            texture11 = Content.Load<Texture2D>("MenuNewGameSelected");
            texture12 = Content.Load<Texture2D>("MenuContinue");
            texture13 = Content.Load<Texture2D>("MenuContinueSelected");
            font = Content.Load<SpriteFont>("Credit");

            menuchoice = 1;
            framecount = 0;
            startframe = -100;


            mapConstruction = new MapConstruction(PillarTile);
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (menuchoice == 7 || menuchoice == 8)
            {
                foreach (var sprite in _sprites)
                    sprite.Update(gameTime, _sprites);
                player.Update(gameTime, _sprites);
            }
 
            // TODO: Add your update logic here

            base.Update(gameTime);
            if (menuchoice == 8)
            {
                foreach (JogonPart part in JogonDragon)
                {
                    part.Update(gameTime);
                }
                Jogon.Update(gameTime);
                if (Jogon.reached)
                {
                    Jogon.position = new Vector2(100, 4000);
                    menuchoice = 2;
                }
                foreach (Fireball fireball in Jogon.fireballs)
                {
                    fireball.Update(gameTime);
                }
            }

        }

        protected override void Draw(GameTime gameTime)
        {
            
           
            
            //part.Draw(_spriteBatch);

            


            //jogonHS.Draw(_spriteBatch);
            //jogonHead.Draw(_spriteBatch);

            _graphics.PreferredBackBufferWidth = width;
            _graphics.PreferredBackBufferHeight = height;
            _graphics.ApplyChanges();

            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);


            KeyboardState state = Keyboard.GetState();
            Keyboard.GetState();

            framecount++;




            if (menuchoice == 2 && Keyboard.GetState().IsKeyDown(Keys.Space) && framecount > startframe + 10)
            {
                menuchoice = 3;
                framecount = startframe;
            }

            if (menuchoice == 1 && Keyboard.GetState().IsKeyDown(Keys.Space) && framecount > startframe + 10)
            {
                menuchoice = 4;
                framecount = startframe;
            }

            if (menuchoice == 3 && Keyboard.GetState().IsKeyDown(Keys.Space) && framecount > startframe + 50)
            {
                menuchoice = 2;
                framecount = startframe;
            }

            if (menuchoice == 6 && Keyboard.GetState().IsKeyDown(Keys.Space) && framecount > startframe + 50)
            {
                menuchoice = 1;
                framecount = startframe;
            }

            if (menuchoice == 4 && Keyboard.GetState().IsKeyDown(Keys.Space) && framecount > startframe + 50)
            {
                menuchoice = 7;
                framecount = startframe;
            }


            // TODO: Add your drawing code here

            if (menuchoice == 1)
            {
                _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
    Matrix.CreateScale(1.3f));
                _spriteBatch.Draw(texture, new Vector2(0, -50), Color.White);
                _spriteBatch.End();

                _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
    Matrix.CreateScale(2.7f));
                _spriteBatch.Draw(texture4, new Vector2(200, 100), Color.White);
                _spriteBatch.Draw(texture3, new Vector2(200, 150), Color.White);
                _spriteBatch.End();

                _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
    Matrix.CreateScale(0.45f));
                _spriteBatch.DrawString(font, "Press", new Vector2(0, 1000), Color.Beige);
                _spriteBatch.DrawString(font, "Arrow Keys", new Vector2(0, 1050), Color.Beige);
                _spriteBatch.DrawString(font, "Press", new Vector2(0, 1150), Color.Beige);
                _spriteBatch.DrawString(font, "Space", new Vector2(0, 1200), Color.Beige);
                _spriteBatch.End();

                if (Keyboard.GetState().IsKeyDown(Keys.Up) && framecount > startframe + 10)

                {
                    menuchoice = 1;


                }

                if (Keyboard.GetState().IsKeyDown(Keys.Down) && framecount > startframe + 10)
                {
                    menuchoice = 2;

                }
            }

            if (menuchoice == 2)
            {
                _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
    Matrix.CreateScale(1.3f));
                _spriteBatch.Draw(texture, new Vector2(0, -50), Color.White);
                _spriteBatch.End();

                _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
    Matrix.CreateScale(2.7f));
                _spriteBatch.Draw(texture2, new Vector2(200, 100), Color.White);
                _spriteBatch.Draw(texture5, new Vector2(200, 150), Color.White);
                _spriteBatch.End();

                _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
Matrix.CreateScale(0.45f));
                _spriteBatch.DrawString(font, "Press", new Vector2(0, 1000), Color.Beige);
                _spriteBatch.DrawString(font, "Arrow Keys", new Vector2(0, 1050), Color.Beige);
                _spriteBatch.DrawString(font, "Press", new Vector2(0, 1150), Color.Beige);
                _spriteBatch.DrawString(font, "Space", new Vector2(0, 1200), Color.Beige);
                _spriteBatch.End();

                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Up) && framecount > startframe + 10)

                {
                    menuchoice = 1;


                }

                if (Keyboard.GetState().IsKeyDown(Keys.Down) && framecount > startframe + 10)
                {
                    menuchoice = 2;

                }
            }

            if (menuchoice == 3)
            {
                _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
    Matrix.CreateScale(1.8f));
                _spriteBatch.Draw(texture6, new Vector2(0, 0), Color.White);
                _spriteBatch.End();

                _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
    Matrix.CreateScale(2.7f));
                _spriteBatch.Draw(texture8, new Vector2(350, 180), Color.White);
                _spriteBatch.End();

                _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
    Matrix.CreateScale(0.6f));

                _spriteBatch.DrawString(font, "Nick Baptist", new Vector2(100, 100), Color.Beige);
                _spriteBatch.DrawString(font, "Nidal Toufik", new Vector2(100, 400), Color.Beige);
                _spriteBatch.DrawString(font, "Jordy Wolf", new Vector2(100, 700), Color.Beige);
                _spriteBatch.DrawString(font, "Jort Keppel", new Vector2(1000, 100), Color.Beige);
                _spriteBatch.DrawString(font, "Olivier Molenaar", new Vector2(1000, 400), Color.Beige);
                _spriteBatch.DrawString(font, "Jordi van der Lem", new Vector2(1000, 700), Color.Beige);

                _spriteBatch.End();
            }

            if (menuchoice == 4)
            {
                _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
    Matrix.CreateScale(2.1f));
                _spriteBatch.Draw(texture9, new Vector2(0, -50), Color.White);
                _spriteBatch.End();

                _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
    Matrix.CreateScale(2.7f));
                _spriteBatch.Draw(texture11, new Vector2(200, 50), Color.White);
                _spriteBatch.Draw(texture12, new Vector2(200, 100), Color.White);
                _spriteBatch.Draw(texture7, new Vector2(350, 180), Color.White);
                _spriteBatch.End();



                if (Keyboard.GetState().IsKeyDown(Keys.Down) && framecount > startframe + 10)
                {
                    menuchoice = 5;
                    framecount = startframe;
                }
            }

            if (menuchoice == 5)
            {
                _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
    Matrix.CreateScale(2.1f));
                _spriteBatch.Draw(texture9, new Vector2(0, -50), Color.White);
                _spriteBatch.End();

                _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
    Matrix.CreateScale(2.7f));
                _spriteBatch.Draw(texture10, new Vector2(200, 50), Color.White);
                _spriteBatch.Draw(texture13, new Vector2(200, 100), Color.White);
                _spriteBatch.Draw(texture7, new Vector2(350, 180), Color.White);
                _spriteBatch.End();

                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Up) && framecount > startframe + 10)

                {
                    menuchoice = 4;
                    framecount = startframe;

                }

                if (Keyboard.GetState().IsKeyDown(Keys.Down) && framecount > startframe + 10)
                {
                    menuchoice = 6;
                    framecount = startframe;
                }
            }

            if (menuchoice == 6)
            {
                _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
    Matrix.CreateScale(2.1f));
                _spriteBatch.Draw(texture9, new Vector2(0, -50), Color.White);
                _spriteBatch.End();

                _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
    Matrix.CreateScale(2.7f));
                _spriteBatch.Draw(texture10, new Vector2(200, 50), Color.White);
                _spriteBatch.Draw(texture12, new Vector2(200, 100), Color.White);
                _spriteBatch.Draw(texture8, new Vector2(350, 180), Color.White);
                _spriteBatch.End();

                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Up) && framecount > startframe + 10)

                {
                    menuchoice = 5;
                    framecount = startframe;

                }


            }

            if (menuchoice == 7)
            {
                
                safeZone.SafeZone(ZandTile, Sleutel, spriteBatch);
                safeZone.SafeZoneStone(SteenTile, spriteBatch);
                safeZone.SafeZoneStoneVert(SteenVert, spriteBatch);
                safeZone.NextLevel1();
                spriteBatch.End();
                //foreach (var sprite in _sprites)
                   // sprite.Draw(spriteBatch);
                //player.Draw(spriteBatch);


            }

            if (menuchoice == 8)
            {
                mapConstruction.FloorConstruction(new Vector2(0, 0), Floortile, _spriteBatch, width, height);
                mapConstruction.WallConstruction(new Vector2(0, 0), new Vector2(0, ((int)(height / Floortile.Height) - 1) * Floortile.Height), new Vector2(0, 0), new Vector2(((int)(width / Floortile.Width) - 1) * Floortile.Width, 0), _spriteBatch, width, height, WalltileStr, WalltileStrD, WalltileL, WalltileR, WalltileCrnL, WalltileCrnR, WalltileCrnDL, WalltileCrnDR);
                mapConstruction.PillarSetup(_spriteBatch, PillarTile, width, height, new Vector2(0, 0));

                
                foreach (Fireball fireball in Jogon.fireballs)
                {
                    fireball.Draw(_spriteBatch);
                }
                foreach (JogonPart part in JogonDragon)
                {
                    part.Draw(_spriteBatch);
                }
                player.Draw(spriteBatch);
                Jogon.Draw(_spriteBatch);

            }



        }
    }
}