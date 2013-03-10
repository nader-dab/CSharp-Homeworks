namespace _02.IEnumerableExtension
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MainProgram
    {
        public static void Main(string[] args)
        {
            int[] intArray = { 23, 4, 5, 11, 8, 3, 7 };
            List<decimal> decList = new List<decimal>() { 3.4m, 45.5m, 8.95m, 4.25m };

            Console.WriteLine("Max = {0}", intArray.ExtensionMax());
            Console.WriteLine("Min = {0}", intArray.ExtensionMin());
            Console.WriteLine("Sum = {0}", intArray.ExtensionSum());
            Console.WriteLine("Pro = {0}", intArray.ExtensionProduct());
            Console.WriteLine("Avr = {0}", intArray.ExtensionAvarage());
            Console.WriteLine();
            Console.WriteLine("Max = {0}", decList.ExtensionMax());
            Console.WriteLine("Min = {0}", decList.ExtensionMin());
            Console.WriteLine("Sum = {0}", decList.ExtensionSum());
            Console.WriteLine("Pro = {0}", decList.ExtensionProduct());
            Console.WriteLine("Avr = {0}", decList.ExtensionAvarage());
        }
    }
}