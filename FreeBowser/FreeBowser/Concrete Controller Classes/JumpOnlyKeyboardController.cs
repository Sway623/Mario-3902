using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class JumpOnlyKeyboardController : IController
    {
        private static Dictionary<Keys, ICommand> controllerMappings;

        private Game1 game;

        KeyboardState previousState;
        MarioRightCommand continueMoving;

        public JumpOnlyKeyboardController(Game1 myGame)
        {
            game = myGame;

            int playerNumber = 0;
            continueMoving = new MarioRightCommand(playerNumber);
            controllerMappings = new Dictionary<Keys, ICommand>
                {
                 {Keys.Q, new ExitGameCommand()},
                 {Keys.W, new MarioUpCommand(playerNumber)},
                 {Keys.Up, new MarioUpCommand(playerNumber) },
                 {Keys.R, new ResetAllCommand()},
                 {Keys.J, new JumpOnlyModeCommand(playerNumber)},
                 {Keys.N, new NightmareModeCommand(playerNumber)},
                 {Keys.L, new LevelEditorCommand()}
                };

        }


        public void Update(GameTime gameTime)
        {

            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            KeyboardState currentState = Keyboard.GetState();

            if (Game1.notPaused)
            {
                continueMoving.Execute(game);
            }
            foreach (Keys key in pressedKeys)
            {
                if (Game1.notPaused)
                {
                    if (controllerMappings.ContainsKey(key))
                    {
                        controllerMappings[key].Execute(game);
                    }

                }

            }

          

            

            if (previousState.IsKeyDown(Keys.Enter) && currentState.IsKeyUp(Keys.Enter))
            {
                new PauseCommand(0).Execute(game);
            }
            if (currentState.IsKeyDown(Keys.X) && previousState.IsKeyUp(Keys.X))
            {
                new MarioRunningCommand(0).Register(game);
            }
          
           
            previousState = currentState;

        }
    }
}
