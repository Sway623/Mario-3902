using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public interface ICollision
    {
       FreeBowser.Game1.Side DetermineCollision(Rectangle currentObject, Rectangle collidingObject);

    }
}
