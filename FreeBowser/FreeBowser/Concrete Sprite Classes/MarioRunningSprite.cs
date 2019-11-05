using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class MarioRunningSprite : IMarioSprite
    {
        int currentFrame = 1;
        int currentSteps = 1;
        const int totalFrames = 100;
        bool movingRight = true;
        private int starMarioDrawCounter = 0;
        public MarioRunningSprite()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = 0;
            MarioUtility.marioSpriteSheetWidths.TryGetValue(currentFrame, out width);

            Rectangle sourceRectangle = new Rectangle(width, 52, 30, 36);
            Rectangle destinationRectangle = new Rectangle((int)location.X + currentSteps, (int)location.Y, 30, 36);
            if (starMarioDrawCounter >= 5 && StarUtility.isStarMario)
            {
                spriteBatch.Draw(TextureManager.marioSpriteTexture, destinationRectangle, sourceRectangle, Color.Green);
                starMarioDrawCounter = 0;
            }
            else
            {
                spriteBatch.Draw(TextureManager.marioSpriteTexture, destinationRectangle, sourceRectangle, Color.White);
            }
            starMarioDrawCounter++;
        }
        public void Update()
        {
        }

        public void Update(bool isRunning)
        {
            if (movingRight)
            {
                currentSteps++;
                currentFrame++;
                if (currentFrame == 5) currentFrame = 1;
                if (currentSteps == totalFrames)
                {
                    movingRight = false;
                    currentFrame = 5;
                }
            }
            else
            {
                currentSteps--;
                currentFrame++;
                if (currentFrame == 9) currentFrame = 5;
                if (currentSteps == -totalFrames)
                {
                    movingRight = true;
                    currentFrame = 1;
                }
            }

        }

    }
}
