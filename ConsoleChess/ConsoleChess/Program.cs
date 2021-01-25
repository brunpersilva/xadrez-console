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

                while (!game.FinishedGame)
                {
                    Console.Clear();
                    Screen.PrintBoard(game.Board);

                    Console.WriteLine();
                    Console.Write("Origen: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();

                    bool[,] possiblePosition = game.Board.Piece(origin).PossibleMoves();

                    Console.Clear();
                    Screen.PrintBoard(game.Board, possiblePosition);

                    Console.WriteLine();
                    Console.Write("Destination: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();

                    game.ExecuteMovement(origin, destination);
                }

                //Screen.PrintBoard(game.Board);
            }
            catch (BoardExceptions e)
            {

                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
