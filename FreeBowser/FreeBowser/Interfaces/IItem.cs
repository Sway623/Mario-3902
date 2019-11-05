using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public interface IItem
    {
        Rectangle GetRectangle();
        void ChangeState();
        void Update();
        void SetLocation(Vector2 coords);
        void AdjustLocation(Vector2 coords);
        void SetCreatedFromBlock(bool itemCreatedFromBlock);
        void SetVerticalVelocity(double newVelocity);
        double GetVerticalVelocity();
        void SetGrounded();
        void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition);
    }
}
