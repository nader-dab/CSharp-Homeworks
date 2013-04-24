namespace TetrisLibrary
{
    using System;

    public class GameField
    {
        public const int WIDTH = 10;
        public const int HEIGTH = 20;

        private int[,] field = new int[HEIGTH, WIDTH];

        public GameField()
        { 
        }

        public int[,] Field
        {
            get
            {
                return this.field;
            }
            set
            {
                this.field = value;
            }
        }
    }
}
