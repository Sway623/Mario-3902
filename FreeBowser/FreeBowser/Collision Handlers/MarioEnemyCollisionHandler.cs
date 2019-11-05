using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class MarioEnemyCollisionHandler
    {

        public static void HandleCollision(IPlayer marioPlayer, IEnemy enemy, Game1.Side side)
        {
            Mario mario = (Mario)marioPlayer;
            if (!mario.IsInSpecialAnimationState())
            {

                if (mario.IsStarMario() && !side.Equals(Game1.Side.None))
                {
                    enemy.BeFlipped();
                }
                else if (side.Equals(Game1.Side.Left) || side.Equals(Game1.Side.Right) || side.Equals(Game1.Side.Top))
                {
                        mario.TakeDamage();
                }
                //case mario on enemy
                else if (side.Equals(Game1.Side.Bottom))
                {
                    int bounceVelocity = -4;
                    // case enemy is goomba
                    if (enemy is Goomba)
                    {
                        Goomba localGoomba = (Goomba)enemy;
                        localGoomba.KillEnemy();

                        mario.SetVerticalVelocity(bounceVelocity);


                    }
                    if (enemy is Koopa)
                    {
                        Koopa localKoopa = (Koopa)enemy;
                       
                            localKoopa.KillEnemy();
                            mario.SetVerticalVelocity(bounceVelocity);

                    }

                    if (!WorldManager.spriteSet.players[0].GetTouchedGround())
                    {
                        WorldManager.spriteSet.players[0].IncrementEnemyMultiplier();
                    }
                }
            }
        }

    }
}
