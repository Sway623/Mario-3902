using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class RightJumpingFireMarioState : IMarioState
    {
        private Mario mario;

        public RightJumpingFireMarioState(Mario mario)
        {
            this.mario = mario;
        }

        public void Down()
        {
            if (mario.IsGrounded())
            {
                mario.state = new RightIdleFireMarioState(mario);
                mario.marioSprite = new RightIdleFireMario();
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
                mario.state = new RightRunningFireMarioState(mario);
                mario.marioSprite = new RightRunningFireMario();
            }
            mario.MoveX(mario.velo);
        }

        public void Left()
        {
            if (!mario.IsGrounded())
            {
                mario.state = new LeftJumpingFireMarioState(mario);
                mario.marioSprite = new LeftJumpingFireMario();
            }
        }

        public void Idle()
        {
            if (mario.IsJumping())
            {
                mario.SetFalling();
            }
            else if(mario.IsFalling())
            {

            }
            else
            {
                mario.state = new RightIdleFireMarioState(mario);
                mario.marioSprite = new RightIdleFireMario();
            }
        }

        public void SwitchToBigMario(bool animate)
        {
            mario.state = new RightJumpingBigMarioState(mario);
            mario.marioSprite = new RightJumpingLargeMario();
        }
        public void SwitchToFireMario(bool animate)
        {
            // no op
        }
        public void SwitchToSmallMario(bool animate)
        {
            mario.state = new RightJumpingSmallMarioState(mario);
            mario.marioSprite = new RightJumpingSmallMario();
        }

        public void BeKilled()
        {
            mario.state = new DeadMarioState(mario);
            mario.marioSprite = new MarioDeadSprite();
        }


        public void Update()
        {

        }

        public void ThrowFireball()
        {
            Fireball fireball = new Fireball(this.mario.location, 1);
            WorldManager.spriteSet.projectiles.Add(fireball);
        }
    }
}
