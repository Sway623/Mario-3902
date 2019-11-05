using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class StarBlockCollisionHanlder
    {
        public static void HandleCollision(IItem star, IBlock block, Game1.Side side)
        {
            Star localStar =  (Star)star;
            int bounceDistance = 3;
                if (side.Equals(Game1.Side.Left) || side.Equals(Game1.Side.Right))
                {
                if (block is UnbreakableBlock)
                {
                    if (localStar.movingRight)
                    {
                        localStar.location.X -= bounceDistance;
                    }
                    else
                    {
                        localStar.location.X += bounceDistance;
                    }
                    localStar.movingRight = !localStar.movingRight;
                }
                }


            }

        }
    }

