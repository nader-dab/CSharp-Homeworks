namespace _01.ShapeSurfaceCalculator
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double heigth)
            : base(width, heigth)
        { 
        }

        public override double CalculateSerface()
        {
             return this.Width * this.Heigth;
        }
    }
}
