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
        public Board tab { get; protected set; }

        public Piece(Board chessBoard, Color color)
        {
            PiecePosition = null;
            Color = color;
            tab = chessBoard;
            NumberOfMoves = 0;
        }
        public void IncrementMovement()
        {
            NumberOfMoves++;
        }

        public abstract bool[,] PossibleMoves();

         
    }
}
