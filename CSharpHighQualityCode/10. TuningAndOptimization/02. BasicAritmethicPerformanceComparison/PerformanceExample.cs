namespace _02.BasicAritmethicPerformanceComparison
{
    using System;
    using System.Diagnostics;

    class PerformanceExample
    {
        static void MeassureAddition<T>(T value, int iteration)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            dynamic addition = default(T);
            dynamic number = value;

            for (int i = 0; i < iteration; i++)
            {
                addition = number + number;
            }

            stopwatch.Stop();

            Console.WriteLine("Elapsed time to ADD {0} \t\t |{1}|", number.GetType().Name, stopwatch.Elapsed);
        }

        static void MeassureSubstraction<T>(T value, int iteration)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            dynamic substractor = default(T);
            dynamic number = value;

            for (int i = 0; i < iteration; i++)
            {
                substractor = number - number;
            }

            Console.WriteLine("Elapsed time to SUBSTRACT {0} \t |{1}|", number.GetType().Name, stopwatch.Elapsed);
        }

        static void MeassureIncrementation<T>(T value, int iteration)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            dynamic number = value;

            for (int i = 0; i < iteration; i++)
            {
                number++;
            }

            Console.WriteLine("Elapsed time to INCREMENT {0} \t |{1}|", number.GetType().Name, stopwatch.Elapsed);
        }

        static void MeassureMultiplication<T>(T value, int iteration)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            dynamic multiplicator = default(T);
            dynamic number = value;

            for (int i = 0; i < iteration; i++)
            {
                multiplicator = number * number;
            }

            Console.WriteLine("Elapsed time to MULTIPLY {0}  \t |{1}|", number.GetType().Name, stopwatch.Elapsed);
        }

        static void MeassureDivision<T>(T value, int iteration)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            dynamic dividor = default(T);
            dynamic number = value;

            for (int i = 0; i < iteration; i++)
            {
                dividor = number * number;
            }

            Console.WriteLine("Elapsed time to DIVIDE {0}    \t |{1}|", number.GetType().Name, stopwatch.Elapsed);
        }


        static void Main(string[] args)
        {
            int intValue = 5;
            long longValue = 5;
            float floatValue = 5;
            double doubleValue = 5;
            decimal decimalValue = 5;

            int iterations = 1000000;

            MeassureAddition<int>(intValue, iterations);
            MeassureAddition<long>(longValue, iterations);
            MeassureAddition<float>(floatValue, iterations);
            MeassureAddition<double>(doubleValue, iterations);
            MeassureAddition<decimal>(decimalValue, iterations);

            MeassureSubstraction<int>(intValue, iterations);
            MeassureSubstraction<long>(longValue, iterations);
            MeassureSubstraction<float>(floatValue, iterations);
            MeassureSubstraction<double>(doubleValue, iterations);
            MeassureSubstraction<decimal>(decimalValue, iterations);

            MeassureIncrementation<int>(intValue, iterations);
            MeassureIncrementation<long>(longValue, iterations);
            MeassureIncrementation<float>(floatValue, iterations);
            MeassureIncrementation<double>(doubleValue, iterations);
            MeassureIncrementation<decimal>(decimalValue, iterations);

            MeassureMultiplication<int>(intValue, iterations);
            MeassureMultiplication<long>(longValue, iterations);
            MeassureMultiplication<float>(floatValue, iterations);
            MeassureMultiplication<double>(doubleValue, iterations);
            MeassureMultiplication<decimal>(decimalValue, iterations);

            MeassureDivision<int>(intValue, iterations);
            MeassureDivision<long>(longValue, iterations);
            MeassureDivision<float>(floatValue, iterations);
            MeassureDivision<double>(doubleValue, iterations);
            MeassureDivision<decimal>(decimalValue, iterations);
        }
    }
}
