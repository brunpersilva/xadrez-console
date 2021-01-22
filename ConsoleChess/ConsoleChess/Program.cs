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
                ChessGame game = new ChessGame();


                Screen.PrintBoard(game.Board);
            }
            catch (BoardExceptions e)
            {

                Console.WriteLine(e.Message);
            }

            Console.Read();
        }
    }
}
