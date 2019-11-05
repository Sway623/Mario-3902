using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    public class PowerUpPlaceholder : IItem
    {

        Vector2 location;
        public PowerUpPlaceholder(Vector2 initLocation)
        {
            location = initLocation;
        }

        public Rectangle GetRectangle()
        {
            Rectangle currentRectangle = new Rectangle((int)location.X, (int)location.Y, 0, 0);
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

        public void ChangeState()
        {

        }
        public void SetVerticalVelocity(double newVelocity)
        {
        }

        public double GetVerticalVelocity()
        {
            return 0;
        }
        public void SetGrounded()
        {

        }
        public void Update()
        {

        }

        public void SetCreatedFromBlock(bool itemCreatedFromBlock)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {

        }


    }
}
