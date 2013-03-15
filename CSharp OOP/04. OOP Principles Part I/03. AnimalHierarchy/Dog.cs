namespace _03.AnimalHierarchy
{
    public class Dog : Animal
    {
        public Dog(byte age, string name, Gender sex)
            : base(age, name, sex)
        {
        }

        public override void MakeSound()
        {
            System.Console.WriteLine("Bau!!!");
        }
    }
}
