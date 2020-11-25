namespace xadrez_console.tabuleiro
{
    class Peca
    {
        public Posicao Position { get; set; }
        public Cor Color { get; protected set; }

        public int QtdMovimento { get; protected set; }

        public Tabuleiro Tab { get; protected set; }


        public Peca(Posicao position, Cor color, Tabuleiro tab)
        {
            Position = position;
            Color = color;
            QtdMovimento = 0;
            Tab = tab;
        }


    } 
}
