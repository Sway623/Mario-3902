using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class UsedBlock : IBlock
    {
        Rectangle sourceRectangle;
        Vector2 location;
        double verticalVelocity = 0;
        double horizontalVelocity = 0;
        bool movingUp = true;
        bool movingLeft;

        public UsedBlock(Vector2 initLocation)
        {
            location = initLocation;
            sourceRectangle = new Rectangle(BlockUtility.blockSize * 3, 0, BlockUtility.blockSize, BlockUtility.blockSize);
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

        public void SetMovingLeft(bool left)
        {
            movingLeft = left;
        }

        public bool GetMovingUp()
        {
            return movingUp;
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

        public void SetHorizontalVelocity(double newVelocity)
        {
            horizontalVelocity = newVelocity;
        }

        public double GetHorizontalVelocity()
        {
            return horizontalVelocity;
        }
        public bool GetMovingLeft()
        {
            return movingLeft;
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

        public Rectangle GetRectangle()
        {
            Rectangle currentRectangle = new Rectangle((int)location.X, (int)location.Y, BlockUtility.blockSize, BlockUtility.blockSize);
            return currentRectangle;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void ChangeState(Game1.Side side)
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            Rectangle destinationRectangle = new Rectangle((int)(location.X - cameraPosition.X), (int) (location.Y - cameraPosition.Y), BlockUtility.blockSize, BlockUtility.blockSize);
            spriteBatch.Draw(TextureManager.blockTexture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
