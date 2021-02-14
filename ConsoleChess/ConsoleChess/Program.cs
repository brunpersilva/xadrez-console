using System;
using board;
using chess;

namespace ConsoleChess
{
    class Program
    {
        static void Main()
        {

            try
            {
                ChessGame game = new ChessGame();

                while (!game.FinishedGame)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintBoard(game.Board);
                        Console.WriteLine();
                        Console.WriteLine("Turn: " + game.Turn);
                        Console.WriteLine("Waiting move from: " + game.CurrentPlayer);

                        Console.WriteLine();
                        Console.Write("Origen: ");
                        Position origin = Screen.ReadChessPosition().ToPosition();
                        game.ValidateOriginPosition(origin);

                        bool[,] possiblePosition = game.Board.Piece(origin).PossibleMoves();

                        Console.Clear();
                        Screen.PrintBoard(game.Board, possiblePosition);

                        Console.WriteLine();
                        Console.Write("Destination: ");
                        Position destination = Screen.ReadChessPosition().ToPosition();
                        game.ValidateDestinationPosition(origin, destination);

                        game.MakeMovment(origin, destination);
                    }
                    catch (BoardExceptions ex)
                    {

                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
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
