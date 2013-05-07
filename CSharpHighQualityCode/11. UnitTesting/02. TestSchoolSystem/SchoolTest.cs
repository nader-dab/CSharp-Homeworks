namespace _02.TestSchoolSystem
{
    using System;
    using System.Collections.Generic;
    using _01.School;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void TestSchoolCourseCount()
        {
            IList<Student> students = new List<Student>() 
            {
                new Student("Pesho", 10002),
                new Student("Gosho", 20003),
                new Student("Mariq", 30004),
                new Student("Pettq", 10042)
            };

            Course course = new Course(students);
            IList<Course> courses = new List<Course>() { course };
            School school = new School(courses);
            Assert.AreEqual(1, school.Courses.Count, "Expected to count 1 school course.");
        }

        [TestMethod]
        public void TestSchoolAddingCourse()
        {
            IList<Student> students = new List<Student>() 
            {
                new Student("Pesho", 10002),
                new Student("Gosho", 20003),
                new Student("Mariq", 30004),
                new Student("Pettq", 10042)
            };

            Course course = new Course(students);
            School school = new School(new List<Course>());
            school.AddCourse(course);
            Assert.AreEqual(1, school.Courses.Count, "Expected to count 1 school course.");
        }

        [TestMethod]
        public void TestSchoolRemovingCourse()
        {
            IList<Student> students = new List<Student>() 
            {
                new Student("Pesho", 10002),
                new Student("Gosho", 20003),
                new Student("Mariq", 30004),
                new Student("Pettq", 10042)
            };

            Course course = new Course(students);
            School school = new School(new List<Course>());
            school.AddCourse(course);
            school.RemoveCourse(course);
            Assert.AreEqual(0, school.Courses.Count, "Expected to count 1 school course.");
        }
    }
}
