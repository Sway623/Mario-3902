using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    class MarioRunningInPlaceSprite : IMarioSprite
    {
        int currentFrame = 1;
        private int starMarioDrawCounter = 0;
        public MarioRunningInPlaceSprite()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = 0;
            MarioUtility.marioSpriteSheetWidths.TryGetValue(currentFrame, out width);

            Rectangle sourceRectangle = new Rectangle(width, 52, 30, 36);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 30, 36);
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
            currentFrame++;
            if (currentFrame == 5) currentFrame = 1;
        }
        public void Update(bool isRunning)
        {
        }
    }
}
