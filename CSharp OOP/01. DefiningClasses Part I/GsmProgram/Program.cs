namespace GsmProgram
{
    using System;
    using GsmLibrary;
 
    public class Program
    {
        public static void Main(string[] args)
        {
            // Task 4
            GSM testGsm = new GSM("3310", "Nokia", 99.99m, "Pesho", "Nokia Battery", default(BatteryType), "14:45:00", "19:30:00", 2.4f, 8);

            Console.WriteLine(testGsm + "\n");

            // Task 5
            Console.WriteLine(GSM.Iphone4S + "\n");

            // Task 7
            GSM[] gsmArray = new GSM[5];
            for (int index = 0; index < gsmArray.Length; index++)
            {
                gsmArray[index] = new GSM(
                    string.Format("TestGsm{0}", index), 
                    string.Format("Manufacturer{0}", index),
                    index * 100,
                    string.Format("Owner{0}", index),
                    string.Format("Type{0}", index),
                    default(BatteryType));
            }

            foreach (var gsm in gsmArray)
            {
                Console.WriteLine(gsm + "\n");
            }

            // Task 10
            testGsm.AddCall(new DateTime(2013, 02, 25), "977 977 456", 45);
            testGsm.AddCall(new DateTime(2013, 02, 27), "966 968 945", 54);
            testGsm.AddCall();
            testGsm.AddCall(new DateTime(2013, 02, 28), "977 555 080", 10);

            testGsm.DeleteCall(2);

            // Task 11
            Console.WriteLine(testGsm.CallHistory);
            Console.WriteLine("Total price of calls {0:0.00}$", testGsm.TotalPrice());

            // Task 12
            testGsm.RemoveLongestCall();
            Console.WriteLine("Total price of calls {0:0.00}$", testGsm.TotalPrice());

            testGsm.ClearCallHistory();
            Console.WriteLine(testGsm.CallHistory); 
        }
    }
}
