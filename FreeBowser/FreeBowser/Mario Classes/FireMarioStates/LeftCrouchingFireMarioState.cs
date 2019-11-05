using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class LeftCrouchingFireMarioState : IMarioState
    {
        private Mario mario;

        public LeftCrouchingFireMarioState(Mario mario)
        {
            int oldHeight = (int)mario.dimensions.Y;
            int yShift = oldHeight - MarioUtility.marioCrouchingHeight;
            this.mario = mario;
            mario.dimensions.X = MarioUtility.marioNormalWidth;
            mario.dimensions.Y = MarioUtility.marioCrouchingHeight;
            mario.ManualMoveY(yShift);
        }

        public void Down()
        {
            mario.state = new LeftCrouchingFireMarioState(mario);
            mario.marioSprite = new LeftCrouchingFireMario();
        }

        public void Up()
        {
            mario.state = new LeftIdleFireMarioState(mario);
            mario.marioSprite = new LeftIdleFireMario();
        }

        public void Right()
        {
            mario.state = new RightCrouchingFireMarioState(mario);
            mario.marioSprite = new RightCrouchingFireMario();
        }

        public void Left()
        {
            mario.state = new LeftRunningFireMarioState(mario);
            mario.marioSprite = new LeftRunningFireMario();
        }

        public void Idle()
        {
            mario.state = new LeftIdleFireMarioState(mario);
            mario.marioSprite = new LeftIdleFireMario();
        }

        public void SwitchToBigMario(bool animate)
        {
            mario.state = new LeftCrouchingBigMarioState(mario);
            mario.marioSprite = new LeftCrouchingLargeMario();
        }
        public void SwitchToFireMario(bool animate)
        {
            // no op here
        }
        public void SwitchToSmallMario(bool animate)
        {
            //since there is no small crouching mario, change the sprite to leftIdleMario
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
            // no op here
        }

        public void ThrowFireball()
        {
            Fireball fireball = new Fireball(this.mario.location, -1);
            WorldManager.spriteSet.projectiles.Add(fireball);
        }
    }
}
