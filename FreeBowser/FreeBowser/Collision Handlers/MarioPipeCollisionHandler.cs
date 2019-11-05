using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class MarioPipeCollisionHandler
    {
        private static bool hasCollided;

        public MarioPipeCollisionHandler()
        {
            hasCollided = false;
        }

        public static void HandleCollision(IPlayer player, IPipe pipe, Game1.Side side)
        {
            int collisionFix = 3;
            if (side.Equals(Game1.Side.Left))
            {
                hasCollided = true;

                player.ManualMoveX(collisionFix);
                player.SetVelo(0);
            }
            else if (side.Equals(Game1.Side.Right))
            {
                hasCollided = true;
                player.SetVelo(0);

                if (pipe.GetType() == typeof(UndergroundSidePipe) && pipe.IsWarp() && player.GetDirection() == MarioDirection.RIGHT)
                {
                    if (!player.IsInSpecialAnimationState())
                    {
                        collisionFix = 0;
                        player.PipeRightAnimation();

                    }
                    else if (!player.HasFinishedSpecialAnimationState())
                    {
                        player.PipeRightAnimation();
                    }

                    if (player.HasFinishedSpecialAnimationState())
                    {
                        //Signal for mario to move down and then load new level
                        WorldManager.switchLevel = true;
                        WorldManager.currentFilename = pipe.GetFileName();
                        LevelManager.marioStartLocation = pipe.GetSpawnCoords();
                        WorldManager.marioStartLocation = pipe.GetSpawnCoords();
                    }
                }
                else
                {
                    player.ManualMoveX(-1 * collisionFix);
                }
            }

            else if (side.Equals(Game1.Side.Bottom))
            {

                if (player.GetVerticalVelocity() > 0)
                {
                    //player.ManualMoveY(-1 * player.GetVerticalVelocity());         //player.GetVerticalVelocity() * (-1.0));

                    int displacement = player.GetRectangle().Bottom - pipe.GetRectangle().Top;

                    if ((displacement) > 1)
                    {
                        player.ManualMoveY(-1 * displacement);
                    }

                }

                player.SetVerticalVelocity(0);

                if (pipe.GetType() == typeof(LargePipe) && pipe.IsWarp() && player.GetDirection() == MarioDirection.DOWN)
                {

                    if (!player.IsInSpecialAnimationState())
                        player.PipeDownAnimation();
                    else if (!player.HasFinishedSpecialAnimationState())

                        player.PipeDownAnimation();

                    if (player.HasFinishedSpecialAnimationState())
                    {
                        //Signal for mario to move down and then load new level
                        WorldManager.switchLevel = true;
                        WorldManager.currentFilename = pipe.GetFileName();
                        WorldManager.marioStartLocation = pipe.GetSpawnCoords();
                    }
                }
            }

            if (hasCollided)
            {
                player.LockMov();
            }
            else
            {
                player.UnlockMov();
            }
            hasCollided = false;
        }
    }
}
