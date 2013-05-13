namespace SinksCommonLibrary
{
    public class AngleDR : Figure
    {
        public AngleDR()
        {
            this.Form = new int[,] { { 1, 0 }, { 1, 1 } };
            this.Center = new Position(1, 0);
        }
    }
}