namespace TetrisLibrary
{
    public class FigureS : Figure
    {
        public FigureS(int x, int y)
            : base(x, y, new int[,] { { 0, 5, 5 }, { 5, 5, 0 } })
        {
        }
    }
}
