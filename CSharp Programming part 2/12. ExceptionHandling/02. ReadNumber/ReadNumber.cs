using System;

class ReadNumbers
{
    static void Main()
    {
        try
        {
            ReadNumber();
        }
        catch (ArgumentOutOfRangeException ae)
        {
            Console.WriteLine("Numbers must be in range [1..100] \n{0}", ae.Message);
        }
        catch(FormatException fe)
        {
            Console.WriteLine("Please enter just numerical values \n{0}", fe.Message);
        }
    }
  
    private static void ReadNumber()
    {
        Console.WriteLine("Please enter a number in the range [1...100]");
        int[] numbers = new int[10];
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Enter number {0}: ", i);
            numbers[i] = int.Parse(Console.ReadLine());
            if (!(numbers[i]> 1 && numbers[i] < 100))
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}