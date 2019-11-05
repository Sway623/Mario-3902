using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class LeftIdleBigMarioState : IMarioState
    {
        private Mario mario;
        bool switchingToFire = false;

        public LeftIdleBigMarioState(Mario mario)
        {
            int oldHeight = (int)mario.dimensions.Y;
            int yShift = oldHeight - MarioUtility.marioNormalHeight;
            this.mario = mario;
            mario.dimensions.X = MarioUtility.marioNormalWidth;
            mario.dimensions.Y = MarioUtility.marioNormalHeight;
            mario.ManualMoveY(yShift);
        }

        public void Down()
        {
            mario.state = new LeftCrouchingBigMarioState(mario);
            mario.marioSprite = new LeftCrouchingLargeMario();
        }

        public void Up()
        {
            mario.state = new LeftJumpingBigMarioState(mario);
            mario.marioSprite = new LeftJumpingLargeMario();
        }

        public void Right()
        {
            mario.state = new RightIdleBigMarioState(mario);
            mario.marioSprite = new RightIdleLargeMario();
            mario.MoveX(mario.velo);

        }

        public void Left()
        {
            mario.state = new LeftRunningBigMarioState(mario);
            mario.marioSprite = new LeftRunningLargeMario();
            mario.MoveX(mario.velo);

        }

        public void Idle()
        {

        }

        public void SwitchToBigMario(bool animate)
        {
        
        }
        public void SwitchToFireMario(bool animate)
        {
            if (animate)
            {
                mario.inSpecialAnimationState = true;
                switchingToFire = true;
            }
            else
            {
                mario.state = new LeftIdleFireMarioState(mario);
                mario.marioSprite = new LeftIdleFireMario();
            }
            
        }
        public void SwitchToSmallMario(bool animate)
        {
            mario.state = new LeftIdleSmallMarioState(mario);
            mario.marioSprite = new LeftIdleSmallMario();
        }

        public void BeKilled()
        {
            mario.state = new DeadMarioState(mario);
            mario.marioSprite = new MarioDeadSprite();
        }

        public void Update()
        {
            if (switchingToFire)
            {
                bool finished = mario.largeToFireManager.ChangeStateAnimation(mario, new LeftFacingPowerupChangeMario(), new LeftFacingPowerupChangeMario2());
                if (finished)
                {
                    mario.state = new LeftIdleFireMarioState(mario);
                    mario.marioSprite = new LeftIdleFireMario();
                    mario.inSpecialAnimationState = false;

                }

            }
        }

        public void ThrowFireball()
        {

        }
    }
}
