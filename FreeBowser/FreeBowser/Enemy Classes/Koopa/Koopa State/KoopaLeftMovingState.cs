﻿using FreeBowser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class KoopaLeftMovingState : IEnemyState
    {
        private Koopa koopa;

        public KoopaLeftMovingState(Koopa myKoopa)
        {
            this.koopa = myKoopa;
        }

        public void ChangeDirection()
        {
            koopa.koopaState = new KoopaRightMovingState(koopa);
            koopa.koopaSprite = new KoopaRightMovingSprite();
        }

        public void BeStomped()
        {
            koopa.koopaState = new KoopaStompedState(koopa);
        }

        public void BeFlipped()
        {
            koopa.koopaState = new KoopaFlippedState(koopa);
        }

        public void BeKilled()
        {
            // no op, needs to be stomped first
        }

        public void Update()
        {
            koopa.moveX(-1);
        }
    }
}
