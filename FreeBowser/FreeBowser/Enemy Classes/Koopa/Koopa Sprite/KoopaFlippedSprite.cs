using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class KoopaFlippedSprite : ISprite
    {
        int timer = 0;
        int koopaSpriteX = 355;
        int koopaSpriteY = 0;
        int koopaShellSize = 25;
        int koopaSpriteWidth = 32;
        int koopaSpriteHeight = 23;
        private bool onScreen = true;
        Rectangle destinationRectangle;
        private Vector2 origin;


        public KoopaFlippedSprite()
        {
            
        }

        public bool IsOnScreen()
        {
            return onScreen;
        }

        public void Update()
        {
            timer++;
            if (timer == 50 && onScreen == true)
            {
                onScreen = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (onScreen)
            {
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y-5, koopaShellSize, koopaShellSize);

            }
            else
            {
                destinationRectangle = new Rectangle(EnemySpriteUtility.offScreen, EnemySpriteUtility.offScreen, EnemySpriteUtility.offScreenSize, EnemySpriteUtility.offScreenSize);
            }
            origin.X = koopaSpriteWidth / 2;
            origin.Y = koopaSpriteHeight / 2;
            Rectangle sourceRectangle = new Rectangle(koopaSpriteX, koopaSpriteY, koopaSpriteWidth, koopaSpriteHeight);
            Nullable<Rectangle> nullrect = sourceRectangle;
            float rotationangle = 0.0f;
            float circle = MathHelper.Pi * 2;
            rotationangle = rotationangle % circle;
            spriteBatch.Draw(TextureManager.enemyTexture, destinationRectangle, nullrect, Color.White, rotationangle, origin, SpriteEffects.FlipVertically, 0f);
        }
    }
}
