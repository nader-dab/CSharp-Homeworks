using System;

class SortThreeNumbers
{
    static int EnterNumber()
    {
        Console.Write("Please enter a number: ");
        while (true)
        {
            int number;
            if (int.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }
            Console.Write("Incorrect Number. Please enter a propper value: ");
        }
    }

    static void Main()
    {
        int firstNumber = EnterNumber();
        int secondNumber = EnterNumber();
        int thirdNumber = EnterNumber();
        int biggestNumber = firstNumber;
        int middleNumber = secondNumber;
        int smallestNumber = thirdNumber;
        
        if (firstNumber <= secondNumber)
        {
            if (secondNumber <= thirdNumber)
            {
                biggestNumber = thirdNumber;
                smallestNumber = firstNumber;
                middleNumber = secondNumber;
            }
            else
            {
                biggestNumber = secondNumber;
                if (firstNumber > thirdNumber)
	            {
                    smallestNumber = thirdNumber;
                    middleNumber = firstNumber;
	            }
                else
                {
                    smallestNumber = firstNumber;
                    middleNumber = thirdNumber;
                }
            }
        }
        else
        {
            if (thirdNumber > firstNumber)
            {
                biggestNumber = thirdNumber;
                smallestNumber = secondNumber;
                middleNumber = firstNumber;
            }
            else
            {
                biggestNumber = firstNumber;

                if (secondNumber > thirdNumber)
                {
                    smallestNumber = thirdNumber;
                    middleNumber = secondNumber;
                }
                else
                {
                    smallestNumber = secondNumber;
                    middleNumber = thirdNumber;
                }
            }
        }
        Console.WriteLine("{0} {1} {2}",biggestNumber, middleNumber ,smallestNumber );
    }
}

