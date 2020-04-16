using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Hole
    {
        // Member variables
        public string type;     // "( )", "(M)", "(S)", "(H)" 

        // Constructor
        public Hole(int x, int y)
        {
            x_coord = x;
            y_coord = y;
            hasShip = false;
            hasPeg = false;
        }

        // Member methods
        public string Status()
        {
            if (hasShip)
            {
                if (hasPeg)
                    return "(H)";
                else
                    return "(S)";
            }
            else 
            {
                if (hasPeg)
                    return "(M)";
                else
                    return "(E)";
            }
        }
    }
}
