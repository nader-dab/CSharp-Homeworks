using System;
namespace TetrisLibrary
{
    public abstract class Figure : IFallable, IMovable, IRotatable
    {
        private int[,] form;
        private Coordinates position;
        private bool canFall = true;

        public Figure(int x, int y, int[,] form)
        {
            this.Position = new Coordinates(x, y);
            this.Form = form;
        }

        public bool CanFall
        {
            get
            {
                return this.canFall;
            }
            set
            {
                this.canFall = value;
            }
        }

        public Coordinates Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        public int PositionX
        {
            get
            {
                return this.Position.X;
            }
            set
            {
                this.Position = new Coordinates(value, this.Position.Y);
            }
        }

        public int PositionY
        {
            get
            {
                return this.Position.Y;
            }
            set
            {
                this.Position = new Coordinates(this.Position.X, value);
            }
        }

        public int[,] Form
        {
            get
            {
                return this.form;
            }
            set
            {
                this.form = value;
            }
        }

        public void Fall()
        {
            if (this.canFall == true)
            {
                this.PositionX += 1;
            }
        }

        public void MoveLeft()
        {
            this.PositionY--;
        }

        public void MoveRight()
        {
            this.PositionY++;
        }

        public void RotateR()
        {
            int[,] block = this.form;
            int w = this.Form.GetUpperBound(0) + 1;
            int h = this.Form.GetUpperBound(1) + 1;
            int[,] rotated = new int[h, w];
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    rotated[j, w - i - 1] = block[i, j];
                }
            }
            this.Form = rotated;
        }
    }
}
