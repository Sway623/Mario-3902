using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class ItemGravityHandler
    {


        public ItemGravityHandler()
        {
        }

        public void ApplyGravityToItem(IItem myItem)
        {

            double currentVelocity = myItem.GetVerticalVelocity();
            double newVelocity = currentVelocity;

            if (newVelocity <= 5)
            {
                newVelocity += .25;
                myItem.SetVerticalVelocity(newVelocity);
            }




        }
    }
}