using System;

class CheckIfSubsetSumIsZero
{
    static int EnterNumber()
    {
        while (true)
        {
            int inputNumber;
            Console.Write("Please enter a number: ");
            if (int.TryParse(Console.ReadLine(), out inputNumber))
            {
                return inputNumber;
            }
            Console.Write("Incorrect Input. Please enter a propper value: ");
        }
    }

    static void Main()
    {
        int elements = 5;
        int[] numbers = new int[elements];
        int[,] matrixForTwoCombinations = new int[2, elements * 2];
        int[,] matrixForThreeCombinations = new int[3, elements * 2];
        int[,] matrixForFourCombinations = new int[4, elements];
        int matrixRow = 0;
        int sumCheck = 0;
        int anySubSums = 0;

        for (int i = 0; i < elements; i++)
        {
            numbers[i] = EnterNumber();
        }

        for (int i = 0; i < elements; i++)
        {
            for (int n = 1; n < elements; n++)
            {
                if ((i != n) && (n > i))
                {
                    matrixForTwoCombinations[0, matrixRow] = numbers[i];
                    matrixForTwoCombinations[1, matrixRow] = numbers[n];
                    matrixRow++;
                }
            }
        }
        matrixRow = 0;

        for (int i = 0; i < elements; i++)
        {
            for (int n = 1; n < elements; n++)
            {
                for (int k = 2; k < elements; k++)
                {
                    if ((i != n) && (n != k) 
                        && (k != i) && (n > i) && (k > n))
                    {
                        matrixForThreeCombinations[0, matrixRow] = numbers[i];
                        matrixForThreeCombinations[1, matrixRow] = numbers[n];
                        matrixForThreeCombinations[2, matrixRow] = numbers[k];
                        matrixRow++;
                    }
                }
            }
        }
        matrixRow = 0;

        for (int i = 0; i < elements; i++)
        {
            for (int n = 1; n < elements; n++)
            {
                for (int k = 2; k < elements; k++)
                {
                    for (int l = 3; l < elements; l++)
                    {
                        if ((i != n) && (n != k) && (k != l) 
                            && (l != n) && (l != i) && (k != i)
                            && (n > i) && (k > n) && (l > k))
                        {
                            matrixForFourCombinations[0, matrixRow] = numbers[i];
                            matrixForFourCombinations[1, matrixRow] = numbers[n];
                            matrixForFourCombinations[2, matrixRow] = numbers[k];
                            matrixForFourCombinations[3, matrixRow] = numbers[l];
                            matrixRow++;
                        }
                    }
                }
            }
        }

        for (int i = 0; i < 2 * elements; i++)
        {
            sumCheck = matrixForTwoCombinations[0, i] + matrixForTwoCombinations[1, i];

            if (sumCheck == 0)
            {
                Console.WriteLine("{0, 2} +{1, 2} = 0", 
                    matrixForTwoCombinations[0, i],
                    matrixForTwoCombinations[1, i]);
                    anySubSums++;
            }
            sumCheck = 0;
        }

        for (int i = 0; i < 2 * elements; i++)
        {
            sumCheck = matrixForThreeCombinations[0, i] 
                + matrixForThreeCombinations[1, i]
                + matrixForThreeCombinations[2, i];

            if (sumCheck == 0)
            {
                Console.WriteLine("{0, 2} +{1, 2} +{2, 2} = 0", 
                    matrixForThreeCombinations[0, i],
                    matrixForThreeCombinations[1, i], 
                    matrixForThreeCombinations[2, i]);
                anySubSums++;
            }
            sumCheck = 0;
        }

        for (int i = 0; i < elements; i++)
        {
            sumCheck = matrixForFourCombinations[0, i] 
                + matrixForFourCombinations[1, i]
                + matrixForFourCombinations[2, i] 
                + matrixForFourCombinations[3, i];

            if (sumCheck == 0)
            {
                Console.WriteLine("{0, 2} +{1, 2} +{2, 2} +{3, 2} = 0", 
                    matrixForFourCombinations[0, i],
                    matrixForFourCombinations[1, i], 
                    matrixForFourCombinations[2, i], 
                    matrixForFourCombinations[3, i]);
                anySubSums++;
            }
            sumCheck = 0;
        }

        for (int i = 0; i < elements; i++)
        {
            sumCheck = sumCheck + numbers[i];
        }
        if (sumCheck == 0)
        {
            Console.WriteLine("{0, 2} +{1, 2} +{2, 2} +{3, 2} +{4, 2} = 0",
                numbers[0], numbers[1], numbers[2], numbers[3], numbers[4]);
            anySubSums++;
        }

        if (anySubSums == 0)
        {
            Console.WriteLine("There are no subsums equal to zero!");
        }
    }
}

