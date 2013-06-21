namespace _05.HashedSet
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            HashedSet<string> students = new HashedSet<string>();
            students.Add("Pesho");
            students.Add("Pesho");
            students.Add("Gosho");
            students.Remove("Gosho");
            students.Add("Misho");
            students.Add("Ivan");
            Console.WriteLine("Student count: {0}", students.Count);

            HashedSet<string> users = new HashedSet<string>();
            users.Add("Mariq");
            users.Add("Pesho");
            users.Add("Misho");

            HashedSet<string> intersection = students.Intersect(users);
            Console.WriteLine("Intersection:");
            foreach (var name in intersection)
            {
                Console.WriteLine(name);
            }

            HashedSet<string> union = students.Union(users);
            Console.WriteLine("Union: ");
            foreach (var name in union)
            {
                Console.WriteLine(name);
            }
        }
    }
}
