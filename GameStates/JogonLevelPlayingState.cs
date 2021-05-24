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

            foreach (JogonPart part in JogonDragon)
            {
                part.Update(gameTime);
            }
            Jogon.Update(gameTime);
            if (Jogon.reached)
            {
                Jogon.LocalPosition = new Vector2(100, 4000);
                Game1.GameStateManager.SwitchTo("");
            }


            if (OverlapsWith(Jogon, testpillar) && !jogonHit && !testpillar.hit && Jogon.vaunerable)
            {
                jogonhealth.Hit(5);
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

            if (gateSpawned) { jogonGate.WarpCheck("safeZoneState2", player); }

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


            if (jogonhealth.CurrentHealth < 10) { Jogon.Attackstate = 2; }
            else if (jogonhealth.CurrentHealth >= 10 && jogonhealth.CurrentHealth <= 20) { Jogon.Attackstate = 3; }
            else if (jogonhealth.CurrentHealth > 20) { Jogon.Attackstate = 1; }
        }
    }
}
