using FreeBowser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    class KoopaStompedState : IEnemyState
    {
        private Koopa koopa;

        public KoopaStompedState(Koopa koopa)
	    {
            this.koopa = koopa;
            this.koopa.koopaSprite = new KoopaStompedSprite();
	    }
	
	    public void ChangeDirection()
	    {
            // no op
            // just needs to remain stationary as a shell
	    }
	
	    public void BeStomped()
	    {
		    // NO-OP
		    // already stomped, do nothing
	    }
	
    	public void BeFlipped()
	    {
		    // NO-OP
		    // if stomped, do not respond to being attacked by star mario (assumed but not tested behavior)
	    }

        public void BeKilled()
        {
            koopa.koopaState = new KoopaDeadState(koopa);
        }
	
    	public void Update()
	    {
            // no op
	    }

    }
}
