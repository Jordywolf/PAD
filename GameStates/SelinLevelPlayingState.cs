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
            //plaatjs de background in het scherm
            background = new SpriteGameObject("Fontein", 0.5f);
            gameObjects.AddChild(background);
            background.Origin = new Vector2(background.sprite.Width / 2, background.sprite.Height / 2);
            background.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 4);
            background.scale = 20;

            //plaatst het platform in het scherm
            platform = new SpriteGameObject("Selin_Arena_Pr", 0.6f);
            gameObjects.AddChild(platform);
            platform.Origin = new Vector2(platform.sprite.Width / 2, platform.sprite.Height / 2);
            platform.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 2);

            //maakt een lijst met posities aan voor de pilaren in elke hoek van de arena
            pillarPS = new List<Vector2>();
            pillarPS.Add(new Vector2(platform.LocalPosition.X - platform.sprite.Width / 2, 100));
            pillarPS.Add(new Vector2(platform.LocalPosition.X + platform.sprite.Width / 2, 100));
            pillarPS.Add(new Vector2(platform.LocalPosition.X - platform.sprite.Width / 2, Game1.height - 100));
            pillarPS.Add(new Vector2(platform.LocalPosition.X + platform.sprite.Width / 2, Game1.height - 100));

            LoadSquareFloor("PAD_Sn_stone_small", 10, 10, new Vector2(Game1.width / 2 - 32, Game1.height / 2 - 32));

            //deze lijst houdt bij hoeveel pilaren er om zijn gegooid door Selin
            PillarsDown = new List<string>();

            //add de pillars
            pillars = new GameObjectList();
            gameObjects.AddChild(pillars);

            //add de stenen
            stenen = new GameObjectList();
            gameObjects.AddChild(stenen);

            //add selin
            selinBoss = new Selin();
            gameObjects.AddChild(selinBoss);

            //add de speler van Game1 in de gamestate
            gameObjects.AddChild(Game1.player);
            gameObjects.AddChild(Game1.playerShadow);
            Game1.playerShadow.Origin = Game1.playerShadow.sprite.Center;
            gameObjects.AddChild(Game1.playerHealth1);
            gameObjects.AddChild(Game1.playerHealth2);
            gameObjects.AddChild(Game1.playerHealth3);
            ActionJump.playerOnGround = true;
            selinsHealth = new HealthBar("Selin the hammer wielder");
            gameObjects.AddChild(selinsHealth);

            //dit deel zorgt ervoor dat er pilaren worden gemaakt op de locaties
            for (int iPillar = 0; iPillar < maxPillars; iPillar++)
            {
                Pillar pilaar = new Pillar(pillarPS[iPillar], "Pilaar");
                pillars.AddChild(pilaar);
            }

            //dit is voor een onderdeel dat er voor zou zorgen dat er op random plekken in de arena stenen worden geplaatst
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

            //dit zorgt ervoor dat de speler is gespawnd op de goede plek
            if (!playerSpawned)
            {
                Game1.player.SpawnLocationDefault();
                playerSpawned = true;
            }

            //zorgt ervoor dat de speler alleen met selin collision kan krijgen als hij daadwerkelijk op de grond is
            if (ActionJump.playerOnGround)
            {
                CollisionUpdate(Game1.player);
                selinBoss.CollShockPlayer(Game1.player);
            }

            //zorgt ervoor dat de speler alleen mapcollision kan krijgen als deze op de grond is
            if (!OverlapsWith(platform, Game1.player) && ActionJump.playerOnGround)
            {
                Game1.player.Hit();
                Game1.player.SpawnLocationDefault();
            }

            //dit zorgt ervoor dat de collision met de pilaren en selin zijn hamers wordt gecheckt
            foreach (Pillar p in pillars.children)
            {
                foreach (Selin_Hammer s in selinBoss.hammers.children)
                {
                    if (OverlapsWith(s, p) && p.Visible)
                    {
                        p.Visible = false;

                        //als een pilaar wordt geraakt dan wordt er een string toegevoegd aan de pilardownlist
                        PillarsDown.Add("hit");

                    }
                }
            }

            //als er meer pillars down zijn dan dat er in de arena zijn dan wordt de pillars down list gecleard en selin krijgt schade
            //de arena wordt vanaf hier soort van gereset
            if (PillarsDown.Count >= pillars.children.Count)
            {
                PillarsDown.Clear();

                foreach (Pillar p in pillars.children)
                {
                    p.Visible = true;
                }

                selinsHealth.Hit(5);
                //selin krijgt hierbij ook een nieuwe hamer erbij
                selinBoss.hammers.AddChild(new Selin_Hammer("Hamer 1"));
            }


            //dit zorgt ervoor dat alles wat moet gebeuren nadat selins hp op nul staat ook gebeurt
            if (selinsHealth.CurrentHealth <= 0)
            {
                //dit zorgt ervoor dat het item gespawned wordt
                //het item is al gemaakt maar wordt aan de gameobjects lijst toegevoegd
                if (!itemspawned)
                {
                    Game1.ItemPickup = new ItemPickup("Hamer_2_small", 1);

                    gameObjects.AddChild(Game1.ItemPickup);
                    itemspawned = true;
                }

                //dit checked de collision met het item dat is gespawned en de speler
                if (CollisionDetection.ShapesIntersect(Game1.ItemPickup.BoundingBox, Game1.player.BoundingBox) && !gatespawned)
                {
                    gameObjects.AddChild(selinGate);
                    gatespawned = true;
                    Game1.ItemPickup.LocalPosition = new Vector2(-300, 0);
                }
            }

            //als de gatespawned door het item op true is gebracht dan wordt de check met de gate gedaan, deze warped de speler naar het niewe level
            if (gatespawned) { selinGate.WarpCheck("menuVictoryScreen", Game1.player); }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            //targeting van selin
            selinBoss.Targeting(Game1.player.LocalPosition);

        }
    }
}
