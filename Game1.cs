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

        private int Segments = 5;


        public Texture2D jogonHeadTexture;
        public Texture2D jogonHSTexture;
        public Texture2D jogonBodyTexture;

        List<JogonPart> JogonDragon = new List<JogonPart>();


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
            Jogon = new Jogonhead(new Vector2(50, 400), new Vector2(0, 0), jogonHeadTexture, 0);
            parentSegment = Jogon;
            //JogonDragon.Add(jogonHead);
            for (int i = 0; i < Segments; i++)
            {
                if (i == 0) { jogonBodyPart = new JogonPart(parentSegment.position, new Vector2(0, 0), jogonBodyTexture, 0.1f); }
                else { jogonBodyPart = new JogonPart(parentSegment.position, new Vector2(0, 0), jogonBodyTexture, 5); }
                jogonBodyPart.Parent = parentSegment;
                Jogon.Body.Add(jogonBodyPart);
                parentSegment = jogonBodyPart;
            }

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            jogonBodyTexture = Content.Load<Texture2D>("jogon_BodyS");
            jogonHeadTexture = Content.Load<Texture2D>("JogonHead");
            jogonHSTexture = Content.Load<Texture2D>("Jogon_HoofdS");
            _spriteBatch = new SpriteBatch(GraphicsDevice);
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

            mapConstruction = new MapConstruction(PillarTile);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here

            base.Update(gameTime);
            foreach (JogonPart part in JogonDragon)
            {
                part.Update();
            }
            Jogon.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            _graphics.PreferredBackBufferWidth = width;
            _graphics.PreferredBackBufferHeight = height;
            _graphics.ApplyChanges();

            GraphicsDevice.Clear(Color.CornflowerBlue);



            // TODO: Add your drawing code here

            base.Draw(gameTime);

            mapConstruction.FloorConstruction(new Vector2(0, 0), Floortile, _spriteBatch, width, height);
            mapConstruction.WallConstruction(new Vector2(0, 0), new Vector2(0, ((int)(height / Floortile.Height) - 1) * Floortile.Height), new Vector2(0, 0), new Vector2(((int)(width / Floortile.Width) - 1) * Floortile.Width, 0), _spriteBatch, width, height, WalltileStr, WalltileStrD, WalltileL, WalltileR, WalltileCrnL, WalltileCrnR, WalltileCrnDL, WalltileCrnDR);
            mapConstruction.PillarSetup(_spriteBatch, PillarTile, width, height, new Vector2(0, 0));

            foreach (JogonPart part in JogonDragon)
            {
                part.Draw(_spriteBatch);
            }
            Jogon.Draw(_spriteBatch);
        }
    }
}