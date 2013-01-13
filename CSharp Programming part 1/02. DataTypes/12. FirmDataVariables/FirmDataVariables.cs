using System;

class FirmDataVariables
{
    static void Main()
    {
        string firstName;
        string lastName;
        byte age;
        char gender;
        int employeeNumber;
        Console.WriteLine("Enter first name");
        firstName = Console.ReadLine();
        Console.WriteLine("Enter last name");
        lastName = Console.ReadLine();
        Console.WriteLine("Enter age");
        age = byte.Parse(Console.ReadLine());
        Console.WriteLine("Enter gender");
        gender = char.Parse(Console.ReadLine());
        Console.WriteLine("Enter employee number");
        employeeNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}",firstName,lastName,age,gender,employeeNumber);
    
    }
}

