namespace _01.School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Course
    {
        public const int MaxStudentCapacity = 10;
        private IList<Student> students = new List<Student>();

        public Course(IList<Student> students)
        {
            this.Students = students;
        }

        public IList<Student> Students
        {
            get
            {
                return this.students;
            }

            private set
            {
                this.CheckForNumberOfStudents(value);
                this.CheckForDuplicatingStudents(value);

                this.students = value;
            }
        }

        public void Join(Student student)
        {
            var updatedList = this.Students;
            updatedList.Add(student);
            this.Students = updatedList;
        }

        public void Leave(Student student)
        {
            for (int i = 0; i < this.Students.Count; i++)
            {
                if (this.Students[i].Name == student.Name && this.Students[i].Number == student.Number)
                {
                    this.Students.RemoveAt(i);
                    i--;
                }
            }
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.Students);
        }
  
        private void CheckForDuplicatingStudents(IList<Student> students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                int uniqueNumbersCount = students.Count((x) => x.Number == students[i].Number);
                if (uniqueNumbersCount != 1)
                {
                    throw new ArgumentException("Cannot have more than one student with the same unique student number");
                }
            }
        }
  
        private void CheckForNumberOfStudents(IList<Student> students)
        {
            if (students.Count > MaxStudentCapacity)
            {
                throw new ArgumentOutOfRangeException(string.Format("The number of students for this course cannot exceed {0}", MaxStudentCapacity));
            }
        }
    }
}
