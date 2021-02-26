using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using board;

namespace chess
{
    class Rook : Piece
    {
        public Rook(Board chessBoard, Color color) : base(chessBoard, color)
        {
        }

        public override string ToString()
        {
            return "R";
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

            //up
            pos.DefineValues(PiecePosition.Rank -1, PiecePosition.File);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Rank--;
            }

            //down
            pos.DefineValues(PiecePosition.Rank, PiecePosition.File+1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Rank++;
            }
            //right
            pos.DefineValues(PiecePosition.Rank, PiecePosition.File + 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.File++;
            }

            //left
            pos.DefineValues(PiecePosition.Rank, PiecePosition.File - 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.File--;
            }
            return mat;
        }
    }
}