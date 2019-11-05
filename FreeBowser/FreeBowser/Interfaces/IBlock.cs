using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public interface IBlock
    {
        Rectangle GetRectangle();
        void SetLocation(Vector2 coords);
        void AdjustLocation(Vector2 coords);
        void Update(GameTime gameTime);
        void ChangeState(Game1.Side side);

        Boolean IsHit();
        Boolean HasItem();
        void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition);
        IItem ReleaseItem(MarioState marioState);
        double GetVerticalVelocity();
        void SetVerticalVelocity(double myVelocity);
        double GetHorizontalVelocity();
        void SetHorizontalVelocity(double myVelocity);
        bool GetMovingUp();
        void SetMovingUp(bool movingUp);
        bool GetMovingLeft();
        void SetMovingLeft(bool left);
    }
}
