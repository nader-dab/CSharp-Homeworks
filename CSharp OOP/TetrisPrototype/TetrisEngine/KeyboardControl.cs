using System;
using System.Linq;

namespace TetrisEngine
{
    public class KeyboardControls : IUserInterface
    {
        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey();
                while (Console.KeyAvailable)
                {
                    Console.ReadKey();
                }
                if (keyInfo.Key.Equals(ConsoleKey.LeftArrow))
                {
                    if (this.OnLeftPressed != null)
                    {
                        this.OnLeftPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.RightArrow))
                {
                    if (this.OnRightPressed != null)
                    {
                        this.OnRightPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.S))
                {
                    if (this.OnRotatePressed != null)
                    {
                        this.OnRotatePressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.Escape))
                {
                    if (this.OnEscapePressed != null)
                    {
                        this.OnEscapePressed(this, new EventArgs());
                    }
                }
            }
        }

        public event EventHandler OnLeftPressed;

        public event EventHandler OnRightPressed;

        public event EventHandler OnRotatePressed;

        public event EventHandler OnEscapePressed;
    }
}
