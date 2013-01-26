using System;
namespace _01.PrintSqrt
{
    public class PrintSqrt
    {
        public static void Main()
        {
            try
            {
                int number = InputNumber();
                double sqrt = CalcScrt(number);
                Print(sqrt);
            }
            catch (ArgumentOutOfRangeException ae)
            {
                Console.WriteLine("Invalid number");
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Invalid number");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }

        public static void Print(double sqrt)
        {
            Console.WriteLine(sqrt);
        }

        public static double CalcScrt(int number)
        {
            double sqrt = Math.Sqrt(number);
            return sqrt;
        }

        public static int InputNumber()
        {
            Console.WriteLine("Please enter an integer number.");
            int number = int.Parse(Console.ReadLine());
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return number;
        }
    }
}