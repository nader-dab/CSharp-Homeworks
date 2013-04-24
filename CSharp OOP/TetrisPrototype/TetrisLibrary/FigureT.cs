namespace TetrisLibrary
{
    public class FigureT : Figure
    {
        public FigureT(int x, int y)
            : base(x, y, new int[,] { { 0, 6, 0 } , {6, 6, 6} })
        { 
        }
    }
}
