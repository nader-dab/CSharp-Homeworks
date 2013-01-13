using System;

class CompareArrays
{
    static void Main()
    {
        Console.WriteLine("Please enter lenght for first array:");
        int firstLenght = int.Parse(Console.ReadLine());
        int[] firstArray = new int[firstLenght];
        for (int i = 0; i < firstLenght; i++)
        {
            Console.Write("Please enter element {0}: ",i+1);
            firstArray[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Please enter lenght for second array:");
        int secondLenght = int.Parse(Console.ReadLine());

        int[] secondArray = new int[secondLenght];
        for (int i = 0; i < secondLenght; i++)
        {
            Console.Write("Please enter element {0}: ", i + 1);
            secondArray[i] = int.Parse(Console.ReadLine());
        }

        if (firstLenght != secondLenght)
        {
            Console.WriteLine("The arrays are different");
        }
        else
        {
            bool same = true;
            for (int i = 0; i < firstArray.GetLength(0); i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    same = false;
                    break;
                }
            }
            if (same == true)
            {
                Console.WriteLine("The arrays are the same");
            }
            else
            {
                Console.WriteLine("The arrays are different");
            }
        }

    }
}

