using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class LargeCloud : IBackgroundObject
    {
        Vector2 location;

        public LargeCloud(Vector2 position)
        {
            location = position;
        }

        public void SetLocation(Vector2 coords)
        {
            location.X = coords.X;
            location.Y = coords.Y;
        }

        public void AdjustLocation(Vector2 coords)
        {
            location.X += coords.X;
            location.Y += coords.Y;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            Rectangle sourceRectangle = new Rectangle(96, 198, 63, 23);
            Rectangle destinationRectangle = new Rectangle((int)(location.X - cameraPosition.X), (int)(location.Y - cameraPosition.Y), 63, 23);
            spriteBatch.Draw(TextureManager.miscTexture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
