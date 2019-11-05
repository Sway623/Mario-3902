using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public static class LevelManager
    {

        static LevelUtility.SpriteSet firstSet = new LevelUtility.SpriteSet(0);
        static LevelUtility.SpriteSet secondSet = new LevelUtility.SpriteSet(1);

        public static Dictionary<String, List<Vector2>> positionDict = new Dictionary<string, List<Vector2>>();
        public static Dictionary<String, List<Vector2>> onePositionDict = new Dictionary<string, List<Vector2>>();
        public static Dictionary<String, List<Vector2>> twoPositionDict = new Dictionary<string, List<Vector2>>();
        public static CameraController camera;
        public static Game1 game;

        static int lives = 3;
        public static bool switchLevel = false;

        public static Vector2 marioStartLocation;

        public static int spriteSet;

        public static MarioState lastState = MarioState.SMALL;

        public static string[] filenames = { "", "" };

        public static int screenHeight = Game1.graphics.PreferredBackBufferHeight;
        public static int screenWidth = Game1.graphics.PreferredBackBufferWidth;

        public static void Initialize(Game1 myGame)
        {
            filenames[1] = "";
            filenames[0] = "Mario Level 1-1.csv";
        }

        public static void ResetLevel()
        {
            onePositionDict = new Dictionary<string, List<Vector2>>();
            twoPositionDict = new Dictionary<string, List<Vector2>>();
            LevelUtility.InitializePositionKey(onePositionDict);
            LevelUtility.InitializePositionKey(twoPositionDict);
            firstSet = new LevelUtility.SpriteSet(0);
            secondSet = new LevelUtility.SpriteSet(1);
        }

        public static LevelUtility.SpriteSet SwitchSpriteSet(int setNum)
        {
            if (setNum == 0)
            {
                return firstSet;
            }
            else
            {
                return secondSet;
            }
        }

        public static LevelUtility.SpriteSet LoadLevel(String filename, Vector2 cameraStart, int setNum, LevelUtility.SpriteSet spriteSet)
        {
            if (setNum == 0)
            {
                positionDict = onePositionDict;
            }
            else
            {
                positionDict = twoPositionDict;
            }

            CSVReader csvReader = new CSVReader();
            List<string> csvLines = csvReader.getLines(filename);

            CSVParser levelParser = new CSVParser();
            camera = new CameraController(game, cameraStart, screenHeight, screenWidth);

            spriteSet = SwitchSpriteSet(setNum);

            levelParser.parse(positionDict, csvLines, screenHeight, screenWidth);

            int levelHeight = csvLines.Count();
            int levelWidth = csvLines[0].Count();

            int worldHeight = screenHeight;
            int worldWidth = levelWidth;

            if (spriteSet.players.Count > 0)
            {
                lastState = spriteSet.players[0].GetState();
                lives = spriteSet.players[0].GetLives();
            }

            spriteSet.players = new List<IPlayer>();

            SpriteGenerator spriteGenerator = new SpriteGenerator();
            foreach (KeyValuePair<string, List<Vector2>> pair in positionDict)
            {
                spriteGenerator.generateSprites(pair.Key, pair.Value, spriteSet.players, spriteSet.blocks, spriteSet.pipes, spriteSet.goombas, spriteSet.koopas, spriteSet.coins, spriteSet.items, spriteSet.objects);
            }

            ResumeLastState(lastState, spriteSet);

            return spriteSet;
        }

        public static int AdjustMarioStart(MarioState state)
        {
            int adjust = 0;
            if (state == MarioState.LARGE || state == MarioState.FIRE)
            {
                adjust = 32;
            }
            return adjust;
        }

        public static void ResumeLastState(MarioState lastState, LevelUtility.SpriteSet spriteSet)
        {
            if (lastState == MarioState.SMALL)
            {
                spriteSet.players[0].SwitchToSmallMario(false);
                spriteSet.players[0].ManualMoveY(-16);
            }
            else if (lastState == MarioState.LARGE)
            {
                spriteSet.players[0].SwitchToBigMario(false);
                //players[0].ManualMoveY(32);
            }
            else if (lastState == MarioState.FIRE)
            {
                spriteSet.players[0].SwitchToFireMario(false);
            }
        }

        public static LevelUtility.SpriteSet SwitchLevel(LevelUtility.SpriteSet spriteSet, int setNum, String currentFilename)
        {
            MarioState temp = spriteSet.players[0].GetState();

            if (setNum == 0)
            {
                firstSet = new LevelUtility.SpriteSet(0);
                onePositionDict = new Dictionary<string, List<Vector2>>();
                LevelUtility.InitializePositionKey(onePositionDict);
            }
            else
            {
                secondSet = new LevelUtility.SpriteSet(1);
                twoPositionDict = new Dictionary<string, List<Vector2>>();
                LevelUtility.InitializePositionKey(twoPositionDict);
            }

            if (filenames[setNum] == currentFilename)
            {
                marioStartLocation.Y -= AdjustMarioStart(temp);
                camera = new CameraController(game, new Vector2(marioStartLocation.X - 20, 0), screenHeight, screenWidth);
            }

            spriteSet = LoadLevel(currentFilename, new Vector2(marioStartLocation.X - 20, 0), setNum, spriteSet);
            ResumeLastState(temp, spriteSet);

            filenames[setNum] = currentFilename;
            return spriteSet;
        }
    }
}
