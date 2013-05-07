namespace Methods
{
    using System;

    public class Methods
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        public static string ConvertDigitToWord(int number)
        {
            var digitAsAWord = string.Empty;

            switch (number)
            {
                case 0: 
                    digitAsAWord = "zero"; 
                    break;
                case 1: 
                    digitAsAWord = "one"; 
                    break;
                case 2: 
                    digitAsAWord = "two"; 
                    break;
                case 3: 
                    digitAsAWord = "three"; 
                    break;
                case 4: 
                    digitAsAWord = "four"; 
                    break;
                case 5: 
                    digitAsAWord = "five"; 
                    break;
                case 6: 
                    digitAsAWord = "six"; 
                    break;
                case 7: 
                    digitAsAWord = "seven"; 
                    break;
                case 8: 
                    digitAsAWord = "eight"; 
                    break;
                case 9: 
                    digitAsAWord = "nine"; 
                    break;
                default: throw new ArgumentException(string.Format("{0} is not a digit", number));
            }

            return digitAsAWord;
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("At least one element is required to find the maximal.");
            }

            var maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        public static void PrintNumberAsFloatingPoint(double number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintNumberAsPercent(double number)
        {
            Console.WriteLine("{0:p}", number);
        }

        public static void PrintNumberWithRightAllignment(double number)
        {
            Console.WriteLine("{0,8}", number);
        }

        public static double CalculateDistanceBetweenTwoPoints(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static bool CheckIfLineIsHorizontal(double x1, double x2)
        {
            bool isHorizontal = x1 == x2; 
            return isHorizontal;
        }

        public static bool CheckIfLineIsVertical(double y1, double y2)
        {
            bool isVertical = y1 == y2;
            return isVertical;
        }

        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(ConvertDigitToWord(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintNumberAsFloatingPoint(1.3);
            PrintNumberAsPercent(0.75);
            PrintNumberWithRightAllignment(2.30);

            bool horizontal = CheckIfLineIsHorizontal(3, 3);
            bool vertical = CheckIfLineIsVertical(-1, 2.5);

            Console.WriteLine(CalculateDistanceBetweenTwoPoints(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 03, 17), "From Vidin");

            Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 03), "From Vidin, gamer, high results");

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
