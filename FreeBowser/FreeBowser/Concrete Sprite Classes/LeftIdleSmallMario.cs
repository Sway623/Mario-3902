using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    class LeftIdleSmallMario : IMarioSprite
    {
        private int starMarioDrawCounter = 0;
        public LeftIdleSmallMario()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(181, 0, 17, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 17, 16);
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
        }
    }
}
