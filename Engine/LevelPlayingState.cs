using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine;

namespace BaseProject.Engine
{
    class LevelPlayingState : GameState
    {
        protected GameObjectList floor;
        protected GameObjectList walls;

        private static int grid = 64;

        private Vector2 collisionVector;

        public LevelPlayingState() : base()
        {
            floor = new GameObjectList();
            gameObjects.AddChild(floor);

            walls = new GameObjectList();
            gameObjects.AddChild(walls);
        }

        public void LoadFullFloor(String floorTexture)
        {
            for (int iXFloor = 0; iXFloor < Game1.width / grid; iXFloor++)
            {
                for (int iYFloor = 0; iYFloor < Game1.height / grid; iYFloor++)
                {
                    floor.AddChild(new FloorTile(floorTexture, new Vector2(grid * iXFloor, grid * iYFloor)));
                }
            }
        }

        public void LoadSquareFloor(String floorTexture, float Ysize, float Xsize, Vector2 midPos)
        {
            for (int iXFloor = 0; iXFloor < Game1.width / grid; iXFloor++)
            {
                for (int iYFloor = 0; iYFloor < Game1.height / grid; iYFloor++)
                {
                    if (iXFloor * grid >= Game1.width / 2 - Xsize / 2 * grid && iXFloor * grid <= Game1.width / 2 + Xsize / 2 * grid
                        && iYFloor * grid >= Game1.height / 2 - Ysize / 2 * grid && iYFloor * grid <= Game1.height / 2 + Ysize / 2 * grid)
                    {
                        floor.AddChild(new FloorTile(floorTexture, new Vector2(grid * iXFloor - (Game1.width / 2 - midPos.X), grid * iYFloor - (Game1.height / 2 - midPos.Y))));
                    }
                }
            }
        }

        public void LoadSquareWalls(String cdl, String d, String cdr, String r, String ctr, String t, String ctl, String l)
        {
            for (int iWalltile = 0; iWalltile < Game1.width / grid; iWalltile++)
            {
                if (iWalltile <= 0)
                {
                    walls.AddChild(new ObjectTile(ctl, new Vector2(grid * iWalltile + grid / 2, grid / 2), 0.6f));
                    walls.AddChild(new ObjectTile(cdl, new Vector2(grid * iWalltile + grid / 2, Game1.height - grid + grid / 2), 0.6f));
                }

                else if (iWalltile >= (Game1.width / grid) - 1)
                {
                    walls.AddChild(new ObjectTile(ctr, new Vector2(grid * iWalltile + grid / 2, 0 + grid / 2), 0.6f));
                    walls.AddChild(new ObjectTile(cdr, new Vector2(grid * iWalltile + grid / 2, Game1.height - grid + grid / 2), 0.6f));
                }

                else
                {
                    walls.AddChild(new ObjectTile(t, new Vector2(grid * iWalltile + grid / 2, 0 + grid / 2), 0.6f));
                    walls.AddChild(new ObjectTile(d, new Vector2(grid * iWalltile + grid / 2, Game1.height - grid + grid / 2), 0.6f));
                    walls.AddChild(new ObjectTile(l, new Vector2(0 + grid / 2, grid * iWalltile + grid / 2), 0.6f));
                    walls.AddChild(new ObjectTile(r, new Vector2(Game1.width - grid + grid / 2, grid * iWalltile + grid / 2), 0.6f));
                }
            }
        }

        public bool OverlapsWith(SpriteGameObject thisOne, SpriteGameObject thatOne)
        {
            return (thisOne.LocalPosition.X + thisOne.sprite.Width * thisOne.scale / 2 > thatOne.LocalPosition.X - thatOne.sprite.Width * thisOne.scale / 2
                && thisOne.LocalPosition.X - thisOne.sprite.Width * thisOne.scale / 2 < thatOne.LocalPosition.X + thatOne.sprite.Width * thisOne.scale / 2
                && thisOne.LocalPosition.Y + thisOne.sprite.Height * thisOne.scale / 2 > thatOne.LocalPosition.Y - thatOne.sprite.Height * thisOne.scale / 2
                && thisOne.LocalPosition.Y - thisOne.sprite.Height * thisOne.scale / 2 < thatOne.LocalPosition.Y + thatOne.sprite.Height * thisOne.scale / 2);
        }

        public void CollisionUpdate(SpriteGameObject p)
        {
            //oude manier om de collision te berekenen
            //adjRec = Rectangle.Union(adjRec, CollisionDetection.CalculateIntersection(p.collisionRec, o.collisionRec));

            /*p.LocalPosition = new Vector2(p.LocalPosition.X - CollisionDetection.CalculateIntersection(p.collisionRec, o.collisionRec).Width,
                p.LocalPosition.Y);*/

            foreach (ObjectTile o in walls.children)
            {
                Rectangle adjRec = new Rectangle();

                //links naar rechts
                if (CollisionDetection.ShapesIntersect(p.collisionRec, o.collisionRec) && p.LocalPosition.X + p.Width / 2
                    > o.LocalPosition.X - o.Width / 2 && p.LocalPosition.X + p.Width / 2 < o.LocalPosition.X)
                {
                    adjRec.Width -= CollisionDetection.CalculateIntersection(p.collisionRec, o.collisionRec).Width;
                }

                //rechts naar links
                if (CollisionDetection.ShapesIntersect(p.collisionRec, o.collisionRec) && p.LocalPosition.X - p.Width / 2
                    < o.LocalPosition.X + o.Width / 2 && p.LocalPosition.X - p.Width / 2 > o.LocalPosition.X)
                {
                    adjRec.Width += CollisionDetection.CalculateIntersection(p.collisionRec, o.collisionRec).Width;
                }

                //boven naar beneden lopen
                if (CollisionDetection.ShapesIntersect(p.collisionRec, o.collisionRec) && p.LocalPosition.Y + p.Height / 2
                    > o.LocalPosition.Y - o.Height / 2 && p.LocalPosition.Y + p.Height / 2 < o.LocalPosition.Y)
                {
                    adjRec.Height -= CollisionDetection.CalculateIntersection(p.collisionRec, o.collisionRec).Height; 
                }

                //onder naar boven
                if (CollisionDetection.ShapesIntersect(p.collisionRec, o.collisionRec) && p.LocalPosition.Y - p.Height / 2
                    < o.LocalPosition.Y + o.Height / 2 && p.LocalPosition.Y - p.Height / 2 > o.LocalPosition.Y)
                {
                    adjRec.Height += CollisionDetection.CalculateIntersection(p.collisionRec, o.collisionRec).Height;
                }
                

                p.LocalPosition = new Vector2(p.LocalPosition.X + adjRec.Width, p.LocalPosition.Y + adjRec.Height);
            }
        }
    }
}
