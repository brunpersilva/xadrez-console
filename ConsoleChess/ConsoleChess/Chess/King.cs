using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using board;

namespace chess
{
    class King : Piece
    {
        public King(Board boar, Color color) : base(boar, color)
        {
        }

        private bool CanMove(Position pos)
        {
            Piece p = tab.Piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[tab.Ranks, tab.Files];

            Position position = new Position(0, 0);

            //up
            position.DefineValues(PiecePosition.Rank - 1, PiecePosition.File);
            if (tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }

            //ne
            position.DefineValues(PiecePosition.Rank - 1, PiecePosition.File + 1);
            if (tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }
            //right
            position.DefineValues(PiecePosition.Rank, PiecePosition.File + 1);
            if (tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }

            //se
            position.DefineValues(PiecePosition.Rank + 1, PiecePosition.File + 1);
            if (tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }
            //left
            position.DefineValues(PiecePosition.Rank, PiecePosition.File - 1);
            if (tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }
            //down
            position.DefineValues(PiecePosition.Rank + 1, PiecePosition.File);
            if (tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }
            //sw
            position.DefineValues(PiecePosition.Rank + 1, PiecePosition.File - 1);
            if (tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }
            //nw
            position.DefineValues(PiecePosition.Rank - 1, PiecePosition.File - 1);
            if (tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
