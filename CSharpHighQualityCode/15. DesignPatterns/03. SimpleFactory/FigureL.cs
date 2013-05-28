namespace _03.SimpleFactory
{
    class FigureL : Figure
    {
        public FigureL()
            :base(new int[,] { { 0, 0, 1 }, { 1, 1, 1 } })
        {
        }
    }
}
