namespace GsmLibrary
{
    using System;
    using System.Linq;

    public class Call
    {
        private DateTime date;
        private string phone;
        private int duration;

        public Call(DateTime date, string phone, int duration)
        {
            this.date = date;
            this.phone = phone;
            this.duration = duration;
        }

        public int Duration
        {
            get
            {
                return this.duration;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.Date, this.Phone, this.Duration);
        }
    }
}
