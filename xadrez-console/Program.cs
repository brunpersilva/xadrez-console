using System;
using xadrez_console.tabuleiro;
namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);
            Cor cor = new Cor();
            Posicao pos = new Posicao(7, 5);
            Peca peca = new Peca(pos, cor, tab);

        } 
    }
}
