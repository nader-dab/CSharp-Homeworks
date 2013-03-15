namespace _02.BankSystem
{
    using System;

    public class Mortage : Account, IDepositable
    {
        public Mortage(Customer customer, decimal balance, decimal interest)
            : base(customer, balance, interest)
        {
        }

        public void DepositeMoney(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot deposite a negative amount.");
            }

            this.Balance += amount;
        }

        public override decimal CalculateInterest(ushort months)
        {
            if (this.Customer is Company)
            {
                if (months <= 12)
                {
                    return months * (this.Interest / 2);
                }
            }

            if (this.Customer is Individual)
            {
                if (months <= 6)
                {
                    return 0;
                }
            }

            return base.CalculateInterest(months);
        }
    }
}
