using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class KoopaStompedState : ISprite
    {
        Vector2 dimensions = new Vector2(23, 22);
        Rectangle destinationRectangle;

        public KoopaStompedState()
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
            Rectangle sourceRectangle = new Rectangle(325, 0, 26, 22);

            spriteBatch.Draw(EnemySpriteFactory.enemySpriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
           
        }
    }
}
