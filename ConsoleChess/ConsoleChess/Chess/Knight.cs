﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using board;

namespace chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {

        }
        private bool CanMove(Position pos)
        {
            Piece p = Tab.Piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Tab.Ranks, Tab.Files];

            Position pos = new Position(0, 0);

            pos.DefineValues(PiecePosition.Rank - 1, PiecePosition.File - 2);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
            }
            pos.DefineValues(PiecePosition.Rank - 2, PiecePosition.File - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
            }
            pos.DefineValues(PiecePosition.Rank - 2, PiecePosition.File + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
            }
            pos.DefineValues(PiecePosition.Rank - 1, PiecePosition.File + 2);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
            }
            pos.DefineValues(PiecePosition.Rank + 1, PiecePosition.File + 2);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
            }
            pos.DefineValues(PiecePosition.Rank + 2, PiecePosition.File + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
            }
            pos.DefineValues(PiecePosition.Rank + 2, PiecePosition.File - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
            }
            pos.DefineValues(PiecePosition.Rank + 1, PiecePosition.File - 2);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
            }
            return mat;
        }

        public override string ToString()
        {
            return "N";
        }
    }
}