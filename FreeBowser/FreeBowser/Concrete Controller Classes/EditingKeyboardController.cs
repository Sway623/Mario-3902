using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class EditingKeyboardController : IController
    {
        static TimeSpan Time { get; set; }

        private static Dictionary<Keys, ICommand> controllerMappings;
        MarioIdleCommand idleCommand;

        NonPressedKeyMarioCommand NonPressedCommand;
        private Game1 game;

        TextBox textBox;

        public EditingKeyboardController(Game1 myGame, CameraController camera)
        {
            game = myGame;
            textBox = EditLevelDisplay.saveTextBox;

            int playerNumber = 0;
            idleCommand = new MarioIdleCommand(playerNumber);
            NonPressedCommand = new NonPressedKeyMarioCommand(playerNumber);

            ResetTimer();

            controllerMappings = new Dictionary<Keys, ICommand>
                {
                 {Keys.W, new CameraUpCommand(camera)},
                 {Keys.A, new CameraLeftCommand(camera)},
                 {Keys.Left, new CameraLeftCommand(camera)},
                 {Keys.Right, new CameraRightCommand(camera) },
                 {Keys.Up, new CameraUpCommand(camera) },
                 {Keys.Down, new CameraDownCommand(camera) },
                 {Keys.S, new CameraDownCommand(camera)},
                 {Keys.D, new CameraRightCommand(camera)},
                 {Keys.B, new LevelEditorCommand()}
                };
        }

        public void Update(GameTime gameTime)
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            KeyboardState currentState = Keyboard.GetState();

            Time = Time.Subtract(gameTime.ElapsedGameTime);

            textBox = EditLevelDisplay.saveTextBox;

            if (EditLevelDisplay.drawSaveTextBox)
            {
                if ((int)Time.TotalMilliseconds <= 0)
                {
                    ResetTimer();
                    foreach (Keys key in pressedKeys)
                    {
                        //Accept input every .15 seconds
                        if (key == Keys.Enter && textBox.GetText().Length > 0)
                        {
                            EditLevelDisplay.savingLevel = true;
                        }
                        else if (key == Keys.Back || key == Keys.Delete)
                        {
                            textBox.RemoveLastLetter();
                        }
                        else
                        {
                            textBox.AppendLetter(key.ToString());
                        }

                    }
                }
            }
            else
            {
                foreach (Keys key in pressedKeys)
                {
                    if (controllerMappings.ContainsKey(key))
                    {
                        controllerMappings[key].Execute(game);
                    }
                }
            }
        }

        public static void ResetTimer()
        {
            Time = new TimeSpan(0, 0, 0, 0, 100);
        }

        public static void ZeroTimer()
        {
            Time = new TimeSpan(0, 0, 0, 0, 0);
        }
    }
}
