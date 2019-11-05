using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class GoombaStompedSprite : ISprite
    {
        int timer = 0;
        int goombaSpriteX = 56;
        int goombaSpriteY = 0;
        int goombaStompedSize = 25;
        int goombaSpriteWidth = 26;
        int goombaSpriteHeight = 22;
        private bool onScreen = true;
        Rectangle destinationRectangle;

        public GoombaStompedSprite()
        {           

        }

        public bool IsOnScreen()
        {
            return onScreen;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (onScreen)
            {
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, goombaStompedSize, goombaStompedSize);
                
            }
            else
            {
                destinationRectangle = new Rectangle(EnemySpriteUtility.offScreen, EnemySpriteUtility.offScreen, EnemySpriteUtility.offScreenSize, EnemySpriteUtility.offScreenSize);
            }
            Rectangle sourceRectangle = new Rectangle(goombaSpriteX, goombaSpriteY, goombaSpriteWidth, goombaSpriteHeight);

            spriteBatch.Draw(TextureManager.enemyTexture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            timer++;
            if (timer == 30 && onScreen == true)
            {
                onScreen = false;
            }
        }
    }
}
