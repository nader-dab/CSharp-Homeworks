namespace PointProgram
{
    using System;
    using System.Linq;
    using PointLibrary;

    // Tasks 1,2,3,4
    public class PointProgram
    {
        public static void Main(string[] args)
        {
            // Creating and printing points
            Point3D pointOne = new Point3D(1, 3, 3);
            Point3D pointTwo = new Point3D(4, 6, -7);
            Console.WriteLine(pointOne);
            Console.WriteLine(Point3D.StartCoord);

            // Calculating distance between two point
            var distance = Calculate3D.Distance(pointOne, Point3D.StartCoord);
            Console.WriteLine("Distance: {0}", distance);

            // Holding sequence of points
            Path sequence = new Path(pointTwo, Point3D.StartCoord, pointOne, pointTwo);
            sequence.AddPoint(new Point3D(14, 14, 22));
            sequence.RemovePoint(0);
            Console.WriteLine(sequence);

            // Saving sequence to file
            PathStorage.Save(sequence, "save.txt");

            // Loading seqence from file
            Console.WriteLine("Loading sequence from file");
            Path loadSequence = new Path();
            PathStorage.Load("save.txt", loadSequence);
            Console.WriteLine(loadSequence);
        }
    }
}