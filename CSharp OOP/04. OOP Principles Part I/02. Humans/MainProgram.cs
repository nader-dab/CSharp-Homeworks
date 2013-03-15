namespace _02.Humans
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MainProgram
    {
        public static void Main(string[] args)
        {
            var students = new List<Student>()
            {
                new Student("Ivan", "Petrov", 10),
                new Student("Mariq", "Petrova", 11),
                new Student("Georgi", "Petrov", 7),
                new Student("Mariq", "Georgiva", 11),
                new Student("Dimitur", "Petrov", 12),
                new Student("Ivan", "Ivanov", 8),
                new Student("Dobromir", "Atanasov", 4),
                new Student("Mariq", "Atanasova", 11),
                new Student("Georgi", "Todorov", 9),
                new Student("Pesho", "Petrov", 11),
            };

            // Sorting students by grade using lambda expresion
            var sortedStudents = students.OrderBy(x => x.Grade);

            Console.WriteLine(string.Join("\n", sortedStudents));
            Console.WriteLine();

            var workers = new List<Worker>()
            {
                new Worker("Bai", "Ivan", 250m, 60),
                new Worker("Mariq", "Ivanova", 350m, 65),
                new Worker("Dimityr", "Pekov", 450m, 70),
                new Worker("Petyr", "Todorov", 500m, 75),
                new Worker("Dobromir", "Zahariev", 200m, 55),
                new Worker("Georgi", "Brejilski", 300m, 60),
                new Worker("Denitsa", "Ivanova", 150m, 80),
                new Worker("Ivan", "Todorov", 360m, 60),
                new Worker("Mariq", "Deliiska", 465m, 60),
                new Worker("Stamat", "Petrov", 175m, 65),
            };

            // Sorting workers by money per hour using LINQ
            var sortedWorkers =
                from worker in workers
                orderby worker.MoneyPerHour()
                select worker;

            foreach (var worker in sortedWorkers.Reverse())
            {
                Console.WriteLine("{0:0.00}$/hour {1}", worker.MoneyPerHour(), worker);
            }

            Console.WriteLine();

            var mergeList = new List<Human>();

            // Merging students and workers
            foreach (var student in students)
            {
                mergeList.Add(student);
            }

            foreach (var worker in workers)
            {
                mergeList.Add(worker);
            }

            // Sorting students and workers by first and last name
            var sortedMergeList = mergeList.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

            Console.WriteLine(string.Join("\n", sortedMergeList));
        }
    }
}
