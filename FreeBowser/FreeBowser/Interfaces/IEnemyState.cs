using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public interface IEnemyState
    {
        void ChangeDirection();
        void BeStomped();
        void BeFlipped();
        void BeKilled();
        void Update();
        // Draw() might also be included here
    }
}
