using System;
using System.Numerics;

public class AddTwoPolynomials
{
    public static void Main()
    {
        int[] polynomialOne = { 5, 0, 1, 9 };
        int[] polynomialTwo = { 2, 1, 2 };
        int[] polynomialThree = AddPolynomials(polynomialOne, polynomialTwo);
        Console.WriteLine(string.Join(" ", polynomialThree));
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