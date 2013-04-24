using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    class Wolf : Animal, ICarnivore
    {
        public Wolf(string name, Point location)
            : base(name, location, 4)
        {
        }


        public int TryEatAnimal(Animal animal)
        {
            if (animal!= null)
            {
                if (animal.State == AnimalState.Sleeping || this.Size >= animal.Size)
                {
                    return animal.GetMeatFromKillQuantity();
                }
            }
            return 0;
            
        }
    }
}
