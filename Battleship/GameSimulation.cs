using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class GameSimulation
    {
        // Member variables
        Player player1;
        Player player2;

        // constructor
        public GameSimulation()
        {
        }

        // Member methods
        public void RunGame()
        {
            Console.Clear();
            Console.WriteLine("Let's play \"Battleship\"");

            Console.WriteLine("\nEnter player1 name: ");
            player1 = new Player(Console.ReadLine());

            Console.WriteLine("\nEnter player2 name: ");
            player2 = new Player(Console.ReadLine());

            player1.PlaceShips();
            player1.PlaceShips();

            Console.ReadLine();
        }
    }
}
