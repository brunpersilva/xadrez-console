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
        private readonly ChessGame _game;
        public Pawn(ChessGame game, Board board, Color color) : base(board, color)
        {
            _game = game;
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

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.DefineValues(PiecePosition.Rank - 1, PiecePosition.File);
                if (Tab.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Rank, pos.File] = true;
                }
                pos.DefineValues(PiecePosition.Rank - 2, PiecePosition.File);
                Position p2 = new Position(PiecePosition.Rank - 1, PiecePosition.File);
                if (Tab.ValidPosition(p2) && Free(p2) && Tab.ValidPosition(pos) && Free(pos) && NumberOfMoves == 0)
                {
                    mat[pos.Rank, pos.File] = true;
                }
                pos.DefineValues(PiecePosition.Rank - 1, PiecePosition.File - 1);
                if (Tab.ValidPosition(pos) && IsthereAdversary(pos))
                {
                    mat[pos.Rank, pos.File] = true;
                }
                pos.DefineValues(PiecePosition.Rank - 1, PiecePosition.File + 1);
                if (Tab.ValidPosition(pos) && IsthereAdversary(pos))
                {
                    mat[pos.Rank, pos.File] = true;
                }
                //en Passant
                if (PiecePosition.Rank == 3)
                {
                    Position left = new Position(PiecePosition.Rank, PiecePosition.File - 1);
                    if (Tab.ValidPosition(left) && IsthereAdversary(left) && Tab.Piece(left) == _game.VulnerableEnpassant)
                    {
                        mat[left.Rank - 1, left.File] = true;
                    }
                    Position right = new Position(PiecePosition.Rank, PiecePosition.File - 1);
                    if (Tab.ValidPosition(right) && IsthereAdversary(right) && Tab.Piece(right) == _game.VulnerableEnpassant)
                    {
                        mat[right.Rank - 1, right.File] = true;
                    }
                }
            }


            else
            {
                pos.DefineValues(PiecePosition.Rank + 1, PiecePosition.File);
                if (Tab.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Rank, pos.File] = true;
                }
                pos.DefineValues(PiecePosition.Rank + 2, PiecePosition.File);
                Position p2 = new Position(PiecePosition.Rank + 1, PiecePosition.File);
                if (Tab.ValidPosition(p2) && Free(p2) && Tab.ValidPosition(pos) && Free(pos) && NumberOfMoves == 0)
                {
                    mat[pos.Rank, pos.File] = true;
                }
                pos.DefineValues(PiecePosition.Rank + 1, PiecePosition.File - 1);
                if (Tab.ValidPosition(pos) && IsthereAdversary(pos))
                {
                    mat[pos.Rank, pos.File] = true;
                }
                pos.DefineValues(PiecePosition.Rank + 1, PiecePosition.File + 1);
                if (Tab.ValidPosition(pos) && IsthereAdversary(pos))
                {
                    mat[pos.Rank, pos.File] = true;
                }

                //en Passant
                if (PiecePosition.Rank == 4)
                {
                    Position left = new Position(PiecePosition.Rank, PiecePosition.File - 1);
                    if (Tab.ValidPosition(left) && IsthereAdversary(left) && Tab.Piece(left) == _game.VulnerableEnpassant)
                    {
                        mat[left.Rank + 1, left.File] = true;
                    }
                    Position right = new Position(PiecePosition.Rank, PiecePosition.File - 1);
                    if (Tab.ValidPosition(right) && IsthereAdversary(right) && Tab.Piece(right) == _game.VulnerableEnpassant)
                    {
                        mat[right.Rank + 1, right.File] = true;
                    }
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