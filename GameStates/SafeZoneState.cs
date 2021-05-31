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
    class SafeZoneState : Engine.LevelPlayingState
    {

        Player player1; // Player die wordt toegevoegd.
        SpriteGameObject Fontein, rots, boom, deur, Helper, Bubble; // Variables voor bepaalde gameobjects in de safezone state
        mapObjects.Item Key;// Key wordt getekent als item zodat de speler hem kan collecten
        ObjectTile pilaar;// Pilaar wordt getekent als muur zodat de speler er niet doorheen kan lopen
        TextGameObject NotCollected,HelperText,ComeText; //TextGameObject om teksten te kunnen tekenen bij bepaalde momenten van collision.
        Boolean KeyCollected = false; // Boolean om bij te houden of de key is gespawned
        public Vector2 TileSz2Pos = new Vector2(0, 0); //De positie van de steen
        public int LowerPosY = 570; //De Y- Positie van de onderste steen rij.
        public int PlatformPosY; // De Y- Positie van het platform
        private bool playerSpawned; // Boolean die bijhoudt of de speler is gespawned

        RotatingSpriteGameObject transition;

        public SafeZoneState() : base()
        {


            //Vloer en muur worden hier aangemaakt voor de safezonestate
            LoadFullFloor("ZandTile");
            LoadSquareWalls("PAD_Jg_walltileCornerDL", "PAD_Jg_walltileStraightD", "PAD_Jg_walltileCornerDR", "PAD_Jg_walltileR",
   "PAD_Jg_walltileCornerR", "PAD_Jg_walltileStraight", "PAD_Jg_walltileCornerL", "PAD_Jg_walltileL");

            //GameObjects worden hier aangemaakt en toegevoegd
            Helper = new ObjectTile("Player", new Vector2(0, 0), 1);
            deur = new ObjectTile("Deur", new Vector2(0, 0), 1);
            Fontein = new ObjectTile("Fontein", new Vector2(0, 0), 1);
            rots = new SpriteGameObject("Rots", 1);
            boom = new ObjectTile("boom", new Vector2(0, 0), 1);
            NotCollected = new TextGameObject("Eightbit", 1, Color.Black);
            HelperText = new TextGameObject("Eightbit", 1, Color.Black);
            ComeText = new TextGameObject("Eightbit", 1, Color.Black);
            Key = new mapObjects.Item("Sleutel", new Vector2(1000, 100));
            pilaar = new ObjectTile("Pilaar", new Vector2(0,0), 1);
            Bubble = new SpriteGameObject("Bubble", 1);
            transition = new RotatingSpriteGameObject("JogonHead", 1);
            walls.AddChild(Helper);
            walls.AddChild(deur);
            walls.AddChild(Fontein);
            gameObjects.AddChild(rots);
            walls.AddChild(boom);
            gameObjects.AddChild(NotCollected);
            gameObjects.AddChild(HelperText);
            gameObjects.AddChild(ComeText);
            gameObjects.AddChild(Key);
            walls.AddChild(pilaar);
            gameObjects.AddChild(transition);


            //Posities van alle gameobjects die zijn getekend in het spel 
            //Origin bepaald het midden van het GameObject
            //Scale om het gameobject te verkleinen/vergroten
            deur.Origin = new Vector2(deur.sprite.Width / 2, deur.sprite.Height / 2 - 30);
            deur.LocalPosition = new Vector2(600, 80);
            deur.scale = 1.2f;
            Fontein.Origin = new Vector2(Fontein.sprite.Width / 2, Fontein.Height / 2 - 30);
            Fontein.scale = 1f;
            Fontein.LocalPosition = new Vector2(250, 80);
            transition.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 2);
            transition.Origin = transition.sprite.Center;
            transition.scale = 60;
            Helper.LocalPosition = new Vector2(Game1.width - 100, Game1.height - 100);
            rots.Origin = new Vector2(rots.sprite.Width / 2, rots.Height / 2);
            rots.scale = 1f;
            rots.LocalPosition = new Vector2(300, 300);
            boom.LocalPosition = new Vector2(300, 470);
            boom.Origin = new Vector2(boom.sprite.Width / 2, boom.Height / 2);
            boom.scale = 1.5f;
            Helper.Origin = new Vector2(Helper.sprite.Width / 2, Helper.sprite.Height / 2);
            NotCollected.LocalPosition = new Vector2(deur.LocalPosition.X - 150, 110);
            pilaar.LocalPosition = new Vector2(980, 110);
            pilaar.Origin = new Vector2(pilaar.sprite.Width / 2, pilaar.sprite.Height / 2);
            pilaar.scale = 1f;
            HelperText.scale = 0.8f;
            ComeText.scale = 0.8f;
            pilaar.Origin = new Vector2(Key.sprite.Width / 2, Key.sprite.Height / 2);
            Key.scale = 0.5f;
            Helper.scale = 1.5f;
            ComeText.Text = "Psstt, come here";
            ComeText.LocalPosition = new Vector2(Helper.LocalPosition.X - 80, Helper.LocalPosition.Y - 50);
            player1 = Game1.player;
            gameObjects.AddChild(player1);
            player1.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 2);
            gameObjects.AddChild(Game1.playerShadow);
            Game1.playerShadow.Origin = Game1.playerShadow.sprite.Center;
            gameObjects.AddChild(Game1.playerHealth1);
            gameObjects.AddChild(Game1.playerHealth2);
            gameObjects.AddChild(Game1.playerHealth3);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            transition.scale -= 1;
            transition.Angle += 5;
            //Dit zorgt voor de transition in het begin van de safezone
            if (transition.scale <= 0) { transition.Visible = false; transition.scale = 1; }
            //Als de speler niet gespawned wordt hij op de standaard plek getekend en zonder vleugel item
            if (!playerSpawned)
            {
                Game1.player.SpawnLocationDefault();
                Game1.player.actionHandeler.actionId = 0;
                playerSpawned = true;
            }
            //Als de speler contact maakt met de rots wordt hij gepusht, speelt er een geluid af en word de positie van de rots verplaatst.
            if (OverlapsWith(rots, player1) == true)
            {
                Vector2 PushDir = new Vector2(rots.LocalPosition.X - player1.LocalPosition.X, rots.LocalPosition.Y - player1.LocalPosition.Y);

                PushDir.Normalize();

                rots.LocalPosition = new Vector2(rots.LocalPosition.X + PushDir.X * 20, rots.LocalPosition.Y + PushDir.Y * 20);
                Game1.BoulderShove.Play(1, Game1.Random.Next(-1, 2), 0);
            }
            //Als de rots in aanraking komt met de pilaar verdwijnen beide de rots en de pilaar van het scherm
            if (OverlapsWith(pilaar, rots) == true)
            {
                Vector2 PushRots = new Vector2(pilaar.LocalPosition.X - rots.LocalPosition.X, pilaar.LocalPosition.Y - rots.LocalPosition.Y);
                PushRots.Normalize();
                pilaar.LocalPosition = new Vector2(pilaar.LocalPosition.X + PushRots.X * 20, pilaar.LocalPosition.Y + PushRots.Y * 20);
                pilaar.LocalPosition = new Vector2(-100, -100);
                rots.LocalPosition = new Vector2(-100, -100);
            }
            //Als de speler op de key loopt gaat de boolean op true en verdwijnt de sleutel van de map
            if (OverlapsWith(Key, player1) == true)
            {
                KeyCollected = true;
                Key.LocalPosition = new Vector2(-100, -100);
            }

            //Deze functies zorgen ervoor dat de speler en rots niet door de muren kunnen
            CollisionUpdate(player1); CollisionUpdate(rots);
            //Als de speler heel dicht in de buurt zit van de deur en hij heeft de key nog niet gecollect krijg je een tekst te zien
            if (InAura(player1, deur) && KeyCollected == false)
            {
                NotCollected.Color = Color.Red;
                NotCollected.LocalPosition = new Vector2(deur.LocalPosition.X - 150, 160);
                NotCollected.Text = "Oh, Seems i have to collect some sort of key first!";
            }

            //Als de speler heel dicht in de buurt zit van de pilaar en hij heeft de key nog niet gecollect krijg je een tekst te zien
            if (InAura(player1, pilaar) && KeyCollected == false)
            {
                NotCollected.Color = Color.Red;
                NotCollected.LocalPosition = new Vector2(pilaar.LocalPosition.X - 190, pilaar.LocalPosition.Y + 120);
                NotCollected.Text = "There seems to be some sort of key behind this pillar \nbut i cant push it!";
            }
            //Als de speler heel dicht in de buurt zit van de pilaar en hij heeft de key wel gecollect krijg je een tekst te zien
            if (InAura(player1, deur) && KeyCollected == true)
            {
                NotCollected.Color = Color.Green;
                NotCollected.LocalPosition = new Vector2(deur.LocalPosition.X - 150, 160);
                NotCollected.Text = "Press Space to  enter Jogon's Lair";
            }
            // Als de speler heel dicht in de buurt zit van de boom  krijg je een tekst te zien
            if (InAura(player1, boom))
            {

                NotCollected.Color = Color.Red;
                NotCollected.LocalPosition = new Vector2(boom.LocalPosition.X, boom.LocalPosition.Y - 100);
                NotCollected.Text = "This tree seems pretty useless.....";
            }
            // Als de speler heel dicht in de buurt zit van de fontein  krijg je een tekst te zien en wordt de health van de speler gereplenisht
            if (InAura(player1, Fontein))
            {

                NotCollected.Color = Color.Blue;
                NotCollected.LocalPosition = new Vector2(Fontein.LocalPosition.X, Fontein.LocalPosition.Y + 100);
                NotCollected.Text = "This fontain's water restored my health!";
                player1.health = 3;
                gameObjects.AddChild(Game1.playerHealth1);
                gameObjects.AddChild(Game1.playerHealth2);
                gameObjects.AddChild(Game1.playerHealth3);
            }
            //Als je de deur aanraakt en je hebt de keygecollect en daarna op spatie drukt ga je naar het volgende level
            if (InAura(player1,deur) && Keyboard.GetState().IsKeyDown(Keys.Space) && KeyCollected == true && Game1.framecount > Game1.startframe + 10)
            {
                Game1.GameStateManager.SwitchTo("jogonLevelPlayingState", "safeZoneState", new GameStates.SafeZoneState());
                Game1.framecount = Game1.startframe;
            }
            //Als je in de buurt zit van de helper krijg je een textbubble te zien met tekst.
            if (InAura(player1, Helper))
            {
                gameObjects.AddChild(Bubble);
                
                Bubble.LocalPosition = new Vector2(Helper.LocalPosition.X - 130, Helper.LocalPosition.Y - 80);
                
                HelperText.LocalPosition = new Vector2(Bubble.LocalPosition.X + 10, Bubble.LocalPosition.Y + 5);
                HelperText.Color = Color.DarkBlue;
                HelperText.Text = "Controls!: \nArrow Keys\nSpace ";
                ComeText.LocalPosition = new Vector2(-500, -500);

            }
            //Zo niet, verdwijnen de bubbel en de tekst.
            if (!InAura(player1, Helper))
            {
                Bubble.LocalPosition = new Vector2(-100, 100l);
                HelperText.LocalPosition = new Vector2(-500, -500);

            }
        }
    }
}
