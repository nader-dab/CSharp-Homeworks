using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PersonInformation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person pesho = new Person("Petur");
            Person misho = new Person("Mihail", 23);

            Console.WriteLine(pesho);
            Console.WriteLine();
            Console.WriteLine(misho);
        }
    }
}
