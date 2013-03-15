namespace _02.BankSystem
{
    using System;

    public class Loan : Account, IDepositable
    {
        public Loan(Customer customer, decimal balance, decimal interest)
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
            if (this.Customer is Individual)
            { 
                if (months <= 3)
                {
                    return 0;
                }

                return this.Interest * (months - 3);
            }

            if (this.Customer is Company)
            {
                if (months <= 2)
                {
                    return 0;
                }

                return this.Interest * (months - 2);
            }

            throw new ArgumentException("Cannot calculate interest. Invalid customer type!");
        }
    }
}