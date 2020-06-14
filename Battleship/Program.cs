using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameSimulation BattleShip = new GameSimulation();

            do
            {
                BattleShip.RunGame();
            }
            while (UserInterface.AskUserYesOrNo("Would you like to play again"));
        }
    }
}
