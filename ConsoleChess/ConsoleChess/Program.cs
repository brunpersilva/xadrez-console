using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using board;

namespace ConsoleChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board bor = new Board(8, 8);

            Screen.PrintBoard(bor);
            Console.Read();
        }
    }
}
