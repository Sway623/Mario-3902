using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class KoopaNightmareState : IEnemyState
    {
        private Koopa koopa;

        public KoopaNightmareState(Koopa myKoopa)
	    {
            this.koopa = myKoopa;
            this.koopa.koopaSprite = new KoopaNightmareSprite();
	    }

        public void ChangeDirection()
        {
            
        }

        public void BeStomped()
        {
            koopa.koopaState = new KoopaDeadState(koopa);
        }

        public void BeFlipped()
        {
            koopa.koopaState = new KoopaDeadState(koopa);
        }

        public void BeKilled()
        {
            // NO OP
        }

        public void Update()
        {
            koopa.moveX(1);

            if(!Game1.nightmare)
            {
                // NO OP, still need to be killed to go away
            }
        }
    }
}
