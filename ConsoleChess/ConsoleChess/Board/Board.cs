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
        public Piece Piece(Position pos)
        {
            return _pieces[pos.Rank, pos.File];
        }

        public void PlacePiece(Piece p, Position pos)
        {
            if (IsThereAPiece(pos))
            {
                throw new BoardExceptions("There is already a piece in this position!"); 
            }
            _pieces[pos.Rank, pos.File] = p;
            p.Position = pos;
        }
        public Piece RemovePiece(Position pos)
        {
            if (Piece(pos) == null)
            {
                return null;
            }
            Piece aux = Piece(pos);
            _pieces[pos.File, pos.Rank] = null;
            return aux;

        }

        public bool IsThereAPiece(Position pos)
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        }

        public bool ValidPosition(Position pos)
        {
            if (pos.Rank < 0 || pos.Rank >= Rank || pos.File < 0 || pos.File >= File)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new BoardExceptions("Invalid Position!");
            }
        }
    }
}
