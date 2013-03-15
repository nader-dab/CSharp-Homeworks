namespace _01.ShapeSurfaceCalculator
{
    public class Triagle : Shape
    {
        public Triagle(double width, double heigth)
            : base(width, heigth)
        { 
        }

        public override double CalculateSerface()
        {
            return (this.Width * this.Heigth) / 2;
        }
    }
}
