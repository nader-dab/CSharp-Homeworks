using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class TrailObject : GameObject
    {
        // Task 5
        private int lifetime;

        public TrailObject( MatrixCoords topLeft, char[,] body, int lifetime)
            : base(topLeft, body)
        {
            this.Lifetime = lifetime;
        }

        public int Lifetime
        {
            get
            {
                return this.lifetime;
            }
            set
            {
                this.lifetime = value;
            }
        }

        public override void Update()
        {
            this.Lifetime--;
            if (this.Lifetime <= 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
