namespace _01.TaskSchool
{
    public class Teacher : Person
    {
        private Discipline[] disciplineSet;

        public Teacher(string name, params Discipline[] disciplineSet)
            : base(name)
        {
            this.DisciplineSet = disciplineSet;
        }

        public Discipline[] DisciplineSet
        {
            get
            {
                return this.disciplineSet;
            }

            set
            {
                this.disciplineSet = value;
            }
        }
    }
}
