using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class NightmareState : IEnemyState
    {
        private Goomba goomba;

        public NightmareState(Goomba myGoomba)
	    {
		    this.goomba = myGoomba;
            this.goomba.goombaSprite = new NightmareSprite();
	    }

        public void ChangeDirection()
        {
            //goomba.goombaState = new GoombaLeftMovingState(goomba);
        }

        public void BeStomped()
        {
            goomba.goombaState = new GoombaStompedState(goomba);
        }

        public void BeFlipped()
        {
            goomba.goombaState = new GoombaStompedState(goomba);
        }

        public void BeKilled()
        {
            // NO OP
        }

        public void Update()
        {
            goomba.moveX(1);

            if(!Game1.nightmare)
            {
                // NO OP, still need to be killed to go away
            }
        }
    }
}
