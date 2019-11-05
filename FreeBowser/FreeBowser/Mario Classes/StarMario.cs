using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    public class StarMario : IPlayer
    {
        Mario decoratedMario;
        public MarioState marioState;
        public MarioDirection marioDirection;
        public IMarioSprite marioSprite;
        Vector2 location;
        int timer = 1000;
        private bool inSpecialAnimationState = false;
        private bool hasFinishedSpecialAnimationState = true;
        private int specialStateFrameCounter = 0;
        private double verticalVelocity = 0;
        private double horizontalVelocity = 0;
        public int enemyMultiplier = 1;
        bool hasTouchedTheGround = true;

        int numLives;

        public void SetStarMario(bool isStar)
        {
        }
        public StarMario(Mario decoratedMario)
        {
            this.decoratedMario = decoratedMario;
        }
        public bool IsGrounded()
        {
            return true;
        }
        public int GetUpTimer()
        {
            return 1;
        }

        public int GetEnemyMultiplier()
        {
            return enemyMultiplier;
        }

        public void ResetEnemyMultiplier(int i)
        {
            enemyMultiplier = i;
        }

        public void IncrementEnemyMultiplier()
        {
            enemyMultiplier++;
        }

        public bool GetTouchedGround()
        {
            return hasTouchedTheGround;
        }

        public void SetTouchedGround(bool val)
        {
            hasTouchedTheGround = val;
        }

        public Vector2 GetLocation()
        {
            return location;
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

        public void TakeDamage()
        {
            // StarMario does not take damage
        }
        public bool IsJumping()
        {
            return false;
        }
        public MarioState GetMarioState()
        {
            return this.marioState;
        }

        public void SetVelo(float v)
        {

        }

        public float GetVelo()
        {
            return 0f;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {

        }
        public void LockMov()
        {

        }
        public void UnlockMov()
        {

        }
        public Rectangle GetRectangle()
        {
            //Rectangle currentRectangle = new Rectangle((int)location.X, (int)location.Y, (int)dimensions.X, (int)dimensions.Y);
            return decoratedMario.GetRectangle();
        }

        public void Update()
        {
            timer--;
            if (timer == 0)
            {
                RemoveStar(); 
            }

            decoratedMario.Update();
        }

        public void SetRun(){

        }

        public void UnsetRun()
        {

        }

  
        public void PipeUpAnimation()
        {
            int numSpecialFrames = 8;
            int sizeDisplacementPerFrame = -1;
            if (specialStateFrameCounter <= numSpecialFrames)
            {
                hasFinishedSpecialAnimationState = false;

                inSpecialAnimationState = true;
                specialStateFrameCounter++;
                ManualMoveY(sizeDisplacementPerFrame);

            }
            else
            {
                hasFinishedSpecialAnimationState = true;
                inSpecialAnimationState = false;
                specialStateFrameCounter = 0;
            }
        }
    

        public void PipeDownAnimation()
        {
            int numSpecialFrames = 8;
            int sizeDisplacementPerFrame = 2;
            if (specialStateFrameCounter <= numSpecialFrames)
            {
                inSpecialAnimationState = true;
                specialStateFrameCounter++;
                ManualMoveY(sizeDisplacementPerFrame);

            }
            else
            {
                inSpecialAnimationState = false;
                specialStateFrameCounter = 0;
            }
        }

        public void PipeRightAnimation()
        {
            int numSpecialFrames = 8;
            int sizeDisplacementPerFrame = -1;
            if (specialStateFrameCounter <= numSpecialFrames)
            {
                hasFinishedSpecialAnimationState = false;
                inSpecialAnimationState = true;
                specialStateFrameCounter++;
                ManualMoveX(sizeDisplacementPerFrame);

            }
            else
            {
                hasFinishedSpecialAnimationState = true;
                inSpecialAnimationState = false;
                specialStateFrameCounter = 0;
            }
        }

        public void PipeLeftAnimation()
        {
            int numSpecialFrames = 8;
            int sizeDisplacementPerFrame = 1;
            if (specialStateFrameCounter <= numSpecialFrames)
            {
                hasFinishedSpecialAnimationState = false;

                inSpecialAnimationState = true;
                specialStateFrameCounter++;
                ManualMoveX(sizeDisplacementPerFrame);

            }
            else
            {
                hasFinishedSpecialAnimationState = true;
                inSpecialAnimationState = false;
                specialStateFrameCounter = 0;
            }
        }

        public bool IsInSpecialAnimationState()
        {
            return inSpecialAnimationState;
        }

        public bool HasFinishedSpecialAnimationState()
        {
            return hasFinishedSpecialAnimationState;
        }
        void RemoveStar()
        {
            Game1.myMario = this.decoratedMario;
        }

        public int GetLives()
        {
            return numLives;
        }

        public void SetLives(int livesRemaining)
        {
            numLives = livesRemaining;
        }

        public void MoveX(float distance)
        {
            //decoratedMario.location.X = decoratedMario.location.X + distance;
        }

        public void moveY(float distance)
        {
            //decoratedMario.location.Y = decoratedMario.location.Y + distance;
        }

        public void MoveY()
        {
            location.Y = location.Y + (int)verticalVelocity; // negative is up
        }

        public void ManualMoveX(double newLocation)
        {
            location.X += (int)newLocation;

        }
        public void ManualMoveY(double newLocation)
        {
            location.Y += (int)newLocation;
        }

        public void ApplyJumpingForce()
        {
            double currentVelocity = GetVerticalVelocity();
            if (currentVelocity <= 0 && currentVelocity >= -15)
            {
                double newVelocity = currentVelocity - .4;  //vf = vi + at

                SetVerticalVelocity(newVelocity);
            }
        }

        public void Up()
        {
            decoratedMario.state.Up();
            ApplyJumpingForce();
        }

        public void Down()
        {
            decoratedMario.state.Down();
        }

        public void Left()
        {
            decoratedMario.state.Left();
        }

        public void Right()
        {
            decoratedMario.state.Right();
        }
        public void Damp()
        {

        }

        public void Idle()
        {
            decoratedMario.state.Idle();
        }

        public void SetVerticalVelocity(double newVelocity)
        {

            verticalVelocity = newVelocity;
        }

        public double GetVerticalVelocity()
        {
            return verticalVelocity;
        }

        public void SetHorizontalVelocity(double newVelocity)
        {
            horizontalVelocity = newVelocity;

        }

        public double GetHorizontalVelocity()
        {
            return horizontalVelocity;
        }


        public void GetKilled()
        {
            decoratedMario.state.BeKilled();
        }

        public void SwitchToBigMario(bool animate)
        {
            decoratedMario.state.SwitchToBigMario(animate);
        }

        public void SwitchToFireMario(bool animate)
        {
            decoratedMario.state.SwitchToFireMario(animate);
        }

        public void SwitchToSmallMario(bool animate)
        {
            decoratedMario.state.SwitchToSmallMario(animate);
        }

        public MarioState GetState()
        {
           return this.marioState;
        }

        public MarioDirection GetDirection()
        {
            return this.marioDirection;
        }

        public void ThrowFireball()
        {
            decoratedMario.state.ThrowFireball();
        }
    }
}
