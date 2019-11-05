using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class LeftJumpingSmallMarioState : IMarioState
    {
        private Mario mario;
        bool switchingToBig = false;

        public LeftJumpingSmallMarioState(Mario mario)
        {
            this.mario = mario;
            //construct sprite here
        }

        public void Down()
        {
            if (mario.IsGrounded())
            {
                mario.state = new LeftIdleSmallMarioState(mario);
                mario.marioSprite = new LeftIdleSmallMario();
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
                mario.state = new RightJumpingSmallMarioState(mario);
                mario.marioSprite = new RightJumpingSmallMario();
            }
            else
            {
                mario.state = new RightIdleSmallMarioState(mario);
                mario.marioSprite = new RightIdleSmallMario();
            }
        }

        public void Left()
        {
            if (mario.IsGrounded())
            {
                mario.state = new LeftRunningSmallMarioState(mario);
                mario.marioSprite = new LeftRunningSmallMario();
            }

            mario.MoveX(mario.velo);
        }

        public void Idle()
        {
            if (mario.IsJumping())
            {
                mario.SetFalling();
            }
            else if (mario.IsGrounded())
            {
                mario.state = new LeftIdleSmallMarioState(mario);
                mario.marioSprite = new LeftIdleSmallMario();
            }
        }

        public void SwitchToBigMario(bool animate)
        {
            if (animate)
            {
                mario.inSpecialAnimationState = true;
                switchingToBig = true;
            }
            else
            {
                mario.state = new LeftJumpingBigMarioState(mario);
                mario.marioSprite = new LeftJumpingLargeMario();
            }
        }
        public void SwitchToFireMario(bool animate)
        {
            mario.state = new LeftJumpingFireMarioState(mario);
            mario.marioSprite = new LeftJumpingFireMario();
        }
        public void SwitchToSmallMario(bool animate)
        {
            // no op here
        }

        public void BeKilled()
        {
            mario.state = new DeadMarioState(mario);
            mario.marioSprite = new MarioDeadSprite();
        }


        public void Update()
        {
            if (switchingToBig)
            {
                bool finished = mario.powerupManager.ChangeStateAnimation(mario, new LeftJumpingSmallMario(), new LeftJumpingLargeMario());
                if (finished)
                {
                    mario.state = new LeftJumpingBigMarioState(mario);
                    mario.marioSprite = new LeftJumpingLargeMario();
                    mario.inSpecialAnimationState = false;

                }

            }
        }

        public void ThrowFireball()
        {

        }


    }
}
