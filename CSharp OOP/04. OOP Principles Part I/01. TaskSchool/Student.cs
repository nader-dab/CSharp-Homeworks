namespace _01.TaskSchool
{
    public class Student : Person
    {
        private string classNumber;

        public Student(string name, string classNumber)
            : base(name)
        {
            this.ClassNumber = classNumber;
        }

        public string ClassNumber
        {
            get
            {
                return this.classNumber;
            }

            set
            {
                this.classNumber = value;
            }
        }
    }
}
