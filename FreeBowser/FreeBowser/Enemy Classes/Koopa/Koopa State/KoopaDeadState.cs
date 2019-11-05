using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class KoopaDeadState : IEnemyState
    {
        private Koopa koopa;

        public KoopaDeadState(Koopa myKoopa)
	    {
            this.koopa = myKoopa;
            this.koopa.koopaSprite = new KoopaDeadSprite();
        }

        public void ChangeDirection()
        {
            // NO OP
        }

        public void BeStomped()
        {
            // NO OP
        }

        public void BeFlipped()
        {
            // NO OP
        }

        public void BeKilled()
        {
            // NO OP
        }

        public void Update()
        {
            //
        }
    }
}
