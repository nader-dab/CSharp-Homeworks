namespace _03.SimpleFactory
{
    class FigureS : Figure
    {
        public FigureS()
            :base(new int[,] { { 0, 1, 1 }, { 1, 1, 0 } })
        {
        }
    }
}
