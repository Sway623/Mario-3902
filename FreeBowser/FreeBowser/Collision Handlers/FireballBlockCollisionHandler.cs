using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class FireballBlockCollisionHandler
    {
        public static void HandleCollision(Fireball fireball, IBlock block, Game1.Side side)
        {
            
            if (side == Game1.Side.Top)
            {
                fireball.Bounce();
            }
            else if (side != Game1.Side.None)
            {
                fireball.ChangeState();
            }
        }
    }
}
