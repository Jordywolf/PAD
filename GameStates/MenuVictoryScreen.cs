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
    class MenuVictoryScreen : GameState
    {
        SpriteGameObject background;
        GameObjectList texten;
        GameObjectList jogons;
        RotatingSpriteGameObject head;

        private int jogon = 1000;
        public MenuVictoryScreen() : base()
        {
            background = new SpriteGameObject("HomeScreen", 0.5f);
            gameObjects.AddChild(background);

            texten = new GameObjectList();
            gameObjects.AddChild(texten);

            gameObjects.AddChild(Game1.player);
            gameObjects.AddChild(Game1.playerShadow);

            jogons = new GameObjectList();
            gameObjects.AddChild(jogons);

            texten.AddChild(new mapObjects.IntroText("Made by\n\nJordi van der Lem\nJordy Wolf\nNidal Toufik\nNick Baptist\nOlivier Molenaar\nJort Keppel", "Eightbit", Color.White, new Vector2(Game1.width / 5 * 4, Game1.height + 200)));


            texten.AddChild(new mapObjects.IntroText("Produced by", "Eightbit", Color.White, new Vector2(Game1.width / 5 * 4, Game1.height + 500)));
            texten.AddChild(new mapObjects.IntroText("Team 41 Groente", "Eightbit", Color.White, new Vector2(Game1.width / 5 * 4, Game1.height + 600)));
            texten.AddChild(new mapObjects.IntroText("Hva", "Eightbit", Color.White, new Vector2(Game1.width / 5 * 4, Game1.height + 620)));
            texten.AddChild(new mapObjects.IntroText("Monogame", "Eightbit", Color.White, new Vector2(Game1.width / 5 * 4, Game1.height + 640)));

            texten.AddChild(new mapObjects.IntroText("Thank you for playing", "Eightbit", Color.White, new Vector2(Game1.width / 5 * 4, Game1.height + 750)));
            texten.AddChild(new mapObjects.IntroText("Press space to return to menu", "Eightbit", Color.White, new Vector2(Game1.width / 5 * 4, Game1.height + 770)));

            texten.AddChild(new mapObjects.IntroText("Jackstraw 2: Revenge of Olivier\n\nComming soon...", "Eightbit", Color.White, new Vector2(Game1.width / 5 * 4, Game1.height + 4000)));


            for (int q = 0; q <= jogon; q++)
            {
                if (q == 0)
                {
                    jogons.AddChild(head = new RotatingSpriteGameObject("JogonHead", 1));
                    head.LocalPosition = new Vector2(Game1.width / 5 * 4 - 50, Game1.height + 200 + q * 45);
                    head.Angle = MathF.PI;
                    head.scale = 1.5f;
                }

                if (q > 0) { jogons.AddChild(new ObjectTile("Jogon_BodyS", new Vector2(Game1.width / 5 * 4 - 50, Game1.height + 200 + q * 45), 0.9f)); }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (mapObjects.IntroText i in texten.children)
            {
                i.LocalPosition = new Vector2(i.LocalPosition.X, i.LocalPosition.Y - 1);
            }

            foreach (SpriteGameObject o in jogons.children)
            {
                o.scale = 1.5f;
                o.Origin = o.sprite.Center;
                o.LocalPosition = new Vector2(o.LocalPosition.X, o.LocalPosition.Y - 1);
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.KeyDown(Keys.Space))
            {
                Game1.GameStateManager.SwitchTo("menuStartSelectedState", "menuVictoryScreen", new GameStates.MenuVictoryScreen());
            }
        }
    }
}
