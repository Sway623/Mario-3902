using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace FreeBowser
{
    public class Castle :IItem
    {
        int spriteHeight = 79;
        int spriteWidthTop = 81;
        Vector2 location;

        public Castle(Vector2 initLocation)
        {
            location = initLocation;
        }
        public void Update()
        {
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

        public void SetCreatedFromBlock(bool itemCreatedFromBlock)
        {
            
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            Rectangle sourceRectangle = new Rectangle(246, 863, spriteWidthTop, spriteHeight);
            Rectangle destinationRectangle = new Rectangle((int)(location.X - cameraPosition.X), (int)(location.Y - cameraPosition.Y), spriteWidthTop, spriteHeight);
            spriteBatch.Draw(TextureManager.pipeTexture, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetRectangle()
        {
            Rectangle currentRectangle = new Rectangle((int)location.X, (int)location.Y, spriteWidthTop, spriteHeight);
            return currentRectangle;
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
    }
}