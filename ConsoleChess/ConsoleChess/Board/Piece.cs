using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    abstract class Piece
    {
        public Position PiecePosition { get; set; }
        public Color Color { get; protected set; }
        public int NumberOfMoves { get; protected set; }
        public Board Tab { get; protected set; }

        public Piece(Board chessBoard, Color color)
        {
            PiecePosition = null;
            Color = color;
            Tab = chessBoard;
            NumberOfMoves = 0;
        }
        public void IncrementMovement()
        {
            NumberOfMoves++;
        }
        public  bool IsTherePossibleMoves()
        {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < Tab.Ranks; i++)
            {
                for (int j = 0; j < Tab.Files; j++)
                {
                    if (mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }   
        public bool CanMove(Position pos)
        {
            return PossibleMoves()[pos.Rank, pos.File];
        }
        public abstract bool[,] PossibleMoves();

         
    }
}
