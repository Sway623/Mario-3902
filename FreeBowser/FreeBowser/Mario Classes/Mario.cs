using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    public class Mario : IPlayer
    {

        public Vector2 location;
        public Vector2 dimensions = new Vector2(17, 16);
        public IMarioState state;
        public IMarioSprite marioSprite;
        public bool isStarMario = false;
        bool isDead = false;
        public float velo;
        public MarioMovingManager marioMovMnger;
        public bool isRunning = false;
        public bool CanMov = true;
        public bool isDying = false;
        public Vector2 deathCoords;
        public bool inSpecialAnimationState = false;
        private bool hasFinishedSpecialAnimationState = true;
        private int specialStateFrameCounter = 0;
        private SoundManager sm;
        static int numLives;
        bool levelOver = false;
        bool doneRising = false;
        bool isJumping = false;
        bool isFalling = false;
        bool isGrounded = true;
        private int upTimer = 0;
        private double verticalVelocity = 0;
        private double horizontalVelocity = 0;
        
        public static MarioState marioState;
        public MarioDirection marioDirection;
        public MarioPowerupChangeManager powerupManager;
        public MarioLargeToFireAnimationManager largeToFireManager;
        private MarioTakingDamageAnimationManager takingDamageManager;
        bool isTakingDamage = false;
        int enemyMultiplier = 0;
        bool hasTouchedTheGround = true;

        public MarioEndOfLevelAnimationManager endLevelManager;

        public Mario(Vector2 initLocation, SoundManager sm)
        {
            location = initLocation;
            state = new RightIdleSmallMarioState(this);
            marioSprite = new RightIdleSmallMario();
            marioState = MarioState.SMALL;
            powerupManager = new MarioPowerupChangeManager();
            largeToFireManager = new MarioLargeToFireAnimationManager();
            endLevelManager = new MarioEndOfLevelAnimationManager();
            takingDamageManager = new MarioTakingDamageAnimationManager();
            velo = 0;
            this.sm = sm;
            numLives = 3;

            marioMovMnger = new MarioMovingManager(this);
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

        public void BeginEndingAnimation()
        {

            levelOver = true;
        }

        public int GetEnemyMultiplier()
        {
            return enemyMultiplier;
        }


        public void IncrementEnemyMultiplier()
        {
            enemyMultiplier++;
        }

        public void ResetEnemyMultiplier(int i)
        {
            enemyMultiplier = i;
        }

        public bool GetTouchedGround()
        {
            return hasTouchedTheGround;
        }

        public void SetTouchedGround(bool val)
        {
            hasTouchedTheGround = val;
        }

        public int GetUpTimer()
        {
            return this.upTimer;
        }
        public Rectangle GetRectangle()
        {
            Rectangle currentRectangle = new Rectangle((int)location.X, (int)location.Y, (int)dimensions.X, (int)dimensions.Y);
            return currentRectangle;
        }

        public void SetIMarioSprite(IMarioSprite newSprite)
        {
            marioSprite = newSprite;
        }

        public bool IsDying()
        {
            return isDying;
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void SetDead(bool d)
        {
            isDead = d;
        }

        public int GetLives()
        {
            return numLives;
        }

        public void SetLives(int livesRemaining)
        {
            numLives = livesRemaining;
        }

        public void ManualMoveX(double newLocation)
        {
            location.X += (int)newLocation;
        }

        public void ManualMoveY(double newLocation)
        {
            location.Y += (int)newLocation;
        }

        public void LockMov()
        {
            CanMov = false;
        }

        public void UnlockMov()
        {
            CanMov = true;
        }

        public void MoveX(float distance)
        {
            if (CanMov)
            {
                location.X = location.X + distance;
            }
        }

        public void MoveY()
        {
            location.Y = location.Y + (int)verticalVelocity; // negative is up
        }

        public void Up()
        {
            if (!IsInSpecialAnimationState())
            {
                state.Up();
                marioDirection = MarioDirection.UP;
                if (!isFalling)
                    ApplyJumpingForce();
            }
        }

        public void ApplyJumpingForce()
        {
            hasTouchedTheGround = false;
            if (marioState != MarioState.DEAD)
            {
                if (isGrounded)
                {
                    ManualMoveY(-6);
                    isJumping = true;
                    isFalling = false;
                    isGrounded = false;
                }

                if (isJumping && upTimer < 23)
                {
                    upTimer++;
                    double currentVelocity = GetVerticalVelocity();
                    if (isJumping && upTimer <= 15 && currentVelocity <= 0 && currentVelocity >= -4.5)
                    {
                        double newVelocity = currentVelocity - 1;  //vf = vi + at

                        SetVerticalVelocity(newVelocity);
                    }
                    else if (isJumping && upTimer <= 15 && currentVelocity <= -4.5)
                    {
                        double newVelocity = currentVelocity - .5; // counteract gravity force

                        SetVerticalVelocity(newVelocity);

                    }
                    else if (upTimer > 15 && currentVelocity <= 0 && currentVelocity <= -4.5)
                    {
                        isJumping = false;
                        isFalling = true;
                    }
                }
            }
        }

        public void Down()
        {
            if (!IsInSpecialAnimationState())
            {
                state.Down();
                marioDirection = MarioDirection.DOWN;
            }
        }

        public void Left()
        {
            if (!IsInSpecialAnimationState())
            {
                this.marioMovMnger.Left();
                marioDirection = MarioDirection.LEFT;
            }
        }

        public void Right()
        {
            if (!IsInSpecialAnimationState())
            {
                this.marioMovMnger.Right();
                marioDirection = MarioDirection.RIGHT;
            }

        }

        public MarioDirection GetDirection()
        {
            return marioDirection;
        }

        public void Idle()
        {
            if (!IsInSpecialAnimationState())
            {
                state.Idle();
                marioDirection = MarioDirection.NONE;
                if (isJumping)
                {
                    isJumping = false;
                    isFalling = true;
                }
            }
        }

        public bool IsJumping()
        {
            return isJumping;
        }

        public bool IsFalling()
        {
            return isFalling;
        }

        public bool IsGrounded()
        {
            return isGrounded;
        }

        public void SetFalling()
        {
            isFalling = true;
            isJumping = false;
            isGrounded = false;
            upTimer = 0;
        }
        public void SetGrounded()
        {
            //ManualMoveY(-5);
            SetVerticalVelocity(0);
            isFalling = false;
            isJumping = false;
            isGrounded = true;
            upTimer = 0;
        }

        public void Damp()
        {
            marioMovMnger.Damp();
        }
        public void SetRun()
        {
            this.isRunning = true;
        }

        public void UnsetRun()
        {
            this.isRunning = false;
        }
        public void GetKilled()
        {
            isDying = true;
            state.BeKilled();
            Game1.mainBGMInstance.Pause();
            SoundManager.PauseTime = 3;
            SoundManager.PlaySound(Game1.marioDieSound);
            SoundManager.SoundLock1 = true;
            marioState = MarioState.DEAD;

            SetVerticalVelocity(-5);
            deathCoords = location;
            enemyMultiplier = 1;
        }

        public void ThrowFireball()
        {
            state.ThrowFireball();
        }

        public void SwitchToBigMario(bool animate)
        {
            if (marioState.Equals(MarioState.SMALL))
            {
                if (animate)
                {
                    SoundManager.PlaySound(Game1.marioPowerUpSound);
                    //state.SwitchToBigMario();
                }
                state.SwitchToBigMario(animate);
            }
            marioState = MarioState.LARGE;
        }

        public void SwitchToFireMario(bool animate)
        {
            if (marioState.Equals(MarioState.LARGE))
            {
                SoundManager.PlaySound(Game1.marioPowerUpSound);

            }
            state.SwitchToFireMario(animate);


            marioState = MarioState.FIRE;

        }

        public void SwitchToSmallMario(bool animate)
        {
          //  ManualMoveY(-17); // put mario back on ground
            state.SwitchToSmallMario(animate);

            marioState = MarioState.SMALL;
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

        public void SetMarioState(MarioState newMarioState)
        {
            marioState = newMarioState;
        }

        public MarioState GetState()
        {
            return marioState;
        }
        public void SetVelo(float v)
        {
            this.velo = v;
        }
        public void SetStarMario(bool isStar)
        {
            isStarMario = isStar;
        }

        public bool IsStarMario()
        {
            return isStarMario;
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
            int sizeDisplacementPerFrame = 1;
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

        public void PipeRightAnimation()
        {
            int numSpecialFrames = 1;
            int sizeDisplacementPerFrame = 1;
            hasFinishedSpecialAnimationState = true;
/*
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
            }*/
        }

        public void PipeLeftAnimation()
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

        public bool IsInSpecialAnimationState()
        {
            return inSpecialAnimationState;
        }

        public bool HasFinishedSpecialAnimationState()
        {
            return hasFinishedSpecialAnimationState;
        }


        public float GetVelo()
        {
            return this.velo;
        }
        public void Update()
        {
            if (IsDying())
            {
                if (!doneRising && deathCoords.Y - 32 <= location.Y)
                {
                    SetVerticalVelocity(-2);
                }
                else
                {
                    SetVerticalVelocity(2);
                    doneRising = true;
                }
            }
            else if (isTakingDamage)
            {
                bool isFinished = takingDamageManager.ChangeStateAnimation(this);
                if (isFinished)
                {
                    isTakingDamage = false;
                    inSpecialAnimationState = false;
                }
            }

            if (levelOver && isGrounded)
            {
                inSpecialAnimationState = true;
                endLevelManager.ChangeStateAnimation(this);
            }
            else
            {
                if (location.Y > WorldManager.screenHeight + WorldManager.camera.GetPosition().Y)
                {
                    isDying = true;
                    SetDead(true);
                }

                if (IsInSpecialAnimationState())
                    state.Update();
                else
                {

                    MoveY();

                    marioSprite.Update(isRunning);
                }

                if (StarUtility.isStarMario == false)
                {
                    this.isStarMario = false;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            marioSprite.Draw(spriteBatch, location - cameraPosition);
        }

        public void TakeDamage()
        {
            if (!isStarMario)
            {
                if (marioState.Equals(MarioState.SMALL))
                {
                    GetKilled();
                }
                else if (marioState.Equals(MarioState.LARGE) || marioState.Equals(MarioState.FIRE))
                {
                    isTakingDamage = true;
                    inSpecialAnimationState = true;

                    /*
                    SwitchToSmallMario(true);
                    marioSprite = new RightIdleSmallMario();
                    state = new RightIdleSmallMarioState(this);
                    */
                }

            }

        }
    }
}
