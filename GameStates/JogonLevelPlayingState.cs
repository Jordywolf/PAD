using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Engine;

namespace BaseProject.GameStates
{
    class JogonLevelPlayingState : Engine.LevelPlayingState
    {

        MapConstruction mapConstruction;
        private Jogonhead Jogon;

        private JogonPart parentSegment;
        public HealthBar bossHealthBar;
        public HealthBar playerHealthBar;
        //private Decoy playerTest;

        private SpriteGameObject target;
        private bool WallCollided;
        private bool PillarCollided;
        private bool playerWallCollided;
        private bool playerPillarCollided;
        private bool PhitJ;
        private bool FhitJ;
        private int levelHeight, levelWidth;
        private Vector2 pillarPositionCollision;
        private int deathTimer;
        private SoundEffectInstance fightSound;
        Player player;
        private Texture2D playerTexture;
        Decoy epicDeur;
        Random rnd = new Random();

        List<JogonPart> JogonDragon = new List<JogonPart>();


        public JogonLevelPlayingState(Texture2D aPillarTile, SoundEffect aSound, Texture2D HBmiddleTexture, Texture2D HBhealthTexture, Texture2D HBedgeRTexture, Texture2D HBedgeLTexture, Texture2D playerTexture, SoundEffect fightSound) : base()
        {
            
            LoadFullFloor("PAD_Jg_Floortile1");
            LoadSquareWalls("PAD_Jg_walltileCornerDL", "PAD_Jg_walltileStraightD", "PAD_Jg_walltileCornerDR", "PAD_Jg_walltileR",
    "PAD_Jg_walltileCornerR", "PAD_Jg_walltileStraight", "PAD_Jg_walltileCornerL", "PAD_Jg_walltileL");
            
            epicDeur = new Decoy("Deur");
            Jogon = new Jogonhead(new Vector2(Game1.width/2, Game1.height/2), 70, "JogonHead", 0.1f, "Fireball", epicDeur, aSound, 1);

            gameObjects.AddChild(new SpriteGameObject("JogonHead", 1));
            
            gameObjects.AddChild(epicDeur);
            epicDeur.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 2);

            gameObjects.AddChild(new SpriteGameObject("healthBarEnd", 1));
            gameObjects.AddChild(new SpriteGameObject("healthBarEndL", 1));
            gameObjects.AddChild(Jogon);
            gameObjects.AddChild(Jogon.fireballs);
            gameObjects.AddChild(Jogon.Body);

            target = Jogon;

            this.player = Game1.player;
            this.playerTexture = playerTexture;

            foreach (GameObject part in JogonDragon) { gameObjects.AddChild(part); }
            this.fightSound = fightSound.CreateInstance();

        }

        /*public bool JogonCollision(Player p, JogonPart j, Texture2D pTexture)
        {
            return (MathF.Abs(p.LocalPosition.X - j.LocalPosition.X) < pTexture.Width + j.sprite.Width
                && MathF.Abs(p.LocalPosition.Y - j.LocalPosition.Y) < pTexture.Height + j.sprite.Height);
        }

        public bool FireballCollision(Player p, Fireball f, Texture2D pTexture)
        {
            return (p.LocalPosition.X + pTexture.Width > f.LocalPosition.X && p.LocalPosition.X < f.LocalPosition.X + f.sprite.Width
                && p.LocalPosition.Y + pTexture.Height > f.LocalPosition.Y && p.LocalPosition.Y < f.LocalPosition.Y + f.sprite.Height);
        }*/

        /*public void JogonLevelConstruction(Player player, Texture2D Floortile, int width, int height, Texture2D WalltileStr, Texture2D WalltileStrD, Texture2D WalltileL, Texture2D WalltileR, Texture2D WalltileCrnL, Texture2D WalltileCrnR, Texture2D WalltileCrnDL, Texture2D WalltileCrnDR, Texture2D PillarTile, Texture2D PlayerTexture, int menuChoice)
        {
            this.player = player;
            levelHeight = height;
            levelWidth = width;
            mapConstruction.FloorConstruction(new Vector2(0, 0), Floortile, levelWidth, levelHeight, Color.White);
            mapConstruction.WallConstruction(new Vector2(0, 0), new Vector2(0, ((int)(levelHeight / Floortile.Height) - 1) * Floortile.Height), new Vector2(0, 0), new Vector2(((int)(levelWidth / Floortile.Width) - 1) * Floortile.Width, 0), levelWidth, levelHeight, WalltileStr, WalltileStrD, WalltileL, WalltileR, WalltileCrnL, WalltileCrnR, WalltileCrnDL, WalltileCrnDR, Color.White);
            //mapConstruction.PillarSetup(PillarTile, levelWidth, levelHeight, pillarPositionCollision, Color.White);
        }*/

        /*public void DrawPillars()
        {
            for (int iPillarsX = 1; iPillarsX <= maxPillarsX; iPillarsX++)
            {
                for (int iPillarsY = 1; iPillarsY <= maxPillarsY; iPillarsY++)
                {

                    pillarPosition.X = ((1280 / (maxPillarsX + 1)) * (iPillarsX)) - (64 / 2);
                    pillarPosition.Y = ((640 / (maxPillarsY + 1)) * (iPillarsY)) - (64 / 2);

                    pillars.children[iPillarsX * iPillarsY].LocalPosition = new Vector2(pillarPosition.X, pillarPosition.Y);
                }
            }
        }*/

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);


            if (!fightSound.IsLooped)
            {
                fightSound.IsLooped = true;
                fightSound.Play();
            }

            //CollisionUpdate(epicDeur);

            //CollisionDetection.ShapesIntersect(epicDeur, player);

            //playerTest.update();

            /*
            if (mapConstruction.Collision(Jogon.LocalPosition, Jogon.sprite) && !WallCollided)
            {
                Jogon.origin = new Vector2(rnd.Next(1280), rnd.Next(640));
                bossHealthBar.MaxHealthLength -= 0.2f;
                WallCollided = true;
            }
            else
            {
                WallCollided = false;
            }
            */
            /*
                        if (mapConstruction.Collision(player.LocalPosition, playerTexture) && !playerWallCollided)
                        {
                            player.moveSpeed = -player.moveSpeed;
                            playerWallCollided = true;
                        }
                        else if (player.moveSpeed < 0)
                        {
                            player.moveSpeed = -player.moveSpeed;
                            playerWallCollided = false;
                        }*/

            /*foreach (JogonPart j in JogonDragon)
            {
                if (JogonCollision(player, j, playerTexture) && !PhitJ)
                {
                    PhitJ = true;
                    Game1.GameStateManager.SwitchTo("");
                    Game1.menuchoice = 1;
                }
                else { PhitJ = false; }
            }

            foreach (Fireball f in Jogon.fireballs.children)
            {
                if (FireballCollision(player, f, playerTexture) && !FhitJ)
                {
                    f.LocalPosition = new Vector2(1000, 1000);
                    //playerHealthBar.MaxHealthLength -= 0.2f;
                    FhitJ = true;
                    Game1.GameStateManager.SwitchTo("deathState");
                    Game1.menuchoice = 1;
                }
                else { FhitJ = false; }
            }*/

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
                Jogon.LocalPosition = new Vector2(100, 4000);
                Game1.GameStateManager.SwitchTo("");
                //menuChoice = 2;
            }
            /*
            if (bossHealthBar.MaxHealthLength <= 0)
            {
                if (deathTimer >= 500)
                {
                    Game1.GameStateManager.SwitchTo("");
                    Game1.menuchoice = 1;
                }
                else
                {
                    deathTimer++;
                    Jogon.origin = new Vector2(rnd.Next(1280), rnd.Next(640));
                }
            }*/
        }
        /*
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
        */
    }
}
