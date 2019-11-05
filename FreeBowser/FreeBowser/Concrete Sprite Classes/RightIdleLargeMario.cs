using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FreeBowser
{
    public class RightIdleLargeMario : IMarioSprite
    {
        private int starMarioDrawCounter = 0;
        public RightIdleLargeMario()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(209, 50, 16, 34);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 34);
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
            //nothing to do
        }
        public void Update(bool isRunning)
        {
        }
    }
}
