using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string courseName)
            : this(courseName, string.Empty)
        {
        }

        public OffsiteCourse(string courseName, string teacherName)
            :this(courseName, teacherName, new List<string>())
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName, students, string.Empty)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
            this.Town = town;
        }

        public string Town { get; set; }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            if (this.Town != null && !string.IsNullOrEmpty(this.Town))
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }
            result.Append(" }");

            return result.ToString();
        }


        
    }
}
