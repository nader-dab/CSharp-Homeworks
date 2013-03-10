namespace _03.FindStudents
{
    using System;
    using System.Linq;

    class FindStudentsBasedOnName
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

            var filteredStudents =
                from students in arrayOfSudents
                where students.FirstName.CompareTo(students.LastName) == -1
                select students;

            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}