using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class StarPipeCollisionHandler
    {
        public static void HandleCollision(IItem star, IPipe pipe, Game1.Side side)
        {
            Star localStar = (Star)star;
            int starDisplacement = 3;

            if (side.Equals(Game1.Side.Left) )
            {
                localStar.location.X += starDisplacement;
                localStar.movingRight = !localStar.movingRight;
            }
            else if ( side.Equals(Game1.Side.Right))
            {
                localStar.location.X -= starDisplacement;
                localStar.movingRight = !localStar.movingRight;
            }


        }

    }
}

