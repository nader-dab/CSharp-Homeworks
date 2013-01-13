using System;


class SequenceEqualToSumInArray
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
        Console.Write("Enter sum: ");
        int s = int.Parse(Console.ReadLine());
        int sum;
        int startPosition = int.MinValue;
        int endPosiotion = int.MinValue;
        for (int i = 0; i < arrayLenght; i++)
        {
            sum = 0;
            for (int j = i; j < arrayLenght; j++)
            {
                sum += myArray[j];
                if (sum == s)
                {
                    startPosition = i;
                    endPosiotion = j;
                    break;
                }
                if (sum > s)
                {
                    break; 
                }
            }
            if (sum == s)
            {
                break;
            }
        }

        if (startPosition!= int.MinValue && endPosiotion != int.MinValue)
        {
            Console.Write("{");
            for (int i = startPosition; i < endPosiotion + 1; i++)
            {

                Console.Write(myArray[i]);
                if (i!= endPosiotion)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("}");
        }
        else
	    {
            Console.WriteLine("No such sum is present");
	    }
    }
}

