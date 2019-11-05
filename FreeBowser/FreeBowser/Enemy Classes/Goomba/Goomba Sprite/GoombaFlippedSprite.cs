using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class GoombaFlippedSprite : ISprite
    {
        int timer = 0;
        int goombaSpriteX = 0;
        int goombaSpriteY = 0;
        int goombaStompedSize = 25;
        int goombaSpriteWidth = 27;
        int goombaSpriteHeight = 24;
        private bool onScreen = true;
        Rectangle destinationRectangle;
        Rectangle sourceRectangle;
        private Vector2 origin;
        int offset = 0;

        public GoombaFlippedSprite()
        {

        }

        public bool IsOnScreen()
        {
            return onScreen;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Vector2 pointsLoc = location;
            pointsLoc.Y -= offset;

            if (onScreen)
            {
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, goombaStompedSize, goombaStompedSize);
                
            }
            else
            {
                destinationRectangle = new Rectangle(EnemySpriteUtility.offScreen, EnemySpriteUtility.offScreen, EnemySpriteUtility.offScreenSize, EnemySpriteUtility.offScreenSize);
            }
            if(Game1.nightmare)
            {
                sourceRectangle = new Rectangle(goombaSpriteX, 64, goombaSpriteWidth, goombaSpriteHeight);
            }
            else
            {
                sourceRectangle = new Rectangle(goombaSpriteX, goombaSpriteY, goombaSpriteWidth, goombaSpriteHeight);
            }
            origin.X = goombaSpriteWidth / 2;
            origin.Y = goombaSpriteHeight / 2;
            
            Nullable<Rectangle> nullrect = sourceRectangle;
            float rotationangle = 0.0f;
            float circle = MathHelper.Pi * 2;
            rotationangle = rotationangle % circle;
            spriteBatch.Draw(TextureManager.enemyTexture, destinationRectangle, nullrect, Color.White, rotationangle, origin, SpriteEffects.FlipVertically, 0f); 
            spriteBatch.DrawString(TextureManager.marioSmallFont, "" + 100 * WorldManager.spriteSet.players[0].GetEnemyMultiplier(), pointsLoc, Color.White);
        }

        public void Update()
        {
            timer++;
            if (timer == 50 && onScreen == true)
            {
                onScreen = false;
            }
            offset += 7;
            if (timer == 15)
            {
                onScreen = false;
            }
        }
    }
}
