namespace SinksCommonLibrary
{
    public class Plus : Figure
    {
        public Plus()
        {
            this.Form = new int[,] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } };
            this.Center = new Position(1, 1);
        }
    }
}
