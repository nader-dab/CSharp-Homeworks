using System;
using System.Linq;

namespace TetrisEngine
{
    public interface IUserInterface
    {
        event EventHandler OnLeftPressed;

        event EventHandler OnRightPressed;

        event EventHandler OnRotatePressed;

        event EventHandler OnEscapePressed;

        void ProcessInput();
    }
}
