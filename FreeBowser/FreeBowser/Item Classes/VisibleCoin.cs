using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace FreeBowser
{
    public class VisibleCoin : ICoin
    {
        int currentFrame = 0;
        int frameToDisplay = 0;
        int spriteWidth = 16;
        int spriteHeight = 16;
        int frameTimer = 0;

        //Default the value of the coin created to 1
        private int coinVal = 1;
        Vector2 location;
        public VisibleCoin(Vector2 initLocation)
        {
            location = initLocation;
        }
        public void SetValue(int value) {
            coinVal = value;
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

        public int GetValue()
        {
            return coinVal;
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
        public void SetCreatedFromBlock(bool itemCreatedFromBlock)
        {
            
        }

        public Rectangle GetRectangle()
        {
            Rectangle currentRectangle = new Rectangle((int)location.X, (int)location.Y, spriteWidth, spriteHeight);
            return currentRectangle;
        }

        public void ChangeState()
        {
            location.X = -100;
            location.Y = -100;
            
            Display.UpdateNumCoins();
        }

        public void Update()
        {
            frameTimer++;
            if (frameTimer > 15)
            {
                frameTimer = 0;
                currentFrame++;
                if (currentFrame > 3)
                {
                    currentFrame = 0;
                }
                frameToDisplay = currentFrame;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
                Rectangle sourceRectangle = new Rectangle(spriteWidth * frameToDisplay, 64, 17, 16);
                Rectangle destinationRectangle = new Rectangle((int)(location.X - cameraPosition.X), (int)(location.Y - cameraPosition.Y), 17, 16);
                spriteBatch.Draw(TextureManager.itemTexture, destinationRectangle, sourceRectangle, Color.White);
            
        }
    }
}
