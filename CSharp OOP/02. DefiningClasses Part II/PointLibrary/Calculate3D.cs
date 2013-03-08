namespace PointLibrary
{
    using System;

    public static class Calculate3D
    {
        public static int Distance(Point3D firstPoint, Point3D secondPoint)
        {
            var distanceX = firstPoint.X - secondPoint.X;
            var distanceY = firstPoint.Y - secondPoint.Y;
            var distanceZ = firstPoint.Z - secondPoint.Z;
            var distance3D = Math.Sqrt((distanceX * distanceX) + (distanceY * distanceY) + (distanceZ * distanceZ));
            return (int)distance3D;
        }
    }
}