﻿using System;
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

                    Console.Write("Origen: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    Console.Write("Destination: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();

                    game.ExecuteMovement(origin, destination);
                }

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
