using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class Bullet : MovingObject
    {
        public Bullet(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] { { '\'' } }, speed)
        { 
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Block.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}
