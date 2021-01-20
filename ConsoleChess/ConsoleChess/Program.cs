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

                bor.PlacePiece(new Rook(bor, Color.Black), new Position(0, 0));
                bor.PlacePiece(new Rook(bor, Color.Black), new Position(1, 6));
                bor.PlacePiece(new King(bor, Color.Black), new Position(0, 2));

                Screen.PrintBoard(bor);
            }
            catch (BoardExceptions e)
            {

                Console.WriteLine(e.Message);
            }

            Console.Read();
        }
    }
}
