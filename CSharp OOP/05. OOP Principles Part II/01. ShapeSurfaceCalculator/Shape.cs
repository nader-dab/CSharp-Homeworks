namespace _01.ShapeSurfaceCalculator
{
    using System;

    public abstract class Shape
    {
        private double width;
        private double heigth;

        public Shape(double width, double heigth)
        {
            this.Width = width;
            this.Heigth = heigth;
        }

        public double Heigth
        {
            get
            {
                return this.heigth;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot set figure dimensions to a negative value");
                }

                this.heigth = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot set figure dimensions to a negative value");
                }

                this.width = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{2} Width = {0} Heigth = {1}", this.Width, this.heigth, this.GetType().Name);
        }

        public abstract double CalculateSerface();
    }
}
