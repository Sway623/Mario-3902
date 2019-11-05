using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class LeftRunningFireMarioState : IMarioState
    {
        private Mario mario;

        public LeftRunningFireMarioState(Mario mario)
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
            mario.state = new LeftCrouchingFireMarioState(mario);
            mario.marioSprite = new LeftCrouchingFireMario();
        }

        public void Up()
        {
            if (mario.IsGrounded())
            {
                mario.state = new LeftJumpingFireMarioState(mario);
                mario.marioSprite = new LeftJumpingFireMario();
            }
        }

        public void Right()
        {
            mario.state = new LeftIdleFireMarioState(mario);
            mario.marioSprite = new LeftIdleFireMario();

        }

        public void Left()
        {
            mario.MoveX(mario.velo);
        }

        public void Idle()
        {
            mario.state = new LeftIdleFireMarioState(mario);
            mario.marioSprite = new LeftIdleFireMario();
            mario.MoveY();
        }

        public void SwitchToBigMario(bool animate)
        {
            mario.state = new LeftRunningBigMarioState(mario);
            mario.marioSprite = new LeftRunningLargeMario();
        }
        public void SwitchToFireMario(bool animate)
        {
            // no op
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
            // no op here
        }

        public void ThrowFireball()
        {
            Fireball fireball = new Fireball(this.mario.location, -1);
            WorldManager.spriteSet.projectiles.Add(fireball);
        }

    }
}
