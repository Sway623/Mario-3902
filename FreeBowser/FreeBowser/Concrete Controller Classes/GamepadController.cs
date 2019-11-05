using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    class GamepadController : IController
    {

        private Game1 game;
        int playerNumber = 0;
        float variance = 0.5f;
        private Dictionary<Buttons, ICommand> controllerMappings;

        public GamepadController(Game1 myGame)
        {
            game = myGame;
            controllerMappings = new Dictionary<Buttons, ICommand>();
            RegisterCommand(Buttons.A, new MarioUpCommand(playerNumber));
            RegisterCommand(Buttons.B, new MarioRunningCommand(playerNumber));
            RegisterCommand(Buttons.X, new GenerateFireballCommand(playerNumber));
        }
        public void RegisterCommand(Buttons button, ICommand command)
        {
            controllerMappings.Add(button, command);
        }

        static GamepadController()
        {

        }

        public void Update(GameTime gameTime)
        {
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            foreach (Buttons button in Enum.GetValues(typeof(Buttons)))
            {
                if (gamePadState.IsConnected && controllerMappings.ContainsKey(button) && gamePadState.IsButtonDown(button))
                {
                    controllerMappings[button].Execute(game);
                }
            }

            if (gamePadState.IsConnected)
            {
                float xDirection = gamePadState.ThumbSticks.Left.X;
                float yDirection = gamePadState.ThumbSticks.Left.Y;

                bool isIdle = true;

                if (xDirection > variance)
                {
                    MarioRightCommand marioRightCmd = new MarioRightCommand(playerNumber);
                    marioRightCmd.Execute(this.game);
                    isIdle = false;
                }
                else if (xDirection < (-1 * variance))
                {
                    MarioLeftCommand marioLeftCmd = new MarioLeftCommand(playerNumber);
                    marioLeftCmd.Execute(this.game);
                    isIdle = false;
                }

                if (yDirection > variance)
                {

                } else if (yDirection < (-1 * variance)) {
                    MarioDownCommand marioDownCmd = new MarioDownCommand(playerNumber);
                    marioDownCmd.Execute(this.game);
                    isIdle = false;
                }

                if (isIdle)
                {
                    MarioIdleCommand marioIdleCmd = new MarioIdleCommand(playerNumber);
                    marioIdleCmd.Execute(this.game);
                }
            }
        }



    }
}
