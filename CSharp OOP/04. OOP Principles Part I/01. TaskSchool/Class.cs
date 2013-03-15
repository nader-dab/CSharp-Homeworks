namespace _01.TaskSchool
{
    public class Class : IOptionable
    {
        private Student[] students;
        private Teacher[] teachers;
        private string textIdentifier;
        private string comment;

        public Class(string texIdentifier, Student[] students, Teacher[] teachers)
        {
            this.TextIdentifier = texIdentifier;
            this.Teachers = teachers;
            this.Students = students;
        }

        public string TextIdentifier
        {
            get
            {
                return this.textIdentifier;
            }

            set
            {
                this.textIdentifier = value;
            }
        }

        public Teacher[] Teachers
        {
            get
            {
                return this.teachers;
            }

            set
            {
                this.teachers = value;
            }
        }

        public Student[] Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
            }
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
    }
}
