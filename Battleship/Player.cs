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
        public string name;
        public Board shipBoard;
        public Board guessBoard;
        public Fleet fleet;

        // constructor
        public Player(string name)
        {
            this.name = name;
            shipBoard = new Board("Ship");
            guessBoard = new Board("Guess");
            fleet = new Fleet(); 
        }

        // Member methods
        public void PlaceShips()
        {
            bool validInput;
            int numShip;

            do
            {
                Console.Clear();
                Console.WriteLine("\n" + name + " deploy your ships.");
                numShip = SelectShipToDeploy();
                Console.Clear();
                shipBoard.DisplayBoard();
                PlaceShipOnBoard(numShip);
            }
            while (!fleet.AllDeployed());
        }
        private int SelectShipToDeploy()
        {
            int numShip;
            bool validInput;

            do
            {
                Console.WriteLine("\nSelect ship to deploy:");
                fleet.DisplayShipsToDeploy();
                // protect against non-number input
                validInput = int.TryParse(Console.ReadLine(), out numShip);
                if (!validInput)
                    continue;
                numShip = fleet.GetUndeployedShipNumber(numShip);
            }
            while (!validInput || numShip < 0 || numShip > fleet.ships.Count - 1);

            return numShip;
        }
        private void PlaceShipOnBoard(int numShip)
        {
            int row;
            int col;
            string orientation;

            do
            {
                Console.WriteLine("\n" + name + " enter location to deploy " + fleet.ships[numShip].ShipTypeAndSize() + ". (row, colum, orientation)");
                do
                {
                    Console.WriteLine("Enter row:");
                } while (!int.TryParse(Console.ReadLine(), out row) || row < 0 || row > shipBoard.numRows - 1);
                do
                {
                    Console.WriteLine("Enter column:");
                } while (!int.TryParse(Console.ReadLine(), out col) || col < 0 || col > shipBoard.numCols - 1);
                do
                {
                    Console.WriteLine("Enter orientation (left, right, up, down):");
                    orientation = Console.ReadLine();
                } while (orientation.ToLower() != "left" && orientation.ToLower() != "right" && orientation.ToLower() != "up" && orientation.ToLower() != "down");
            }
            while (!PlaceShip(numShip, row, col, orientation));
        }
        // Determine if ship location is valid.  Within board and nothing else in location. If valid, place ship.
        private bool PlaceShip(int numShip, int row, int col, string orientation)
        {
            bool rtnBool = true;
            int numHoles = fleet.ships[numShip].numHoles;
            int startRow = 0;
            int endRow = 0;
            int startCol = 0;
            int endCol = 0;

            // Set locatiton of ship and check if entirely on board.
            switch (orientation)
            {
                case "left":
                    startRow = endRow = row;
                    endCol = col;
                    startCol = endCol - numHoles + 1;
                    if (startCol < 0)
                        rtnBool = false;
                    break;
                case "right":
                    startRow = endRow = row;
                    startCol = col;
                    endCol = startCol + numHoles - 1;
                    if (endCol > shipBoard.numCols - 1)
                        rtnBool = false;
                    break;
                case "up":
                    startCol = endCol = col;
                    startRow = row;
                    endRow = startRow + numHoles - 1;
                    if (endRow > shipBoard.numRows - 1)
                        rtnBool = false;
                    break;
                case "down":
                    startCol = endCol = col;
                    endRow = row;
                    startRow = endRow - numHoles + 1;
                    if (startRow < 0)
                        rtnBool = false;
                    break;
                default:
                    rtnBool = false;
                    break;
            }
            if (rtnBool == true)
            {
                // Check that location is unoccupied
                for (int i = startRow; i <= endRow; i++)
                {
                    for (int j = startCol; j <= endCol; j++)
                    {
                        if (shipBoard.grid[i, j].type != "( )")
                        {
                            rtnBool = false;
                            break;
                        }
                    }
                    if (rtnBool == false)
                        break;
                }
            }
            if (rtnBool == false)
                Console.WriteLine("Invalid location for " + fleet.ships[numShip].ShipTypeAndSize());
            else
            {
                // Place the ship
                for (int i = startRow; i <= endRow; i++)
                {
                    for (int j = startCol; j <= endCol; j++)
                    {
                        shipBoard.grid[i, j].type = fleet.ships[numShip].ShipHoleType();
                    }
                }
                fleet.ships[numShip].deployed = true;
            }

            return true;
        }
        //public void ChooseActions()
        //{
        //    bool validInput;
        //    int numAction;

        //    Console.Clear();            // Don't want to see other player's board.
        //    do
        //    {
        //        Console.WriteLine("\n" + name + " select an action: ");
        //        Console.WriteLine("1) Display Ship Board");
        //        Console.WriteLine("2) Place Ship On Ship Board");
        //        Console.WriteLine("3) Display Guess Board");
        //        Console.WriteLine("4) Make Guess on Guess Board");
        //        // protect against non-number input
        //        validInput = int.TryParse(Console.ReadLine(), out numAction);
        //        if (!validInput)
        //            continue;
        //    }
        //    while (!validInput || numAction < 0 || numAction > ruleTable.rules.Count - 1);

        //    gesture = ruleTable.rules[numGesture][0].winGesture;

        //    Console.WriteLine(name + " selected " + gesture);
        //    Console.WriteLine("\nPress any key to continue...");
        //    Console.ReadLine();
        //}


    }
}
