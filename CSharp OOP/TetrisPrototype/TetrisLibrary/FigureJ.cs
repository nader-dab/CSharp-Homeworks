namespace TetrisLibrary
{
    public class FigureJ : Figure
    {
        public FigureJ(int x, int y)
            : base(x, y, new int[,] { { 2, 0, 0 }, { 2, 2, 2 } })
        {
        }
    }
}
