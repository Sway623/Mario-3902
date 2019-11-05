using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class KoopaShell : IItem
    {
        Vector2 dimensions = new Vector2(14, 11);
        Rectangle sourceRectangle = new Rectangle(361, 5, 14, 11);
        public bool isHit = false;
        int horizontalVelocity = 2;
        double verticalVelocity = 0;

        Vector2 location;

        public KoopaShell(Vector2 initLocation)
        {
            location = initLocation;
        }

        public Rectangle GetRectangle()
        {
            Rectangle currentRectangle = new Rectangle((int)location.X, (int)location.Y, (int)dimensions.X, (int)dimensions.Y);
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

        public void ChangeDirection()
        {
            horizontalVelocity *= -1;
        }

        public void ChangeState()
        {
            isHit = true;
        }

        public void Update()
        {
            if (isHit)
            {
                location.X += horizontalVelocity;
            }
        }
        public void SetVerticalVelocity(double newVelocity)
        {
            verticalVelocity = newVelocity;
        }

        public double GetVerticalVelocity()
        {
            return verticalVelocity;
        }
        public void SetGrounded()
        {
            verticalVelocity = 0;
        }
        public void SetCreatedFromBlock(bool itemCreatedFromBlock)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            Rectangle destinationRectangle = new Rectangle((int)(location.X - cameraPosition.X), (int)(location.Y - cameraPosition.Y), 14, 11);
            spriteBatch.Draw(TextureManager.enemyTexture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
