namespace PointLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Path
    {
        private List<Point3D> sequence = new List<Point3D>();

        public Path(params Point3D[] points)
        {
            foreach (var point in points)
            {
                this.Sequence.Add(point);
            }
        }

        private List<Point3D> Sequence
        {
            get
            {
                return this.sequence;
            }

            set
            {
                this.sequence = value;
            }
        }

        public void AddPoint(Point3D point)
        {
            this.Sequence.Add(point);
        }

        public void RemovePoint(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("Invalid position. Index should be greater than 0");
            }

            if (index >= this.Sequence.Count)
            {
                throw new ArgumentException(string.Format("Invalid position. Index should not be greater than {0}", this.Sequence.Count - 1));
            }

            this.Sequence.RemoveAt(index);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < this.Sequence.Count; index++)
            {
                sb.Append(this.Sequence[index]);
                if (index != this.Sequence.Count - 1)
                {
                    sb.Append("\n");
                }
            }

            return sb.ToString();
        }
    }
}
