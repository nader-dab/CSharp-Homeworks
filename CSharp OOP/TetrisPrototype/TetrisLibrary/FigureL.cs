namespace TetrisLibrary
{
    public class FigureL : Figure
    {
        public FigureL(int x, int y)
            : base(x, y, new int[,] { { 0, 0, 3}, { 3, 3, 3 } })
        {
        }
    }
}
