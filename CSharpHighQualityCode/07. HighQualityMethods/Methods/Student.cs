namespace Methods
{
    using System;

    public class Student
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string additionalInfo;

        public Student(string firstName, string lastName, DateTime dateOfBirth)
            : this(firstName, lastName, dateOfBirth, string.Empty)
        {
        }

        public Student(string firstName, string lastName, DateTime dateOfBirth, string additionalInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.AdditionalInfo = additionalInfo;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.lastName = value;
            }
        }

        public DateTime DateOfBirth 
        {
            get
            {
                return this.dateOfBirth;
            }

            set
            {
                this.dateOfBirth = value;
            }
        }

        public string AdditionalInfo
        {
            get
            {
                return this.additionalInfo;
            }

            set
            {
                this.additionalInfo = value;
            }
        }

        public bool IsOlderThan(Student other)
        {
            bool isOlder = true;

            if (this.DateOfBirth > other.DateOfBirth)
            {
                isOlder = false;
            }

            return isOlder;
        }
    }
}
