using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using board;

namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
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

            //NO
            pos.DefineValues(PiecePosition.Rank - 1, PiecePosition.File - 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Rank - 1, pos.File - 1);
            }

            //NE
            pos.DefineValues(PiecePosition.Rank - 1, PiecePosition.File + 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Rank - 1, pos.File + 1);
            }
            //SE
            pos.DefineValues(PiecePosition.Rank + 1, PiecePosition.File + 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Rank + 1, pos.File + 1);
            }

            //SO
            pos.DefineValues(PiecePosition.Rank + 1, PiecePosition.File - 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Rank + 1, pos.File - 1);
            }
            return mat;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}