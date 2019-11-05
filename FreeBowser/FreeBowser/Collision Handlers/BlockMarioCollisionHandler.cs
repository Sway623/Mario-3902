using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace FreeBowser
{
    public class BlockMarioCollisionHandler
    {
        public static void HandleCollision(IPlayer player, IBlock block, Game1.Side side)
        {
            if (!player.IsInSpecialAnimationState())
            {
                if (block is BrickBlock && player.GetState().Equals(MarioState.SMALL))
                {
                    BrickBlock brickBlock = (BrickBlock)block;
                    brickBlock.ChangeStateWhenSmall(side);
                }
                else
                {
                    block.ChangeState(side);
                }
            }
        }
    }
}
