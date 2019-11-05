using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class EnemyGravityHandler
    {


        public EnemyGravityHandler()
        {
        }

        public void ApplyGravityToEnemy(IEnemy myEnemy)
        {

            double currentVelocity = myEnemy.GetVerticalVelocity();
            double newVelocity = currentVelocity;

            if (newVelocity <= 5)
            {
                newVelocity += .5;
                myEnemy.SetVerticalVelocity(newVelocity);
            }
           



        }
    }
}