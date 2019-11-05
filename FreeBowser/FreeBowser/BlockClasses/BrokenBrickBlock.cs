using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class BrokenBrickBlock : IBlock
    {
        Vector2 location;
        Rectangle sourceRectangle;
        public bool movingUp = false;
        public bool isHit = false;
        public bool movingLeft = true;
        double verticalVelocity;
        double horizontalVelocity;
        int spriteWidth = 4;

        public BrokenBrickBlock(Vector2 initLocation)
        {
            location = initLocation;
            sourceRectangle = new Rectangle(16, 0, 9, 9);
        }

        public Rectangle GetRectangle()
        {
            Rectangle currentRectangle = new Rectangle((int)location.X, (int)location.Y, spriteWidth, spriteWidth);
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
            location.Y += (int)verticalVelocity;
            location.X += (int)horizontalVelocity;
        }

        public Boolean IsHit()
        {
            return isHit;
        }

        public bool GetMovingLeft()
        {
            return movingLeft;
        }

        public void SetMovingLeft(bool left)
        {
            movingLeft = left;
        }

        public void ChangeState(Game1.Side side)
        {
           
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

        public bool GetMovingUp()
        {
            return movingUp;
        }

        public void SetMovingUp(bool up)
        {
            movingUp = up;
        }

        public Boolean HasItem()
        {
            return false;
        }

        public IItem ReleaseItem(MarioState state)
        {
            return null;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            Rectangle destinationRectangle = new Rectangle((int)(location.X - cameraPosition.X), (int)(location.Y - cameraPosition.Y), 7, 7);
            spriteBatch.Draw(TextureManager.blockTexture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
