using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class MarioBlockCollisionHandler
    {
        public MarioBlockCollisionHandler()
        {
        }
        public static void HandleCollision(IPlayer player, IBlock block, Game1.Side side)
        {
            
            int collisionFix = 4;
            if (!player.IsInSpecialAnimationState())
            {
                if (side.Equals(Game1.Side.Left))
                {

                    player.ManualMoveX(collisionFix);

                    player.SetVelo(0);

                }
                else if (side.Equals(Game1.Side.Right))
                {

                    player.ManualMoveX(-1 * collisionFix);

                    player.SetVelo(0);
                }
                else if (side.Equals(Game1.Side.Top))
                {


                    player.ManualMoveY(player.GetVerticalVelocity() * (-2));

                    player.SetVerticalVelocity(0);
                }


                else if (side.Equals(Game1.Side.Bottom))
                {

                    int downDirection = 1;
                    int upDirection = -1;
                    if (player.GetVerticalVelocity() > 0)
                    {
                        // player.ManualMoveY(upDirection * player.GetVerticalVelocity());         //player.GetVerticalVelocity() * (-1.0));

                        double displacement = player.GetRectangle().Bottom - block.GetRectangle().Top;

                        if ((displacement) >= downDirection)
                        {

                            player.ManualMoveY(upDirection * displacement + upDirection);
                        }
                        else
                        {
                            player.ManualMoveY(0);
                        }

                    }
                    player.SetTouchedGround(true);
                    player.SetVerticalVelocity(0);
                    player.ResetEnemyMultiplier(1);
                    /*
                    player.ManualMoveY(player.GetVerticalVelocity() * (-2));
                    plyer.SetVerticalVelocity(0);*/
                }
            }
        }

        


        public static void FixVerticalCollision(IPlayer player)
        {
            double currentVelocity = player.GetVerticalVelocity();
            player.ManualMoveY(-currentVelocity/2);
        }
    }
}
