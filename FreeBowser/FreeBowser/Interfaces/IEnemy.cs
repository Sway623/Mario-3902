using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public interface IEnemy
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void ChangeDirection();

        double GetVerticalVelocity();

        void ManualMoveY(double displacement);

        void ManualMoveX(double displacement);

        void SetVerticalVelocity(double newVelocity);
        Rectangle GetRectangle();
        void SetLocation(Vector2 coords);
        void AdjustLocation(Vector2 coords);
        IEnemyState GetState();

        void KillEnemy();
        void BeFlipped();
        //bool GetDirection();
    }
}