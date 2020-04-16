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
                Console.Clear();

                BattleShip.RunGame();

                Console.WriteLine("\nWould you like to play again? (Y/N)");
                if (Console.ReadLine().ToUpper() != "Y")
                    break;
            }
            while (true);
        }
    }
}
