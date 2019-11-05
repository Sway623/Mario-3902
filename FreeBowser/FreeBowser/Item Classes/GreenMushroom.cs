using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    public class GreenMushroom : IItem
    {

        int spriteWidth = 17;
        int spriteHeight = 17;
        int currentHeight = 0;
        double verticalVelocity = 0;
        public bool isHidden = false;
        bool createdFromBlock = false;
        int frameCounter = 0;
        public bool movingRight = true;
        int delayTimer = 0;
        public Vector2 location;
        Vector2 pointsLoc;

        public GreenMushroom(Vector2 initLocation)
        {
            location = initLocation;
            pointsLoc = initLocation;
            pointsLoc.X += 15;
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

        public Rectangle GetRectangle()
        {
            Rectangle currentRectangle = new Rectangle((int)location.X, (int)location.Y, spriteWidth, currentHeight-1);
            return currentRectangle;
        }

        public void ToggleHidden()
        {
            isHidden = !isHidden;
        }

        public void SetCurrentHeight(int height)
        {
            currentHeight = height;
        }

        public void ChangeState()
        {
            location.X = -1000;
            location.Y = -1000;
            ToggleHidden();
        }

        public void Update()
        {
            frameCounter++;
            if (!isHidden && frameCounter % 2 == 0)
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
                        location.X += 1;
                    }
                    else
                    {
                        location.X -= 1;
                    }

                }
                else
                {
                    location.Y--;
                    delayTimer++;
                }
            }
            if(!isHidden)
            {
                pointsLoc.Y++;
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
            SetVerticalVelocity(0);

        }
        public void SetCreatedFromBlock(bool itemCreatedFromBlock)
        {
            createdFromBlock = true;
            currentHeight = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            Rectangle sourceRectangle = new Rectangle(16, 0, spriteWidth, currentHeight);
            Rectangle destinationRectangle = new Rectangle((int)(location.X - cameraPosition.X), (int)(location.Y + spriteHeight - currentHeight - cameraPosition.Y), 17, currentHeight);
            spriteBatch.Draw(TextureManager.itemTexture, destinationRectangle, sourceRectangle, Color.White);

            if(!isHidden)
            {
                spriteBatch.DrawString(TextureManager.marioSmallFont, "1UP", pointsLoc, Color.White);
            }
        }
    }
}
