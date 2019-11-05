using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections;
using System.Text;

namespace FreeBowser
{
    public class EditLevelDisplay
    {
        static Vector2 location;
        static TimeSpan Time { get; set; }
        static TimeSpan ClickTime { get; set; }

        public List<IPlayer> players;
        public List<IBlock> blocks;
        public List<IPipe> pipes;
        public List<IEnemy> enemies;
        public List<IItem> items;
        public List<IBackgroundObject> objects;

        public List<IPlayer> displayPlayers;
        public List<IBlock> displayBlocks;
        public List<IPipe> displayPipes;
        public List<IEnemy> displayEnemies;
        public List<IItem> displayItems;
        public List<IBackgroundObject> displayObjects;

        public static List<ActionText> options;
        public static CameraController camera;

        public static Dictionary<Type, String> typeDict = new Dictionary<Type, String>();
        public static Dictionary<Type, int> blockDict = new Dictionary<Type, int>();
        public static Dictionary<Type, int> pipeDict = new Dictionary<Type, int>();
        public static Dictionary<Type, int> enemyDict = new Dictionary<Type, int>();
        public static Dictionary<Type, int> itemDict = new Dictionary<Type, int>();
        public static Dictionary<MarioState, int> playerDict = new Dictionary<MarioState, int>();
        public static int optionsIndex;

        static Vector2 zeroVector = new Vector2(0, 0);

        public static String filename = "";

        static ActionText saveAction;
        static ActionText loadAction;
        public static bool savingLevel = false;
        public static SoundManager sm;

        static Vector4 extremes;

        public static TextBox saveTextBox;
        public static TextBox loadTextBox;
        public static bool drawSaveTextBox = false;
        public static bool drawLoadTextBox = false;

        public static string path;

        static Rectangle mouseRect = new Rectangle(0, 0, 1, 1);
        static Rectangle previousMouseRect = new Rectangle(0, 0, 1, 1);

        static int minimum = 300;
        static int maximum = 0;

        const String fileExt = ".csv";

        Game1 game;

        public void Initialize(Game1 myGame, Vector2 coords, CameraController c, SoundManager soundManager)
        {
            //200 milliseconds
            Time = new TimeSpan(0, 0, 0, 0, 150);
            ClickTime = new TimeSpan(0, 0, 0, 0, 400);
            game = myGame;

            camera = c;
            location = coords;
            sm = soundManager;

            path = string.Concat(Environment.CurrentDirectory, @"\Levels\");

            extremes = new Vector4(Game1.graphics.PreferredBackBufferWidth, 0, Game1.graphics.PreferredBackBufferHeight, Game1.graphics.PreferredBackBufferHeight);

            blocks = new List<IBlock>();
            pipes = new List<IPipe>();
            enemies = new List<IEnemy>();
            items = new List<IItem>();
            players = new List<IPlayer>();

            displayBlocks = new List<IBlock>();
            displayPipes = new List<IPipe>();
            displayEnemies = new List<IEnemy>();
            displayItems = new List<IItem>();
            displayPlayers = new List<IPlayer>();

            EditUtility.InitTypeDicts(blockDict, pipeDict, enemyDict, itemDict, playerDict);
            InitBlocks();
            InitPipes();
            InitEnemies();
            InitItems();
            InitPlayers();

            optionsIndex = 0;

            options = new List<ActionText>();
            options.Add(new ActionText("Blocks", zeroVector, new Vector2(80, 16)));
            options.Add(new ActionText("Pipes", zeroVector, new Vector2(80, 16)));
            options.Add(new ActionText("Enemies", zeroVector, new Vector2(80, 16)));
            options.Add(new ActionText("Items", zeroVector, new Vector2(80, 16)));
            options.Add(new ActionText("Players", zeroVector, new Vector2(80, 16)));
            saveAction = new ActionText("Save Level", new Vector2(150, 0), new Vector2(100, 16));
            loadAction = new ActionText("Load Level", new Vector2(320, 0), new Vector2(100, 16));

            string[] files = System.IO.Directory.GetFiles(path);

            saveTextBox = new TextBox(new Vector2(125, 75), fileExt, "Type desired level name \n      then press ENTER", new Vector2(165, 85), new Vector2(125, 150));

            loadTextBox = new TextBox(new Vector2(125, 75), files, "Left Click a level to load", new Vector2(140, 85), new Vector2(125, 150));
            
            players.Add(new Mario(new Vector2(Game1.graphics.PreferredBackBufferWidth / 2, Game1.graphics.PreferredBackBufferHeight / 2), sm));

        }

        public void InitBlocks()
        {
            displayBlocks.Add(new BrickBlock(new Vector2(16, 16)));
            displayBlocks.Add(new UsedBlock(new Vector2(16, 48)));
            displayBlocks.Add(new UnbreakableBlock(new Vector2(16, 80)));
            displayBlocks.Add(new HiddenBlock(new Vector2(48, 16), new GreenMushroom(new Vector2(48, 16 - 16))));
            displayBlocks.Add(new QuestionBlock(new Vector2(48, 48), new PowerUpPlaceholder(new Vector2(48, 48 - 16)), false));
            displayBlocks.Add(new FloorBlock(new Vector2(48, 80)));
        }

        public void InitPipes()
        {
            //Declare now, modify filename, warp potential, and mario spawn later.
            //If we decide to place a pipe, we ask the user if it is a warp pipe
            displayPipes.Add(new SmallPipe(new Vector2(12, 64), false, "", zeroVector));
            displayPipes.Add(new MediumPipe(new Vector2(48, 48), false, "", zeroVector));
            displayPipes.Add(new LargePipe(new Vector2(84, 32), false, "", zeroVector));
        }

        public void InitEnemies()
        {
            displayEnemies.Add(new Goomba(new Vector2(16, 16)));
            displayEnemies.Add(new Koopa(new Vector2(48, 16)));
        }

        public void InitItems()
        {
            displayItems.Add(new RedMushroom(new Vector2(16, 16)));
            GreenMushroom gm = new GreenMushroom(new Vector2(16, 48));
            gm.ToggleHidden();
            gm.SetCurrentHeight(17);
            displayItems.Add(gm);

            Star st = new Star(new Vector2(48, 16));
            st.SetCurrentHeight(16);
            displayItems.Add(st);
            displayItems.Add(new FireFlower(new Vector2(48, 48)));
            displayItems.Add(new VisibleCoin(new Vector2(16, 80)));
        }

        public void InitPlayers()
        {
            Mario smallMario = new Mario(new Vector2(20, 16), null);
            displayPlayers.Add((new Mario(new Vector2(20, 16), null)));

            Mario bigMario = new Mario(new Vector2(20, 60), null);
            bigMario.SwitchToBigMario(false);
            displayPlayers.Add(bigMario);

            Mario fireMario = new Mario(new Vector2(20, 100), null);
            fireMario.SwitchToFireMario(false);
            displayPlayers.Add(fireMario);

        }

        public void DrawDisplay(SpriteBatch spriteBatch, String option)
        {
            switch (option)
            {
                case "Blocks":
                    foreach (IBlock displayBlock in displayBlocks)
                    {
                        displayBlock.Draw(spriteBatch, zeroVector);
                    }
                    break;
                case "Pipes":
                    foreach (IPipe displayPipe in displayPipes)
                    {
                        displayPipe.Draw(spriteBatch, zeroVector);
                    }
                    break;
                case "Enemies":
                    foreach (IEnemy displayEnemy in displayEnemies)
                    {
                        displayEnemy.Draw(spriteBatch, zeroVector);
                    }
                    break;
                case "Items":
                    foreach (IItem displayItem in displayItems)
                    {
                        displayItem.Draw(spriteBatch, zeroVector);
                    }
                    break;
                case "Players":
                    foreach (IPlayer displayPlayer in displayPlayers)
                    {
                        displayPlayer.Draw(spriteBatch, zeroVector);
                    }
                    break;
            }

            options[optionsIndex].Draw(spriteBatch);
        }

        public void DrawOptions(SpriteBatch spriteBatch)
        {
            saveAction.Draw(spriteBatch);
            loadAction.Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Game1.graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            if (savingLevel)
            {
                saveTextBox.Draw(spriteBatch);
            }
            else
            {
                DrawDisplay(spriteBatch, options[optionsIndex].GetOption());
                DrawOptions(spriteBatch);
            }

            foreach (IBlock block in blocks)
            {
                block.Draw(spriteBatch, camera.GetPosition());
            }

            foreach (IPipe pipe in pipes)
            {
                pipe.Draw(spriteBatch, camera.GetPosition());
            }

            foreach (IEnemy enemy in enemies)
            {
                enemy.Draw(spriteBatch, camera.GetPosition());
            }

            foreach (IItem item in items)
            {
                item.Draw(spriteBatch, camera.GetPosition());
            }

            foreach (IPlayer player in players)
            {
                player.Draw(spriteBatch, camera.GetPosition());
            }

            if (drawSaveTextBox)
            {
                saveTextBox.Draw(spriteBatch);
            }

            if (drawLoadTextBox)
            {
                loadTextBox.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            Time = Time.Subtract(gameTime.ElapsedGameTime);
            ClickTime = ClickTime.Subtract(gameTime.ElapsedGameTime);

            if (drawLoadTextBox)
            {
                string result = loadTextBox.CheckMultilineCollisions(mouseState);
                if (!result.Equals(""))
                {
                    game.SetFilename(result);
                    game.SwitchMode();
                }
            }

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                int x = mouseState.X;
                int y = mouseState.Y;

                mouseRect = new Rectangle(x, y, 1, 1);
                MouseCollisionChecker mouseCollisionChecker = new MouseCollisionChecker(blockDict, pipeDict, enemyDict, itemDict, playerDict);

                if ((int)Time.TotalMilliseconds <= 0)
                {
                    Time = new TimeSpan(0, 0, 0, 0, 150);
                    mouseCollisionChecker.CheckMouseDisplayCollisions(options[optionsIndex], mouseRect, previousMouseRect, displayBlocks, displayPipes, displayEnemies, displayItems, displayPlayers, blocks, pipes, enemies, items, players);
                }

                mouseCollisionChecker.CheckMouseDefaultCollisions(mouseRect, previousMouseRect, blocks, pipes, enemies, items, players);

                if (mouseRect.Intersects(saveAction.GetRectangle()))
                {
                    drawSaveTextBox = true;
                }

                if (mouseRect.Intersects(loadAction.GetRectangle()))
                {
                    drawLoadTextBox = true;
                }

                previousMouseRect = mouseRect;

            } else if ((int)ClickTime.TotalMilliseconds <= 0){
                ClickTime = new TimeSpan(0, 0, 0, 0, 200);
                previousMouseRect = mouseRect;
            }

            if (savingLevel)
            {
                SaveLevel(saveTextBox.GetText());
            }
        }

        public static void SetExtremes(int X, int Y)
        {
            int A = (int)extremes.X; //left
            int B = (int)extremes.Y; //right

            if (A > X)
            {
                A = X;
            }
            if (B < X)
            {
                B = X;
            }

            if (Y > maximum)
            {
                maximum = Y;
            }

            if (Y < minimum)
            {
                minimum = Y;
            }

            Console.WriteLine(extremes);
            extremes = new Vector4(A, B, minimum, maximum);
        }

        public void SaveLevel(String filename)
        {
            drawSaveTextBox = false;
            savingLevel = false;
            filename = filename + fileExt;


            string filePath = path + filename;

            CSVWriter writer = new CSVWriter(path, filename, extremes, blocks, items, enemies, pipes, players);
            writer.Write();
        }

    }
}
