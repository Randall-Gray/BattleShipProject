using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public abstract class Ship
    {
        // Member variables
        public string type;         // Destroyer, Submarine, Cruiser, Battleship, Aircraft Carrier
        public int numHoles;
        public bool deployed;       // placed on board?
        public bool sunk;

        // constructor
        public Ship(string type, int numHoles)
        {
            this.type = type;
            this.numHoles = numHoles;
            deployed = false;
            sunk = false;
        }

        // Member methods
        public string ShipTypeAndSize()
        {
            return type + "(" + numHoles + ")";
        }

        // A ship's Hole.type is the first letter of the ship's type, capitalized, and in parenthesis. 
        public string ShipHoleType()
        {
            return "(" + type.ToUpper()[0] + ")";
        }
    }
}
