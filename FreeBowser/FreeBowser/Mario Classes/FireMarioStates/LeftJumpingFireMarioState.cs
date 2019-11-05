using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class LeftJumpingFireMarioState : IMarioState
    {
        private Mario mario;

        public LeftJumpingFireMarioState(Mario mario)
        {
            this.mario = mario;
        }

        public void Down()
        {
            if (mario.IsGrounded())
            {
                mario.state = new LeftIdleFireMarioState(mario);
                mario.marioSprite = new LeftIdleFireMario();
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
                mario.state = new RightJumpingFireMarioState(mario);
                mario.marioSprite = new RightJumpingFireMario();
            }
        }

        public void Left()
        {
            if (mario.IsGrounded())
            {
                mario.state = new LeftRunningFireMarioState(mario);
                mario.marioSprite = new LeftRunningFireMario();
            }
            mario.MoveX(mario.velo);
        }

        public void Idle()
        {
            if (mario.IsJumping())
            {
                mario.SetFalling();
            }
            else if (mario.IsFalling())
            {

            }
            else
            {
                mario.state = new LeftIdleFireMarioState(mario);
                mario.marioSprite = new LeftIdleFireMario();
            }
        }

        public void SwitchToBigMario(bool animate)
        {
            mario.state = new LeftJumpingBigMarioState(mario);
            mario.marioSprite = new LeftJumpingLargeMario();
        }

        public void SwitchToFireMario(bool animate)
        {
            // no op here
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
            // no op here
        }

        public void ThrowFireball()
        {
            Fireball fireball = new Fireball(this.mario.location, -1);
            WorldManager.spriteSet.projectiles.Add(fireball);
        }
    }
}
