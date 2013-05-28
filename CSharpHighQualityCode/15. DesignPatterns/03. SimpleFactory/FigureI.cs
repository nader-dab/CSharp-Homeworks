namespace _03.SimpleFactory
{
    class FigureI : Figure
    {
        public FigureI()
            :base(new int[,] { { 1, 1, 1, 1 } })
        {
        }
    }
}
