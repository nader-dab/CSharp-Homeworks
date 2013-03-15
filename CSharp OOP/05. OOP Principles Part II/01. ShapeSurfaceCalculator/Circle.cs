namespace _01.ShapeSurfaceCalculator
{
    using System;

    public class Circle : Shape
    {
        public Circle(double radius)
            : base(radius * 2, radius * 2)
        { 
        }

        public override double CalculateSerface()
        {
            return Math.PI * Math.Pow(this.Width / 2, 2); 
        }
    }
}
