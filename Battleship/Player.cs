using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Player
    {
        // Member variables
        public string name;
        public Board guessBoard;
        public Board shipBoard;
        public Fleet fleet;

        // constructor
        public Player(string name)
        {
            this.name = name;
            guessBoard = new Board("Guess", 20, 20);
            shipBoard = new Board("Ship", 20, 20);
            fleet = new Fleet(); 
        }

        // Member methods
        public void PlaceShips()
        {
            int numShip;

            do
            {
                numShip = UserInterface.SelectShipToDeploy(this);
                UserInterface.DisplayBoard(name, shipBoard);
                PlaceShipOnBoard(numShip);
            }
            while (!fleet.AllDeployed());
        }

        private void PlaceShipOnBoard(int numShip)
        {
            int row;
            int col;
            string orientation;

            do
            {
                UserInterface.GetLocationToDeployShip(this, numShip, out row, out col, out orientation);
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
                UserInterface.DisplayLocationInvalidForShip(fleet, numShip);
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

        public bool MakeGuess(Player opponent)
        {
            int row;
            int col;

            UserInterface.DisplayBoard(name, guessBoard);
            UserInterface.GetPlayerGuess(this, out row, out col);

            if (opponent.shipBoard.grid[row, col].type == "( )")
                MarkGuessMiss(row, col);
            else
                MarkGuessHit(opponent, row, col);

            return opponent.fleet.NumShipsNotSunk() == 0;
        }

        private void MarkGuessMiss(int row, int col)
        {
            guessBoard.grid[row, col].type = "(-)";     // Miss
            UserInterface.DisplayBoard(name, guessBoard);
            UserInterface.ReportMiss(this, row, col);
        }

        private void MarkGuessHit(Player opponent, int row, int col)
        {
            string shipType = opponent.shipBoard.grid[row, col].type;
            int shipNum = fleet.GetShipNumber(shipType);

            guessBoard.grid[row, col].type = shipType;
            opponent.shipBoard.grid[row, col].type = "(!)";
            opponent.fleet.ships[shipNum].numHits++;
            UserInterface.DisplayBoard(name, guessBoard);
            UserInterface.ReportHit(this, row, col, opponent.fleet.ships[shipNum]);
        }
    }
}
