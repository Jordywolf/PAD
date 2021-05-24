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


        mapObjects.PillarTile testpillar;

        MapConstruction mapConstruction;
        private Jogonhead Jogon;

        private JogonPart parentSegment;
        public HealthBar bossHealthBar;
        public HealthBar playerHealthBar;
        mapObjects.GateTile jogonGate;
        //private Decoy playerTest;

        private SpriteGameObject target;
        private bool WallCollided;
        private bool PillarCollided;
        private bool playerWallCollided;
        private bool playerPillarCollided;
        private bool PhitJ;
        private bool FhitJ;
        private bool itemSpawned;
        private bool gateSpawned;
        private bool jogonHit;
        private bool playerhit;
        private bool playerhitf;
        private int levelHeight, levelWidth;
        private Vector2 pillarPositionCollision;
        private int deathTimer;
        private SoundEffectInstance fightSound;
        Player player;
        HealthBar jogonhealth;
        private Texture2D playerTexture;
        Random rnd = new Random();

        ObjectTile test;

        List<JogonPart> JogonDragon = new List<JogonPart>();


        public JogonLevelPlayingState(SoundEffect aSound, Texture2D playerTexture, SoundEffect fightSound) : base()
        {
            LoadFullFloor("PAD_Jg_Floortile1");
            LoadSquareWalls("PAD_Jg_walltileCornerDL", "PAD_Jg_walltileStraightD", "PAD_Jg_walltileCornerDR", "PAD_Jg_walltileR",
    "PAD_Jg_walltileCornerR", "PAD_Jg_walltileStraight", "PAD_Jg_walltileCornerL", "PAD_Jg_walltileL");

            player = Game1.player;
            gameObjects.AddChild(Game1.playerShadow);
            Game1.playerShadow.Origin = Game1.playerShadow.sprite.Center;
            gameObjects.AddChild(Game1.playerHealth1);
            gameObjects.AddChild(Game1.playerHealth2);
            gameObjects.AddChild(Game1.playerHealth3);
            Jogon = new Jogonhead(new Vector2(Game1.width / 4, Game1.height / 4), 70, "JogonHead", 0.1f, "Fireball", player, aSound, 1);

            jogonGate = new mapObjects.GateTile("PAD_Jg_walltileGate", new Vector2(Game1.width / 2, 32));


            gameObjects.AddChild(player);
            player.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 2);

            //Do this when jogon dies
            //Game1.ItemPickup = new ItemPickup("De_Rakker", 1);
            //gameObjects.AddChild(Game1.ItemPickup);


            gameObjects.AddChild(Jogon);
            gameObjects.AddChild(Jogon.fireballs);
            gameObjects.AddChild(Jogon.Body);

            testpillar = new mapObjects.PillarTile("PAD_Jg_Pillar", new Vector2(Game1.width / 2, Game1.height / 2));
            walls.AddChild(testpillar);

            target = Jogon;

            this.player = Game1.player;
            this.playerTexture = playerTexture;
            jogonhealth = new HealthBar();
            gameObjects.AddChild(jogonhealth);
            jogonhealth.LocalPosition = new Vector2(0, 0);

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
                fightSound.Volume = 0.5f;
                fightSound.Play();
            }

            CollisionUpdate(player);

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


            if (OverlapsWith(Jogon, testpillar) && !jogonHit && !testpillar.hit)
            {
                jogonhealth.Hit(30);
                jogonHit = true;

                testpillar.invisTimer = 600;
            }
            else if (!OverlapsWith(Jogon, testpillar))
            {
                jogonHit = false;
            }




            if (jogonhealth.CurrentHealth <= 0 && !itemSpawned)
            {
                Game1.ItemPickup = new ItemPickup("Vleugels_Item", 1);
                gameObjects.AddChild(Game1.ItemPickup);
                foreach (JogonPart j in Jogon.Body.children)
                {
                    Jogon.target = new ObjectTile("Deur", new Vector2(-9999, -9000), 1);
                }
                

                if (CollisionDetection.ShapesIntersect(Game1.ItemPickup.BoundingBox, player.BoundingBox))
                {
                    itemSpawned = true;
                    gameObjects.AddChild(jogonGate);
                    gateSpawned = true;
                }
            }

            if (gateSpawned) { jogonGate.WarpCheck("safeZoneState2", player);
                
            }

            foreach (JogonPart j in Jogon.Body.children)
            {
                if (OverlapsWith(player, j) && !playerhit)
                {
                    player.Hit();
                    playerhit = true;
                }
                else if (!OverlapsWith(player, j))
                {
                    playerhit = false;
                }
            }

            foreach (Fireball f in Jogon.fireballs.children)
            {
                if (OverlapsWith(player, f) && !playerhitf)
                {
                    player.Hit();
                    playerhitf = true;
                }
                else if (!OverlapsWith(player, f))
                {
                    playerhitf = false;
                }
            }


            if (jogonhealth.CurrentHealth < 10) { Jogon.Attackstate = 3; }
            else if (jogonhealth.CurrentHealth >= 10 && jogonhealth.CurrentHealth <= 20) { Jogon.Attackstate = 2; }
            else if (jogonhealth.CurrentHealth > 20) { Jogon.Attackstate = 1; }

            /*if (bossHealthBar.MaxHealthLength <= 0)
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
