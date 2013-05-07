namespace _03.AdvancedAritmethicPerformanceComparison
{
    using System;
    using System.Diagnostics;

    class PerformanceExample
    {
        static void MeassureSquareRoot<T>(T value, int iteration)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            dynamic squareRoot = default(T);
            dynamic number = value;

            for (int i = 0; i < iteration; i++)
            {
                if (number is decimal)
                {
                    squareRoot = Math.Sqrt((double)number);
                }
                else
                {
                    squareRoot = Math.Sqrt(number);
                }
                
            }

            stopwatch.Stop();

            Console.WriteLine("Elapsed time for SQRT {0} \t |{1}|", number.GetType().Name, stopwatch.Elapsed);
        }

        static void MeassureLogarithm<T>(T value, int iteration)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            dynamic log = default(T);
            dynamic number = value;

            for (int i = 0; i < iteration; i++)
            {
                if (number is decimal)
                {
                    log = Math.Log((double)number);
                }
                else
                {
                    log = Math.Log(number);
                }
                
            }

            stopwatch.Stop();

            Console.WriteLine("Elapsed time for LOG {0} \t |{1}|", number.GetType().Name, stopwatch.Elapsed);
        }

        static void MeassureSinus<T>(T value, int iteration)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            dynamic sin = default(T);
            dynamic number = value;

            for (int i = 0; i < iteration; i++)
            {
                if (number is decimal)
                {
                    sin = Math.Sin((double)number);
                }
                else
                {
                    sin = Math.Sin(number);
                }
                
            }

            stopwatch.Stop();

            Console.WriteLine("Elapsed time for SIN {0} \t |{1}|", number.GetType().Name, stopwatch.Elapsed);
        }

        static void Main(string[] args)
        {
            float floatValue = 5;
            double doubleValue = 5;
            decimal decimalValue = 5;

            int iterations = 1000000;

            MeassureSquareRoot<float>(floatValue, iterations);
            MeassureSquareRoot<double>(doubleValue, iterations);
            MeassureSquareRoot<decimal>(decimalValue, iterations);

            MeassureLogarithm<float>(floatValue, iterations);
            MeassureLogarithm<double>(doubleValue, iterations);
            MeassureLogarithm<decimal>(decimalValue, iterations);

            MeassureSinus<float>(floatValue, iterations);
            MeassureSinus<double>(doubleValue, iterations);
            MeassureSinus<decimal>(decimalValue, iterations);

        }
    }
}
