using System;

class ChooseInputVariable
{
    static void Main()
    {
        Console.WriteLine("Please select variable type [1, 2 or 3]");
        Console.WriteLine("1. int");
        Console.WriteLine("2. double");
        Console.WriteLine("3. string");

        byte select;
        while (true)
        {
            if ((byte.TryParse(Console.ReadLine(), out select)) && (select > 0 && select <= 3))
            {
                break;
            }
            Console.WriteLine("Incorrect Input. Please enter a propper value.");
        }

        switch (select)
        {
            case 1:
                {
                    int intChoice;
                    Console.WriteLine("Enter an integer value");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out intChoice))
                        {
                            break;
                        }
                        Console.WriteLine("Incorrect Input. Please enter a propper value.");

                    }
                    intChoice++;
                    Console.WriteLine(intChoice);
                    break;
                }
            case 2:
                {
                    double doubleChoice;
                    Console.WriteLine("Enter a double value");
                    while (true)
                    {
                        if (double.TryParse(Console.ReadLine(), out doubleChoice))
                        {
                            break;
                        }
                        Console.WriteLine("Incorrect Input. Please enter a propper value.");

                    }
                    doubleChoice++;
                    Console.WriteLine(doubleChoice);
                    break;
                }
            case 3:
                {
                    Console.WriteLine("Enter a string");
                    string stringChoice = Console.ReadLine();
                    stringChoice = stringChoice + "*";
                    Console.WriteLine(stringChoice);
                    break;
                }

            default:
                break;
        }
    }
}

