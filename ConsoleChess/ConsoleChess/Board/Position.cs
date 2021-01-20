namespace board
{
    class Position
    {
        public int File { get; set; }
        public int Rank { get; set; }

        public Position(int file, int rank)
        {
            File = file;
            Rank = rank;
        }

        public override string ToString()
        {
            return Rank 
                + ", " 
                + File;
        }
    }
}
