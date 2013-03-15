namespace _02.BankSystem
{
    using System;

    public class Deposite : Account, IDepositable, IWithdrawable
    {
        public Deposite(Customer customer, decimal balance, decimal interest)
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

        public void WithdrawMoney(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot withdraw a negative amount.");
            }

            this.Balance -= amount;
        }

        public override decimal CalculateInterest(ushort months)
        {
            if (this.Balance >= 0 && this.Balance <= 1000)
            {
                return 0;
            }

            return base.CalculateInterest(months);
        }
    }
}