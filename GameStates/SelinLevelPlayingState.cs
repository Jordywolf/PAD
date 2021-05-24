using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Engine;

namespace BaseProject.GameStates
{
    class SelinLevelPlayingState : Engine.LevelPlayingState
    {
        Selin selinBoss;
        SpriteGameObject platform;
        SpriteGameObject background;
        GameObjectList pillars;
        GameObjectList stenen;
        HealthBar selinsHealth;
        mapObjects.GateTile selinGate;

        private bool itemspawned;
        private bool gatespawned;
        private bool playerSpawned;

        Random rnd = new Random();

        private int maxPillars = 4;
        private int maxStenen = 10;

        List<Vector2> pillarPS;
        List<String> PillarsDown;

        public SelinLevelPlayingState() : base()
        {
            background = new SpriteGameObject("Fontein", 0.5f);
            gameObjects.AddChild(background);
            background.Origin = new Vector2(background.sprite.Width / 2, background.sprite.Height / 2);
            background.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 4);
            background.scale = 20;

            platform = new SpriteGameObject("Selin_Arena_Pr", 0.6f);
            gameObjects.AddChild(platform);
            platform.Origin = new Vector2(platform.sprite.Width / 2, platform.sprite.Height / 2);
            platform.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 2);

            pillarPS = new List<Vector2>();
            pillarPS.Add(new Vector2(platform.LocalPosition.X - platform.sprite.Width / 2, 100));
            pillarPS.Add(new Vector2(platform.LocalPosition.X + platform.sprite.Width / 2, 100));
            pillarPS.Add(new Vector2(platform.LocalPosition.X - platform.sprite.Width / 2, Game1.height - 100));
            pillarPS.Add(new Vector2(platform.LocalPosition.X + platform.sprite.Width / 2, Game1.height - 100));

            LoadSquareFloor("PAD_Sn_stone_small", 10, 10, new Vector2(Game1.width / 2 - 32, Game1.height / 2 - 32));

            PillarsDown = new List<string>();

            pillars = new GameObjectList();
            gameObjects.AddChild(pillars);

            stenen = new GameObjectList();
            gameObjects.AddChild(stenen);

            selinBoss = new Selin();
            gameObjects.AddChild(selinBoss);

            //player objects
            gameObjects.AddChild(Game1.player);
            gameObjects.AddChild(Game1.playerShadow);
            Game1.playerShadow.Origin = Game1.playerShadow.sprite.Center;
            gameObjects.AddChild(Game1.playerHealth1);
            gameObjects.AddChild(Game1.playerHealth2);
            gameObjects.AddChild(Game1.playerHealth3);
            ActionJump.playerOnGround = true;
            selinsHealth = new HealthBar("Selin the hammer wielder");
            gameObjects.AddChild(selinsHealth);

            for (int iPillar = 0; iPillar < maxPillars; iPillar++)
            {
                Pillar pilaar = new Pillar(pillarPS[iPillar], "Pilaar");
                pillars.AddChild(pilaar);
            }

            for (int iSteen = 0; iSteen < maxStenen; iSteen++)
            {
                SpriteGameObject steen = new SpriteGameObject("Rots", 1);
                steen.LocalPosition = new Vector2(rnd.Next(0, Game1.width - steen.sprite.Width),
                    rnd.Next(0, Game1.height - steen.sprite.Height));
                //stenen.AddChild(steen);
            }

            selinGate = new mapObjects.GateTile("PAD_Sn_groundGate", new Vector2(Game1.width / 2, Game1.height / 5));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (!playerSpawned)
            {
                Game1.player.SpawnLocationDefault();
                playerSpawned = true;
            }

            if (ActionJump.playerOnGround)
            {
                CollisionUpdate(Game1.player);
                selinBoss.CollShockPlayer(Game1.player);
            }

            if (!OverlapsWith(platform, Game1.player) && ActionJump.playerOnGround)
            {
                Game1.GameStateManager.SwitchTo("deathState", "selinLevelPlayingState", new GameStates.SelinLevelPlayingState());
            }

            foreach (Pillar p in pillars.children)
            {
                foreach (Selin_Hammer s in selinBoss.hammers.children)
                {
                    if (OverlapsWith(s, p) && p.Visible)
                    {
                        p.Visible = false;
                        PillarsDown.Add("hit");

                    }
                }
            }

            if (PillarsDown.Count >= pillars.children.Count)
            {
                PillarsDown.Clear();

                foreach (Pillar p in pillars.children)
                {
                    p.Visible = true;
                }

                selinsHealth.Hit(5);
                selinBoss.hammers.AddChild(new Selin_Hammer("Selin_HmrL"));
            }

            if (selinsHealth.CurrentHealth <= 0)
            {
                if (!itemspawned)
                {
                    Game1.ItemPickup = new ItemPickup("Deur", 1);
                    gameObjects.AddChild(Game1.ItemPickup);
                    itemspawned = true;
                }

                if (CollisionDetection.ShapesIntersect(Game1.ItemPickup.BoundingBox, Game1.player.BoundingBox) && !gatespawned)
                {
                    gameObjects.AddChild(selinGate);
                    gatespawned = true;
                    Game1.ItemPickup.LocalPosition = new Vector2(-300, 0);
                }
            }

            if (gatespawned) { selinGate.WarpCheck("menuStartSelectedState", Game1.player); }



            //if (CollisionDetection.ShapesIntersect(Game1.ItemPickup.collisionRec, Game1.player.collisionRec) && itemspawned)
            //{

            //}
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            selinBoss.Targeting(Game1.player.LocalPosition);

        }
    }
}
