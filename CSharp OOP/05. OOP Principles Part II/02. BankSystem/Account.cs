namespace _02.BankSystem
{
    public abstract class Account
    {
        private Customer customer;
        private decimal balance;
        private decimal interest;

        public Account(Customer customer, decimal balance, decimal interest)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.Interest = interest;
        }

        public decimal Interest
        {
            get
            {
                return this.interest;
            }

            protected set
            {
                this.interest = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            protected set
            {
                this.balance = value;
            }
        }

        public Customer Customer
        {
            get
            {
                return this.customer;
            }

            private set
            {
                this.customer = value;
            }
        }

        public virtual decimal CalculateInterest(ushort months)
        {
            return this.Interest * months;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.Customer, this.Balance, this.Interest);
        }
    }
}
