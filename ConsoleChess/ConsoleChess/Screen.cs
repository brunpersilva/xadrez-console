using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using board;
using chess;

namespace ConsoleChess
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Ranks; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Files; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        internal static void PrintGame(ChessGame game)
        {
            PrintBoard(game.Board);
            Console.WriteLine();
            PrintCapturedPieces(game);
            Console.WriteLine("Turn: " + game.Turn);
            Console.WriteLine("Waiting move from: " + game.CurrentPlayer);

            if (game.Check)
            {
                Console.WriteLine("Check!");  
            }
        }

        private static void PrintCapturedPieces(ChessGame game)
        {
            Console.WriteLine("Capt ured Pieces:");
            Console.Write($"White: "); 
            PrintSet(game.CapturedPiece(Color.White));
            Console.Write($"Black: ");
            ConsoleColor helper = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(game.CapturedPiece(Color.Black));
            Console.ForegroundColor = helper;

            Console.WriteLine();
        }

        private static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece piece in set)
            {
                Console.Write(piece+ " ");
            }
            Console.WriteLine("]");
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackgroundColor = Console.BackgroundColor;
            ConsoleColor alteredBackgroundColor = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Ranks; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Files; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = alteredBackgroundColor;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackgroundColor;
                    }

                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalBackgroundColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = originalBackgroundColor;
        }
        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char file = s[0];
            int rank = int.Parse(s[1] + "");
            return new ChessPosition(file, rank);
        }
        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
