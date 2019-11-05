using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public interface ICoin : IItem
    {
        void SetValue(int value);
        int GetValue();
    }
}
