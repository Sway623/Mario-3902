using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    public class RedMushroom : IItem
    {

        int spriteWidth = 17;
        int spriteHeight = 17; //17
        int currentHeight = 17;
        double verticalVelocity = 0;
        public bool isHidden = false;
        bool createdFromBlock = false;
        int frameCounter = 0;
        public bool movingRight = true;
        int delayTimer = 0;
        public Vector2 location;
        public RedMushroom(Vector2 initLocation)
        {
            location = initLocation;
        }

        public Rectangle GetRectangle()
        {
            Rectangle currentRectangle = new Rectangle((int)location.X, (int)location.Y, spriteWidth, currentHeight-1);
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
            int offScreen = -1000;
            location.X = offScreen;
            location.Y = offScreen;
            isHidden = true;
        }

        public void Update()
        {
            frameCounter++;
            if (frameCounter % 2 == 0 && !isHidden)
            {

                if (createdFromBlock && currentHeight < spriteHeight )
                {
                    currentHeight++;
                }
                else if  (delayTimer >= 3)
                {
                    currentHeight = spriteHeight;
                    location.Y += (int)verticalVelocity;
                    if (!isHidden)
                    {
                        if (movingRight)
                        {
                            location.X += 2;
                        }
                        else
                        {
                            location.X -= 2;
                        }
                    }
                    

                }
                else
                {
                    location.Y--;
                    delayTimer++;
                }
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
            Rectangle sourceRectangle = new Rectangle(0, 0, spriteWidth, currentHeight);
            Rectangle destinationRectangle = new Rectangle((int)(location.X - cameraPosition.X), (int)(location.Y + spriteHeight - currentHeight - cameraPosition.Y), 17, currentHeight);
            spriteBatch.Draw(TextureManager.itemTexture, destinationRectangle, sourceRectangle, Color.White);
        }


    }
}
