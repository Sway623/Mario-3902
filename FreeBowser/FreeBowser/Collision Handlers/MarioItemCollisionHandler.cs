using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class MarioItemCollisionHandler
    {
        public static void HandleCollision(IPlayer player, IItem item, Game1.Side side)
        {
            if (!side.Equals(Game1.Side.None))
            {
                MarioState playerState = player.GetState();
              
                if (item is FireFlower)
                {
                    if (playerState.Equals(MarioState.SMALL) || playerState.Equals(MarioState.LARGE)) {
                        player.SwitchToFireMario(true);
                    }
                    item.ChangeState();
                }

                if (item is RedMushroom)
                {
                    if (playerState.Equals(MarioState.SMALL)) {
                        player.SwitchToBigMario(true);
                    }
                    item.ChangeState();
                }

                if (item is Star)
                {
                    //go to star state
                    item.ChangeState();
                   
                    if (StarUtility.isFirstShown == false)
                    {
                        StarUtility.starTime = 8;
                        StarUtility.isStarMario = true;
                        player.SetStarMario(true);
                        StarUtility.StarMarioLock = true;
                        Console.Out.WriteLine("collide with star");
                        StarUtility.isFirstShown = true;
                    }

                }

                if (item is VisibleCoin)
                {
                    item.ChangeState();
                }

                if(item is GreenMushroom)
                {
                    int lives = player.GetLives();
                    player.SetLives(lives + 1);
                    item.ChangeState();
                }

            }

            if (item is KoopaShell)
            {
                KoopaShell shell = (KoopaShell)item;
                int collisionFix = 2;
                if (side.Equals(Game1.Side.Top))
                {
                    int bounceVelocity = -5;
                    //Console.WriteLine("here");
                    player.SetVerticalVelocity(bounceVelocity);
                    item.ChangeState();

                }

                if (side.Equals(Game1.Side.Left))
                {
                    if (shell.isHit)
                    {
                        player.TakeDamage();
                    }
                    else
                    {
                        player.MoveX(-1 * collisionFix);
                        player.SetHorizontalVelocity(0);
                    }
                }
                else if (side.Equals(Game1.Side.Right))
                {

                    if (shell.isHit)
                    {
                        player.TakeDamage();
                    }
                    else
                    {
                        player.MoveX(collisionFix);
                        player.SetHorizontalVelocity(0);
                    }
                    

                }

            }

            if (item is Flag)
            {
                if (side.Equals(Game1.Side.Left))
                {
                    MarioFlagCollisionHandler.HandleCollision(player, item);
                }
            }
        }
    }
}
