using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    public class FireFlower : IItem
    {

        int spriteWidth = 16;
        int spriteHeight = 16;
        int currentHeight = 16;
        public bool isHidden = false;
        bool createdFromBlock = false;
        int frameTimer = 0;
        int currentFrame = 0;
        int frameToDisplay = 0;

        Vector2 location;
        public FireFlower(Vector2 initLocation)
        {
            location = initLocation;
        }

        public Rectangle GetRectangle()
        {
            Rectangle currentRectangle = new Rectangle((int)location.X, (int)location.Y, spriteWidth, currentHeight);
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
            location.X = -100;
            location.Y = -100;
            isHidden = true;
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
            frameTimer++;
            if (frameTimer > 10)
            {
                frameTimer = 0;
                currentFrame++;
                if (currentFrame > 3)
                {
                    currentFrame = 0;
                }
                frameToDisplay = currentFrame;
            }

            if (frameTimer % 2 == 0)
            {

                if (createdFromBlock && currentHeight < spriteHeight)
                {
                    currentHeight++;
                }
                else
                {
                    currentHeight = spriteHeight;
                }
            }
        }

        public void SetCreatedFromBlock(bool itemCreatedFromBlock)
        {
            createdFromBlock = true;
            currentHeight = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            Rectangle sourceRectangle = new Rectangle(spriteWidth * frameToDisplay, 17, spriteWidth, currentHeight);
            Rectangle destinationRectangle = new Rectangle((int)(location.X - cameraPosition.X), (int)(location.Y + spriteHeight - currentHeight - cameraPosition.Y), 16, currentHeight);
            spriteBatch.Draw(TextureManager.itemTexture, destinationRectangle, sourceRectangle, Color.White);
        }


    }
}
