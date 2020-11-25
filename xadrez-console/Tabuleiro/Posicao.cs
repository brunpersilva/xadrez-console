namespace xadrez_console.tabuleiro
{
    class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public Posicao(int linha, int coluna)
        {
            Coluna = coluna;
            Linha = linha;

        }
        public override string ToString()
        {
            return Linha
                + ", "
                + Coluna; 
        }

    }
}
