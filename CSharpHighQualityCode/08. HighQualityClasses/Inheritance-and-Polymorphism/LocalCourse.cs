using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        public LocalCourse(string courseName)
            :this(courseName, string.Empty)
        {
        }

        public LocalCourse(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>())
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            :this(courseName, teacherName, students, string.Empty)
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
            this.Lab = lab;
        }

        public string Lab { get; set; }

        public override string ToString()
        {

            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            if (this.Lab != null && !string.IsNullOrEmpty(this.Lab))
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }
            result.Append(" }");

            return result.ToString();
        }
    }
}
