namespace _07.UsingDelegatesTimer
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public delegate void TimeDelegate();

    public class Timer
    {
        private TimeDelegate observer;
        private int timeInterval;

        public Timer(TimeDelegate observer, int seconds)
        {
            this.Observer = observer;
            this.TimeInterval = seconds;
        }

        public TimeDelegate Observer
        {
            get
            {
                return this.observer;
            }

            set
            {
                this.observer = value;
            }
        }

        public int TimeInterval
        {
            get 
            {
                return this.timeInterval;
            }

            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid value for time interval. Must be larger than 0.");
                }

                this.timeInterval = value * 1000;
            }
        }

        public void StartTimer()
        {
            while (true)
            {
                this.Observer();
                Thread.Sleep(this.TimeInterval);
            }
        }
    }
}