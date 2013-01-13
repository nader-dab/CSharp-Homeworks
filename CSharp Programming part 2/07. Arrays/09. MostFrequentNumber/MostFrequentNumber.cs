using System;

class MostFrequentNumber
{
    static void Main()
    {
        Console.Write("Enter array lenght: ");
        int arrayLenght = int.Parse(Console.ReadLine());
        int[] myArray = new int[arrayLenght];
        for (int i = 0; i < arrayLenght; i++)
        {
            Console.Write("Enter element[{0}] = ", i);
            myArray[i] = int.Parse(Console.ReadLine());
        }
        int mostFrequentNumber = 0;
        int maxFrequency = 0;

        for (int i = 0; i < arrayLenght; i++)
        {
            int checkNumber = myArray[i];
            int frequency = 0;
            for (int j = 0; j < arrayLenght; j++)
            {
                if (checkNumber == myArray[j])
                {
                    frequency++;
                }
            }
            if (frequency > maxFrequency)
            {
                maxFrequency = frequency;
                mostFrequentNumber = checkNumber;
            }
        }
        Console.WriteLine("{0}({1} times)", mostFrequentNumber, maxFrequency);
    }
}

