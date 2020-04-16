using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Fleet
    {
        // Member variables
        List<Ship> ships;

        // constructor
        public Fleet()
        {
            ships = new List<Ship>();

            ships.Add(new Ship("Destroyer", 2));
            ships.Add(new Ship("Submarine", 3));
            ships.Add(new Ship("Cruiser", 3));
            ships.Add(new Ship("Battleship", 4));
            ships.Add(new Ship("Aircraft Carrier", 5));
        }

        // Member methods
        // Writes line to console listing available ships in fleet:  "ship1(size)  ship2(size)...."
        public void WriteLine()
        {
            for (int i = 0; i < ships.Count; i++)
                Console.Write(ships[i].type + "(" + ships[i].numHoles + ")  ");
            Console.Write("\n");
        }
    }
}
