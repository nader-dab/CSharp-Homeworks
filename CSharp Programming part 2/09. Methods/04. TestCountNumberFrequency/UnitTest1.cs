using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _04.TestCountNumberFrequency;

namespace _04.TestCountNumberFrequency
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] array = { 4, 4, 5, 6, 7, 5, 4, 5, 6, 3 };
            int number = 4;
            int result = CountNumberFrequency.CheckFrequency(array, number);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] array = { 234, 23, 124, 54, 756, 4, 8 };
            int number = 13;
            int result = CountNumberFrequency.CheckFrequency(array, number);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[] array = { 43, 42, 45, 42, 42, 45, 34, 43, 42, 42 };
            int number = 42;
            int result = CountNumberFrequency.CheckFrequency(array, number);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int[] array = { 1, 4, 5, 6, 7, 10, 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 1, 2 , 1, 1, 2, 1, 1, 2 };
            int number = 1;
            int result = CountNumberFrequency.CheckFrequency(array, number);
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            int[] array = { 33, 33, 33, 33, 33, 33, 33, 33, 33, 33 };
            int number = 33;
            int result = CountNumberFrequency.CheckFrequency(array, number);
            Assert.AreEqual(10, result);
        }
    }
}
