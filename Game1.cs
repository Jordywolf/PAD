using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class Game1 : GameEnvironment
    {
        private GraphicsDeviceManager _graphics;
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
        GameStates.SafeZoneState safeZoneState2;
        GameStates.JogonLevelPlayingState jogonLevelPlayingState;
        //GameStates.JogonSafeZoneState jogonSafeZoneState;

        public int width = 1280;
        public int height = 640;

        public Vector2 playerPos;

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
        public SpriteFont font;
        public static int menuchoice;
        public static int framecount;
        public static int startframe;

        public Texture2D HBedgeLTexture;
        public Texture2D HBedgeRTexture;
        public Texture2D HBmiddleTexture;
        public Texture2D HBhealthTexture;

        public static Player player;
        public static List<Sprite> _sprites;

        public Boolean KeyCollected;
        public Vector2 SteenPosition, SteenVertPosition = new Vector2(0, 0);
        public Vector2 PlayerPosition = new Vector2(1920 / 2, 1080);
        public Vector2 RotsPosition = new Vector2(1920 / 3, 1080 / 2.5f);
        public Vector2 position = new Vector2(0, 0);
        public Vector2 PilaarPosition = new Vector2(1590, 200);
        public Vector2 DoorPosition = new Vector2(1920 / 2, 1080 / 100);
        public static Texture2D FonteinTexture, Pilaar, SteenTile, ZandTile, SteenVert, Boom, Rots, Deur, Player, Sleutel, TileSz2, TileSz3;
        public static Texture2D PlayerShadow;

        private ActionHandeler actionHandeler;

        SafeZone1 safeZone = new SafeZone1();
        SafeZone2 safeZone2 = new SafeZone2();

        public Game1() : base()
        {
            IsMouseVisible = true;

            screen.X = width;
            screen.Y = height;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            ApplyResolutionSettings();
            base.LoadContent();
            Pilaar = Content.Load<Texture2D>("Pilaar");
            FonteinTexture = Content.Load<Texture2D>("Fontein");
            ZandTile = Content.Load<Texture2D>("ZandTile");
            SteenTile = Content.Load<Texture2D>("steen");
            SteenVert = Content.Load<Texture2D>("SteenVert");
            Boom = Content.Load<Texture2D>("Boom");
            Rots = Content.Load<Texture2D>("Rots");
            Deur = Content.Load<Texture2D>("Deur");
            Player = Content.Load<Texture2D>("Player");
            PlayerShadow = content.Load<Texture2D>("PlayerShadow");
            Sleutel = Content.Load<Texture2D>("Sleutel");
            TileSz2 = Content.Load<Texture2D>("TileSz2");
            TileSz3 = Content.Load<Texture2D>("TileSz3");
            actionHandeler = new ActionHandeler();
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

            font = Content.Load<SpriteFont>("Credit");

            menuchoice = 1;
            framecount = 0;
            startframe = -100;

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

            safeZoneState2 = new GameStates.SafeZoneState();
            GameEnvironment.gameStateList.Add(safeZoneState2);
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
                actionHandeler.Update();
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

            if (menuchoice == 1)
            {
                menuStartSelectedState.Draw(spriteBatch, HomeScreen, MenuCredits, MenuStartGameSelected, font);
            }

            if (menuchoice == 2)
            {
                menuCreditsSelectedState.Draw(spriteBatch, HomeScreen, MenuStartGame, MenuCreditsSelected, font);
            }

            if (menuchoice == 3)
            {
                menuCreditsState.Draw(spriteBatch, CreditScreen, MenuBackSelected, font);
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
                spriteBatch.End();
                foreach (var sprite in _sprites)
                    sprite.Draw(spriteBatch);
                player.Draw(spriteBatch);
            }

            if (menuchoice == 8)
            {
                jogonLevelPlayingState.JogonLevelConstruction(player, Floortile, width, height, WalltileStr, WalltileStrD, WalltileL, WalltileR, WalltileCrnL, WalltileCrnR, WalltileCrnDL, WalltileCrnDR, PillarTile, Player, menuchoice);
            }

            if (menuchoice == 9)
            {
                safeZone2.SafeZone(TileSz2, spriteBatch);
                safeZone2.SafeZonePlatForm(TileSz2, spriteBatch);
                safeZone2.MovingPlatForm(TileSz3, spriteBatch);
            }
        }
    }
}