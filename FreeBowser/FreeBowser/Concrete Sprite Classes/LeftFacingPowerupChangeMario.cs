using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    class LeftFacingPowerupChangeMario : IMarioSprite
    {
        private int starMarioDrawCounter = 0;
        public LeftFacingPowerupChangeMario()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(123, 184, 16, 22);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 22);

            if (starMarioDrawCounter >= 5 && StarUtility.isStarMario)
            {
                spriteBatch.Draw(TextureManager.marioSpriteTexture, destinationRectangle, sourceRectangle, Color.Green);
                starMarioDrawCounter = 0;
            }
            else
            {
                spriteBatch.Draw(TextureManager.marioPowerupChangeTexture, destinationRectangle, sourceRectangle, Color.White);
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
