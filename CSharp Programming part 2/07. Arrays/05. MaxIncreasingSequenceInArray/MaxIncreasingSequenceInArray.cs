using System;

class MaxSimularSequenceInArray
{
    static void Main()
    {
        Console.Write("Enter lenght for the array: ");
        int arrayLenght = int.Parse(Console.ReadLine());
        char[] myArray = new char[arrayLenght];
        for (int i = 0; i < arrayLenght; i++)
        {
            Console.Write("Please enter element[{0}]: ", i + 1);
            myArray[i] = char.Parse(Console.ReadLine());
        }
        int start = 0;
        int lenght = 1;
        int bestStart = 0;
        int bestLenght = 1;
        for (int i = 1; i < myArray.GetLength(0); i++)
        {
            if (myArray[i - 1] == myArray[i] - 1)
            {
                lenght++;
            }

            if (myArray[i - 1] != myArray[i] - 1 || i == myArray.GetLength(0) - 1)
            {
                if (lenght > bestLenght)
                {
                    bestLenght = lenght;
                    bestStart = start;
                }
                start = i;
                lenght = 1;
            }

        }
        Console.Write("Maximum sequence of similar elements is {");
        for (int i = 0; i < bestLenght; i++)
        {
            Console.Write(myArray[bestStart + i]);
            if (i != bestLenght - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("}");
    }
}

