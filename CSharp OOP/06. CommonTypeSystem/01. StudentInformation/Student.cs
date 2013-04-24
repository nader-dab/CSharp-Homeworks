namespace _01.StudentInformation
{
    using System;

    public class Student : ICloneable, IComparable<Student>
    {
        // Private Fields
        private string firstName;
        private string middleName;
        private string lastName;
        private long ssn;
        private string address;
        private string phone;
        private string email;
        private string course;
        private Specialties specialty;
        private Universities university;
        private Faculties faculty;

        // Constructor
        public Student(string firstName, string middleName, string lastName, long ssn, string address, string phone, string email, string course, Specialties specialty, Universities university, Faculties faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Ssn = ssn;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        // Public Properties
        public Faculties Faculty
        {
            get
            {
                return this.faculty;
            }

            set
            {
                this.faculty = value;
            }
        }

        public Universities University
        {
            get
            {
                return this.university;
            }

            set
            {
                this.university = value;
            }
        }

        public Specialties Specialty
        {
            get
            {
                return this.specialty;
            }

            set
            {
                this.specialty = value;
            }
        }

        public string Course
        {
            get
            {
                return this.course;
            }

            set
            {
                this.course = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }

            set
            {
                this.phone = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                this.address = value;
            }
        }

        public long Ssn
        {
            get
            {
                return this.ssn;
            }

            set
            {
                this.ssn = value;
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

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            set
            {
                this.middleName = value;
            }
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

        public static bool operator ==(Student s1, Student s2)
        {
            return Student.Equals(s1, s2);
        }

        public static bool operator !=(Student s1, Student s2)
        {
            return !Student.Equals(s1, s2);
        }

        // Overriding Equals()
        public override bool Equals(object param)
        {
            if (!(param is Student))
            {
                return false;
            }

            Student student = param as Student;

            if (!object.Equals(this.FirstName, student.FirstName))
            {
                return false;
            }

            if (!object.Equals(this.MiddleName, student.MiddleName))
            {
                return false;
            }

            if (!object.Equals(this.LastName, student.LastName))
            {
                return false;
            }

            if (!object.Equals(this.Ssn, student.Ssn))
            {
                return false;
            }

            return true;
        }

        // Overriding ToString()
        public override string ToString()
        {
            return string.Format(
                "Name: {0} {1} {2} \nSSN: {3} \nAddress: {4} \nPhone: {5} \nEmail: {6} \nCourse: {7} \nSpecialty: {8} \nUniversity: {9} \nFaculty: {10}",
                this.FirstName, 
                this.MiddleName, 
                this.LastName,  
                this.Ssn,
                this.Address,
                this.Phone,
                this.Email,
                this.Course,
                this.Specialty,
                this.University,
                this.Faculty);
        }

        // Overriding GetGachCode()
        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.Ssn.GetHashCode();
        }

        // Implementing Student Clone
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Student Clone()
        {
            Student original = this;
            string firstName = original.FirstName;
            string middleName = original.MiddleName;
            string lastName = original.LastName;
            long ssn = original.Ssn;
            string address = original.Address;
            string phone = original.Phone;
            string email = original.Email;
            string course = original.Course;
            Specialties specialty = original.Specialty;
            Universities university = original.University;
            Faculties faculty = original.Faculty;

            return new Student(firstName, middleName, lastName, ssn, address, phone, email, course, specialty, university, faculty);
        }

        // Implementing IComparable<Student>
        public int CompareTo(Student student)
        {
            if (this.FirstName != student.FirstName)
            { 
                return string.Compare(this.FirstName, student.FirstName);
            }

            if (this.MiddleName != student.MiddleName)
            {
                return string.Compare(this.FirstName, student.FirstName);
            }

            if (this.LastName != student.LastName)
            {
                return string.Compare(this.FirstName, student.FirstName);
            }

            if (this.Ssn != student.Ssn)
            {
                return this.Ssn.CompareTo(student.Ssn);
            }

            return 0;
        }
    }
}
