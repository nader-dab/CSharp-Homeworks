namespace SinksCommonLibrary
{
    public class Hline : Figure
    {
        public Hline()
        {
            this.Form = new int[,] { { 1, 1, 1 } };
            this.Center = new Position(0, 1);
        }
    }
}
