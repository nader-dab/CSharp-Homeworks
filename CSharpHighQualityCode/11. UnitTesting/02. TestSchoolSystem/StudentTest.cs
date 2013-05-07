namespace _02.TestSchoolSystem
{
    using System;
    using _01.School;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTest
    {
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestStudentEmptyStringName()
        {
            Student student = new Student(string.Empty, 10002);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestStudentWhitespacesName()
        {
            Student student = new Student("     ", 10002);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void TestStudentUniqueNumberBelowAllowedRange()
        {
            Student student = new Student("John", 8);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void TestStudentUniqueNumberAboveAllowedRange()
        {
            Student student = new Student("John", 1234567);
        }

        [TestMethod]
        public void TestStudentToString()
        {
            Student student = new Student("John", 65655);
            Assert.AreEqual("John 65655", student.ToString());
        }
    }
}
