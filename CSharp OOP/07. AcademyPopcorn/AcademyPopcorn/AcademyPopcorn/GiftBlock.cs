using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class GiftBlock : Block, IObjectProducer
    {
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        { 
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<Gift> gift = new List<Gift>();
            if (this.IsDestroyed == true)
            {
                gift.Add(new Gift(this.topLeft, new char[,] {{'@'}}, new MatrixCoords(1, 0)));
            }
            return gift;
        }
    }
}
