using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    class Board
    { 
        public int Rank { get; set; }
        public int File { get; set; }

        private Piece[,] _pieces;

        public Board(int file, int rank)
        {
            File = file;
            Rank = rank;
            _pieces = new Piece[file, rank];
        }

        public Piece Piece(int file, int rank)
        {
            return _pieces[rank, file];
        }

        public void PlacePiece(Piece p, Position pos)
        {
            _pieces[pos.Rank, pos.File] = p;
            p.Position = pos;
        }
    }
}
