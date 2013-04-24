namespace _02.Human
{
    public class HumanApplication
    {
        public static void Main()
        {
            CreatePerson(22);
        }

        public static void CreatePerson(int age)
        {
            Human human = new Human();
            human.Age = age;

            if (age % 2 == 0)
            {
                human.Name = "Boy";
                human.Gender = Gender.Male;
            }
            else
            {
                human.Name = "Girl";
                human.Gender = Gender.Female;
            }
        }
    }
}
