using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        CheckNumberOfWorkdays();
    }

    public static void CheckNumberOfWorkdays()
    {
        try
        {
            List<DateTime> listOfHolidays = new List<DateTime>();
            {
                // TODO: Add all national holidays
                listOfHolidays.Add(new DateTime(2013, 2, 21));
                listOfHolidays.Add(new DateTime(2013, 3, 3));
                listOfHolidays.Add(new DateTime(2013, 9, 8));
            }

            Console.WriteLine("Please enter date after {0:dd/MM/yyyy}", DateTime.Now.Date);
            string[] inputDate = Console.ReadLine().Split(new char[] { ' ', '.', ':', '/', '-' });
            DateTime startDate = DateTime.Now;
            DateTime endDate = new DateTime(int.Parse(inputDate[2]), int.Parse(inputDate[1]), int.Parse(inputDate[0]));
            if (endDate < startDate)
            {
                throw new ArgumentOutOfRangeException("The end date must be after the current date!");
            }

            int difference = (endDate - startDate).Days;
            int workDays = 0;
            for (int index = 0; index < difference; index++)
            {
                if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (!listOfHolidays.Contains(startDate))
                    {
                        workDays++;
                    }
                }

                startDate.AddDays(1);
            }

            Console.WriteLine("Workdays between {0:dd/MM/yyyy} and {1:dd/MM/yyyy} = {2}", DateTime.Now.Date, endDate.Date, workDays);
        }
        catch (ArgumentOutOfRangeException ae)
        {
            Console.Error.WriteLine("Invalid date! " + ae.ParamName);
        } 
    }
}