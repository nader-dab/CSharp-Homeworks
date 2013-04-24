namespace TetrisLibrary
{
    public struct Coordinates
    {
        private int x;
        private int y;

        public Coordinates(int x = 0, int y = 0)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }
    }
}
