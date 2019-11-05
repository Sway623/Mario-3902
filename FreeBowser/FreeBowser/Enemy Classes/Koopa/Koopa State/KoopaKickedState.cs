using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class KoopaKickedState : ISprite
    {
        Vector2 dimensions = new Vector2(25, 25);
        Rectangle destinationRectangle;
       // int timer = 0;
       // bool onScreen = true;

        public KoopaKickedState()
        {
        }

        public Rectangle getRectangle(Vector2 location, Vector2 dimensions)
        {
            Rectangle koopaRectangle = new Rectangle((int)location.X, (int)location.Y, (int)dimensions.X, (int)dimensions.Y);
            return koopaRectangle;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            
            destinationRectangle = getRectangle(location, dimensions);
            Rectangle sourceRectangle = new Rectangle(355, 0, 32, 23);

            spriteBatch.Draw(TextureManager.enemyTexture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void moveX(int distance)
        {
            
        }

        public void Update()
        {
            // TODO : update so that the kicked shell moves off screen
            //Console.Write("I have been kicked ow");
        }
    }
}
