namespace _02.TestSchoolSystem
{
    using System;
    using System.Collections.Generic;
    using _01.School;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void TestCourseStudentCount()
        {
            IList<Student> students = new List<Student>() 
            {
                new Student("Pesho", 10002),
                new Student("Gosho", 20003),
                new Student("Mariq", 30004),
                new Student("Pettq", 10042)
            };

            Course course = new Course(students);

            Assert.AreEqual(4, course.Students.Count, "Expected to count 4 students.");
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestCourseAddingMoreThanOneStudentWithSameNumber()
        {
            IList<Student> students = new List<Student>() 
            {
                new Student("Pesho", 10002),
                new Student("Gosho", 20003),
                new Student("Mariq", 30004),
                new Student("Pettq", 10042)
            };

            Course course = new Course(students);

            course.Join(new Student("John", 20003));
        }

        [TestMethod]
        public void TestCourseStudentLeaving()
        {
            Student studentToRemove = new Student("Pesho", 34342);

            IList<Student> students = new List<Student>() 
            {
                new Student("Pesho", 10002),
                new Student("Gosho", 20003),
                new Student("Mariq", 30004),
                new Student("Pettq", 10042),
                studentToRemove
            };
 
            Course course = new Course(students);

            course.Leave(studentToRemove);

            bool studentHasLeft = true;

            for (int i = 0; i < course.Students.Count; i++)
            {
                if (course.Students[i].Name == studentToRemove.Name && course.Students[i].Number == studentToRemove.Number)
                {
                    studentHasLeft = false;
                }
            }

            Assert.AreEqual(4, students.Count, "Expected to count 4 students after removing one from the course.");
            Assert.IsFalse(students.ToString().Contains(studentToRemove.Number.ToString()), "Expected to remove the student from the course but found his unique number.");
            Assert.IsTrue(studentHasLeft, "Expected to not find a student with the same name and number");
        }

        [TestMethod]
        public void TestCourseStudentsJoining()
        {
            Student studentToJoin = new Student("Pesho", 34342);

            IList<Student> students = new List<Student>() 
            {
                new Student("Pesho", 10002),
                new Student("Gosho", 20003),
                new Student("Mariq", 30004),
                new Student("Pettq", 10042),
            };

            Course course = new Course(students);

            course.Join(studentToJoin);

            bool studentHasJoined = false;

            for (int i = 0; i < course.Students.Count; i++)
            {
                if (course.Students[i].Name == studentToJoin.Name && course.Students[i].Number == studentToJoin.Number)
                {
                    studentHasJoined = true;
                }
            }

            Assert.AreEqual(5, students.Count, "Expected to count 5 students after adding one to the course.");
            Assert.IsTrue(course.ToString().Contains(studentToJoin.Number.ToString()), "Expected to find a match for the added students unique number in the course.");
            Assert.IsTrue(studentHasJoined, "Expected to find a student with the same name and number as the added one in the course.");
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void TestCourseExceedingMaxNumberOfStudentsWhenJoining()
        {
            Student studentToJoin = new Student("Pesho", 34342);

            IList<Student> students = new List<Student>();
            Course course = new Course(students);

            int startingNumber = 10000;
            for (int i = 0; i < Course.MaxStudentCapacity + 1; i++)
            {
                course.Join(new Student("Pesho", startingNumber + i));
            }
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void TestCourseExceedingMaxNumberOfStudentsWhenCreatingNewInstance()
        {
            Student studentToJoin = new Student("Pesho", 34342);

            IList<Student> students = new List<Student>();
            
            int startingNumber = 10000;
            for (int i = 0; i < Course.MaxStudentCapacity + 1; i++)
            {
                students.Add(new Student("Pesho", startingNumber + i));
            }

            Course course = new Course(students);
        }
    }
}
