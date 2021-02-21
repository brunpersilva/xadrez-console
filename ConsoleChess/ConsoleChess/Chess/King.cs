using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using board;

namespace chess
{
    public class King : Piece
    {
        private readonly ChessGame _match;
        public King(Board boar, Color color, ChessGame match) : base(boar, color)
        {
            _match = match;
        }

        private bool CanMove(Position pos)
        {
            Piece p = Tab.Piece(pos);
            return p == null || p.Color != Color;
        }
        private bool CastleTest(Position pos)
        {
            Piece p = Tab.Piece(pos);
            return p != null && p is Rook && p.Color == Color && p.NumberOfMoves == 0;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Tab.Ranks, Tab.Files];

            Position position = new Position(0, 0);

            //up
            position.DefineValues(PiecePosition.Rank - 1, PiecePosition.File);
            if (Tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }

            //ne
            position.DefineValues(PiecePosition.Rank - 1, PiecePosition.File + 1);
            if (Tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }
            //right
            position.DefineValues(PiecePosition.Rank, PiecePosition.File + 1);
            if (Tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }

            //se
            position.DefineValues(PiecePosition.Rank + 1, PiecePosition.File + 1);
            if (Tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }
            //left
            position.DefineValues(PiecePosition.Rank, PiecePosition.File - 1);
            if (Tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }
            //down
            position.DefineValues(PiecePosition.Rank + 1, PiecePosition.File);
            if (Tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }
            //sw
            position.DefineValues(PiecePosition.Rank + 1, PiecePosition.File - 1);
            if (Tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }
            //nw
            position.DefineValues(PiecePosition.Rank - 1, PiecePosition.File - 1);
            if (Tab.ValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }


            // #Special Move King Side Castle
            if (NumberOfMoves == 0 && !_match.Check)
            {
                Position KingSideRook = new Position(position.Rank, position.File + 3);
                if (CastleTest(KingSideRook))
                {
                    Position p1 = new Position(position.Rank, position.File + 1);
                    Position p2 = new Position(position.Rank, position.File + 2);
                    if (Tab.Piece(p1) == null && Tab.Piece(p2) == null)
                    {
                        mat[position.Rank, position.File + 2] = true;
                    }
                }
            }

            // #Special Move Queen Side Castle
            if (NumberOfMoves == 0 && !_match.Check)
            {
                Position QueenSideRook = new Position(position.Rank, position.File - 4);
                if (CastleTest(QueenSideRook))
                {
                    Position p1 = new Position(position.Rank, position.File - 1);
                    Position p2 = new Position(position.Rank, position.File - 2);
                    Position p3 = new Position(position.Rank, position.File - 3);
                    if (Tab.Piece(p1) == null && Tab.Piece(p2) == null && Tab.Piece(p3) == null)
                    {
                        mat[position.Rank, position.File - 2] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
