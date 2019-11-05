using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public interface IMarioState
    {
        void Up();
        void Down();
        void Right();
        void Left();
        void Idle();
        void ThrowFireball();
        void SwitchToBigMario(bool animate);
        void SwitchToFireMario(bool animate);
        void SwitchToSmallMario(bool animate);
        void BeKilled();
        void Update();
    }
}
