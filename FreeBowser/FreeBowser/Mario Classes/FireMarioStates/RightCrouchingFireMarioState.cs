using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class RightCrouchingFireMarioState : IMarioState
    {
        private Mario mario;

        public RightCrouchingFireMarioState(Mario mario)
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

        }

        public void Up()
        {
            mario.state = new RightIdleFireMarioState(mario);
            mario.marioSprite = new RightIdleFireMario();
        }

        public void Right()
        {
 
            mario.state = new RightRunningFireMarioState(mario);
            mario.marioSprite = new RightRunningFireMario();
        }

        public void Left()
        {

            mario.state = new LeftCrouchingFireMarioState(mario);
            mario.marioSprite = new LeftCrouchingFireMario();
        }

        public void Idle()
        {

            mario.state = new RightIdleFireMarioState(mario);
            mario.marioSprite = new RightIdleFireMario();
        }

        public void SwitchToBigMario(bool animate)
        {
            mario.state = new RightCrouchingBigMarioState(mario);
            mario.marioSprite = new RightCrouchingLargeMario();
        }
        public void SwitchToFireMario(bool animate)
        {// no op 

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
            Fireball fireball = new Fireball(this.mario.location, 1);
            WorldManager.spriteSet.projectiles.Add(fireball);
        }

    }
}
