using System;

public class AccountInfo
{
  
    public string firstName;
    public string middleName;
    public string lastName;
    public decimal balance;
    public string bankName;
    public  string iban;
    public string bic;
    public string creditCard1;
    public string creditCard2;
    public string creditCard3;
    
    public AccountInfo()
    {
        firstName = "Ivan";
        middleName = "Alexandrov";
        lastName = "Krustev";
        balance = 3054.34m;
        bankName = "Reiffeizen Bank";
        iban = "BG98TRGG87541000598787";
        bic = "TRGG88VDF";
        creditCard1 = "6454879820549898";
        creditCard2 = "6454877899551212";
        creditCard3 = "6454800045559321";
    }
}

class BankAccountInfo
{
    static void Main()
    {
        AccountInfo client = new AccountInfo();
        string line = new string('-', 40);
        Console.WriteLine(line);
        Console.WriteLine(client.firstName);
        Console.WriteLine(client.middleName);
        Console.WriteLine(client.lastName);
        Console.WriteLine(client.balance);
        Console.WriteLine(client.bankName);
        Console.WriteLine(client.iban);
        Console.WriteLine(client.bic);
        Console.WriteLine(client.creditCard1);
        Console.WriteLine(client.creditCard2);
        Console.WriteLine(client.creditCard3);
        Console.WriteLine(line);
    }
}

