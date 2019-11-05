using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class BlockGravityHandler
    {
        public BlockGravityHandler()
        {
        }

        public void ApplyGravityToBlock(IBlock myBlock)
        {
            bool movingUp = myBlock.GetMovingUp();
            double verticalVelocity = myBlock.GetVerticalVelocity();
            double horizontalVelocity = myBlock.GetHorizontalVelocity();

            horizontalVelocity++;
            if (!movingUp && verticalVelocity > 0)
            {
                verticalVelocity--;
            }
            else if (movingUp)
            {
                verticalVelocity+=3;
                if (verticalVelocity <= -5)
                {
                    myBlock.SetMovingUp(false);
                }
            }


            myBlock.SetHorizontalVelocity(horizontalVelocity);
            myBlock.SetVerticalVelocity(verticalVelocity);

        }

    }
}
