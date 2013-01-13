using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Console.Write("Enter array lenght N: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter number of elements K: ");
        int k = int.Parse(Console.ReadLine());

        Console.Write("Enter sum S: ");
        int s = int.Parse(Console.ReadLine());

        int[] myArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element[{0}] = ", i);
            myArray[i] = int.Parse(Console.ReadLine());
        }
        
        List<int> positions = new List<int>();
        bool sumFound = false;
        for (int check = 0; check < Math.Pow(2, myArray.GetLength(0)) - 1; check++)
        {
            int sum = 0;
            positions = new List<int>();
            for (int position = 0; position < myArray.GetLength(0); position++)
            {

                if (((1 << position) & check) != 0)
                {
                    sum += myArray[position];
                    positions.Add(position);
                }
            }
            if (sum == s && positions.Count == k)
            {
                sumFound = true;
                break;
            }
        }
        if (sumFound == true)
        {
            Console.Write("Yes -> {");
            foreach (var item in positions)
            {
                Console.Write("{0} ", myArray[item]);
            }
            Console.WriteLine("}");
        }
        else
        {
            Console.WriteLine("No");
        }

    }
}