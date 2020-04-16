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

            // ship names must start with different letter to distintguish them on board.
            ships.Add(new Ship("Destroyer", 2));
            ships.Add(new Ship("Submarine", 3));
            ships.Add(new Ship("Cruiser", 3));
            ships.Add(new Ship("Battleship", 4));
            ships.Add(new Ship("Aircraft Carrier", 5));
        }

        // Member methods
        // Displays list of ships to deploy for number selection   e.g. "1) Destroyer (2)"....
        public void DisplayShipsToDeploy()
        {
            for (int i = 0; i < ships.Count; i++)
                if (!ships[i].deployed)
                     Console.WriteLine(i + ") " + ships[i].ShipTypeAndSize());
        }
        // Returns if all ships in fleet are deployed.
        public bool AllDeployed()
        {
            for (int i = 0; i < ships.Count; i++)
                if (!ships[i].deployed)
                    return false;

            return true;
        }
        public int ConvertUndeployedShipNumber(int numNotDeployed)
        {
            int i = 0;

            for (; i < ships.Count && numNotDeployed; i++)
            {
                if (!ships[i].deployed)
                    numNotDeployed--;
            }
            return i
        }
    }
}
