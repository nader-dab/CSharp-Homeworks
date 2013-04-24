namespace _02.PersonInformationTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PersonInformation;
    
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestMethod1()
        {
            Person pesho = new Person("Petyr");
            string result = "Name: Petyr \nAge: Unspecified";
            Assert.AreEqual(result, pesho.ToString());
        }

        [TestMethod]
        public void TestMethod2()
        {
            Person misho = new Person("Mihail", 23);
            string result = "Name: Mihail \nAge: 23";
            Assert.AreEqual(result, misho.ToString());
        }
    }
}
