namespace _01.School
{
    using System;

    public class Student
    {
        public const int MinUniqueNumber = 10000;
        public const int MaxUniqueNumber = 99999;
        private string name = string.Empty;
        private int number = 0;

        public Student(string name, int number)
        {
            this.Name = name;
            this.Number = number;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid student name. Names cannot be empty or consist of white-space characters.");
                }

                this.name = value;
            }
        }

        public int Number 
        { 
            get
            {
                return this.number;
            }
            
            set 
            {
                if (value < MinUniqueNumber)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The students unique number cannot be smaller than {0}", MinUniqueNumber));
                }

                if (value > MaxUniqueNumber)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The students unique number cannot be greater than {0}", MaxUniqueNumber));
                }

                this.number = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Name, this.Number);
        }
    }
}
