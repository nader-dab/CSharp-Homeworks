using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ShootingRacket : Racket
    {
        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        { 
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<Bullet> bullets = new List<Bullet>();
            bullets.Add( new Bullet( this.topLeft, new MatrixCoords(-1,0)));
            return bullets;
        }

    }
}
