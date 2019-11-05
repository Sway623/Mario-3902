using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class GamerReplayer
    {
        string strReadFilePath = @"../../../Replay.txt";
        String lastCommand = "";
        String currentCommand;
        String[] currentString;
        StreamReader srReadFile;
        NonPressedKeyMarioCommand NonPressedCommand;
        MarioIdleCommand idleCommand;
        private Game1 game;
        int playerNumber = 0;
        public static Dictionary<String, ICommand> LogCommandMappings;


        public GamerReplayer(Game1 game)
        {
            this.srReadFile = new StreamReader(strReadFilePath);
            this.game = game;
            idleCommand = new MarioIdleCommand(playerNumber);
            NonPressedCommand = new NonPressedKeyMarioCommand(playerNumber);
            LogCommandMappings = new Dictionary<String, ICommand>
                {
                 {"Q", new ExitGameCommand()},
                 {"W", new MarioUpCommand(playerNumber)},
                 {"A", new MarioLeftCommand(playerNumber)},
                 
                 {"D", new MarioRightCommand(playerNumber) },
                 
                 {"X", new MarioRunningCommand(playerNumber)},
                
            
                };
        }
        public void ParseLog()
        {
            if (!srReadFile.EndOfStream)
            {
                currentCommand = srReadFile.ReadLine();
                currentString = currentCommand.Split();
            }
            else
            {
                game.Exit();
            }
        }
        public void Update()
        {
            ParseLog();
            bool keyWasNotPressed = true;
            if (currentCommand.Equals("N"))
            {
                NonPressedCommand.Execute(game);

            }

            foreach (String str in currentString)
            {
                if (Game1.notPaused)
                {
                    if (LogCommandMappings.ContainsKey(str))
                    {
                        LogCommandMappings[str].Execute(game);
                        keyWasNotPressed = false;

                    }
                }
            }

            if (!lastCommand.Equals("T")&&currentCommand.Equals("T"))
            {
                new GenerateFireballCommand(0).Execute(game);
            }

            if (keyWasNotPressed)
            {
                idleCommand.Execute(game);
            }

            /*       if (currentState.IsKeyDown(Keys.T) && previousState.IsKeyUp(Keys.T))
                   {
                       new GenerateFireballCommand(0).Execute(game);
                   }
               */


            lastCommand = currentCommand;
        }
    }
}
