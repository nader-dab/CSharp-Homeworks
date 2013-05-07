namespace Snake
{
    using System;

    public class Food
    {
        public Food(int x, int y, char form)
        {
            this.Position = new Coordinates(x, y);
            this.Form = form;
        }

        public Coordinates Position { get; set; }

        public char Form { get; set; }

        public void Draw()
        {
            ColorConsole.SetCursorPosition(this.Position.X, this.Position.Y);
            ColorConsole.WriteLine(this.Form, ConsoleColor.Magenta);
        }
    }
}
