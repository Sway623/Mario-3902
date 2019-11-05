using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class RightJumpingSmallMarioState : IMarioState
    {
        private Mario mario;
        bool switchingToBig = false;
        public RightJumpingSmallMarioState(Mario mario)
        {
            this.mario = mario;
            //construct sprite here
        }

        public void Down()
        {
            if (mario.IsGrounded())
            {
                mario.state = new RightIdleSmallMarioState(mario);
                mario.marioSprite = new RightIdleSmallMario();
                mario.SetGrounded();
            }
        }

        public void Up()
        {
            
        }

        public void Right()
        {
            if (mario.IsGrounded())
            {
                mario.SetGrounded();
                mario.state = new RightIdleSmallMarioState(mario);
                mario.marioSprite = new RightIdleSmallMario();
            }
            mario.MoveX(mario.velo);
        }

        public void Left()
        {
            if (!mario.IsGrounded())
            {
                mario.state = new LeftJumpingSmallMarioState(mario);
                mario.marioSprite = new LeftJumpingSmallMario();
            }
        
        }

        public void Idle()
        {
            if (mario.IsJumping())
            {
                mario.SetFalling();
            }
            else if(mario.IsGrounded())
            {
                mario.state = new RightIdleSmallMarioState(mario);
                mario.marioSprite = new RightIdleSmallMario();
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
                mario.state = new RightJumpingBigMarioState(mario);
                mario.marioSprite = new RightJumpingLargeMario();
            }
            
        }
        public void SwitchToFireMario(bool animate)
        {
            mario.state = new RightJumpingFireMarioState(mario);
            mario.marioSprite = new RightJumpingFireMario();
        }
        public void SwitchToSmallMario(bool animate)
        {
            // no op
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
                bool finished = mario.powerupManager.ChangeStateAnimation(mario, new RightJumpingSmallMario(), new RightJumpingLargeMario());
                if (finished)
                {
                    mario.state = new RightJumpingBigMarioState(mario);
                    mario.marioSprite = new RightJumpingLargeMario();
                    mario.inSpecialAnimationState = false;

                }

            }
        }

        public void ThrowFireball()
        {

        }
    }
}
