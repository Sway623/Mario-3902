using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    public class MultiCoin : ICoin
    {

        int currentFrame = 0;
        int frameToDisplay = 0;
        int spriteWidth = 16;
        int spriteHeight = 16;
        bool isHidden = false;
        int frameTimer = 0;
        bool createdFromBlock = false;
        int offset = 0;
        bool doneUp = false;
        bool spawnFinished = false;
        Vector2 pointsLoc;

        //Default the value of the coin created to 1
        private int coinVal = 1;

        Vector2 location;
        public MultiCoin(Vector2 initLocation)
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

        public void SetValue(int value)
        {
            coinVal = value;
        }

        public int GetValue()
        {
            return coinVal;
        }

        public void SetCreatedFromBlock(bool itemCreatedFromBlock)
        {
            createdFromBlock = true;
        }

        public Rectangle GetRectangle()
        {
            Rectangle currentRectangle = new Rectangle((int)location.X, (int)location.Y, spriteWidth, spriteHeight);
            return currentRectangle;
        }

        public void ChangeState()
        {
            location.X = -1000;
            location.Y = -1000;
            isHidden = true;

            Display.UpdateNumCoins();
        }

        public void Update()
        {
            frameTimer++;
            if (!isHidden)
            {
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
                pointsLoc.Y--;
            }
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

        public int adjustOffset()
        {

            if (doneUp && offset <= 0)
            {
                offset++;
            }
            else if (!doneUp)
            {
                offset--;
                if (offset <= -48)
                {
                    doneUp = true;
                }
            }
            else
            {
                isHidden = true;
            }

            return offset;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            if (!spawnFinished && createdFromBlock)
            {
                adjustOffset();
            }
            if (!isHidden)
            {
                Rectangle sourceRectangle = new Rectangle(spriteWidth * frameToDisplay, 80, 17, 16);
                Rectangle destinationRectangle = new Rectangle((int)(location.X - cameraPosition.X), (int)(location.Y - cameraPosition.Y + offset), 17, 16);
                spriteBatch.Draw(TextureManager.itemTexture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.DrawString(TextureManager.marioSmallFont, "200", pointsLoc, Color.White);
            }
        }
    }
}
