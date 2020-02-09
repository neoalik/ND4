using DiceConsoleGame.Data;
using DiceConsoleGame.Game;
using DiceConsoleGame.Gui;
using DiceConsoleGame.MenuGui;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DiceConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Utils.DisableConsoleQuickEdit.Go();//cia tam kad pele negalima butu statyti zemeklio

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;


            GuiController guiController = new GuiController(0,0, 120, 30, '#');
            guiController.ShowMenu();

            #region paslepta
            /*
            Console.WriteLine("┌───────┐");
            Console.WriteLine("│ ●   ● │");
            Console.WriteLine("│ ●   ● │");
            Console.WriteLine("│ ●   ● │");
            Console.WriteLine("└───────┘");

            Console.WriteLine("┌───────┐");
            Console.WriteLine("│ ●   ● │");
            Console.WriteLine("│   ●   │");
            Console.WriteLine("│ ●   ● │");
            Console.WriteLine("└───────┘");

            Console.WriteLine("┌───────┐");
            Console.WriteLine("│ ●   ● │");
            Console.WriteLine("│       │");
            Console.WriteLine("│ ●   ● │");
            Console.WriteLine("└───────┘");

            Console.WriteLine("┌───────┐");
            Console.WriteLine("│     ● │");
            Console.WriteLine("│   ●   │");
            Console.WriteLine("│ ●     │");
            Console.WriteLine("└───────┘");

            Console.WriteLine("┌───────┐");
            Console.WriteLine("│     ● │");
            Console.WriteLine("│       │");
            Console.WriteLine("│ ●     │");
            Console.WriteLine("└───────┘");

            Console.WriteLine("┌───────┐");
            Console.WriteLine("│       │");
            Console.WriteLine("│   ●   │");
            Console.WriteLine("│       │");
            Console.WriteLine("└───────┘");

            */

            //Dice(1);
            #endregion
        }
    }
}
