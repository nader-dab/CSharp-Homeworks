namespace _03.SimpleFactory
{
    public interface IFigure
    {
        int[,] Form { get; set; }

        void Render();

        void Rotate();
    }
}