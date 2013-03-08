using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GsmLibrary;
using System.Diagnostics;

namespace GsmTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            GSM[] gsmArray = new GSM[5];
            for (int index = 0; index < gsmArray.Length; index++)
			{
			    gsmArray[index] = new GSM(string.Format("TestGsm{0}", index), string.Format("Manufacturer{0}", index));
			}

            foreach (var gsm in gsmArray)
	        {
                Debug.WriteLine(gsm);
	        }
        }
        [TestMethod]
        public void TestMethod2()
        {
            Debug.WriteLine(GSM.Iphone4S);
        }
    }
}
