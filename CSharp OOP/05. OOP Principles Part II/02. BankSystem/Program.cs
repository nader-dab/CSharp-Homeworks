namespace _02.BankSystem
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var bankAccounts = new Account[]
            {
                new Loan(new Company("Mtel"), 20000000, 4),
                new Deposite(new Individual("Pesho Tunkoto"), 25, 6),
                new Mortage(new Individual("Todor Gerov"), 400, 4),
                new Deposite(new Company("Apple"), 599999999, 4),
            };

            (bankAccounts[0] as Loan).DepositeMoney(77777);
            (bankAccounts[1] as Deposite).WithdrawMoney(50);

            foreach (var account in bankAccounts)
            {
                Console.WriteLine("{0} Interest: {1}%", account, account.CalculateInterest(8));
            }
        }
    }
}
