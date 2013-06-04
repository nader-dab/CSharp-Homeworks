namespace _04.LongestSubsequenceOfEqualNumbers.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SequenceFinderTests
    {
        [TestMethod]
        public void TestGetEqualNumbersSubsequence_SequenceInTheBegginingOfTheList()
        {
            List<int> numbers = new List<int>() { 1, 1, 1, 2, 3, 4 };
            List<int> expected = new List<int>() { 1, 1, 1 };

            SequenceFinder finder = new SequenceFinder();
            List<int> result = finder.GetEqualNumbersSubsequence(numbers);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetEqualNumbersSubsequence_SequenceAtTheEndOfTheList()
        {
            List<int> numbers = new List<int>() { 1, 1, 1, 2, 3, 3, 3, 3, 3 };
            List<int> expected = new List<int>() { 3, 3, 3, 3, 3 };

            SequenceFinder finder = new SequenceFinder();
            List<int> result = finder.GetEqualNumbersSubsequence(numbers);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetEqualNumbersSubsequence_SequenceInTheMiddleOfTheList()
        {
            List<int> numbers = new List<int>() { 1, 1, 1, 2, 3, 3, 3, 3, 3, 4, 5, 6 };
            List<int> expected = new List<int>() { 3, 3, 3, 3, 3 };

            SequenceFinder finder = new SequenceFinder();
            List<int> result = finder.GetEqualNumbersSubsequence(numbers);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetEqualNumbersSubsequence_SameNumbersInTheEntireSequence()
        {
            List<int> numbers = new List<int>() { 3, 3, 3, 3, 3 };
            List<int> expected = new List<int>() { 3, 3, 3, 3, 3 };

            SequenceFinder finder = new SequenceFinder();
            List<int> result = finder.GetEqualNumbersSubsequence(numbers);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetEqualNumbersSubsequence_TwoEqualSubsequences()
        {
            List<int> numbers = new List<int>() { 3, 3, 3, 4, 4, 4 };
            List<int> expected = new List<int>() { 3, 3, 3 };

            SequenceFinder finder = new SequenceFinder();
            List<int> result = finder.GetEqualNumbersSubsequence(numbers);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetEqualNumbersSubsequence_OneNumberInTheEntireSequence()
        {
            List<int> numbers = new List<int>() { 1 };
            List<int> expected = new List<int>() { 1 };

            SequenceFinder finder = new SequenceFinder();
            List<int> result = finder.GetEqualNumbersSubsequence(numbers);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetEqualNumbersSubsequence_SequenceWithNoNumbers()
        {
            List<int> numbers = new List<int>();
            List<int> expected = new List<int>();

            SequenceFinder finder = new SequenceFinder();
            List<int> result = finder.GetEqualNumbersSubsequence(numbers);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestGetEqualNumbersSubsequence_NullSequence()
        {
            List<int> numbers = null;

            SequenceFinder finder = new SequenceFinder();
            List<int> result = finder.GetEqualNumbersSubsequence(numbers);
        }
    }
}
