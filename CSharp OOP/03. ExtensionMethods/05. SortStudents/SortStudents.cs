namespace _05.SortStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class SortStudents
    {
        static void Main(string[] args)
        {
            var arrayOfSudents = new[]
            {
                new {FirstName = "Ivan", LastName = "Ivanov"},
                new {FirstName = "Stamat", LastName = "Georgiev"},
                new {FirstName = "Gosho", LastName = "Petrov"},
                new {FirstName = "Pesho", LastName = "Georgiev"},
                new {FirstName = "Mariq", LastName = "Atanasova"},
                new {FirstName = "Mariq", LastName = "Qneva"},
                new {FirstName = "Mariq", LastName = "Petrova"},
            };

            var lambdaSortedStudents = arrayOfSudents.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

            foreach (var student in lambdaSortedStudents)
            {
                Console.WriteLine("Lambda Sort: {0}", student);
            }

            var linqSortedStudents =
                from student in arrayOfSudents
                orderby student.LastName
                orderby student.FirstName
                select student;

            foreach (var student in linqSortedStudents)
            {
                Console.WriteLine("LINQ Sort: {0}", student);
            }

        }
    }
}