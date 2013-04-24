namespace AcademyPopcorn
{
    using System.Collections.Generic;

    class MeteoriteBall : Ball, IObjectProducer
    {
        private char[,] trail = new char[,] { { '*' } };
        private const int lifetime = 3;
        // Task 6
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        { 
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<TrailObject> tail = new List<TrailObject>();
            tail.Add(new TrailObject(this.topLeft, trail, lifetime));
            return tail;
        }
    }
}
