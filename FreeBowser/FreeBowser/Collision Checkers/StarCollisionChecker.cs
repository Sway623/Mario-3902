using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class StarCollisionChecker
    {
        public StarCollisionChecker()
        {

        }

        public void CheckStarCollisions(List<IItem> items, List<IBlock> blocks, List<IPipe> pipes)
        {
            Game1.Side collisionType = Game1.Side.None;
            BlockCollisionDetector generalDetector = new BlockCollisionDetector();
            ItemGravityHandler gravityHandler = new ItemGravityHandler();
            bool shouldBounce = false;
            foreach (IItem star in items)
            {
                if (star is Star)
                {
                    Rectangle currentStar = star.GetRectangle();
                    foreach (IBlock block in blocks)
                    {

                        Rectangle currentBlock = block.GetRectangle();
                        collisionType = generalDetector.DetermineCollision(currentStar, currentBlock);

                        StarBlockCollisionHanlder.HandleCollision(star, block, collisionType);
                        if (collisionType.Equals(Game1.Side.Bottom))
                        {
                            shouldBounce = true;
                        }
                    }
                    
                    foreach (IPipe pipe in pipes)
                    {
                        Rectangle currentPipe = pipe.GetRectangle();
                        collisionType = generalDetector.DetermineCollision(currentStar, currentPipe);

                        StarPipeCollisionHandler.HandleCollision(star, pipe, collisionType);
                        if (collisionType.Equals(Game1.Side.Bottom))
                        {
                            shouldBounce = true;
                        }

                    }

                    if (shouldBounce)
                    {
                        star.SetGrounded();
                    }
                    else
                    {
                        gravityHandler.ApplyGravityToItem(star);
                    }
                }
            }
        }
    }

}