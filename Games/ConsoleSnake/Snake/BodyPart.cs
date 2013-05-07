namespace Snake
{
    public class BodyPart
    {
        public BodyPart(int x, int y, char form)
        {
            this.Position = new Coordinates(x, y);
            this.Form = form;
        }

        public Coordinates Position { get; set; }

        public char Form { get; set; }
    }
}
