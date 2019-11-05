using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public static class MarioUtility
    {        
        public static Dictionary<int, int> marioSpriteSheetWidths = new Dictionary<int, int>();

        public static int marioNormalWidth = 16;
        public static int marioNormalHeight = 34;
        public static int marioCrouchingHeight = 22;
        public static int marioSmallHeight = 16;
        public static int marioSmallWidth = 17;

        public static void SetSpriteSheetWidths()
        {
            marioSpriteSheetWidths.Add(1, 235);
            marioSpriteSheetWidths.Add(2, 265);
            marioSpriteSheetWidths.Add(3, 295);
            marioSpriteSheetWidths.Add(4, 265);
            marioSpriteSheetWidths.Add(5, 115);
            marioSpriteSheetWidths.Add(6, 145);
            marioSpriteSheetWidths.Add(7, 115);
            marioSpriteSheetWidths.Add(8, 85);
        }

    }
}
