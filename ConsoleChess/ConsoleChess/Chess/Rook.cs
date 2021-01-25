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
            Piece p = tab.Piece(pos);
            return p == null || p.Color != Color;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[tab.Ranks, tab.Files];

            Position position = new Position(0, 0);

            //up
            position.DefineValues(PiecePosition.Rank -1, PiecePosition.File);
            while (tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
                if (tab.Piece(position) != null && tab.Piece(position).Color != Color)
                {
                    break;
                }
                position.Rank--;
            }

            //down
            position.DefineValues(PiecePosition.Rank, PiecePosition.File+1);
            while (tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
                if (tab.Piece(position) != null && tab.Piece(position).Color != Color)
                {
                    break;
                }
                position.Rank++;
            }
            //right
            position.DefineValues(PiecePosition.Rank, PiecePosition.File + 1);
            while (tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
                if (tab.Piece(position) != null && tab.Piece(position).Color != Color)
                {
                    break;
                }
                position.File++;
            }

            //left
            position.DefineValues(PiecePosition.Rank, PiecePosition.File - 1);
            while (tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
                if (tab.Piece(position) != null && tab.Piece(position).Color != Color)
                {
                    break;
                }
                position.File--;
            }
            return mat;
        }
    }
}