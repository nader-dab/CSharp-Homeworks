namespace _03.AnimalHierarchy
{
    public class Cat : Animal
    {
        public Cat(byte age, string name, Gender sex)
            : base(age, name, sex)
        { 
        }

        public override void MakeSound()
        {
            System.Console.WriteLine("Miau!!!");
        }
    }
}
