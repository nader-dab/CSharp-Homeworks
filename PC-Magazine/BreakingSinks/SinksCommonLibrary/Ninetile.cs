namespace SinksCommonLibrary
{
    public class Ninetile : Figure
    {
        public Ninetile()
        {
            this.Form = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };

            this.Center = new Position(1, 1);
        }
    }
}
