namespace _02.Humans
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private byte workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, byte workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public byte WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                this.workHoursPerDay = value;
            }
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                this.weekSalary = value;
            }
        }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / this.WorkHoursPerDay;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", this.FirstName, this.LastName, this.WeekSalary, this.workHoursPerDay);
        }
    }
}
