using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class MushroomCollisionChecker
    {
        public MushroomCollisionChecker()
        {

        }

        public void CheckMushroomCollisions(List<IItem> items, List<IBlock> blocks, List<IPipe> pipes)
        {
            Game1.Side collisionType = Game1.Side.None;
            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();
            ItemGravityHandler gravityHandler = new ItemGravityHandler();

            foreach (IItem rm in items)
            {

                bool itemIsSupported = false;
                if (rm is RedMushroom)
                {
                    Rectangle currentRM = rm.GetRectangle();

                    foreach (IBlock block in blocks)
                    {
                        Rectangle currentBlock = block.GetRectangle();
                        collisionType = generalDetector.DetermineCollision(currentBlock, currentRM);

                        MushroomBlockCollisionHandler.HandleCollision(rm, block, collisionType);
                        if (collisionType.Equals(Game1.Side.Top) || (currentBlock.Top - currentRM.Bottom <= 5 && generalDetector.IsAlongSameYAxis(currentRM, currentBlock)))
                        {
                            itemIsSupported = true;
                        }
                    }

                    foreach (IPipe pipe in pipes)
                    {
                        Rectangle currentPipe = pipe.GetRectangle();
                        collisionType = generalDetector.DetermineCollision(currentPipe, currentRM);

                        MushroomPipeCollisionHandler.HandleCollision(rm, pipe, collisionType);

                        if (collisionType.Equals(Game1.Side.Top) || (currentPipe.Top - currentRM.Bottom <= 5 && generalDetector.IsAlongSameYAxis(currentRM, currentPipe)))
                        {
                            itemIsSupported = true;
                        }
                    }
                    if (!(itemIsSupported))
                    {
                        gravityHandler.ApplyGravityToItem(rm);
                    }
                    else
                    {
                        rm.SetGrounded();
                    }
                }

            }

            foreach (IItem gm in items)
            {

                bool itemIsSupported = false;

                if (gm is GreenMushroom)
                {
                    Rectangle currentGM = gm.GetRectangle();

                    foreach (IBlock block in blocks)
                    {
                        Rectangle currentBlock = block.GetRectangle();
                        collisionType = generalDetector.DetermineCollision(currentBlock, currentGM);

                        MushroomBlockCollisionHandler.HandleCollision(gm, block, collisionType);
                        if (collisionType.Equals(Game1.Side.Top) || (currentBlock.Top - currentGM.Bottom <= 5 && generalDetector.IsAlongSameYAxis(currentGM, currentBlock)))
                        {
                            itemIsSupported = true;
                        }
                    }

                    foreach (IPipe pipe in pipes)
                    {
                        Rectangle currentPipe = pipe.GetRectangle();
                        collisionType = generalDetector.DetermineCollision(currentPipe, currentGM);

                        MushroomPipeCollisionHandler.HandleCollision(gm, pipe, collisionType);

                        if (collisionType.Equals(Game1.Side.Top) || (currentPipe.Top - currentGM.Bottom <= 5 && generalDetector.IsAlongSameYAxis(currentGM, currentPipe)))
                        {
                            itemIsSupported = true;
                        }

                    }
                }

                if (!(itemIsSupported))
                {
                    gravityHandler.ApplyGravityToItem(gm);
                }
                else
                {
                    gm.SetGrounded();
                }

            }
        }

    }
}
