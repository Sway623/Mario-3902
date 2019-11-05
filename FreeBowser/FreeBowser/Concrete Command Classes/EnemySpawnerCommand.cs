using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class EnemySpawnerCommand : ICommand
    {
        int playerNumber;

        public EnemySpawnerCommand(int playerNum)
        {
            playerNumber = playerNum;
        }
        public void Execute(Game1 game)
        {
            Game1.isSpawning = !Game1.isSpawning;
        }
    }
}
