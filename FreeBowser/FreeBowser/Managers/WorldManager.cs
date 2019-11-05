using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public static class WorldManager
    {
        public static Dictionary<String, List<Vector2>> positionDict = new Dictionary<string, List<Vector2>>();
        public static Dictionary<String, List<Vector2>> onePositionDict = new Dictionary<string, List<Vector2>>();
        public static Dictionary<String, List<Vector2>> twoPositionDict = new Dictionary<string, List<Vector2>>();
        public static CameraController camera;
        public static Game1 game;

        public static bool switchLevel = false;

        public static Vector2 marioStartLocation;

        public static int setNum;

        public static MarioState lastState = MarioState.SMALL;

        public static string currentFilename = "";
        public static string[] filenames = { "", "" };

        public static int screenHeight = Game1.graphics.PreferredBackBufferHeight;
        public static int screenWidth = Game1.graphics.PreferredBackBufferWidth;

        public static LevelUtility.SpriteSet spriteSet = new LevelUtility.SpriteSet(0);


        public static void Initialize(Game1 myGame, String filename)
        {
            game = myGame;

            setNum = 0;

            if (filename.Equals(""))
            {
                filenames[0] = "Mario Level 1-1.csv";
            }
            else
            {
                filenames[0] = filename;
            }
            filenames[1] = "";
            
            currentFilename = filenames[0];

            LevelManager.ResetLevel();
            LevelManager.Initialize(myGame);

            marioStartLocation = new Vector2(50, screenHeight - 50);

            spriteSet.players = new List<IPlayer>();

            spriteSet = LevelManager.LoadLevel(currentFilename, new Vector2(0, 0), setNum, spriteSet);
            int life = 3;

            camera = GetCamera();
            spriteSet.players[0].SetLives(life);
            spriteSet.players[0].SwitchToSmallMario(false);
            Display.Initalize();
            RemainingLives.Initalize();
            RemainingLives.ResetTimer();
        }

        public static CameraController GetCamera(){
            return LevelManager.camera;
        }

        public static void Update(GameTime gameTime)
        {
            if (switchLevel)
            {
                setNum = 1 - setNum;
                spriteSet = LevelManager.SwitchLevel(spriteSet, setNum, currentFilename);
                spriteSet.players[0].SetLocation(new Vector2(marioStartLocation.X, marioStartLocation.Y - 16));
                switchLevel = false;
            }

            CollisionChecker gameCollisionChecker = new CollisionChecker();
            gameCollisionChecker.CheckEachCollision(spriteSet.players, spriteSet.blocks, spriteSet.pipes, spriteSet.goombas, spriteSet.koopas, spriteSet.coins, spriteSet.items, spriteSet.projectiles);

            //When we are within a 1/3 of the camera's width from an enemy, begin to animate
            camera = GetCamera();
            int rightThreshold = (int)camera.GetPosition().X;

            foreach (Mario mario in spriteSet.players)
            {
                if (mario.IsDead())
                {
                    ResetAllCommand reset = new ResetAllCommand();
                    int lives = mario.GetLives();
                    reset.Execute(game);
                    if (lives - 1 <= 0)
                    {
                        GameOver.ResetTimer();
                        GameOver.EndGame();
                    }
                    else
                    {
                        mario.SetLives(lives - 1);
                    }
                }

                mario.Update();
            }

            foreach (IPipe pipe in spriteSet.pipes)
            {
                pipe.Update();
            }

            foreach (Goomba goomba in spriteSet.goombas)
            {
                //If the goomba's x position is within 4/ of the width of the rectangle
                if (goomba.GetRectangle().X < ((20 + camera.GetPosition().X) + camera.GetWidth()))
                {
                    goomba.Update();
                }
            }

            foreach (Koopa koopa in spriteSet.koopas)
            {
                if (koopa.GetRectangle().X < ((20 + camera.GetPosition().X) + camera.GetWidth()))
                {
                    koopa.Update();
                }
            }

            foreach (IItem item in spriteSet.items)
            {
                item.Update();
            }

            foreach (IBlock block in spriteSet.blocks)
            {
                block.Update(gameTime);
            }

            foreach (Fireball fireball in spriteSet.projectiles)
            {
                fireball.Update();
            }

            camera.Update(gameTime);

            Display.Update(gameTime);

        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (currentFilename == "Underground.csv")
            {
                Game1.graphics.GraphicsDevice.Clear(Color.Black);
            }
            else
            {
                Game1.graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            }

            Vector2 cameraPosition = camera.GetPosition();

            if (GameOver.GameIsOver())
            {
                GameOver.Blackout();
                GameOver.Draw(spriteBatch);
            }
            else if (RemainingLives.ShowScreen())
            {
                RemainingLives.Blackout();
                RemainingLives.Draw(spriteBatch);
            }
            else
            {
                foreach (IBackgroundObject obj in spriteSet.objects)
                {
                    obj.Draw(spriteBatch, cameraPosition);
                }

                foreach (Goomba goomba in spriteSet.goombas)
                {
                    goomba.Draw(spriteBatch, cameraPosition);
                }

                foreach (Koopa koopa in spriteSet.koopas)
                {
                    koopa.Draw(spriteBatch, cameraPosition);
                }

                foreach (IItem item in spriteSet.items)
                {
                    item.Draw(spriteBatch, cameraPosition);
                }
                foreach (IBlock block in spriteSet.blocks)
                {
                    block.Draw(spriteBatch, cameraPosition);
                }

                foreach (IItem item in spriteSet.items)
                {
                    if (item is Star)
                    {
                        Star star = (Star)item;
                        if (star.isHidden == false)
                            star.Draw(spriteBatch, cameraPosition);
                    }
                }

                foreach (Fireball fireball in spriteSet.projectiles)
                {
                    fireball.Draw(spriteBatch, cameraPosition);
                }

                foreach (Mario mario in spriteSet.players)
                {
                    mario.Draw(spriteBatch, cameraPosition);
                }

                foreach (IPipe pipe in spriteSet.pipes)
                {
                    pipe.Draw(spriteBatch, cameraPosition);
                }

            }
            Display.Draw(spriteBatch, cameraPosition);
        }

    }
}
