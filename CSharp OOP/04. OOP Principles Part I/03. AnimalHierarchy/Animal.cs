namespace _03.AnimalHierarchy
{
    public abstract class Animal : ISound
    {
        private byte age;
        private string name;
        private Gender sex;

        public Animal(byte age, string name, Gender sex)
        {
            this.Age = age;
            this.Name = name;
            this.Sex = sex;
        }

        public Gender Sex
        {
            get
            {
                return this.sex;
            }

            set
            {
                this.sex = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public byte Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.age = value;
            }
        }

        public abstract void MakeSound();
    }
}
