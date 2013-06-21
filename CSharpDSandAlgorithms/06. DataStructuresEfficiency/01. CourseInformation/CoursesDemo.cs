namespace _01.CourseInformation
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class CoursesDemo
    {
        const string StudentsFile = @"../../students.txt";

        private static SortedDictionary<string, SortedSet<Student>> courses = new SortedDictionary<string, SortedSet<Student>>();

        public static void Main(string[] args)
        {
            ReadInputFile();
            PrintCourses();
        }

        private static void PrintCourses()
        {
            foreach (var entry in courses)
            {
                Console.WriteLine("{0}: {1}", entry.Key, string.Join(", ", entry.Value));
            }
        }

        private static void ReadInputFile()
        {
            string[] text = File.ReadAllLines(StudentsFile);

            for (int i = 0; i < text.Length; i++)
            {
                string line = text[i];
                string[] tokens = line.Split(new char[]{'|'}, StringSplitOptions.RemoveEmptyEntries);
                string firstName = tokens[0].Trim();
                string lastName = tokens[1].Trim();
                string courseName = tokens[2].Trim();
                Student currentStudent = new Student(firstName, lastName);

                if (courses.ContainsKey(courseName))
                {
                    courses[courseName].Add(currentStudent);
                }
                else
                {
                    SortedSet<Student> students = new SortedSet<Student>();
                    students.Add(currentStudent);
                    courses.Add(courseName, students);
                }
            }
        }
    }
}
