namespace _01.StudentInformation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            Student pesho = new Student("Petur", "Ivanov", "Petrov", 8849282128, "Sofia jk Mladost", "088 888 888", "pesho@abv.bg", "first", Specialties.ComptuterScience, Universities.TU, Faculties.Science);
            
            Student misho = pesho.Clone();
            Student petur = pesho.Clone();
            petur.Ssn = 8849282129; // changing SSN to be greater
            misho.FirstName = "Mihail";

            Console.WriteLine(misho.Equals(pesho));

            var students = new List<Student> { petur, pesho, misho };
            students.Sort(); // sorting students using IComparable<Student>

            Console.WriteLine(string.Join("\n\n", students)); // Printing sorted student
        }
    }
}
