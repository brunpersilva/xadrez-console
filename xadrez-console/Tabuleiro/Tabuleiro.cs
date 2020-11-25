namespace xadrez_console.tabuleiro
{
    class Tabuleiro
    {
        public int Colunas { get; set; }
        public int Linhas { get; set; }
        public Peca[,] Pieces;
        public Tabuleiro(int colunas, int linhas)
        {
            Colunas = colunas;
            Linhas = Linhas;
            Pieces = new Peca[Linhas, Colunas];
        }


    }


}
