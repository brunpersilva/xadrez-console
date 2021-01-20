using System;
using board;
using chess;

namespace ConsoleChess
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Board bor = new Board(8, 8);

                bor.PlacePiece(new Rook(bor, Color.White), new Position(0, 0));
                bor.PlacePiece(new Rook(bor, Color.Black), new Position(1, 7));
                bor.PlacePiece(new King(bor, Color.Black), new Position(0, 2));

                Screen.PrintBoard(bor);
            }
            catch (BoardExceptions e)
            {

                Console.WriteLine(e.Message);
            }
            ChessPosition pos = new ChessPosition('c', 7);
            Console.WriteLine(pos);
            Console.WriteLine(pos.ToPosition());

            Console.Read();
        }
    }
}
