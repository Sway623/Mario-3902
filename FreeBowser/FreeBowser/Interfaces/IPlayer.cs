using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    public enum MarioState
    {
        FIRE, 
        DEAD, 
        SMALL, 
        LARGE
    };

    public enum MarioDirection
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        NONE
    };



    public interface IPlayer
    {
        void SetStarMario(bool isStar);
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition);
        void MoveX(float distance);
        Rectangle GetRectangle();
        int GetUpTimer();
        void AdjustLocation(Vector2 coords);
        Vector2 GetLocation();
        bool IsJumping();
        double GetVerticalVelocity();
        void SetVerticalVelocity(double newVelocity);
        double GetHorizontalVelocity();
        void SetHorizontalVelocity(double newVelocity);
        void MoveY();
        bool IsGrounded();
        int GetLives();
        void SetLives(int livesRemaining);


        void ManualMoveX(double X);
        void ManualMoveY(double Y);
        void Up();
        void Down();
        void Left();
        void Right();
        void ThrowFireball();
        void Idle();
        void Damp();
        void GetKilled();
        void SwitchToBigMario(bool animate);
        void SwitchToFireMario(bool animate);
        void SwitchToSmallMario(bool animate);
        void SetRun();
        void UnsetRun();
        int GetEnemyMultiplier();
        void IncrementEnemyMultiplier();
        void ResetEnemyMultiplier(int i);
        bool IsInSpecialAnimationState();
        bool HasFinishedSpecialAnimationState();
        bool GetTouchedGround();
        void SetTouchedGround(bool val);

        void PipeDownAnimation();

        void PipeUpAnimation();
        void PipeRightAnimation();

        void PipeLeftAnimation();
        MarioState GetState();
        MarioDirection GetDirection();
        void TakeDamage();
        void SetVelo(float v);
        float GetVelo();
        void LockMov();
        void UnlockMov();

        void SetLocation(Vector2 vector2);
    }
}
