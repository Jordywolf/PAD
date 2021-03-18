﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class Game1 : GameEnvironment
    {
        //private GraphicsDeviceManager _graphics;
        //private SpriteBatch _spriteBatch;

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
        GameStates.MenuStartSelectedState menuStartSelectedState;
        GameStates.MenuCreditsSelectedState menuCreditsSelectedState;
        GameStates.MenuCreditsState menuCreditsState;
        GameStates.NewGameState newGameState;
        GameStates.ContinueState continueState;
        GameStates.BackState backState;
        GameStates.SafeZoneState safeZoneState;
        GameStates.JogonLevelPlayingState jogonLevelPlayingState;
        //GameStates.JogonSafeZoneState jogonSafeZoneState;

        public int width = 1280;
        public int height = 640;

        public Vector2 playerPos;

        //MapConstruction mapConstruction;

        //private int Segments = 15;


        public Texture2D jogonHeadTexture;
        public Texture2D jogonHSTexture;
        public Texture2D jogonBodyTexture;
        public Texture2D fireBallTexture;

        //List<JogonPart> JogonDragon = new List<JogonPart>();


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

        public Texture2D HBedgeLTexture;
        public Texture2D HBedgeRTexture;
        public Texture2D HBmiddleTexture;
        public Texture2D HBhealthTexture;

        //private SpriteBatch spriteBatch;
        public static Player player;
        public static List<Sprite> _sprites;
        //private JogonPart jogonHead;
        // private JogonPart jogonHS;
        //private int Segments = 4;

        public Boolean KeyCollected;
        public Vector2 SteenPosition, SteenVertPosition = new Vector2(0, 0);
        public Vector2 PlayerPosition = new Vector2(1920 / 2, 1080);
        public Vector2 RotsPosition = new Vector2(1920 / 3, 1080 / 2.5f);
        public Vector2 position = new Vector2(0, 0);
        public Vector2 PilaarPosition = new Vector2(1590, 200);
        public Vector2 DoorPosition = new Vector2(1920 / 2, 1080 / 100);
        public Texture2D FonteinTexture, Pilaar, SteenTile, ZandTile, SteenVert, Boom, Rots, Deur, Player, Sleutel;

        //SafeZone1 safeZone = new SafeZone1();


        //public Texture2D jogonHeadTexture;
        //public Texture2D jogonHSTexture;
        //public Texture2D jogonBodyTexture;
        // List<JogonPart> JogonDragon = new List<JogonPart>();


        public Game1() : base()
        {
            //_graphics = new GraphicsDeviceManager(this);
            //Content.RootDirectory = "Content";
            IsMouseVisible = true;

            screen.X = width;
            screen.Y = height;

            //graphics.PreferredBackBufferWidth = width;
            //graphics.PreferredBackBufferHeight = height;
            //graphics.ApplyChanges();

            //GraphicsDevice.Clear(Color.CornflowerBlue);
        }

        protected override void Initialize()
        {
            base.Initialize();
            /*Jogon = new Jogonhead(new Vector2(50, 400), new Vector2(0, 0), 0, 1.5f, jogonHeadTexture, 10, fireBallTexture, player);
            parentSegment = Jogon;
            for (int i = 0; i < Segments; i++)
            {
                if (i == 0) { jogonBodyPart = new JogonPart(parentSegment.position, new Vector2(0, 0), 0, 1.5f, jogonBodyTexture, 0.1f); }
                else { jogonBodyPart = new JogonPart(parentSegment.position, new Vector2(0, 0), 0, 1.5f, jogonBodyTexture, 5); }
                jogonBodyPart.Parent = parentSegment;
                Jogon.Body.Add(jogonBodyPart);
                parentSegment = jogonBodyPart;
            }*/
        }

        protected override void LoadContent()
        {
            ApplyResolutionSettings();
            base.LoadContent();
            //spriteBatch = new SpriteBatch(GraphicsDevice);
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
            //spriteBatch = new SpriteBatch(GraphicsDevice);
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
            HBhealthTexture = Content.Load<Texture2D>("healthBarMiddle");
            HBmiddleTexture = Content.Load<Texture2D>("healthBarMiddleborder");
            HBedgeRTexture = Content.Load<Texture2D>("healthBarEnd");
            HBedgeLTexture = Content.Load<Texture2D>("healthBarEndL");

            menuchoice = 1;
            framecount = 0;
            startframe = -100;


            //mapConstruction = new MapConstruction(PillarTile);

            menuStartSelectedState = new GameStates.MenuStartSelectedState();
            GameEnvironment.gameStateList.Add(menuStartSelectedState);
            GameEnvironment.SwitchTo(0);

            menuCreditsSelectedState = new GameStates.MenuCreditsSelectedState();
            GameEnvironment.gameStateList.Add(menuCreditsSelectedState);

            menuCreditsState = new GameStates.MenuCreditsState();
            GameEnvironment.gameStateList.Add(menuCreditsState);

            newGameState = new GameStates.NewGameState();
            GameEnvironment.gameStateList.Add(newGameState);

            continueState = new GameStates.ContinueState();
            GameEnvironment.gameStateList.Add(continueState);

            backState = new GameStates.BackState();
            GameEnvironment.gameStateList.Add(backState);

            safeZoneState = new GameStates.SafeZoneState();
            GameEnvironment.gameStateList.Add(safeZoneState);

            jogonLevelPlayingState = new GameStates.JogonLevelPlayingState(PillarTile, jogonHeadTexture, fireBallTexture, jogonBodyTexture, HBmiddleTexture, HBhealthTexture, HBedgeRTexture, HBedgeLTexture, player);
            GameEnvironment.gameStateList.Add(jogonLevelPlayingState);
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
            /*if (menuchoice == 8)
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
            }*/

        }

        protected override void Draw(GameTime gameTime)
        {



            //part.Draw(_spriteBatch);




            //jogonHS.Draw(_spriteBatch);
            //jogonHead.Draw(_spriteBatch);


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
                menuStartSelectedState.Draw(spriteBatch, texture, texture3, texture4, font);
            }

            if (menuchoice == 2)
            {
                menuCreditsSelectedState.Draw(spriteBatch, texture, texture2, texture5, font);
            }

            if (menuchoice == 3)
            {
                menuCreditsState.Draw(spriteBatch, texture6, texture8, font);
            }

            if (menuchoice == 4)
            {
                newGameState.Draw(spriteBatch, texture9, texture11, texture12, texture7);
            }

            if (menuchoice == 5)
            {
                continueState.Draw(spriteBatch, texture9, texture10, texture13, texture7);
            }

            if (menuchoice == 6)
            {
                backState.Draw(spriteBatch, texture9, texture10, texture12, texture8);
            }

            if (menuchoice == 7)
            {
                safeZoneState.SafzoneConstruction(spriteBatch, player, _sprites, ZandTile, Sleutel, SteenTile, SteenVert);
            }

            if (menuchoice == 8)
            {
                jogonLevelPlayingState.JogonLevelConstruction(player, Floortile, width, height, WalltileStr, WalltileStrD, WalltileL, WalltileR, WalltileCrnL, WalltileCrnR, WalltileCrnDL, WalltileCrnDR, PillarTile, Player, menuchoice);
                //jogonLevelPlayingState.Draw(_spriteBatch);
            }
        }
    }
}