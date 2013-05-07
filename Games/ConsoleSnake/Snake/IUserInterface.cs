namespace Snake
{
    using System;

    public interface IUserInterface
    {
        event EventHandler OnLeftPress;

        event EventHandler OnRightPress;

        event EventHandler OnDownPress;

        event EventHandler OnUpPress;

        event EventHandler OnEscape;

        void ProcessInput();
    }
}
