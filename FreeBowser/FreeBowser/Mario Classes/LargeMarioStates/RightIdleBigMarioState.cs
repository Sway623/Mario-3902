using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class RightIdleBigMarioState : IMarioState 
    {
        private Mario mario;
        bool switchingToFire = false;

        public RightIdleBigMarioState(Mario mario)
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
           mario.state = new RightCrouchingBigMarioState(mario);
           mario.marioSprite = new RightCrouchingLargeMario();
        }

        public void Up()
        {
            mario.state = new RightJumpingBigMarioState(mario);
            mario.marioSprite = new RightJumpingLargeMario();
        }

        public void Right()
        {
            mario.state = new RightRunningBigMarioState(mario);
            mario.marioSprite = new RightRunningLargeMario();
            mario.MoveX(mario.velo);
        }

        public void Left()
        {
            mario.state = new LeftIdleBigMarioState(mario);
            mario.marioSprite = new LeftIdleLargeMario();
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
                mario.state = new RightIdleFireMarioState(mario);
                mario.marioSprite = new RightIdleFireMario();
            }
           
        }
        public void SwitchToSmallMario(bool animate)
        {
            mario.state = new RightIdleSmallMarioState(mario);
            mario.marioSprite = new RightIdleSmallMario();
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
                bool finished = mario.largeToFireManager.ChangeStateAnimation(mario, new RightFacingPowerupChangeMario(), new RightFacingPowerupChangeMario2());
                if (finished)
                {
                    mario.state = new RightIdleFireMarioState(mario);
                    mario.marioSprite = new RightIdleFireMario();
                    mario.inSpecialAnimationState = false;

                }

            }
        }

        public void ThrowFireball()
        {

        }

    }
}
