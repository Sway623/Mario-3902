using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class MushroomBlockCollisionHandler
    {
        public static void HandleCollision(IItem mushroom, IBlock block, Game1.Side side)
        {
            RedMushroom localRM;
            GreenMushroom localGM;

            if (mushroom is RedMushroom)
            {
                localRM = (RedMushroom)mushroom;
                if (side == Game1.Side.Bottom)
                {
                    localRM.location.Y += 1;
                }
                if (side == Game1.Side.Right)
                {
                    if (block is UnbreakableBlock)
                    localRM.movingRight = false;
                }
                else if (side == Game1.Side.Left)
                {
                    if (block is UnbreakableBlock)
                        localRM.movingRight = true;
                }
            }

            if (mushroom is GreenMushroom)
            {
                localGM = (GreenMushroom)mushroom;
                if (side == Game1.Side.Bottom)
                {
                    localGM.location.Y += 1;
                }
                if (side == Game1.Side.Right)
                {
                    localGM.movingRight = false;
                }
                else if (side == Game1.Side.Left)
                {
                    localGM.movingRight = true;
                }
            }
        }
        
    }
}
