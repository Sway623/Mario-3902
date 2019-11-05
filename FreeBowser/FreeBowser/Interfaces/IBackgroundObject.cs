using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public interface IBackgroundObject
    {
        void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition);
        void SetLocation(Vector2 coords);
        void AdjustLocation(Vector2 coords);
    }
}
