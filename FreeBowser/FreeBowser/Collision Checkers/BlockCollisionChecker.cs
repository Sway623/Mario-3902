using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class BlockCollisionChecker
    {
        public BlockCollisionChecker()
        {

        }

        public void CheckBlockCollisions(List<IBlock> blocks, List<IPlayer> players)
        {
            Game1.Side collisionType;
            BlockCollisionDetector blockDetector = new BlockCollisionDetector();
            BlockGravityHandler gravityHandler = new BlockGravityHandler();

            foreach (IBlock block in blocks)
            {
                if (block is BrickBlock)
                {
                    Rectangle currentBlock = block.GetRectangle();
                    foreach (IPlayer player in players)
                    {
                        Rectangle currentPlayer = player.GetRectangle();
                       
                        collisionType = blockDetector.DetermineCollision(currentBlock, currentPlayer);

                        if(collisionType.Equals(Game1.Side.Top))
                        {                            
                            block.ChangeState(Game1.Side.Top);
                        }
                    }
                }
            }

        }
    }
}

