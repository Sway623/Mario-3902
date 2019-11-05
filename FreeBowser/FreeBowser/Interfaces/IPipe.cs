using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public interface IPipe
    {
        void Update();
        bool IsWarp();
        void SetLocation(Vector2 coords);
        void AdjustLocation(Vector2 coords);
        String GetFileName();
        Vector2 GetSpawnCoords();
        Rectangle GetRectangle();
        void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition);
    }
}
