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
        private SpriteBatch _spriteBatch;
        private JogonPart jogonHead;
        private JogonPart jogonHS;
        private Fireball fireball;

        private int Segments = 4;
        

        public Texture2D jogonHeadTexture;
        public Texture2D jogonHSTexture;
        public Texture2D jogonBodyTexture;
        public Texture2D fireBallTexture;
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
            jogonHead = new JogonPart(new Vector2(100, 50), new Vector2(0, 0), 0, 2, jogonHeadTexture,0);
            jogonHS = new JogonPart(new Vector2(100, 50), new Vector2(0, 0), 0, 2, jogonHSTexture,1);
            fireball = new Fireball(jogonHead.position, Vector2.Zero, 0, 1, fireBallTexture);

            JogonDragon.Add(jogonHead);
            for (int i = 0; i < Segments; i++)
            {
                JogonDragon.Add(new JogonPart(new Vector2(100, 50), new Vector2(0, 0), 0, 1, jogonBodyTexture, i*10));
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //jogonBodyTexture = Content.Load<Texture2D>("jogon_BodySegment");
            jogonHeadTexture = Content.Load<Texture2D>("JogonHead2");
            //jogonHSTexture = Content.Load<Texture2D>("Jogon_HeadSegment");
            fireBallTexture = Content.Load<Texture2D>("Fireball");
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
                //part.Update();
            }
            //jogonHS.Update();
            jogonHead.Update(gameTime);
            fireball.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            foreach (JogonPart part in JogonDragon)
            {
                //part.Draw(_spriteBatch);
            }
            //jogonHS.Draw(_spriteBatch);
            jogonHead.Draw(_spriteBatch);
            fireball.Draw(_spriteBatch);


            // TODO: Add your drawing code here

            base.Draw(gameTime);

        }
    }
}
