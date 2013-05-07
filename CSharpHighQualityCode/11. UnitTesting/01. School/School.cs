namespace _01.School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        public School(IList<Course> courses)
        {
            this.Courses = courses;
        }

        public IList<Course> Courses { get; set; }

        public void AddCourse(Course course)
        {
            this.Courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            this.Courses.Remove(course);
        }
    }
}
