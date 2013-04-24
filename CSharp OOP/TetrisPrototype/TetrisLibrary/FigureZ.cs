namespace TetrisLibrary
{
    public class FigureZ : Figure
    {
        public FigureZ(int x, int y)
            : base(x, y, new int[,] { { 7, 7, 0 }, { 0, 7, 7 } })
        {
        }
    }
}
