using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    public class Star : IItem
    {

        int spriteWidth = 16;
        int spriteHeight = 16;
        int currentHeight = 0;
        public bool isHidden = false;
        bool createdFromBlock = false;
        int frameTimer = 0;
        int currentFrame = 0;
        int frameToDisplay = 0;

        double verticalVelocity = 0;
        public bool movingRight = true;
        int delayTimer = 0;

        public Vector2 location;
        public Star(Vector2 initLocation)
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
            int offScreen = -100;
            location.X = offScreen;
            location.Y = offScreen;
            isHidden = true;
        }

        public void SetCurrentHeight(int height)
        {
            currentHeight = height;
        }

        public void Update()
        {
            int maxFrameTimer = 3;
            
            frameTimer++;
            if (frameTimer > maxFrameTimer)
            {
                frameTimer = 0;
                currentFrame++;
                if (currentFrame > maxFrameTimer)
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
                else if (delayTimer >= 3)
                {
                    currentHeight = spriteHeight;
                    location.Y += (int)verticalVelocity;

                    if (movingRight)
                    {
                        location.X += 2;
                    }
                    else
                    {
                        location.X -= 2;
                    }

                }
                else
                {
                    location.Y--;
                    delayTimer++;
                    // = spriteHeight;
                }
            }
        }

        public void SetCreatedFromBlock(bool itemCreatedFromBlock)
        {
            createdFromBlock = true;
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
            int starBouncingSpeed = -7;
            location.Y -= (int)verticalVelocity;   
            SetVerticalVelocity(starBouncingSpeed);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            Rectangle sourceRectangle = new Rectangle(spriteWidth * frameToDisplay, 32, spriteWidth, currentHeight);
            Rectangle destinationRectangle = new Rectangle((int)(location.X - cameraPosition.X), (int)(location.Y + spriteHeight - currentHeight - cameraPosition.Y), 16, currentHeight);
            spriteBatch.Draw(TextureManager.itemTexture, destinationRectangle, sourceRectangle, Color.White);
        }


    }
}
