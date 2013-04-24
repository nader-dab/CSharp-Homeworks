using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class TrialBall : Ball
    {
        private int lifetime = 1;

        public TrialBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        { 
        }

        public override void Update()
        {
            base.Update();
            this.lifetime--;
            if (this.lifetime <= 0)
            {
                this.IsDestroyed = true;
            }
            
        }
    }
}
