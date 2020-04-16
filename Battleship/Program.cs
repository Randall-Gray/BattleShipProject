using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Player playerOne = new Player("Charlie");
            Player playerTwo = new Player("Stanley");

            playerOne.PlaceShips();
            playerTwo.PlaceShips();
        }
    }
}
