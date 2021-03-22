using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace BaseProject.GameStates
{
    class JogonLevelPlayingState : GameState
    {
        MapConstruction mapConstruction;
        private Jogonhead Jogon;
        private JogonPart jogonBodyPart;
        private JogonPart parentSegment;
        public HealthBar bossHealthBar;
        public HealthBar playerHealthBar;
        //private Decoy playerTest;

        private bool WallCollided;
        private bool PillarCollided;
        private bool playerWallCollided;
        private bool playerPillarCollided;
        private bool PhitJ;
        private bool FhitJ;
        private int levelHeight, levelWidth;
        private Vector2 pillarPositionCollision;
        private int deathTimer;
        public Vector2 PlayerPosition = new Vector2(GameEnvironment.Screen.X, GameEnvironment.Screen.Y);
        private SoundEffectInstance fightSound;
        Player player;
        private Texture2D playerTexture;

        Random rnd = new Random();

        List<JogonPart> JogonDragon = new List<JogonPart>();
        private int Segments = 15;

        public JogonLevelPlayingState(Texture2D aPillarTile, Texture2D jogonHeadTexture, Texture2D fireBallTexture, Texture2D jogonBodyTexture, SoundEffect aSound, Texture2D HBmiddleTexture, Texture2D HBhealthTexture, Texture2D HBedgeRTexture, Texture2D HBedgeLTexture, Texture2D playerTexture, SoundEffect fightSound) : base()
        {
            this.player = Game1.player;
            this.playerTexture = playerTexture;

            mapConstruction = new MapConstruction(aPillarTile);

            this.fightSound = fightSound.CreateInstance();

            bossHealthBar = new HealthBar(new Vector2(640, 20), HBedgeRTexture, HBedgeLTexture, HBmiddleTexture, HBhealthTexture);
            playerHealthBar = new HealthBar(new Vector2(640, 100), HBedgeRTexture, HBedgeLTexture, HBmiddleTexture, HBhealthTexture);

            Jogon = new Jogonhead(new Vector2(100, 100), new Vector2(0, 0), 0, 1.5f, jogonHeadTexture, 10, fireBallTexture, player, null, aSound);
            parentSegment = Jogon;
            for (int i = 0; i < Segments; i++)
            {
                if (i == 0) { jogonBodyPart = new JogonPart(parentSegment.position, new Vector2(0, 0), 0, 1.5f, jogonBodyTexture, 0.1f, parentSegment); }
                else { jogonBodyPart = new JogonPart(parentSegment.position, new Vector2(0, 0), 0, 1.5f, jogonBodyTexture, 15, parentSegment); }
                jogonBodyPart.Parent = parentSegment;
                Jogon.Body.Add(jogonBodyPart);
                parentSegment = jogonBodyPart;
            }
        }

        public bool JogonCollision(Player p, JogonPart j, Texture2D pTexture)
        {
            return (MathF.Abs(p.Position.X - j.position.X) < pTexture.Width + j.texture.Width
                && MathF.Abs(p.Position.Y - j.position.Y) < pTexture.Height + j.texture.Height);
        }

        public bool FireballCollision(Player p, Fireball f, Texture2D pTexture)
        {
            return (p.Position.X +pTexture.Width > f.position.X && p.Position.X < f.position.X + f.texture.Width
                && p.Position.Y + pTexture.Height > f.position.Y && p.Position.Y < f.position.Y + f.texture.Height);
        }

        public void JogonLevelConstruction(Player player, Texture2D Floortile, int width, int height, Texture2D WalltileStr, Texture2D WalltileStrD, Texture2D WalltileL, Texture2D WalltileR, Texture2D WalltileCrnL, Texture2D WalltileCrnR, Texture2D WalltileCrnDL, Texture2D WalltileCrnDR, Texture2D PillarTile, Texture2D PlayerTexture, int menuChoice)
        {
            this.player = player;
            levelHeight = height;
            levelWidth = width;
            mapConstruction.FloorConstruction(new Vector2(0, 0), Floortile, levelWidth, levelHeight, Color.White);
            mapConstruction.WallConstruction(new Vector2(0, 0), new Vector2(0, ((int)(levelHeight / Floortile.Height) - 1) * Floortile.Height), new Vector2(0, 0), new Vector2(((int)(levelWidth / Floortile.Width) - 1) * Floortile.Width, 0), levelWidth, levelHeight, WalltileStr, WalltileStrD, WalltileL, WalltileR, WalltileCrnL, WalltileCrnR, WalltileCrnDL, WalltileCrnDR, Color.White);
            mapConstruction.PillarSetup(PillarTile, levelWidth, levelHeight, pillarPositionCollision, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            if (!fightSound.IsLooped)
            {
                fightSound.IsLooped = true;
                fightSound.Play();
            }
            base.Update(gameTime);
            //playerTest.update();

            Jogon.origin = player.Position;

            if (mapConstruction.Collision(Jogon.position, Jogon.texture) && !WallCollided)
            {
                Jogon.origin = new Vector2(rnd.Next(1280), rnd.Next(640));
                bossHealthBar.MaxHealthLength -= 0.2f;
                WallCollided = true;
            }
            else
            {
                WallCollided = false;
            }

            if (mapConstruction.Collision(player.Position, playerTexture) && !playerWallCollided)
            {
                player.Speed = -player.Speed;
                playerWallCollided = true;
            }
            else if (player.Speed < 0)
            {
                player.Speed = -player.Speed;
                playerWallCollided = false;
            }

            foreach (JogonPart j in JogonDragon)
            {
                if (JogonCollision(player, j, playerTexture) && !PhitJ)
                {
                    PhitJ = true;
                    GameEnvironment.SwitchTo(0);
                    Game1.menuchoice = 1;
                }
                else { PhitJ = false; }
            }

            foreach (Fireball f in Jogon.fireballs)
            {
                if (FireballCollision(player, f, playerTexture) && !FhitJ)
                {
                    f.position = new Vector2(1000, 1000);
                    playerHealthBar.MaxHealthLength -= 0.2f;
                    FhitJ = true;
                    GameEnvironment.SwitchTo(0);
                    Game1.menuchoice = 1;
                }
                else { FhitJ = false; }
            }

            //mapConstruction.PlayerCollision(player.Position, playerTexture);

            /*for (int iPillarsX = 1; iPillarsX <= mapConstruction.maxPillarsX; iPillarsX++)
            {
                for (int iPillarsY = 1; iPillarsY <= mapConstruction.maxPillarsY; iPillarsY++)
                {
                    pillarPositionCollision.X = ((levelWidth / (mapConstruction.maxPillarsX + 1)) * (iPillarsX)) - (mapConstruction.pillarTile.Width / 2);
                    pillarPositionCollision.Y = ((levelHeight / (mapConstruction.maxPillarsY + 1)) * (iPillarsY)) - (mapConstruction.pillarTile.Height / 2);

                    if (mapConstruction.pillars[iPillarsX * iPillarsY].Collision(player.Position, this.playerTexture, pillarPositionCollision) && !playerPillarCollided)
                    {
                        player.Velocity = -player.Velocity;
                        playerPillarCollided = true;
                    }
                    else if (mapConstruction.pillars[iPillarsX * iPillarsY].Collision(player.Position, this.playerTexture, pillarPositionCollision))
                    {
                        playerPillarCollided = false;
                    }

                    if (mapConstruction.pillars[iPillarsX * iPillarsY].Collision(Jogon.position, Jogon.texture, pillarPositionCollision) && !PillarCollided)
                    {
                        Jogon.origin = new Vector2(rnd.Next(1280), rnd.Next(640));
                        PillarCollided = true;
                    }
                    else if (!mapConstruction.pillars[iPillarsX * iPillarsY].Collision(Jogon.position, Jogon.texture, pillarPositionCollision))
                    {
                        PillarCollided = false;
                    }
                }
            }*/

            foreach (JogonPart part in JogonDragon)
            {
                part.Update(gameTime);
            }
            Jogon.Update(gameTime);
            if (Jogon.reached)
            {
                Jogon.position = new Vector2(100, 4000);
                GameEnvironment.SwitchTo(0);
                //menuChoice = 2;
            }
            foreach (Fireball fireball in Jogon.fireballs)
            {
                fireball.Update(gameTime);
            }

            if (bossHealthBar.MaxHealthLength <= 0)
            {
                if (deathTimer >= 500)
                {
                    GameEnvironment.SwitchTo(0);
                    Game1.menuchoice = 1;
                }
                else
                {
                    deathTimer++;
                    Jogon.origin = new Vector2(rnd.Next(1280), rnd.Next(640));
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            mapConstruction.Draw(spriteBatch);

            foreach (Fireball fireball in Jogon.fireballs)
            {
                fireball.Draw(spriteBatch);
            }
            foreach (JogonPart part in JogonDragon)
            {
                part.Draw(spriteBatch);
            }
            //player.Draw(spriteBatch);
            Jogon.Draw(spriteBatch);

            bossHealthBar.Draw(spriteBatch);
            playerHealthBar.Draw(spriteBatch);
            //playerTest.Draw(spriteBatch);
        }
    }
}
