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
        public Texture2D BlackTile;
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
        GameStates.IntroGameState introGameState;
        GameStates.IntroGameState2 introGameState2;
        GameStates.MenuVictoryScreen menuVictoryScreen;

        //GameStates.JogonSafeZoneState jogonSafeZoneState;

        public static int width = 1280;
        public static int height = 640;

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
        public static SoundEffectInstance jogonFightSoundInstance;
        public static SoundEffect ButtonSound;
        public static SoundEffect Fireball;
        public static SoundEffect HammerHit;
        public static SoundEffect BoulderShove;
        public static SoundEffect SelinScream;
        public static SoundEffect MenuBM;
        public static SoundEffectInstance MenuBMInctance;

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
        public Vector2 RotsPosition = new Vector2(1920 / 3, 1080 / 2.5f);
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
            jogonFightSoundInstance = jogonFightSound.CreateInstance();

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

            //UI
            HBmiddleTexture = Content.Load<Texture2D>("healthBarMiddleborder");
            HBedgeRTexture = Content.Load<Texture2D>("healthBarEnd");
            HBedgeLTexture = Content.Load<Texture2D>("healthBarEndL");

            //Sound Effects
            MenuBM = Content.Load<SoundEffect>("BeginBM");
            MenuBMInctance = MenuBM.CreateInstance();
            ButtonSound = Content.Load<SoundEffect>("ButtonClick");
            Fireball = Content.Load<SoundEffect>("SoundEffect_Fireball");
            HammerHit = Content.Load<SoundEffect>("SoundEffect_Hammer");
            BoulderShove = Content.Load<SoundEffect>("SoundEffect_Boulder");
            SelinScream = Content.Load<SoundEffect>("SoundEffect_Selin");

            //Layering
            BlackTile = Content.Load<Texture2D>("Black Tile");
            font2 = Content.Load<SpriteFont>("Eightbit");
            font = Content.Load<SpriteFont>("Credit");
            player = new Player();
            playerShadow = new SpriteGameObject("PlayerShadow", 0.9f);
            playerHealth1 = new SpriteGameObject("Heart", 1);
            playerHealth2 = new SpriteGameObject("Heart", 1);
            playerHealth3 = new SpriteGameObject("Heart", 1);


  


            //Hier worden de gamestates toegevoegd aan de manager
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

            //Gamestate met ekst erin
            introGameState = new GameStates.IntroGameState("Out there in the desert he lays", "His riddle is yours to solve", "He charges with some delays", "In his fire you will dissolve");
            GameStateManager.AddGameState("introGameState", introGameState);

            safeZoneState = new GameStates.SafeZoneState();
            GameStateManager.AddGameState("safeZoneState", safeZoneState);

            jogonLevelPlayingState = new GameStates.JogonLevelPlayingState(jogonSound, Player);
            GameStateManager.AddGameState("jogonLevelPlayingState", jogonLevelPlayingState);

            //gamestate met tekst erin
            introGameState2 = new GameStates.IntroGameState2("With lots of glamour and much delight", "he trains his 10-pack on repeat", "he does not back out from a fight", "but the pillars will bring his defeat");
            GameStateManager.AddGameState("introGameState2", introGameState2);

            safeZoneState2 = new GameStates.SafeZoneState2();
            GameStateManager.AddGameState("safeZoneState2", safeZoneState2);

            selinLevelPlayingState = new GameStates.SelinLevelPlayingState();
            GameStateManager.AddGameState("selinLevelPlayingState", selinLevelPlayingState);

            menuVictoryScreen = new GameStates.MenuVictoryScreen();
            GameStateManager.AddGameState("menuVictoryScreen", menuVictoryScreen);

            //Begin met "menuStartSelectedState", ofwel het hoofdmenu
            GameStateManager.SwitchTo("menuStartSelectedState");
        }


        protected override void Update(GameTime gameTime)
        {
            //Als de state anders is dan het level van jogon, stopt de vecht muziek met spelen
            if (Game1.GameStateManager.currentGameState != Game1.GameStateManager.GetGameState("jogonLevelPlayingState"))
            {
                Game1.jogonFightSoundInstance.Stop();
            }
            //Als de state anders is dan de eerste safe zone, dan stopt de muziek van het menu met spelen
            if (Game1.GameStateManager.currentGameState == Game1.GameStateManager.GetGameState("safeZoneState")|| Game1.GameStateManager.currentGameState == Game1.GameStateManager.GetGameState("safeZoneState2") || Game1.GameStateManager.currentGameState == Game1.GameStateManager.GetGameState("selinLevelPlayingState") || Game1.GameStateManager.currentGameState == Game1.GameStateManager.GetGameState("jogonLevelPlayingState"))
            {
                    MenuBMInctance.Stop();
            }
            //Als je op escape drukt sluit het spel zich af
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

 
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            base.Draw(gameTime);

            KeyboardState state = Keyboard.GetState();
            Keyboard.GetState();

            //Framecount blijft altijd optellen
            framecount++;



            //Als de state het level van Jogon is, je op P drukt en de framecount is groter dan startframe + 50, dan veranderd de state naar het pauzescherm.
            if (Game1.GameStateManager.currentGameState == Game1.GameStateManager.GetGameState("jogonLevelPlayingState") && Keyboard.GetState().IsKeyDown(Keys.P) && framecount > startframe + 50)
            {
                GameStateManager.SwitchTo("pauseState");
                framecount = startframe;
            }

            //Als de state het level van Selin is, je op L drukt en de framecount is groter dan startframe + 50, dan veranderd de state naar het pauzescherm.
            if (Game1.GameStateManager.currentGameState == Game1.GameStateManager.GetGameState("selinLevelPlayingState") && Keyboard.GetState().IsKeyDown(Keys.L) && framecount > startframe + 50)
                {
                    GameStateManager.SwitchTo("pauseStateSelin");
                    framecount = startframe;

                }
            


        }
    }
}