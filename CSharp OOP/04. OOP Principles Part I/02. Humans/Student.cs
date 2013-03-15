namespace _02.Humans
{
    public class Student : Human
    {
        private byte grade;

        public Student(string firstName, string lastName, byte grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public byte Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                this.grade = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.FirstName, this.LastName, this.Grade);
        }
    }
}
