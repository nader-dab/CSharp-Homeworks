namespace GsmLibrary
{
    using System;
    using System.Linq;

    public class Display
    {
        private float displaySize;
        private int displayColors;
        
        public Display()
            : this(0, 0)
        {
        }

        public Display(float size, int colors)
        {
            this.Size = size;
            this.Colors = colors;
        }

        public int Colors
        {
            get
            {
                return this.displayColors;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Incorrect number of colors. Must be a positive number.");
                }
                else
                {
                    this.displayColors = value;
                }
            }
        }

        public float Size
        {
            get
            {
                return this.displaySize;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Incorrect display size. Must be a positive number.");
                }
                else
                {
                    this.displaySize = value;
                }
            }
        }

        public override string ToString()
        {
            string information = string.Format("Size: {0} \nColors: {1}", this.displaySize, this.displayColors);
            return information;
        }
    }
}
