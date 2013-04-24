using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block, IObjectProducer
    {
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        { 
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<TrialBall> explosion = new List<TrialBall>();
            if (this.IsDestroyed == true)
            {
                explosion.Add(new TrialBall(this.topLeft, new MatrixCoords(1, 1)));
                explosion.Add(new TrialBall(this.topLeft, new MatrixCoords(-1, 1)));
                explosion.Add(new TrialBall(this.topLeft, new MatrixCoords(1, -1)));
                explosion.Add(new TrialBall(this.topLeft, new MatrixCoords(-1, -1)));
            }

            return explosion;
        }
    }
}
