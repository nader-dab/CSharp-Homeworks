namespace _03.AnimalHierarchy
{
    using System;
    using System.Linq;

    public class MainProgram
    {
        public static void Main(string[] args)
        {
            var cats = new Cat[]
            {
                new Cat(25, "Mufasa", Gender.Male),
                new Kitten(5, "Butch"),
                new Tomcat(5, "Snowball"),
            };

            Console.WriteLine("Avarage cat years {0:0.0}", cats.Average(x => x.Age));

            var dogs = new Dog[]
            {
                new Dog(7, "Sharo", Gender.Male),
                new Dog(5, "Strela", Gender.Female),
                new Dog(5, "Droopy", Gender.Male),
            };

            Console.WriteLine("Avarage dog years {0:0.0}", dogs.Average(x => x.Age));

            var animalKingdom = new Animal[]
            {
                new Dog(7, "Sharo", Gender.Male),
                new Dog(5, "Strela", Gender.Female),
                new Frog(65, "Kermit", Gender.Male),
                new Cat(25, "Mufasa", Gender.Male),
                new Kitten(5, "Butch"),
                new Tomcat(5, "Snowball"),
                new Dog(5, "Droopy", Gender.Male),
            };

            foreach (var animal in animalKingdom)
            {
                animal.MakeSound();
            }
        }
    }
}
