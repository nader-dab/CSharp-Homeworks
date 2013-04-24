namespace TetrisLibrary
{
    public class FigureI : Figure
    {
        public FigureI(int x, int y)
            : base(x, y, new int[,] { { 1, 1, 1, 1 } })
        {
        }
    }
}
