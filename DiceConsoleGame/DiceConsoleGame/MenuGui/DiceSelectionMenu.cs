using DiceConsoleGame.Data;
using DiceConsoleGame.Gui;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiceConsoleGame.MenuGui
{
    class DiceSelectionMenu : Menu
    {
        public event Action<int> OnDiceQuantitySelect;
        public override event Action<Menu, MenuOperations> OnMenuLeave;

        private int counterDice;

        private TextLine titleMenu;
        private TextLine diceQuantity;
        private Frame frame;
        private Button _setDiceQuantityButton;


        public DiceSelectionMenu(int x, int y, int width, int height/*, char charBorder*/) : base(x, y, width, height)
        {

        }

        public override void Init()
        {
            counterDice = 1;

            int X = 120 / 2;
            int Y = 30 / 2 - 3;

            

            frame = new Frame(X - 20, Y - 1, 40, 12, '#');

            string title = "Select +/- dice quantity:";

            int centerTitle = Width / 2 - title.Length / 2;

            titleMenu = new TextLine(centerTitle, Y + 2, title.Length, title);


            string dicesQ = counterDice.ToString();

            centerTitle = Width / 2 - dicesQ.Length / 2;

            diceQuantity = new TextLine(centerTitle, Y + 4, dicesQ.Length, dicesQ);

            _setDiceQuantityButton = new Button("setDiceQuantityButton", X + 1 - 9, Y + 6, 18, 3, "Select");
            _setDiceQuantityButton.SetActive();
            _setDiceQuantityButton.OnEnter += _setDiceQuantityButton_OnEnter;

            AddButton(_setDiceQuantityButton);

            Render();
        }

        private void _setDiceQuantityButton_OnEnter(Button button)
        {
            if(OnDiceQuantitySelect != null)
            {
                OnDiceQuantitySelect(counterDice);
                ExitMenu();
            }
        }

        public override void Render()
        {
            frame.Render();
            titleMenu.Render();
            diceQuantity.Render();
            _setDiceQuantityButton.Render();
        }

        public override void MenuKeyPress(ConsoleKeyInfo pressedChar)
        {
            switch (pressedChar.Key)
            {
                case ConsoleKey.Escape:
                    OnMenuLeave?.Invoke(this, MenuOperations.Quit);
                    ExitMenu();
                    break;
                case ConsoleKey.Enter:
                    MenuEnterButton();
                    break;
                case ConsoleKey.Add:
                case ConsoleKey.UpArrow:
                    counterDice++;

                    diceQuantity.Label = counterDice.ToString();
                    Render();
                    break;
                case ConsoleKey.Subtract:
                case ConsoleKey.DownArrow:
                    if (counterDice > 1)
                    { 
                        counterDice--; 
                    }

                    diceQuantity.Label = counterDice.ToString();
                    Render();
                    break;
                default:
                    break;
            }
        }

        public override void Clear()
        {
            
        }

        public override void CloseMenu()
        {
            OnMenuLeave = null;
        }
    }
}
