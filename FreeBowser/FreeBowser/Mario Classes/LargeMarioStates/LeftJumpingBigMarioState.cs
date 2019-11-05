using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class LeftJumpingBigMarioState : IMarioState
    {
        private Mario mario;
        bool switchingToFire = false;

        public LeftJumpingBigMarioState(Mario mario)
        {
            this.mario = mario;
        }

        public void Down()
        {
            if (mario.IsGrounded())
            {
                mario.state = new LeftIdleBigMarioState(mario);
                mario.marioSprite = new LeftIdleLargeMario();
                mario.SetGrounded();
            }
        }

        public void Up()
        {
           
        }

        public void Right()
        {
            if (!mario.IsGrounded())
            {
                mario.state = new RightJumpingBigMarioState(mario);
                mario.marioSprite = new RightJumpingLargeMario();
            }
        }

        public void Left()
        {
            if (mario.IsGrounded())
            {
                mario.state = new LeftRunningBigMarioState(mario);
                mario.marioSprite = new LeftRunningLargeMario();
            }
            mario.MoveX(mario.velo);
        }

        public void Idle()
        {
            if (mario.IsJumping())
            {
                mario.SetFalling();
            }
            else if(mario.IsGrounded())
            {
                mario.state = new LeftIdleBigMarioState(mario);
                mario.marioSprite = new LeftIdleLargeMario();
            }
        }

        public void SwitchToBigMario(bool animate)
        {
            // no po here
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
                mario.state = new LeftJumpingFireMarioState(mario);
                mario.marioSprite = new LeftJumpingFireMario();
            }
         
        }
        public void SwitchToSmallMario(bool animate)
        {
            mario.state = new LeftJumpingSmallMarioState(mario);
            mario.marioSprite = new LeftJumpingSmallMario();
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
                    mario.state = new LeftJumpingFireMarioState(mario);
                    mario.marioSprite = new LeftJumpingFireMario();
                    mario.inSpecialAnimationState = false;

                }

            }
        }

        public void ThrowFireball()
        {
            
        }
    }
}
