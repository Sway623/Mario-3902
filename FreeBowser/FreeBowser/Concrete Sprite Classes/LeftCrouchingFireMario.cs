using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    class LeftCrouchingFireMario : IMarioSprite
    {
        private int starMarioDrawCounter = 0;
        public LeftCrouchingFireMario()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            Rectangle sourceRectangle = new Rectangle(0, 128, 16, 22);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 22);
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
            //throw new NotImplementedException();
        }

        public void Update(bool isRunning)
        {
        }
    }
}
