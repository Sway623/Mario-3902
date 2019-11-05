using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class EnemyBlockCollisionHandler
    {

        public static void HandleCollision(IEnemy enemy, IBlock block,  Game1.Side side )
        {
            EnemyGravityHandler gravity = new EnemyGravityHandler();
            if (side.Equals(Game1.Side.Left) || side.Equals(Game1.Side.Right))// || side.Equals(Game1.Side.Top)) 
            {
                if (block.IsHit())
                {
                    enemy.BeFlipped();
                    gravity.ApplyGravityToEnemy(enemy);
                }
                

              else if (block is UnbreakableBlock)
                enemy.ChangeDirection();
            }
       
            else if (side.Equals(Game1.Side.Bottom))
            {
                if (block.IsHit())
                {
                    enemy.BeFlipped();
                    gravity.ApplyGravityToEnemy(enemy);
                    Display.UpdateKilledEnemy();
                }

                enemy.ManualMoveY(-1 * enemy.GetVerticalVelocity());
            }
            
        }
    }
}
