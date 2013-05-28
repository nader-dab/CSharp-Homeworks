namespace _03.SimpleFactory
{
    class FigureT : Figure
    {
        public FigureT()
            :base(new int[,] { {0, 1, 0 }, { 1, 1, 1} })
        {
        }
    }
}
