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
            bool winner;

            UserInterface.Welcome();

            player1 = new Player(UserInterface.GetPlayerName("player1"));
            player2 = new Player(UserInterface.GetPlayerName("player2"));

            player1.PlaceShips();
            player2.PlaceShips();

            UserInterface.LetsPlay(player1);

            do
            {
                winner = player1.MakeGuess(player2);
                if (!winner)
                    winner = player2.MakeGuess(player1);
            } while (!winner);

            UserInterface.DisplayEndGameStats();
        }
    }
}
