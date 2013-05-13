namespace SinksCommonLibrary
{
    public class AngleUL : Figure
    {
        public AngleUL()
        {
            this.Form = new int[,] { { 1, 1 }, { 0, 1 } };
            this.Center = new Position(0, 1);
        }
    }
}
