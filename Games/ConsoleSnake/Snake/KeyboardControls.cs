namespace Snake
{
    using System;

    public class KeyboardControls : IUserInterface
    {
        public event EventHandler OnLeftPress;

        public event EventHandler OnRightPress;

        public event EventHandler OnDownPress;

        public event EventHandler OnUpPress;

        public event EventHandler OnEscape;

        public void ProcessInput()
        {
            if (!Console.KeyAvailable)
            {
                return;
            }

            var keyInfo = Console.ReadKey();

            while (Console.KeyAvailable)
            {
                Console.ReadKey();
            }

            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (this.OnLeftPress != null)
                {
                    this.OnLeftPress(this, new EventArgs());
                }
            }

            if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                if (this.OnRightPress != null)
                {
                    this.OnRightPress(this, new EventArgs());
                }
            }

            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (this.OnDownPress != null)
                {
                    this.OnDownPress(this, new EventArgs());
                }
            }

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (this.OnUpPress != null)
                {
                    this.OnUpPress(this, new EventArgs());
                }
            }

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                if (this.OnEscape != null)
                {
                    this.OnEscape(this, new EventArgs());
                }
            }
            
        }
    }
}
