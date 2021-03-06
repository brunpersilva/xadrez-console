﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using board;

namespace chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
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

            Position position = new Position(0, 0);
            //up
            position.DefineValues(PiecePosition.Rank - 1, PiecePosition.File);
            while (Tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
                if (Tab.Piece(position) != null && Tab.Piece(position).Color != Color)
                {
                    break;
                }
                position.Rank--;
            }

            //down
            position.DefineValues(PiecePosition.Rank, PiecePosition.File + 1);
            while (Tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
                if (Tab.Piece(position) != null && Tab.Piece(position).Color != Color)
                {
                    break;
                }
                position.Rank++;
            }
            //right
            position.DefineValues(PiecePosition.Rank, PiecePosition.File + 1);
            while (Tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
                if (Tab.Piece(position) != null && Tab.Piece(position).Color != Color)
                {
                    break;
                }
                position.File++;
            }

            //left
            position.DefineValues(PiecePosition.Rank, PiecePosition.File - 1);
            while (Tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
                if (Tab.Piece(position) != null && Tab.Piece(position).Color != Color)
                {
                    break;
                }
                position.File--;
            }
            //NO
            position.DefineValues(PiecePosition.Rank - 1, PiecePosition.File - 1);
            while (Tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
                if (Tab.Piece(position) != null && Tab.Piece(position).Color != Color)
                {
                    break;
                }
                position.DefineValues(position.Rank - 1, position.File - 1);
            }

            //NE
            position.DefineValues(PiecePosition.Rank - 1, PiecePosition.File + 1);
            while (Tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
                if (Tab.Piece(position) != null && Tab.Piece(position).Color != Color)
                {
                    break;
                }
                position.DefineValues(position.Rank - 1, position.File + 1);
            }
            //SE
            position.DefineValues(PiecePosition.Rank + 1, PiecePosition.File + 1);
            while (Tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
                if (Tab.Piece(position) != null && Tab.Piece(position).Color != Color)
                {
                    break;
                }
                position.DefineValues(position.Rank + 1, position.File + 1);
            }

            //SO
            position.DefineValues(PiecePosition.Rank + 1, PiecePosition.File - 1);
            while (Tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
                if (Tab.Piece(position) != null && Tab.Piece(position).Color != Color)
                {
                    break;
                }
                position.DefineValues(position.Rank + 1, position.File - 1);
            }
            return mat;
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
