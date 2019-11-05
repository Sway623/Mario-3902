using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class MushroomPipeCollisionHandler
    {
        public static void HandleCollision(IItem mushroom, IPipe pipe, Game1.Side side)
        {
            RedMushroom localRM;
            GreenMushroom localGM;
            if (mushroom is RedMushroom)
            {
                localRM = (RedMushroom)mushroom;
                if (side == Game1.Side.Bottom)
                {
                    localRM.location.Y += 2;
                }
                if (side == Game1.Side.Left)
                {
                    localRM.movingRight = false;
                }
                else if (side == Game1.Side.Right)
                {
                    localRM.movingRight = true;
                }
            }

            if (mushroom is GreenMushroom)
            {
                localGM = (GreenMushroom)mushroom;
                if (side == Game1.Side.Left)
                {
                    localGM.movingRight = false;
                }
                else if (side == Game1.Side.Right)
                {
                    localGM.movingRight = true;
                }
            }
        }
    }
}
