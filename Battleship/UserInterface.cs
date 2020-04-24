﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    static public class UserInterface
    {
        // member methods
        static public void Welcome()
        {
            Console.Clear();
            Console.WriteLine("Let's play \"Battleship\"");
        }

        static public string GetPlayerName(string name)
        {
            Console.WriteLine($"Enter {name} name: ");
            return Console.ReadLine();
        }

        static public int SelectShipToDeploy(string playerName, Fleet fleet)
        {
            int numShip;
            int numDeployed;
            bool validInput;

            Console.Clear();
            Console.WriteLine("\n" + playerName + " deploy your ships.");

            do
            {
                Console.WriteLine("\nSelect ship to deploy:");
                numDeployed = UserInterface.DisplayShipsToDeploy(fleet);
                
                validInput = int.TryParse(Console.ReadLine(), out numShip);
                if (!validInput)
                    continue;

            }
            while (!validInput || numShip <= 0 || numShip > fleet.ships.Count - numDeployed);

            return fleet.ConvertSelectionToFleetShipNumber(numShip);
        }

        // Displays list of remaining ships in fleet to deploy for number selection   e.g. "1) Destroyer (2)"....
        // Returns number of ships already deployed.
        static private int DisplayShipsToDeploy(Fleet fleet)
        {
            int numDeployed = 0;

            for (int i = 0; i < fleet.ships.Count; i++)
            {
                if (!fleet.ships[i].deployed)
                {
                    Console.WriteLine((i - numDeployed + 1) + ") " + fleet.ships[i].ShipTypeAndSize());
                }
                else
                    numDeployed++;
            }
            return numDeployed;
        }

        static public void DisplayLocationInvalidForShip(Fleet fleet, int numShip)
        {
            Console.WriteLine("Invalid location for " + fleet.ships[numShip].ShipTypeAndSize());
            Console.ReadLine();
        }

        static public void DisplayBoard(Board board)
        {
            Console.WriteLine($"\n{board.type} Board");

            for (int row = board.numRows - 1; row >= 0; row--)
            {
                Console.Write("Row: " + row + "\t");        // Display row numbers

                for (int col = 0; col < board.numCols; col++)
                {
                    Console.Write(board.grid[row, col].type);
                }
                Console.Write("\n");
            }
            // Display column numbers
            Console.Write("Column:\t");
            for (int col = 0; col < board.numCols; col++)
            {
                if (col <= 10)
                    Console.Write(" ");
                Console.Write(col + " ");
            }
            Console.Write("\n");
        }

        static public void GetLocationToDeployShip(string playerName, Fleet fleet, int numShip, out int row, out int col, out string orientation)
        {
            Console.WriteLine("\n" + playerName + " enter location to deploy " + fleet.ships[numShip].ShipTypeAndSize() + ". (row, colum, orientation)");
            do
            {
                Console.WriteLine("Enter row:");
            } while (!int.TryParse(Console.ReadLine(), out row) || row < 0 || row > Constants.boardNumRows - 1);
            do
            {
                Console.WriteLine("Enter column:");
            } while (!int.TryParse(Console.ReadLine(), out col) || col < 0 || col > Constants.boardNumCols - 1);
            do
            {
                Console.WriteLine("Enter orientation (left, right, up, down):");
                orientation = Console.ReadLine();
            } while (orientation.ToLower() != "left" && orientation.ToLower() != "right" && orientation.ToLower() != "up" && orientation.ToLower() != "down");
        }

        static public void GetPlayerGuess(string playerName, out int row, out int col)
        {
            Console.Clear();
            Console.WriteLine("\n" + playerName + " enter guess location.  (row, colum)");
            do
            {
                Console.WriteLine("Enter row:");
            } while (!int.TryParse(Console.ReadLine(), out row) || row < 0 || row > Constants.boardNumRows - 1);
            do
            {
                Console.WriteLine("Enter column:");
            } while (!int.TryParse(Console.ReadLine(), out col) || col < 0 || col > Constants.boardNumCols - 1);
        }

        static public void DisplayEndGameStats()
        {
            Console.WriteLine("\nGAME OVER!");
        }

        // Ask user a Yes or No question e.g. "Play again"
        static public bool AskUserYesOrNo(string question)
        {
            bool rtnAns;

            Console.WriteLine("\n" + question + "? (Y/N)");
            rtnAns = Console.ReadLine().ToUpper() == "Y";
            if (rtnAns)
                Console.Clear();
            return rtnAns;
        }
    }
}
