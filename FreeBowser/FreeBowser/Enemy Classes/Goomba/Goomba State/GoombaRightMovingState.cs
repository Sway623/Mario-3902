using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class GoombaRightMovingState : IEnemyState
    {
        private Goomba goomba;

        public GoombaRightMovingState(Goomba myGoomba)
	    {
		    this.goomba = myGoomba;
            this.goomba.goombaSprite = new GoombaSprite();
	    }

        public void ChangeDirection()
        {
            goomba.goombaState = new GoombaLeftMovingState(goomba);
        }

        public void BeStomped()
        {
            goomba.goombaState = new GoombaStompedState(goomba);
        }

        public void BeFlipped()
        {
            goomba.goombaState = new GoombaFlippedState(goomba);
        }

        public void BeKilled()
        {
            // no op, needs to be stomped first
        }

        public void Update()
        {
            goomba.moveX(1);
        }
    }
}
