using System;
using System.Collections.Generic;

public class SolveEquation
{
    public static void Main()
    {
        PrintMenu();
        int choice;
        int.TryParse(Console.ReadLine(), out choice);
        switch (choice)
        {
            case 1: ReverseDigits(); break;
            case 2: CalculateAvarageOfSequence(); break;
            case 3: SolveLinierEquation(); break;
            default: Console.WriteLine("Incorrect Input!!!"); break;
        }
    }
    public static void PrintMenu()
    {
        string line = new string('-', 42);
        Console.WriteLine(line);
        Console.WriteLine("| 1) Reverse Digits                      |");
        Console.WriteLine("| 2) Calculate avarage of a sequence     |");
        Console.WriteLine("| 3) Solve linier equation a * x + b = 0 |");
        Console.WriteLine(line);
        Console.WriteLine("Please enter your choise with the coresponding number:");
    }

    public static void SolveLinierEquation()
    {
        Console.Clear();
        Console.WriteLine("Solving the equation a * x = b");
        Console.Write("Please enter non zero value for element a: ");
        float a = ValidateElementA();
        Console.Write("Please enter element b: ");
        float b = ValidateElementB();
        Console.WriteLine("x = {0}", CalcEquation(a, b));
        
    }

    private static float CalcEquation(float a, float b)
    {
        float x = -1 * b / a;
        return x;
    }

    private static float ValidateElementA()
    {
        float inputNumber;
        while (float.TryParse(Console.ReadLine(), out inputNumber) == false || inputNumber == 0)
        {
            Console.Write("Please enter proper value: ");
        }

        return inputNumber;
    }
    private static float ValidateElementB()
    {
        float inputNumber;
        while (float.TryParse(Console.ReadLine(), out inputNumber) != true)
        {
            Console.Write("Please enter proper value: ");
        }

        return inputNumber;
    }
    public static void CalculateAvarageOfSequence()
    {
        Console.Clear();
        Console.WriteLine("Calculate avarage of a sequence.");
        List<int> sequence = new List<int>();
        int sequenceLenght = ValidateSequenceLenght();
        for (int index = 0; index < sequenceLenght; index++)
        {
             sequence.Add(ValidateElement(index));
        }
        long sum = 0;
        foreach (var item in sequence)
        {
            sum += item;
        }
        float avarage = (float)sum / sequence.Count;
        Console.WriteLine("The avarage is: {0}", avarage);
    }
    
    private static int ValidateElement(int index)
    {
        int inputNumber;
        do
        {
            Console.Write("Enter element[{0}]: ", index);
        }
        while (int.TryParse(Console.ReadLine(), out inputNumber) == false);
        return inputNumber;
    }
  
    private static int ValidateSequenceLenght()
    {
        int sequenceLenght;
        do
        {
            Console.Write("Please enter positive value for sequence lenght: ");
        }
        while (int.TryParse(Console.ReadLine(), out sequenceLenght) == false || sequenceLenght <= 0);
        return sequenceLenght;
    }

    public static void ReverseDigits()
    {
        Console.Clear();
        Console.WriteLine("Calculate avarage of a sequence.");
        Console.Write("Please input a positive decimal value: ");
        decimal inputNumber = ValidateReverseDigitsInput();
        decimal reversedNumber = 0;
        while (inputNumber != 0)
        {
            reversedNumber = reversedNumber * 10 + inputNumber % 10;
            inputNumber = Math.Truncate(inputNumber / 10);
        }

        Console.WriteLine("Reversed value: {0}", reversedNumber);
    }
  
    private static decimal ValidateReverseDigitsInput()
    {
        decimal inputNumber;
        while (decimal.TryParse(Console.ReadLine(), out inputNumber) == false || inputNumber < 0)
        {
            Console.Write("Please enter proper value: ");
        }
        
        return inputNumber;
    }
}