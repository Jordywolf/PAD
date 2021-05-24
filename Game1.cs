using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Engine;

namespace BaseProject
{
    class Game1 : ExtendedGame
    {
        //-----------------------------------------------------------------------------------
        public static bool buttonPressed;
        //-----------------------------------------------------------------------------------

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
        GameStates.PauseStateJogon pauseState;
        GameStates.PauseStateSelin pauseStateSelin;
        GameStates.DeathState deathState;
        GameStates.SafeZoneState safeZoneState;
        GameStates.SafeZoneState2 safeZoneState2;
        GameStates.JogonLevelPlayingState jogonLevelPlayingState;
        GameStates.SelinLevelPlayingState selinLevelPlayingState;

        //GameStates.JogonSafeZoneState jogonSafeZoneState;

        public static int width = 1280;
        public static int height = 640;

        public Vector2 playerPos;

        //Textures
        public Texture2D jogonHeadTexture;
        public Texture2D jogonHSTexture;
        public Texture2D jogonBodyTexture;
        public Texture2D fireBallTexture;

        public Texture2D HomeScreen;
        public Texture2D MenuStartGame;
        public Texture2D MenuCredits;
        public Texture2D MenuStartGameSelected;
        public Texture2D MenuCreditsSelected;
        public Texture2D CreditScreen;
        public Texture2D MenuBack;
        public Texture2D MenuBackSelected;
        public Texture2D SecondStart;
        public Texture2D MenuNewGame;
        public Texture2D MenuNewGameSelected;
        public Texture2D MenuContinue;
        public Texture2D MenuContinueSelected;
        public SpriteFont font,font2;
        public static int menuchoice;
        public static int framecount;
        public static int startframe;

        // Sounds
        public static SoundEffect jogonSound;
        public static SoundEffect jogonFightSound;
        public SoundEffect MenuBM;
        public SoundEffect ButtonSound;
        public SoundEffectInstance MenuBMI;

        public Texture2D HBedgeLTexture;
        public Texture2D HBedgeRTexture;
        public Texture2D HBmiddleTexture;
        public Texture2D HBhealthTexture;

        public Texture2D Sn_grassTexture;
        public Texture2D Sn_stoneTexture;
        public Texture2D Sn_obstacleTexture;

        public static Player player;
        public static SpriteGameObject playerShadow;
        public static SpriteGameObject playerHealth1;
        public static SpriteGameObject playerHealth2;
        public static SpriteGameObject playerHealth3;
        public static List<Sprite> _sprites;
        public static List<Sprite> noSprite;

        public static ItemPickup ItemPickup;

        public Boolean KeyCollected;
        public Vector2 SteenPosition, SteenVertPosition = new Vector2(0, 0);
        public Vector2 PlayerPosition = new Vector2(1920 / 2, 1080);
        public Vector2 RotsPosition = new Vector2(1920 / 3, 1080 / 2.5f);
        public Vector2 position = new Vector2(0, 0);
        public Vector2 PilaarPosition = new Vector2(1590, 200);
        public Vector2 DoorPosition = new Vector2(1920 / 2, 1080 / 100);
        public static Texture2D FonteinTexture, Pilaar, SteenTile, ZandTile, SteenVert, Boom, Rots, Deur, Player, Sleutel, TileSz2, TileSz3;

        SafeZone1 safeZone = new SafeZone1();
        SafeZone2 safeZone2 = new SafeZone2();

        public Game1() : base()
        {
            IsMouseVisible = true;

            windowSize = new Point(width, height);
            worldSize = windowSize;


        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            FullScreen = false;
            base.LoadContent();
            //Safezone 1
            Pilaar = Content.Load<Texture2D>("Pilaar");
            FonteinTexture = Content.Load<Texture2D>("Fontein");
            ZandTile = Content.Load<Texture2D>("ZandTile");
            SteenTile = Content.Load<Texture2D>("steen");
            SteenVert = Content.Load<Texture2D>("SteenVert");
            Boom = Content.Load<Texture2D>("Boom");
            Rots = Content.Load<Texture2D>("Rots");
            Deur = Content.Load<Texture2D>("Deur");
            //player
            Player = Content.Load<Texture2D>("De_Rakker");
            //Tiles
            Sleutel = Content.Load<Texture2D>("Sleutel");
            TileSz2 = Content.Load<Texture2D>("TileSz2");
            TileSz3 = Content.Load<Texture2D>("TileSz3");
            //Jogon
            jogonBodyTexture = Content.Load<Texture2D>("jogon_BodyS");
            jogonHeadTexture = Content.Load<Texture2D>("JogonHead");
            jogonSound = Content.Load<SoundEffect>("JogonRoar");
            jogonFightSound = Content.Load<SoundEffect>("JogonBattelMusic");
            //JogonLevel
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
            //Home en menus

            HomeScreen = Content.Load<Texture2D>("HomeScreen");
            MenuStartGame = Content.Load<Texture2D>("MenuStartGame");
            MenuCredits = Content.Load<Texture2D>("MenuCredits");
            MenuStartGameSelected = Content.Load<Texture2D>("MenuStartGameSelected");
            MenuCreditsSelected = Content.Load<Texture2D>("MenuCreditsSelected");
            CreditScreen = Content.Load<Texture2D>("CreditScreen");
            MenuBack = Content.Load<Texture2D>("MenuBack");
            MenuBackSelected = Content.Load<Texture2D>("MenuBackSelected");
            SecondStart = Content.Load<Texture2D>("SecondStart");
            MenuNewGame = Content.Load<Texture2D>("MenuNewGame");
            MenuNewGameSelected = Content.Load<Texture2D>("MenuNewGameSelected");
            MenuContinue = Content.Load<Texture2D>("MenuContinue");
            MenuContinueSelected = Content.Load<Texture2D>("MenuContinueSelected");
            HBhealthTexture = Content.Load<Texture2D>("healthBarMiddle");
            HBmiddleTexture = Content.Load<Texture2D>("healthBarMiddleborder");
            HBedgeRTexture = Content.Load<Texture2D>("healthBarEnd");
            HBedgeLTexture = Content.Load<Texture2D>("healthBarEndL");
            MenuBM = Content.Load<SoundEffect>("BeginBM");
            MenuBMI = MenuBM.CreateInstance();
            ButtonSound = Content.Load<SoundEffect>("ButtonClick");

            font2 = Content.Load<SpriteFont>("Eightbit");
            font = Content.Load<SpriteFont>("Credit");
            player = new Player();
            playerShadow = new SpriteGameObject("PlayerShadow", 0.9f);
            playerHealth1 = new SpriteGameObject("Heart", 1);
            playerHealth2 = new SpriteGameObject("Heart", 1);
            playerHealth3 = new SpriteGameObject("Heart", 1);

            noSprite = new List<Sprite>();
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



            menuchoice = 1;
            framecount = 0;
            startframe = -100;

            menuStartSelectedState = new GameStates.MenuStartSelectedState();
            GameStateManager.AddGameState("menuStartSelectedState", menuStartSelectedState);



            menuCreditsSelectedState = new GameStates.MenuCreditsSelectedState();
            GameStateManager.AddGameState("menuCreditsSelectedState", menuCreditsSelectedState);

            menuCreditsState = new GameStates.MenuCreditsState();
            GameStateManager.AddGameState("menuCreditsState", menuCreditsState);

            newGameState = new GameStates.NewGameState();
            GameStateManager.AddGameState("newGameState", newGameState);

            continueState = new GameStates.ContinueState();
            GameStateManager.AddGameState("continueState", continueState);

            backState = new GameStates.BackState();
            GameStateManager.AddGameState("backState", backState);

            pauseState = new GameStates.PauseStateJogon();
            GameStateManager.AddGameState("pauseState", pauseState);

            pauseStateSelin = new GameStates.PauseStateSelin();
            GameStateManager.AddGameState("pauseStateSelin", pauseStateSelin);

            deathState = new GameStates.DeathState();
            GameStateManager.AddGameState("deathState", deathState);

            safeZoneState = new GameStates.SafeZoneState();
            GameStateManager.AddGameState("safeZoneState", safeZoneState);

            jogonLevelPlayingState = new GameStates.JogonLevelPlayingState(jogonSound, Player, jogonFightSound);
            GameStateManager.AddGameState("jogonLevelPlayingState", jogonLevelPlayingState);

            safeZoneState2 = new GameStates.SafeZoneState2();
            GameStateManager.AddGameState("safeZoneState2", safeZoneState2);

            selinLevelPlayingState = new GameStates.SelinLevelPlayingState();
            GameStateManager.AddGameState("selinLevelPlayingState", selinLevelPlayingState);

            GameStateManager.SwitchTo("menuStartSelectedState");
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (menuchoice == 7)
            {
                foreach (var sprite in _sprites)
                    sprite.Update(gameTime, _sprites);
                player.Update(gameTime);
            }
            if (menuchoice == 8)
            {
                foreach (var sprite in noSprite)
                    sprite.Update(gameTime, noSprite);
                player.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);

            KeyboardState state = Keyboard.GetState();
            Keyboard.GetState();

            framecount++;

            if (Keyboard.GetState().IsKeyDown(Keys.O) && framecount > startframe + 50)
            {
                GameStateManager.SwitchTo("deathState");
                framecount = startframe;
                MenuBMI.Stop();
            }

          

                if (Keyboard.GetState().IsKeyDown(Keys.P) && framecount > startframe + 50)
                {
                    GameStateManager.SwitchTo("pauseState");
                    framecount = startframe;
                    
                }
            

          
                if (Keyboard.GetState().IsKeyDown(Keys.L) && framecount > startframe + 50)
                {
                    GameStateManager.SwitchTo("pauseStateSelin");
                    framecount = startframe;

                }
            

            /*if (menuchoice == 2 && Keyboard.GetState().IsKeyDown(Keys.Space) && framecount > startframe + 10)
            {
                ButtonSound.Play();
                menuchoice = 3;
                //GameStateManager.SwitchTo("menuCreditsState");
                framecount = startframe;
            }

            if (menuchoice == 1 && Keyboard.GetState().IsKeyDown(Keys.Space) && framecount > startframe + 10)
            {
                ButtonSound.Play();
                menuchoice = 4;
                framecount = startframe;
            }

            if (menuchoice == 3 && Keyboard.GetState().IsKeyDown(Keys.Space) && framecount > startframe + 50)
            {
                ButtonSound.Play();
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
                ButtonSound.Play();
                MenuBMI.Stop();
                menuchoice = 7;
                framecount = startframe;
                
            }

            if (Keyboard.GetState().IsKeyDown(Keys.P) && framecount > startframe + 50)
            {
                menuchoice = 11;
                framecount = startframe;
            }

            if (menuchoice == 1)
            {
                //menuStartSelectedState.Draw(spriteBatch, HomeScreen, MenuCredits, MenuStartGameSelected, font);
            }

            if (menuchoice == 2)
            {
                //menuCreditsSelectedState.Draw(spriteBatch, HomeScreen, MenuStartGame, MenuCreditsSelected, font);
            }

            if (menuchoice == 3)
            {
                //menuCreditsState.Draw(spriteBatch, CreditScreen, MenuBackSelected, font);
            }

            if (menuchoice == 4)
            {
                newGameState.Draw(spriteBatch, SecondStart, MenuNewGameSelected, MenuContinue, MenuBack);
            }

            if (menuchoice == 5)
            {
                continueState.Draw(spriteBatch, SecondStart, MenuNewGame, MenuContinueSelected, MenuBack);
            }

            if (menuchoice == 6)
            {
                backState.Draw(spriteBatch, SecondStart, MenuNewGame, MenuContinue, MenuBackSelected);
            }

            if (menuchoice == 7)
            {
                spriteBatch.Begin();
                safeZone.SafeZone(ZandTile, Sleutel, spriteBatch);
                safeZone.SafeZoneStone(SteenTile, spriteBatch);
                safeZone.SafeZoneStoneVert(SteenVert, spriteBatch);
                safeZone.NextLevel1();
                player.Draw(gameTime, spriteBatch);
                spriteBatch.End();
                foreach (var sprite in _sprites)
                    sprite.Draw(spriteBatch);
            }

            if (menuchoice == 8)
            {
                jogonLevelPlayingState.JogonLevelConstruction(player, Floortile, width, height, WalltileStr, WalltileStrD, WalltileL, WalltileR, WalltileCrnL, WalltileCrnR, WalltileCrnDL, WalltileCrnDR, PillarTile, Player, menuchoice);
                player.Draw(gameTime, spriteBatch);


            }

            if (menuchoice == 9)
            {
                spriteBatch.Begin();
                safeZone2.SafeZone(TileSz2, spriteBatch);
                safeZone2.SafeZonePlatForm(TileSz2, spriteBatch);
                safeZone2.MovingPlatForm(TileSz3, spriteBatch);
                spriteBatch.End();
            }

            if (menuchoice == 10)
            {
                spriteBatch.Begin();
                //selinLevelPlayingState.Draw(spriteBatch);
                spriteBatch.End();
            }*/
        }
    }
}