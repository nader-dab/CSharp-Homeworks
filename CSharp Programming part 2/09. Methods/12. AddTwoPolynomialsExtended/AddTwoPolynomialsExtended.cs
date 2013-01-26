using System;
using System.Collections.Generic;

public class AddTwoPolynomialsExtended
{
    public static void Main()
    {
        int[] polynomialOne = { 5, 4, 1, 9 };
        int[] polynomialTwo = { 2, 1, 2 };
        int[] polynomialThree = AddPolynomials(polynomialOne, polynomialTwo);
        Console.WriteLine("Addition = {0}", string.Join(" ", polynomialThree));
        polynomialThree = SubstractPolynomials(polynomialOne, polynomialTwo);
        Console.WriteLine("Subsctraction = {0}", string.Join(" ", polynomialThree));
        polynomialThree = MultyplyPolynomials(polynomialOne, polynomialTwo);
        Console.WriteLine("Multyplication = {0}", string.Join(" ", polynomialThree));
    }

    public static int[] SubstractPolynomials(int[] polynomialOne, int[] polynomialTwo)
    {
        CheckArraySizes(ref polynomialTwo, ref polynomialOne);
        int[] polynomialSub = new int[polynomialOne.Length];
        for (int index = 0; index < polynomialOne.Length; index++)
        {
            polynomialSub[index] = polynomialOne[index] - polynomialTwo[index];
        }

        return polynomialSub;
    }

    public static int[] MultyplyPolynomials(int[] polynomialOne, int[] polynomialTwo)
    {
        List<int> polynomialMulty = new List<int>();
        for (int index1 = 0; index1 < polynomialOne.Length; index1++)
        {
            for (int index2 = 0; index2 < polynomialTwo.Length; index2++)
            {
                polynomialMulty.Add(polynomialOne[index1] * polynomialTwo[index2]);
            }
        }

        return polynomialMulty.ToArray();
    }

    public static int[] AddPolynomials(int[] polynomialOne, int[] polynomialTwo)
    {
        CheckArraySizes(ref polynomialTwo, ref polynomialOne);
        int[] polynomialSum = new int[polynomialOne.Length];
        for (int index = 0; index < polynomialOne.Length; index++)
        {
            polynomialSum[index] = polynomialOne[index] + polynomialTwo[index];
        }

        return polynomialSum;
    }

    public static void CheckArraySizes(ref int[] polynomialTwo, ref int[] polynomialOne)
    {
        if (polynomialOne.Length > polynomialTwo.Length)
        {
            polynomialTwo = ExtendArray(polynomialTwo, polynomialOne.Length);
        }
        else if (polynomialOne.Length < polynomialTwo.Length)
        {
            polynomialOne = ExtendArray(polynomialOne, polynomialTwo.Length);
        }
    }

    public static int[] ExtendArray(int[] smallerArray, int newSize)
    {
        int[] extendedArray = new int[smallerArray.Length + newSize];
        Array.Copy(smallerArray, 0, extendedArray, newSize - smallerArray.Length, smallerArray.Length);
        return extendedArray;
    }
}