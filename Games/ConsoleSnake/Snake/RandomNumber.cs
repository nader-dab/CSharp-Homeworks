namespace Snake
{
    using System;

    public static class RandomNumber
    {
        private static Random rand = new Random();

        public static int Generate(int minValue, int maxValue)
        {
            return rand.Next(minValue, maxValue + 1);
        }
    }
}
