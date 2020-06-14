using System;
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

        static public void LetsPlay(Player player)
        {
            Console.Clear();
            Console.WriteLine("Setup complete!");
            Console.WriteLine($"\n{player.name} - You go first.");
            PressEnter();
        }

        static public void PressEnter()
        {
            Console.WriteLine("\nPress <Enter>...");
            Console.ReadLine();
        }

        static public string GetPlayerName(string name)
        {
            Console.WriteLine($"\nEnter {name} name: ");
            return Console.ReadLine();
        }

        static public int SelectShipToDeploy(Player player)
        {
            int numShip;
            int numDeployed;
            bool validInput;

            Console.Clear();
            Console.WriteLine($"\n{player.name} deploy your ships.");

            do
            {
                Console.WriteLine("\nSelect ship to deploy:");
                numDeployed = UserInterface.DisplayShipsToDeploy(player.fleet);
                
                validInput = int.TryParse(Console.ReadLine(), out numShip);
            }
            while (!validInput || numShip <= 0 || numShip > player.fleet.ships.Count - numDeployed);

            return player.fleet.ConvertSelectionToFleetShipNumber(numShip);
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
                    Console.WriteLine($"{i - numDeployed + 1}) {fleet.ships[i].ShipTypeAndSize()}");
                }
                else
                    numDeployed++;
            }
            return numDeployed;
        }

        static public void DisplayLocationInvalidForShip(Fleet fleet, int numShip)
        {
            Console.WriteLine($"Invalid location for {fleet.ships[numShip].ShipTypeAndSize()}");
            Console.ReadLine();
        }

        static public void DisplayBoard(string playerName, Board board)
        {
            Console.Clear();
            Console.WriteLine($"\n{playerName}'s {board.type} Board");

            for (int row = board.numRows - 1; row >= 0; row--)
            {
                Console.Write($"Row: {row}\t");        // Display row numbers

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
                Console.Write($"{col} ");
            }
            Console.Write("\n");
        }

        static public void GetLocationToDeployShip(Player player, int numShip, out int row, out int col, out string orientation)
        {
            Console.WriteLine($"\n{player.name} enter location to deploy {player.fleet.ships[numShip].ShipTypeAndSize()}. (row, colum, orientation)");
            do
            {
                Console.WriteLine("Enter row:");
            } while (!int.TryParse(Console.ReadLine(), out row) || row < 0 || row > player.shipBoard.numRows - 1);
            do
            {
                Console.WriteLine("Enter column:");
            } while (!int.TryParse(Console.ReadLine(), out col) || col < 0 || col > player.shipBoard.numCols - 1);
            do
            {
                Console.WriteLine("Enter orientation (left, right, up, down):");
                orientation = Console.ReadLine();
            } while (orientation.ToLower() != "left" && orientation.ToLower() != "right" && orientation.ToLower() != "up" && orientation.ToLower() != "down");
        }

        static public void GetPlayerGuess(Player player, int shotsLeft, out int row, out int col)
        {
            string input = "";
            row = -1;
            col = -1;

            Console.WriteLine($"\n{player.name} you have {shotsLeft} shot(s) left this turn.");
            Console.WriteLine("Enter guess location:  (row, colum)  ('s' to display ship board)");
            do
            {
                Console.WriteLine("Enter row:");
                input = Console.ReadLine();
                if (input.ToLower() == "s")
                    break;
            } while (!int.TryParse(input, out row) || row < 0 || row > player.guessBoard.numRows - 1);
            if (input.ToLower() != "s")
            {
                do
                {
                    Console.WriteLine("Enter column:");
                    input = Console.ReadLine();
                    if (input.ToLower() == "s")
                        break;
                } while (!int.TryParse(input, out col) || col < 0 || col > player.guessBoard.numCols - 1);
            }
        }

        static public void ReportMiss(Player player, int row, int col)
        {
            Console.WriteLine($"\n{player.name} ({row}, {col}) MISS!");
            PressEnter();
        }

        static public void ReportHit(Player player, int row, int col, Ship ship)
        {
            if (ship.ShipSunk())
                Console.WriteLine($"\n{player.name} ({row}, {col}) HIT! {ship.ShipTypeAndSize()} - SUNK!");
            else 
                Console.WriteLine($"\n{player.name} ({row}, {col}) HIT! {ship.ShipTypeAndSize()}");

            PressEnter();
        }

        static public void DisplayEndGameStats(Player winner)
        {
            Console.WriteLine($"\nGAME OVER!   {winner.name.ToUpper()} WON!");
        }

        // Ask user a Yes or No question e.g. "Play again"
        static public bool AskUserYesOrNo(string question)
        {
            bool rtnAns;

            Console.WriteLine($"\n{question}? (Y/N)");
            rtnAns = Console.ReadLine().ToUpper() == "Y";
            if (rtnAns)
                Console.Clear();
            return rtnAns;
        }
    }
}
