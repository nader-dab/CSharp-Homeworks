using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Task 8, 9
    class UnpassableBlock : IndestructibleBlock
    {
        public new const string CollisionGroupString = "unpassableBlock";

        public UnpassableBlock(MatrixCoords topLeft)
            : base(topLeft)
        { 
        }

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }
    }
}
