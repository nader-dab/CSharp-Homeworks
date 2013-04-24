namespace AcademyPopcorn
{
    class ShootEngine : Engine
    {
        public ShootEngine(IRenderer renderer, IUserInterface userInterface, int threadSleep)
            : base(renderer,userInterface, threadSleep)
        {
        }

        // Task 4
        public static void ShootPlayerRacket(Gift gift, Racket racket)
        {
            if (gift.IsDestroyed == true)
            {
                racket = new ShootingRacket(racket.TopLeft, racket.Width);
            }
        }
    }
}
