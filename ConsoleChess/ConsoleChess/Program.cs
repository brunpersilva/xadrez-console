using System;
using board;
using chess;

namespace ConsoleChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board bor = new Board(8, 8);

            bor.PlacePiece(new Rook(bor, Color.Black), new Position(0, 0));
            bor.PlacePiece(new Rook(bor, Color.Black), new Position(1, 3));
            bor.PlacePiece(new King(bor, Color.Black), new Position(2, 4));

            Screen.PrintBoard(bor);

            Console.Read();
        }
    }
}
