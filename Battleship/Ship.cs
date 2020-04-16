using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Ship
    {
        // Member variables
        public string type;
        public int numHoles;
        public Hole location;
        public int orientation;   // Up, down, left, right starting at location.

        // constructor
        public Ship(string type, int numHoles)
        {
            this.type = type;
            this.numHoles = numHoles;
        }

        // Member methods
        public void PlaceShip(Hole location, int orientation)
        {
            this.location = location;
            this.orientation = orientation;
        }
    }
}
