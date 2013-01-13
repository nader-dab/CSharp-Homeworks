using System;

class Program
{
    static int inputNumber;
    static int firstDigit;
    static int middleDigit;
    static int lastDigit;
    static string upperCaseNumber;
    static string lowerCaseNumber;

    static void DigitNumber(int number)
    {
        switch (number)
        {
            case 0:
            {
                upperCaseNumber = "Zero";
                break;
            }
            case 1:
            {
                upperCaseNumber = "One";
                lowerCaseNumber = "one";
                break;       
            }                
            case 2:              
            {                
                upperCaseNumber = "Two";
                lowerCaseNumber = "two";
                break;       
            }                
            case 3:              
            {
                upperCaseNumber = "Three";
                lowerCaseNumber = "three";
                break;       
            }                
            case 4:               
            {                
                upperCaseNumber = "Four";
                lowerCaseNumber = "four";
                break;       
            }                
            case 5:              
            {                
                upperCaseNumber = "Five";
                lowerCaseNumber = "five";
                break;       
            }                
            case 6:              
            {                
                upperCaseNumber = "Six";
                lowerCaseNumber = "six";
                break;       
            }                
            case 7:              
            {                
                upperCaseNumber = "Seven";
                lowerCaseNumber = "seven";
                break;       
            }                
            case 8:              
            {   
                upperCaseNumber = "Eight";
                lowerCaseNumber = "eight";
                break;       
            }                
            case 9:              
            {                
                upperCaseNumber = "Nine";
                lowerCaseNumber = "nine";
                break;
            }
            default:
                break;
        }
    }

    static void TeenNumber()
    {
        switch (lastDigit)
        {
            case 0:
            {
                upperCaseNumber = "Ten";
                lowerCaseNumber = "ten";
                break;
            }
            case 1:
             {
                upperCaseNumber = "Eleven";
                lowerCaseNumber = "eleven";
                break;
            }
            case 2:
            {
                upperCaseNumber = "Twelve";
                lowerCaseNumber = "twelve";        
                break;
            }
            case 3:
            {
                upperCaseNumber = "Thirteen";
                lowerCaseNumber = "thirteen";
                break;
            }
            case 4:
            {
                upperCaseNumber = "Fourteen";
                lowerCaseNumber = "fourteen";
                break;
            }
            case 5:
            {
                upperCaseNumber = "Fifteen";
                lowerCaseNumber = "fifteen";
                break;
            }
            case 6:
            {
                upperCaseNumber = "Sixteen";
                lowerCaseNumber = "sixteen";
                break;
            }
            case 7:
            {
                upperCaseNumber = "Seventeen";
                lowerCaseNumber = "seventeen";
                break;
            }
            case 8:
            {
                upperCaseNumber = "Eighteen";
                lowerCaseNumber = "eighteen";
                break;
            }
            case 9:
            {
                upperCaseNumber = "Nineteen";
                lowerCaseNumber = "nineteen";
                break;
            }
            default:
                break;
        }
    
    }

    static void DecimalNumber()
    {
        switch (middleDigit)
        {
            
            case 2:
            {
                upperCaseNumber = "Twenty";
                lowerCaseNumber = "twenty";
                break;
            }
            case 3:
            {
                upperCaseNumber = "Thirty";
                lowerCaseNumber = "thirty";
                break;
            }
            case 4:
            {
                upperCaseNumber = "Fourty";
                lowerCaseNumber = "fourty";
                break;
            }
            case 5:
            {
                upperCaseNumber = "Fifty";
                lowerCaseNumber = "fifty";
                break;
            }
            case 6:
            {
                upperCaseNumber = "Sixty";
                lowerCaseNumber = "sixty";
                break;
            }
            case 7:
            {
                upperCaseNumber = "Seventy";
                lowerCaseNumber = "seventy";
                break;
            }
            case 8:
            {
                upperCaseNumber = "Eighty";
                lowerCaseNumber = "eighty";
                break;
            }
            case 9:
            {
                upperCaseNumber = "Ninety";
                lowerCaseNumber = "ninety";
                break;
            }
            default:
                break;
        }
    }
    
    static void Main()
    {
        Console.WriteLine("Please enter a number between 0 and 999.");
        while (true)
        {
            if ((int.TryParse(Console.ReadLine(), out inputNumber)) 
                && (inputNumber >= 0) 
                && (inputNumber <= 999))
            {
                break;
            }
            Console.Write("Incorrect Input. Please enter a propper value: ");
        }

        lastDigit = inputNumber % 10;
        middleDigit = (inputNumber / 10) % 10;
        firstDigit = (inputNumber / 100) % 10;

        if (firstDigit == 0)
        {
            if (middleDigit == 0)
            {
                DigitNumber(lastDigit);
                Console.WriteLine(upperCaseNumber + ".");      
            }
            else if (middleDigit == 1)
            {
                TeenNumber();
                Console.WriteLine(upperCaseNumber + ".");  
            }
            else if (lastDigit == 0)
            {
                DecimalNumber();
                Console.WriteLine(upperCaseNumber + ".");  
            }
            else
            {
                DecimalNumber();
                Console.Write(upperCaseNumber + " ");
                DigitNumber(lastDigit);
                Console.WriteLine(lowerCaseNumber + "."); 
            }
        }
        else if (middleDigit == 0)
        {
            if (lastDigit == 0)
            {
                DigitNumber(firstDigit);
                Console.WriteLine("{0} hundred.", upperCaseNumber);
            }
            else
            {
                
                DigitNumber(firstDigit);
                Console.Write("{0} hundred and ", upperCaseNumber);
                DigitNumber(lastDigit);
                Console.WriteLine(lowerCaseNumber + ".");
            }
        }
        else if (middleDigit == 1)
        {
            DigitNumber(firstDigit);
            Console.Write("{0} hundred and ", upperCaseNumber);
            TeenNumber();
            Console.WriteLine(lowerCaseNumber + ".");
        }
        else if (lastDigit == 0)
        {
            DigitNumber(firstDigit);
            Console.Write("{0} hundred and ", upperCaseNumber);
            DecimalNumber();
            Console.WriteLine(lowerCaseNumber + ".");
        }
        else
        {
            DigitNumber(firstDigit);
            Console.Write("{0} hundred and ", upperCaseNumber);
            DecimalNumber();
            Console.Write(lowerCaseNumber + " ");
            DigitNumber(lastDigit);
            Console.WriteLine(lowerCaseNumber + ".");
        }   
    }
}
