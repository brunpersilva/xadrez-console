using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using board;

namespace ConsoleChess
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rank; i++)
            {
                for (int j = 0; j < board.File; j++)
                {
                    if (board.piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    Console.Write(board.piece(i,j) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
