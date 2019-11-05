using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class DeadMarioState : IMarioState
    {
        private Mario mario;

        public DeadMarioState(Mario mario)
        {
            Display.UpdateScore(0);
            this.mario = mario;
            //construc sprite here
        }
        public void Down()
        {
           // no op
        }


        public void Up()
        {
            // no op
        }

        public void Right()
        {
            // no op
        }

        public void Left()
        {
            // no op
        }

        public void Idle()
        {

        }

        public void SwitchToBigMario(bool animate)
        {
            mario.state = new RightIdleBigMarioState(mario);
            mario.marioSprite = new RightIdleLargeMario();
        }
        public void SwitchToFireMario(bool animate)
        {
            mario.state = new RightIdleFireMarioState(mario);
            mario.marioSprite = new RightIdleFireMario();
        }
        public void SwitchToSmallMario(bool animate)
        {
            mario.state = new RightIdleSmallMarioState(mario);
            mario.marioSprite = new RightIdleSmallMario();
        }

        public void BeKilled()
        {
        }


        public void Update()
        {

        }

        public void ThrowFireball()
        {
            
        }
    }
}
