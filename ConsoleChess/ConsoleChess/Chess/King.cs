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

            Position pos = new Position(0, 0);

            //up
            pos.DefineValues(PiecePosition.Rank - 1, PiecePosition.File);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
            }

            //ne
            pos.DefineValues(PiecePosition.Rank - 1, PiecePosition.File + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
            }
            //right
            pos.DefineValues(PiecePosition.Rank, PiecePosition.File + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
            }

            //se
            pos.DefineValues(PiecePosition.Rank + 1, PiecePosition.File + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
            }
            //left
            pos.DefineValues(PiecePosition.Rank, PiecePosition.File - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
            }
            //down
            pos.DefineValues(PiecePosition.Rank + 1, PiecePosition.File);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
            }
            //sw
            pos.DefineValues(PiecePosition.Rank + 1, PiecePosition.File - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
            }
            //nw
            pos.DefineValues(PiecePosition.Rank - 1, PiecePosition.File - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Rank, pos.File] = true;
            }


            // #Special Move King Side Castle
            if (NumberOfMoves == 0 && !_match.Check)
            {
                Position KingSideRook = new Position(PiecePosition.Rank, PiecePosition.File + 3);
                if (CastleTest(KingSideRook))
                {
                    Position p1 = new Position(PiecePosition.Rank, PiecePosition.File + 1);
                    Position p2 = new Position(PiecePosition.Rank, PiecePosition.File + 2);
                    if (Tab.Piece(p1) == null && Tab.Piece(p2) == null)
                    {
                        mat[pos.Rank, pos.File + 2] = true;
                    }
                }
                // #Special Move Queen Side Castle
                Position QueenSideRook = new Position(PiecePosition.Rank, PiecePosition.File - 4);
                if (CastleTest(QueenSideRook))
                {
                    Position p1 = new Position(PiecePosition.Rank, PiecePosition.File - 1);
                    Position p2 = new Position(PiecePosition.Rank, PiecePosition.File - 2);
                    Position p3 = new Position(PiecePosition.Rank, PiecePosition.File - 3);
                    if (Tab.Piece(p1) == null && Tab.Piece(p2) == null && Tab.Piece(p3) == null)
                    {
                        mat[pos.Rank, pos.File - 2] = true;
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
