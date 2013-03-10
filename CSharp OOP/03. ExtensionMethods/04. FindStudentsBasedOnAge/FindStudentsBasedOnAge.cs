namespace _04.FindStudentsBasedOnAge
{
    using System;
    using System.Linq;

    class FindStudentsBasedOnAge
    {
        static void Main(string[] args)
        {
            var arrayOfSudents = new[]
            {
                new {FirstName = "Ivan", LastName = "Ivanov", Age = 20 },
                new {FirstName = "Stamat", LastName = "Georgiev", Age = 25 },
                new {FirstName = "Gosho", LastName = "Petrov", Age = 21 },
                new {FirstName = "Pesho", LastName = "Georgiev", Age = 17 },
                new {FirstName = "Mariq", LastName = "Atanasova", Age = 18 },
                new {FirstName = "Mariq", LastName = "Qneva", Age = 24 },
                new {FirstName = "Mariq", LastName = "Petrova", Age = 32},
            };

            var filteredStudents =
                from student in arrayOfSudents
                where student.Age >= 18 && student.Age <= 24
                select student;

            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}