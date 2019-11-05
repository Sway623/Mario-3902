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
using System.IO;

namespace FreeBowser
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public enum Side { Left, Right, Top, Bottom, None };
        public static SoundEffect mainBGM;
        public static SoundEffect jumpSmallSound;
        public static SoundEffect collectCoinSound;
        public static SoundEffect bumpSound;
        public static SoundEffect marioDieSound;
        public static SoundEffect marioPowerUpSound;
        public static SoundEffect stompSound;
        public static SoundEffect jumpSuperSound;
        public static SoundEffect breakBlockSound;
        public static SoundEffectInstance mainBGMInstance;
        public SoundManager sm;
        public StarUtility su;
        public StreamWriter swWriteFile;
        string strWriteFilePath = @"../../../WriteLog.txt";
        public Boolean isInReplayMode = false;
        public GamerReplayer gR;

        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static ArrayList controllerList;
        public static ArrayList defaultControllerList;
        public static ArrayList levelControllerList;
        public static ArrayList jumpOnlyControllerList;

        public static Mario myMario;

        public static bool notPaused = true;
        public static bool nightmare = false;
        public static bool editingLevel = false;
        EnemySpawner EnSp;
        public static bool isSpawning = false;

        CameraController levelEditingCamera;

        public static bool jumpOnlyMode = false;

        public Texture2D marioSpriteSheet { get; set; }
        public static string filename;

        EditLevelDisplay eld;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = 300;

            controllerList = new ArrayList();
            defaultControllerList = new ArrayList();
            defaultControllerList.Add(new DefaultKeyboardController(this));
            defaultControllerList.Add(new GamepadController(this));

            levelControllerList = new ArrayList();
            levelEditingCamera = new CameraController(this, new Vector2(0, 0), graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            levelControllerList.Add(new EditingKeyboardController(this, levelEditingCamera));

            jumpOnlyControllerList = new ArrayList();
            jumpOnlyControllerList.Add(new JumpOnlyKeyboardController(this));
            //Add mouse controller

            filename = "";
            if (!this.isInReplayMode)
            {

                swWriteFile = File.CreateText(strWriteFilePath);
            }
            else
            {
                this.gR = new GamerReplayer(this);
            }

            sm = new SoundManager();
            su = new StarUtility();

            Content.RootDirectory = "Content";

            SoundManager.LoadSoundContent(this);

            mainBGMInstance = mainBGM.CreateInstance();
            mainBGMInstance.Play();

            MarioUtility.SetSpriteSheetWidths();
            EnemySpriteUtility.SetSpriteSheetWidths();

            EnSp = new EnemySpawner();

            eld = new EditLevelDisplay();
            eld.Initialize(this, new Vector2(0, 0), levelEditingCamera, sm);
        }

        protected override void Initialize()
        {
            WorldManager.Initialize(this, filename);
            if (jumpOnlyMode)
            {
                controllerList = jumpOnlyControllerList;
            }
            else
            {
                controllerList = defaultControllerList;
            }
            GameOver.Initalize();
            RemainingLives.Initalize();
            GameOver.ZeroTimer();
            base.Initialize();
            
        }

        public void SetFilename(string file)
        {
            filename = file;
        }

        public void SwitchMode()
        {
            //First switch mode
            editingLevel = !editingLevel;

            ResetStates();

            //Now switch controls
            if (editingLevel)
            {
                controllerList = levelControllerList;
            }
            else
            {
                controllerList = defaultControllerList;
            }


        }

        public void SwitchJumpOnlyMode()
        {
            ResetStates();
            jumpOnlyMode = !jumpOnlyMode;
            if (jumpOnlyMode)
            {
                controllerList = jumpOnlyControllerList;
            }
            else
            {
                controllerList = defaultControllerList;
            }


        }
       
        public void ResetStates()
        {
            Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureManager.LoadContent(this);
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            if (isInReplayMode)
            {
                if (gR == null)
                {
                    this.gR = new GamerReplayer(this);
                }
                gR.Update();
            }
            else{
                foreach (IController controller in controllerList)
            {
                controller.Update(gameTime);
            }
            }

            if (editingLevel)
            {
                eld.Update(gameTime);
                this.IsMouseVisible = true;
            }
            else
            {
                if (notPaused)
                {
                    WorldManager.Update(gameTime);
                }

                if (isSpawning)
                {
                    EnSp.Update();
                }

                GameOver.Update(gameTime);
                RemainingLives.Update(gameTime);
                base.Update(gameTime);

                if (SoundManager.SoundLock1 == true)
                {
                    //set initial TimeSpan
                    SoundManager.Time = gameTime.TotalGameTime;
                    SoundManager.SoundLock1 = false;
                }

                if (StarUtility.StarMarioLock == true)
                {
                    StarUtility.Time = gameTime.TotalGameTime;
                    StarUtility.StarMarioLock = false;
                }
                sm.Update(gameTime);
                su.Update(gameTime);
                this.IsMouseVisible = false;
            }            
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (editingLevel)
            {
                eld.Draw(spriteBatch);
            }
            else
            {
                WorldManager.Draw(gameTime, spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
