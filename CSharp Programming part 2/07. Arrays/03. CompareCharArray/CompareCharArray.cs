using System;

class CompareCharArray
{
    static void Main()
    {
        Console.Write("Enter lenght for the first array: ");
        int firstArrayLenght = int.Parse(Console.ReadLine());
        char[] firstArray = new char[firstArrayLenght];
        for (int i = 0; i < firstArrayLenght; i++)
        {
            Console.Write("Please enter element for first array {0}: ", i+1);
            firstArray[i] = char.Parse(Console.ReadLine());
        }
        Console.Write("Enter lenght for the second array: ");
        int secondArrayLenght = int.Parse(Console.ReadLine());
        char[] secondArray = new char[secondArrayLenght];
        for (int i = 0; i < secondArrayLenght; i++)
        {
            Console.Write("Please enter element for second array {0}: ", i + 1);
            secondArray[i] = char.Parse(Console.ReadLine());
        }
        int maxLenght = (int)Math.Max(firstArrayLenght, secondArrayLenght);

        bool same = true;
        for (int i = 0; i < maxLenght; i++)
        {
            if (firstArray[i] < secondArray[i])
            {
                same = false;
                Console.WriteLine("First array is lexicographically shorter");
                break;
            }
            if (firstArray[i] > secondArray[i])
            {
                same = false;
                Console.WriteLine("Second array is lexicographically shorter");
                break;
            }
        }

        if (same == true)
        {
            if (firstArrayLenght < secondArrayLenght)
            {
                Console.WriteLine("First array is lexicographically shorter");
            }
            if (firstArrayLenght > secondArrayLenght)
            {
                Console.WriteLine("Second array is lexicographically shorter");
            }
            if (firstArrayLenght == secondArrayLenght)
            {
                Console.WriteLine("Arrays are lexicographically equal");
            }
        }
    }
}

