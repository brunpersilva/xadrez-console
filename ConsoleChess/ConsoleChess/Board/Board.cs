using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    public class Board
    {
        public int Rows { get; set; }
        public int Ranks { get; set; }
        private Piece[,] _pieces;

        public Board(int rows, int ranks)
        {
            Rows = rows;
            Ranks = ranks;
            _pieces = new Piece[rows, ranks];
        }
    }
}
