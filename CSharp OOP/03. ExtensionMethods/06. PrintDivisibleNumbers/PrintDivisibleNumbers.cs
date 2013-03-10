namespace _06.PrintDivisibleNumbers
{
    using System;
    using System.Linq;

    class PrintDivisibleNumbers
    {
        static void Main(string[] args)
        {
            var array = new int[] { 12, 23, 24, 63, 15, 14, 12, 75, 32, 21, 28, 54, 94 };

            var lambdaArray = array.Where(x => x % 3 == 0 && x % 7 == 0);

            Console.WriteLine("Lambda: {0}", string.Join(", ", lambdaArray));

            var linqArray =
                from numbers in array
                where numbers % 3 == 0 && numbers % 7 == 0
                select numbers;

            Console.WriteLine("LINQ: {0}", string.Join(", ", linqArray));
        }
    }
}
