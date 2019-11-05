using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class FireballEnemyCollisionHandler
    {
        public static void HandleCollision(Fireball fireball, IEnemy enemy, Game1.Side side)
        {
            EnemyGravityHandler gravity = new EnemyGravityHandler();
            if (side != Game1.Side.None)
            {
                if (enemy is Goomba)
                {
                    Goomba localGoomba = (Goomba)enemy;
                    localGoomba.BeFlipped();
                    gravity.ApplyGravityToEnemy(localGoomba);
                }

                if (enemy is Koopa)
                {
                    Koopa localKoopa = (Koopa)enemy;
                    localKoopa.BeFlipped();
                    gravity.ApplyGravityToEnemy(localKoopa);
                }

                fireball.ChangeState();
            }

        }
    }
}
