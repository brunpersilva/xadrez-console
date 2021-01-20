namespace Board
{
    public class Position
    {
        public int Rows { get; set; }
        public int Ranks { get; set; }

        public Position(int rowns, int ranks)
        {
            Rows = rowns;
            Ranks = ranks;
        }

        public override string ToString()
        {
            return Ranks + ", " + Rows;
        }
    }
}
