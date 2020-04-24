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
        public GameSimulation()
        {
        }

        // Member methods
        public void RunGame()
        {
            bool winner = false;

            UserInterface.Welcome();

            player1 = new Player(UserInterface.GetPlayerName("player1"));
            player2 = new Player(UserInterface.GetPlayerName("player2"));

            player1.PlaceShips();
            player2.PlaceShips();

            do
            {
                winner = player1.MakeGuess(player2);
                winner = player2.MakeGuess(player1);
            } while (!winner);

            UserInterface.DisplayEndGameStats();
        }
    }
}
