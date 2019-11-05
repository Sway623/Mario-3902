using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class BrickBlock : IBlock
    {
        Rectangle sourceRectangle;
        int spriteWidth = 16;
        int offset = 0;
        bool doneUp = false;
        bool movingUp = true;
        public bool isHit = false;
        bool shouldBreak = false;
        double verticalVelocity;
        double horizontalVelocity;
        BrokenBrickBlock block1;
        BrokenBrickBlock block2;
        BrokenBrickBlock block3;
        BrokenBrickBlock block4;
        bool movingLeft;
        BlockGravityHandler gravityHandler = new BlockGravityHandler();

        Vector2 location;

        public BrickBlock(Vector2 initLocation)
        {
            location = initLocation;
            sourceRectangle = new Rectangle(spriteWidth * 1, 0, BlockUtility.blockSize, BlockUtility.blockSize);
        }

        public Rectangle GetRectangle()
        {
            Rectangle currentRectangle;
            if (isHit)
            {
                currentRectangle = new Rectangle((int)location.X, (int)location.Y - 5, spriteWidth, spriteWidth);
            }
            else
            {
                currentRectangle = new Rectangle((int)location.X, (int)location.Y, spriteWidth, spriteWidth);
            }
            return currentRectangle;
        }

        public void SetLocation(Vector2 coords)
        {
            location.X = coords.X;
            location.Y = coords.Y;
        }

        public void AdjustLocation(Vector2 coords)
        {
            location.X += coords.X;
            location.Y += coords.Y;
        }

        public void Update(GameTime gameTime)
        {
            if (isHit && shouldBreak)
            {
                block1.Update(gameTime);
                block2.Update(gameTime);
                block3.Update(gameTime);
                block4.Update(gameTime);
            }
        }

        public Boolean IsHit()
        {
            return isHit;
        }

        public Boolean HasItem()
        {
            return false;
        }

        public IItem ReleaseItem(MarioState state)
        {
            return null;
        }

        public void ChangeStateWhenSmall(Game1.Side side)
        {
            if (side.Equals(Game1.Side.Top))
            {
                isHit = true;
            }
        }

        public void ChangeState(Game1.Side side)
        {
            if (side.Equals(Game1.Side.Top))
            {
                if (isHit == true)
                {
                    SoundManager.PlaySound(Game1.breakBlockSound);
                    Rectangle destinationRectangle = new Rectangle(BlockUtility.offScreen, BlockUtility.offScreen, BlockUtility.blockSize, BlockUtility.blockSize);
                }
                else
                {
                    isHit = true;
                    shouldBreak = true;
                    BreakBlock();
                }
            }
        }

        public void SetVerticalVelocity(double newVelocity)
        {
            verticalVelocity += newVelocity;

            block1.SetVerticalVelocity(verticalVelocity);
            block2.SetVerticalVelocity(verticalVelocity);
            block3.SetVerticalVelocity(verticalVelocity);
            block4.SetVerticalVelocity(verticalVelocity);

        }

        public double GetVerticalVelocity()
        {
            return verticalVelocity;
        }

        public void SetHorizontalVelocity(double newVelocity)
        {
            horizontalVelocity += newVelocity;
            block1.SetHorizontalVelocity(horizontalVelocity);
            block2.SetHorizontalVelocity((-1) * horizontalVelocity);
            block3.SetHorizontalVelocity(horizontalVelocity);
            block4.SetHorizontalVelocity((-1) * horizontalVelocity);
        }

        public double GetHorizontalVelocity()
        {
            return horizontalVelocity;
        }

        public bool GetMovingUp()
        {
            return movingUp;
        }

        public void SetMovingUp(bool up)
        {
            movingUp = up;
        }

        public bool GetMovingLeft()
        {
            return movingLeft;
        }

        public void SetMovingLeft(bool left)
        {
            movingLeft = left;
        }

        public void BreakBlock()
        {
            block1 = new BrokenBrickBlock(new Vector2(location.X + 10, location.Y));
            block2 = new BrokenBrickBlock(new Vector2(location.X - 10, location.Y));
            block3 = new BrokenBrickBlock(new Vector2(location.X + 10, location.Y + 10));
            block4 = new BrokenBrickBlock(new Vector2(location.X - 10, location.Y + 10));

            BlockGravityHandler gravityHandler = new BlockGravityHandler();
            gravityHandler.ApplyGravityToBlock(this);
        }

        public void adjustOffset()
        {
            if (doneUp && offset < 0)
            {
                offset++;
            }
            else if (!doneUp)
            {
                offset--;
                if (offset <= -5)
                {
                    doneUp = true;
                }
            }
            if (doneUp && offset == 0)
            {
                isHit = false;
                doneUp = false;
            }
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            if (isHit && shouldBreak)
            {
                block1.Draw(spriteBatch, cameraPosition);
                block2.Draw(spriteBatch, cameraPosition);
                block3.Draw(spriteBatch, cameraPosition);
                block4.Draw(spriteBatch, cameraPosition);

                location.X = BlockUtility.offScreen;
                location.Y = BlockUtility.offScreen;
            }
            else
            {
                if (isHit)
                {
                    adjustOffset();
                }
                Rectangle destinationRectangle = new Rectangle((int)(location.X - cameraPosition.X), (int)(location.Y - cameraPosition.Y) + offset, BlockUtility.blockSize, BlockUtility.blockSize);
                spriteBatch.Draw(TextureManager.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            }

        }
    }
}
