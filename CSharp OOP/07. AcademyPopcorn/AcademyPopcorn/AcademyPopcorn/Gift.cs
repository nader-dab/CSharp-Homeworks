using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task 11
    class Gift : MovingObject
    {
        private new const string CollisionGroupString = "Gift";

        public Gift(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
            : base(topLeft, body, speed)
        { 
        }

        public override string GetCollisionGroupString()
        {
            return Gift.CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Racket.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

    }
}
