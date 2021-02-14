using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    class Board
    {
        public int Ranks { get; set; }
        public int Files { get; set; }

        private readonly Piece[,] _pieces;

        public Board( int ranks, int files)
        {
            Ranks = ranks;
            Files = files;   
            _pieces = new Piece[ranks, files];
        }

        public Piece Piece(int rank, int file)
        {
            return _pieces[rank, file];
        }
        public Piece Piece(Position pos)
        {
            return _pieces[pos.Rank, pos.File];
        }
        public bool IsThereAPiece(Position pos)
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        }
        public void PlacePiece(Piece p, Position pos)
        {
            if (IsThereAPiece(pos))
            {
                throw new BoardExceptions("There is already a piece in this position!"); 
            }
            _pieces[pos.Rank, pos.File] = p;
            p.PiecePosition = pos;
        }
        public Piece RemovePiece(Position pos)
        {
            if (Piece(pos) == null)
            {
                return null;
            }
            Piece aux = Piece(pos);
            _pieces[pos.Rank, pos.File] = null;
            return aux;

        }
        public bool ValidPosition(Position pos)
        {
            if (pos.Rank < 0 || pos.Rank >= Ranks || pos.File < 0 || pos.File >= Files)
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
