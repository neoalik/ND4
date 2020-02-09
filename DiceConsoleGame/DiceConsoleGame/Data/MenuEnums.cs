using System;
using System.Collections.Generic;
using System.Text;

namespace DiceConsoleGame.Data
{
    public enum MenuDirections
    {
        UP,
        Down,
        Left,
        Right
    }

    public enum MenuOperations
    {
        Play,
        Replay,
        GotoMainMenu,
        GotoPlayerSelectionMenu,
        GotoDiceSelectionMenu,
        GotoGameOverMenu,
        Quit
    }
}
