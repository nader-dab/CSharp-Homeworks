namespace _01.TaskSchool
{
    public abstract class Person : IOptionable
    {
        private string name;
        private string comment;

        public Person(string name)
        { 
            this.Name = name;
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }

            set
            {
                this.comment = value;
            }
        }

        protected string Name
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
    }
}
