using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class DefaultKeyboardController : IController
    {
        private static Dictionary<Keys, ICommand> controllerMappings;
        MarioIdleCommand idleCommand;

        NonPressedKeyMarioCommand NonPressedCommand;
        private Game1 game;

        KeyboardState previousState;

        public DefaultKeyboardController(Game1 myGame)
        {
            game = myGame;

            int playerNumber = 0;
            idleCommand = new MarioIdleCommand(playerNumber);
            NonPressedCommand = new NonPressedKeyMarioCommand(playerNumber);

            controllerMappings = new Dictionary<Keys, ICommand>
                {
                 {Keys.Q, new ExitGameCommand()},
                 {Keys.W, new MarioUpCommand(playerNumber)},
                 {Keys.A, new MarioLeftCommand(playerNumber)},
                 {Keys.Left, new MarioLeftCommand(playerNumber)},
                 {Keys.Right, new MarioRightCommand(playerNumber) },
                 {Keys.Up, new MarioUpCommand(playerNumber) },
                 {Keys.Down, new MarioDownCommand(playerNumber) },
                 {Keys.S, new MarioDownCommand(playerNumber)},
                 {Keys.D, new MarioRightCommand(playerNumber)},
                 {Keys.R, new ResetAllCommand()},
                 {Keys.I, new SwitchToFireMarioCommand(playerNumber)},
                 {Keys.Y, new SwitchToSmallMarioCommand(playerNumber)},
                 {Keys.O, new KillMarioCommand(playerNumber)},
                 {Keys.U, new SwitchToBigMarioCommand(playerNumber)},
                 {Keys.X, new MarioRunningCommand(playerNumber)},
                 {Keys.N, new NightmareModeCommand(playerNumber)},
                 {Keys.J, new JumpOnlyModeCommand(playerNumber)},
                 {Keys.L, new LevelEditorCommand()},
                 {Keys.H, new ReplayCommander()}
                };

        }


        public void Update(GameTime gameTime)
        {

            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            bool keyWasNotPressed = true;

            KeyboardState currentState = Keyboard.GetState();
            if (pressedKeys.Count() == 0)
            {
                NonPressedCommand.Execute(game);
                GameRecorder.Write(game.swWriteFile, "N");
                
            }
            foreach (Keys key in pressedKeys)
            {
                if (Game1.notPaused)
                {
                    if (controllerMappings.ContainsKey(key))
                    {
                        controllerMappings[key].Execute(game);
                        keyWasNotPressed = false;
                        if (GameRecorder.KeyboardRecordLogMappings.ContainsKey(key))
                        {
                            GameRecorder.Write(game.swWriteFile, GameRecorder.KeyboardRecordLogMappings[key]);
                        }

                    }
                }

            }
            if (currentState.IsKeyDown(Keys.T)){
                 GameRecorder.Write(game.swWriteFile, GameRecorder.KeyboardRecordLogMappings[Keys.T]);
            }

            if (keyWasNotPressed)
            {
                idleCommand.Execute(game);
            }

            if (currentState.IsKeyDown(Keys.T) && previousState.IsKeyUp(Keys.T))
            {

                new GenerateFireballCommand(0).Execute(game);
            }

            if (previousState.IsKeyDown(Keys.Enter) && currentState.IsKeyUp(Keys.Enter))
            {
                new PauseCommand(0).Execute(game);
            }
            if (currentState.IsKeyDown(Keys.X) && previousState.IsKeyUp(Keys.X))
            {
                new MarioRunningCommand(0).Register(game);
            }
            if (!currentState.IsKeyDown(Keys.X))
            {
                new MarioRunningCommand(0).Unregister(game);
            }
            if (currentState.IsKeyDown(Keys.P) && previousState.IsKeyUp(Keys.P))
            {
                new EnemySpawnerCommand(0).Execute(game);
            }
            previousState = currentState;
            GameRecorder.Enter(game.swWriteFile);
        }
    }
}
