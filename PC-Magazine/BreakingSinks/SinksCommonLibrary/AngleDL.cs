namespace SinksCommonLibrary
{
    public class AngleDL : Figure
    {
        public AngleDL()
        {
            this.Form = new int[,] { { 0, 1 }, { 1, 1 } };
            this.Center = new Position(1, 1);
        }
    }
}