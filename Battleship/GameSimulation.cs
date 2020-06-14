using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class GameSimulation
    {
        // Member variables
        Player player1;
        Player player2;

        // constructor

        // Member methods
        public void RunGame()
        {
            bool winner = false;

            UserInterface.Welcome();

            player1 = new Player(UserInterface.GetPlayerName("player1"));
            player2 = new Player(UserInterface.GetPlayerName("player2"));

            player1.PlaceShips();
            player2.PlaceShips();

            UserInterface.LetsPlay(player1);

            do
            {
                // A player gets one shot for every ship they have left.
                for (int i = player1.fleet.NumShipsNotSunk(); i > 0; i--)
                {
                    winner = player1.MakeGuess(player2, i);
                    if (winner)
                    {
                        UserInterface.DisplayEndGameStats(player1);
                        break;
                    }
                }
                if (!winner)
                {
                    for (int i = player2.fleet.NumShipsNotSunk(); i > 0; i--)
                    {
                        winner = player2.MakeGuess(player1, i);
                        if (winner)
                        {
                            UserInterface.DisplayEndGameStats(player2);
                            break;
                        }
                    }
                }
            } while (!winner);
        }
    }
}
