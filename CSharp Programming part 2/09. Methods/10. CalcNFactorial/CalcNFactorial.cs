using System;

public class CalcNFactorial
{
    public static void Main()
    {
        Console.WriteLine("Please enter N:");
        int n = int.Parse(Console.ReadLine());
        int[] factorial = CalcFactorial(n);
        Console.WriteLine("N! = {0}", string.Join(string.Empty, factorial));
    }

    public static int[] CalcFactorial(int n)
    {
        int[] factorial = { 1 };
        for (int index = 1; index <= n; index++)
        {
            factorial = CalcCurrentFactorial(factorial, index);
        }

        return factorial;
    }

    public static int[] CalcCurrentFactorial(int[] currentFactorial, int multyply)
    {
        int[] multypliedArray = MultiplyArrayValues(currentFactorial, multyply);
        int[] carryTransferedArray = new int[multypliedArray.Length];
        int carry = 0;
        for (int index = multypliedArray.Length - 1; index >= 0; index--)
        {
            carry = CarryTransfer(multypliedArray, index, carryTransferedArray, carry);
        }

        if (carry != 0)
        {
            return ExtendArray(carryTransferedArray, carry);
        }

        return carryTransferedArray;
    }

    public static int CarryTransfer(int[] multypliedArray, int index, int[] carryTransferedArray, int carry)
    {
        carry = multypliedArray[index] / 10;
        if (carry != 0)
        {
            carryTransferedArray[index] = multypliedArray[index] % 10;
            if (index != 0)
            {
                multypliedArray[index - 1] = multypliedArray[index - 1] + (multypliedArray[index] / 10);
            }
        }
        else
        {
            carryTransferedArray[index] = multypliedArray[index];
        }

        return carry;
    }

    public static int[] MultiplyArrayValues(int[] currentFactorial, int multyply)
    {
        int[] multypliedArray = new int[currentFactorial.Length];
        for (int index = 0; index < multypliedArray.Length; index++)
        {
            multypliedArray[index] = multyply * currentFactorial[index];
        }

        return multypliedArray;
    }

    public static int[] ExtendArray(int[] carryTransferedArray, int carry)
    {
        // extend array
        int[] extendedArray = new int[carryTransferedArray.Length + carry.ToString().Length];
        Array.Copy(carryTransferedArray, 0, extendedArray, carry.ToString().Length, carryTransferedArray.Length);
        for (int i = carry.ToString().Length - 1; i >= 0; i--)
        {
            extendedArray[i] = carry % 10;
            carry = carry / 10;
        }

        return extendedArray;
    }
}