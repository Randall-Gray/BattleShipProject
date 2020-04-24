using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Board
    {
        // Member variables
        public Hole[,] grid;            // [x,y] coordinates - Hole[0][0]  is bottom-left corner of board
        public int numRows, numCols;
        public string type;             // Ship or Guess

        // Constructor
        public Board(string type, int numRows, int numCols)
        {
            Hole hole;

            this.numRows = numRows;
            this.numCols = numCols;
            this.type = type;

            grid = new Hole[numRows,numCols];
            // Must put a Hole into each grid index.
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    hole = new Hole();
                    grid[i, j] = hole;
                }
            }
        }

        // Member methods
    }
}
