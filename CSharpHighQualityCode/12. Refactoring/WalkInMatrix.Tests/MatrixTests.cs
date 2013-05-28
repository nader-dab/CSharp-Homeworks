using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace WalkInMatrix.Tests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void PrintMatrixToConsoleSizeFiveTest()
        {
            string outputFile = "ConsoleOutput.txt";
            StreamWriter writer = new StreamWriter(outputFile);
            using(writer)
	        {
		        Console.SetOut(writer);
                WalkInMatrix matrix = new WalkInMatrix(5);
                matrix.PrintMatrixToConsole();
	        }
            
           

            StreamReader reader = new StreamReader(outputFile);

            string consoleResult = string.Empty;

            using (reader)
            {
                consoleResult = reader.ReadToEnd();
            }

            string expectedResult = @"  1 13 14 15 16
 12  2 21 22 17
 11 22  3 20 18
 10 24 23  4 19
  9  8  7  6  5
";

            Assert.AreEqual(expectedResult, consoleResult, "result is incorect");

        }

        [TestMethod]
        public void PrintMatrixToConsoleSizeTenTest()
        {
            string outputFile = "ConsoleOutput.txt";
            StreamWriter writer = new StreamWriter(outputFile);
            using (writer)
            {
                Console.SetOut(writer);
                WalkInMatrix matrix = new WalkInMatrix(10);
                matrix.PrintMatrixToConsole();
            }



            StreamReader reader = new StreamReader(outputFile);

            string consoleResult = string.Empty;

            using (reader)
            {
                consoleResult = reader.ReadToEnd();
            }

            string expectedResult = @"  1 28 29 30 31 32 33 34 35 36
 27  2 51 52 53 54 55 56 57 37
 26 72  3 50 66 67 68 69 58 38
 25 89 73  4 49 65 72 70 59 39
 24 88 90 74  5 48 64 71 60 40
 23 87 98 91 75  6 47 63 61 41
 22 86 97 99 92 76  7 46 62 42
 21 85 96 95 94 93 77  8 45 43
 20 84 83 82 81 80 79 78  9 44
 19 18 17 16 15 14 13 12 11 10
";

            Assert.AreEqual(expectedResult, consoleResult, "result is incorect");

        }
    }
}
