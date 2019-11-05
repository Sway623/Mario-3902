using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class MarioGravityHandler2
    {


        public MarioGravityHandler2()
        {
        }

        public void ApplyGravityToMario(Mario myMario)
        {
            double currentVelocity = myMario.GetVerticalVelocity();
            double newVelocity = currentVelocity;
            Rectangle marioReference = myMario.GetRectangle();
           
            if (newVelocity <= 5)
            {
                newVelocity += .5;
                myMario.SetVerticalVelocity(newVelocity);
            }
        }
    }
}