using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace BaseProject
{

    public class Game1 : Game
    {
        public int width = 1920;
        public int height = 1080;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Jogonhead Jogon;
        private JogonPart jogonBodyPart;
        private JogonPart parentSegment;

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
            Jogon = new Jogonhead(new Vector2(50, 400), new Vector2(0, 0), jogonHeadTexture,0);
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

            // TODO: use this.Content to load your game content here
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
            foreach (JogonPart part in JogonDragon)
            {
                part.Draw(_spriteBatch);
            }
            Jogon.Draw(_spriteBatch);


            // TODO: Add your drawing code here

            base.Draw(gameTime);

        }
    }
    // test jordi branch
}
