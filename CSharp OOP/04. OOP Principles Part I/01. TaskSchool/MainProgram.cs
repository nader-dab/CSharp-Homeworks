namespace _01.TaskSchool
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            var students = new Student[] 
            {
                new Student("Ivan Ivanov", "123"), 
                new Student("Georgi Popov", "124"),
                new Student("Mariq Gerova", "125"),
                new Student("Todor Petkov", "129"),
            };

            var teachers = new Teacher[] 
            {
                new Teacher("Momchil Kostov", new Discipline("Math", 4, 12)),
                new Teacher("Sava Gerov", new Discipline("Biology", 2, 6))
            };

            var eleventhGrade = new Class("11b", students, teachers);
            eleventhGrade.Comment = "Excelent Performance";
        }
    }
}
