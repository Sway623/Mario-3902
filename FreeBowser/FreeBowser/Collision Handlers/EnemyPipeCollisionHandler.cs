using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class EnemyPipeCollisionHandler
    {
        public static void HandleCollision(IEnemy enemy, IPipe pipe, Game1.Side side)
        {
            if (side.Equals(Game1.Side.Left) || side.Equals(Game1.Side.Right) || side.Equals(Game1.Side.Top))
            {
                enemy.ChangeDirection();
            }

            else
            {
                //just keep walking
            }
        }

    }
}
