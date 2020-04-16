using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Player
    {
        // Member variables
        string name;
        Board shipBoard;
        Board guessBoard;
        Fleet ships;

        // constructor
        public Player(string name)
        {
            this.name = name;
            shipBoard = new Board();
            guessBoard = new Board();
            ships = new Fleet(); 
        }

        // Member methods
        public void PlaceShips()
        {
            string shipname;

            Console.WriteLine("Player: " + name);
            Console.WriteLine("Place your ships: name, x-coordinate, y-coordinate, orientation");
            ships.WriteLine();
            shipname = Console.ReadLine();
            Console.Clear();
        }
    }
}
