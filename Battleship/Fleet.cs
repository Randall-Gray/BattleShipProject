using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Fleet
    {
        // Member variables
        public List<Ship> ships;    

        // constructor
        public Fleet()
        {
            ships = new List<Ship>();

            ships.Add(new Destroyer());
            ships.Add(new Submarine());
            ships.Add(new Cruiser());
            ships.Add(new Battleship());
            ships.Add(new AircraftCarrier());
        }

        // Member methods
        // Returns if all ships in fleet are deployed.
        public bool AllDeployed()
        {
            for (int i = 0; i < ships.Count; i++)
                if (!ships[i].deployed)
                    return false;

            return true;
        }

        // The ship deployment list gets smaller as ships are deployed.  Convert list selection to actual fleet ship number.
        public int ConvertSelectionToFleetShipNumber(int nonDeployedShipNumber)
        {
            int i = 0;

            for (; i < ships.Count && nonDeployedShipNumber > 0; i++)
            {
                if (!ships[i].deployed)
                    nonDeployedShipNumber--;
            }
            return i - 1;
        }
    }
}
