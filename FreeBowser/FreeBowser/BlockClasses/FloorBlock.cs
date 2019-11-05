using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class FloorBlock : IBlock
    {
        Rectangle sourceRectangle;
        int spriteWidth = 16;
        Vector2 location;
        bool movingLeft;
        double verticalVelocity;

        double horizontalVelocity;
        bool movingUp = true;

        public FloorBlock(Vector2 initLocation)
        {
            int x = (int)initLocation.X;
            int y = (int)initLocation.Y;
            location = new Vector2(x, y);
            sourceRectangle = new Rectangle(spriteWidth * 0, 0, BlockUtility.blockSize, BlockUtility.blockSize);
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

        public double GetHorizontalVelocity()
        {
            return horizontalVelocity;
        }

        public void SetHorizontalVelocity(double newVelocity)
        {
            horizontalVelocity = newVelocity;
        }

        public bool GetMovingUp()
        {
            return movingUp;
        }

        public void SetMovingLeft(bool left)
        {
            movingLeft = left;
        }

        public void SetMovingUp(bool up)
        {
            movingUp = up;
        }

        public void SetVerticalVelocity(double newVelocity)
        {
            verticalVelocity = newVelocity;
        }

        public double GetVerticalVelocity()
        {
            return verticalVelocity;
        }

        public Rectangle GetRectangle()
        {
            Rectangle currentRectangle = new Rectangle((int)location.X-1, (int)location.Y+1, spriteWidth+2, spriteWidth);
            return currentRectangle;
        }

        public void Update(GameTime gameTime)
        {

        }

        public Boolean IsHit()
        {
            return false;
        }

        public Boolean HasItem()
        {
            return false;
        }

        public IItem ReleaseItem(MarioState state)
        {
         
                return null;
        }
        public void ChangeState(Game1.Side side)
        {
        }

        public bool GetMovingLeft()
        {
            return movingLeft;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            Rectangle destinationRectangle = new Rectangle((int)(location.X - cameraPosition.X), (int)(location.Y - cameraPosition.Y), BlockUtility.blockSize, BlockUtility.blockSize);
            spriteBatch.Draw(TextureManager.blockTexture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}

