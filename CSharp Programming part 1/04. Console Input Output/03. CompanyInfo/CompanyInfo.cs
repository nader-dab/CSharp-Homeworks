using System;

class CompanyInfo
{
    static void Main()
    {
        Console.WriteLine("Please enter company name:");
        string companyName = Console.ReadLine();
        Console.WriteLine("Please enter company address:");
        string companyAddress = Console.ReadLine();
        Console.WriteLine("Please enter company phone:");
        int companyPhone = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter company fax:");
        int companyFax = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter company website:");
        string companyWebsite = Console.ReadLine();
        Console.WriteLine("Please enter manager first name:");
        string managerFirstName = Console.ReadLine();
        Console.WriteLine("Please enter manager last name:");
        string managerLastName = Console.ReadLine();
        Console.WriteLine("Please enter manager age:");
        byte managerAge = byte.Parse(Console.ReadLine());
        Console.WriteLine("Please enter manager phone:");
        int managerPhone = int.Parse(Console.ReadLine());

        string line = new String('-', 45);
        Console.WriteLine(line);
        Console.WriteLine("{0,-15} {1}", "Company name:", companyName);
        Console.WriteLine("{0,-15} {1}", "Phone:", companyPhone);
        Console.WriteLine("{0,-15} {1}", "Fax:", companyFax);
        Console.WriteLine("{0,-15} {1}", "Website:", companyWebsite);
        Console.WriteLine(line);
        Console.WriteLine("{0,-15} {1} {2}", "Manager:", managerFirstName, managerLastName);
        Console.WriteLine("{0,-15} {1}", "Age:", managerAge);
        Console.WriteLine("{0,-15} {1}", "Phone:", managerPhone);
        Console.WriteLine(line);
    }
}

