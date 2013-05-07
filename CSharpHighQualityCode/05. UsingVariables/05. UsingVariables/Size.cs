namespace _05.UsingVariables
{
    using System;

    public class Size
    {
        private double width;
        private double height;

        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
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
                this.width = value;
            }
        }

        public static Size GetRotatedSize(Size initialSize, double rotationAngle)
        {
            var rotationAngleCos = Math.Cos(rotationAngle);
            var widthCos = Math.Abs(rotationAngleCos) * initialSize.Width;
            var heightCos = Math.Abs(rotationAngleCos) * initialSize.Height;

            var rotationAngleSin = Math.Sin(rotationAngle);
            var witdhSin = Math.Abs(rotationAngleSin) * initialSize.Width;
            var heightSin = Math.Abs(rotationAngleSin) * initialSize.Height;

            var newWidth = widthCos + heightSin;
            var newHeight = witdhSin + heightCos;

            var result = new Size(newWidth, newHeight);

            return result;
        }
    }
}
