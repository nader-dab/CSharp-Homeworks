using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PersonInformation
{
    public class Person
    {
        private string name;
        private int? age;

        public Person(string name)
            : this(name, null)
        { 
        }

        public Person(string name, int? age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0} \nAge: {1}", this.Name, !string.IsNullOrEmpty(this.Age.ToString()) ? this.Age.ToString() : "Unspecified");
        }
    }
}
