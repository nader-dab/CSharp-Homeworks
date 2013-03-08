namespace GsmLibrary
{
    using System;
    using System.Globalization;

    public class Battery
    {
        private string model;
        private BatteryType type;
        private DateTime hoursIdle;
        private DateTime hoursTalk;
        private string hourFormat = "HH:mm:ss";

        public Battery()
            : this(null)
        {
        }

        public Battery(string model)
            : this(model, (BatteryType)0, "00:00:00", "00:00:00")
        { 
        }

        public Battery(string model, BatteryType type, string hoursIdle, string hoursTalk)
        {
            this.Model = model;
            this.Type = type;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }

        public string HoursTalk
        {
            get
            {
                return this.hoursTalk.ToString(this.hourFormat, CultureInfo.InvariantCulture);
            }

            set
            {
                if (!DateTime.TryParse(value, out this.hoursTalk))
                {
                     throw new ArgumentException("Invalid time format for Battery HoursTalk.");
                }
                else if (this.hoursTalk > this.hoursIdle)
                {
                    throw new ArgumentException("Invalid battery life. Hours talk connot be larger than hours idle");
                }
            }
        }

        public BatteryType Type
        {
            get 
            {
                return this.type;
            }

            set
            {
                this.type = value;
            }
        }

        public string HoursIdle
        {
            get
            {
                return this.hoursIdle.ToString(this.hourFormat, CultureInfo.InvariantCulture);
            }

            set
            {
                if (!DateTime.TryParse(value, out this.hoursIdle))
                {
                    throw new ArgumentException("Invalid time format for Battery HoursIdle.");
                } 
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.model = value;
            }
        }

        public override string ToString()
        {
            string information = string.Format("Model: {0} \nType: {1} \nHours Idle: {2} \nHours Talk: {3}", this.Model, this.Type, this.HoursIdle, this.HoursTalk);
            return information;
        }
    }
}
