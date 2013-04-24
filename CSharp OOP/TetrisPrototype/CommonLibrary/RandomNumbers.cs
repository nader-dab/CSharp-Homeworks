/// Design pattern Singleton http://en.wikipedia.org/wiki/Singleton_pattern
/// Creates a single instace of Random the first time this class is used
namespace CommonLibrary
{
    using System;

    public static class RandomNumber
    {
        private static Random rand;

        static RandomNumber()
        {
            rand = new Random();
        }

        public static int Generate(int numberX = 0, int numberY = 500)
        {
            return rand.Next(numberX, numberY + 1);
        }
    }
}