using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public static class EnemySpriteUtility
    {

        public static Dictionary<int, int> koopaRightSpriteSheetWidths = new Dictionary<int, int>();
        public static Dictionary<int, int> koopaLeftSpriteSheetWidths = new Dictionary<int, int>();
        public static Dictionary<int, int> goombaSpriteSheetWidths = new Dictionary<int, int>();
        public static Dictionary<int, int> koopaNightmareRightSpriteSheetWidths = new Dictionary<int, int>();
        public static Dictionary<int, int> koopaNightmareLeftSpriteSheetWidths = new Dictionary<int, int>();


        public static int offScreen = -100000;
        public static int offScreenSize = 10;
        public static int koopaSourceWidth = 26;
        public static int koopaSourceHeight = 28;
        public static int koopaDestWidth = 22;
        public static int koopaDestHeight = 28;
        public static int goombaWidth = 19;
        public static int goombaHeight = 16;


        public static void SetSpriteSheetWidths()
        {
            
            koopaLeftSpriteSheetWidths.Add(1, 80);
            koopaLeftSpriteSheetWidths.Add(2, 115);
            koopaLeftSpriteSheetWidths.Add(3, 145);
            koopaLeftSpriteSheetWidths.Add(4, 175);

            koopaRightSpriteSheetWidths.Add(1, 205);
            koopaRightSpriteSheetWidths.Add(2, 235);
            koopaRightSpriteSheetWidths.Add(3, 265);
            koopaRightSpriteSheetWidths.Add(4, 295);

            koopaNightmareLeftSpriteSheetWidths.Add(1, 58);
            koopaNightmareLeftSpriteSheetWidths.Add(2, 115);
            koopaNightmareLeftSpriteSheetWidths.Add(3, 145);
            koopaNightmareLeftSpriteSheetWidths.Add(4, 175);

            koopaNightmareRightSpriteSheetWidths.Add(1, 205);
            koopaNightmareRightSpriteSheetWidths.Add(2, 235);
            koopaNightmareRightSpriteSheetWidths.Add(3, 265);
            koopaNightmareRightSpriteSheetWidths.Add(4, 295);

            goombaSpriteSheetWidths.Add(1, 0);
            goombaSpriteSheetWidths.Add(2, 27);

        }

    }
}
