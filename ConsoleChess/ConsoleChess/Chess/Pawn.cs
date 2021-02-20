using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using board;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {

        }
        private bool IsthereAdversary(Position pos)
        {
            Piece p = Tab.Piece(pos);
            return p != null && p.Color != Color;
        }
        private bool Free(Position pos)
        {
            return Tab.Piece(pos) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Tab.Ranks, Tab.Files];

            Position position = new Position(0, 0);

            if (Color == Color.White)
            {
                position.DefineValues(position.Rank - 1, position.File);
                if (Tab.ValidPosition(position) && Free(position))
                {
                    mat[position.Rank, position.File] = true;
                }
                position.DefineValues(position.Rank - 2, position.File);
                if (Tab.ValidPosition(position) && Free(position) && NumberOfMoves == 0)
                {
                    mat[position.Rank, position.File] = true;
                }
                position.DefineValues(position.Rank - 1, position.File - 1);
                if (Tab.ValidPosition(position) && Free(position))
                {
                    mat[position.Rank, position.File] = true;
                }
                position.DefineValues(position.Rank - 1, position.File + 1);
                if (Tab.ValidPosition(position) && Free(position))
                {
                    mat[position.Rank, position.File] = true;
                }
            }
            else
            {
                position.DefineValues(position.Rank + 1, position.File);
                if (Tab.ValidPosition(position) && Free(position))
                {
                    mat[position.Rank, position.File] = true;
                }
                position.DefineValues(position.Rank + 2, position.File);
                if (Tab.ValidPosition(position) && Free(position) && NumberOfMoves == 0)
                {
                    mat[position.Rank, position.File] = true;
                }
                position.DefineValues(position.Rank + 1, position.File - 1);
                if (Tab.ValidPosition(position) && Free(position))
                {
                    mat[position.Rank, position.File] = true;
                }
                position.DefineValues(position.Rank + 1, position.File + 1);
                if (Tab.ValidPosition(position) && Free(position))
                {
                    mat[position.Rank, position.File] = true;
                }
            }
            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}