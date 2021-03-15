using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace BaseProject.GameStates
{
    class JogonLevelPlayingState
    {
        MapConstruction mapConstruction;
        private Jogonhead Jogon;
        private JogonPart jogonBodyPart;
        private JogonPart parentSegment;

        List<JogonPart> JogonDragon = new List<JogonPart>();
        private int Segments = 15;

        public JogonLevelPlayingState(Texture2D aPillarTile, Texture2D jogonHeadTexture, Texture2D fireBallTexture, Texture2D jogonBodyTexture, Sprite player) : base()
        {
            mapConstruction = new MapConstruction(aPillarTile);

            Jogon = new Jogonhead(new Vector2(50, 400), new Vector2(0, 0), 0, 1.5f, jogonHeadTexture, 10, fireBallTexture, player);
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

        public void JogonLevelConstruction(GameTime gameTime, SpriteBatch spriteBatch, Player player, Texture2D Floortile, int width, int height, Texture2D WalltileStr, Texture2D WalltileStrD, Texture2D WalltileL, Texture2D WalltileR, Texture2D WalltileCrnL, Texture2D WalltileCrnR, Texture2D WalltileCrnDL, Texture2D WalltileCrnDR, Texture2D PillarTile, Texture2D PlayerTexture, int menuChoice)
        {
            mapConstruction.FloorConstruction(new Vector2(0, 0), Floortile, spriteBatch, width, height);
            mapConstruction.WallConstruction(new Vector2(0, 0), new Vector2(0, ((int)(height / Floortile.Height) - 1) * Floortile.Height), new Vector2(0, 0), new Vector2(((int)(width / Floortile.Width) - 1) * Floortile.Width, 0), spriteBatch, width, height, WalltileStr, WalltileStrD, WalltileL, WalltileR, WalltileCrnL, WalltileCrnR, WalltileCrnDL, WalltileCrnDR);
            mapConstruction.PillarSetup(spriteBatch, PillarTile, width, height, new Vector2(0, 0));
            mapConstruction.Collision(Jogon.position, Jogon.texture, 9, height - 9, 9, width - 9);
            mapConstruction.Collision(player.Position, PlayerTexture, 9, height - 9, 9, width - 9);
            mapConstruction.PillarCollision(player.Position, PlayerTexture);
            mapConstruction.PillarCollision(Jogon.position, Jogon.texture);

            Console.WriteLine(mapConstruction.check);

            foreach (JogonPart part in JogonDragon)
            {
                part.Update(gameTime);
            }
            Jogon.Update(gameTime);
            if (Jogon.reached)
            {
                Jogon.position = new Vector2(100, 4000);
                GameEnvironment.SwitchTo(0);
                menuChoice = 2;
            }
            foreach (Fireball fireball in Jogon.fireballs)
            {
                fireball.Update(gameTime);
            }

            foreach (Fireball fireball in Jogon.fireballs)
            {
                fireball.Draw(spriteBatch);
            }
            foreach (JogonPart part in JogonDragon)
            {
                part.Draw(spriteBatch);
            }
            player.Draw(spriteBatch);
            Jogon.Draw(spriteBatch);

        }
    }
}
