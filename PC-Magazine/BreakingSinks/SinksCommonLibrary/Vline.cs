namespace SinksCommonLibrary
{
    public class Vline : Figure
    {
        public Vline()
        {
            this.Form = new int[,] { { 1 }, { 1 }, { 1 } };
            this.Center = new Position(1, 0);
        }
    }
}
