using DiceConsoleGame.Data;
using DiceConsoleGame.Gui;
using System;
using System.Collections.Generic;

namespace DiceConsoleGame.MenuGui
{
    class PlayerSelectionMenu : Menu
    {
        public event Action<Menu, int> OnPlayersSelect;
        public override event Action<Menu, MenuOperations> OnMenuLeave;

        private int _players = 2;

        private int _yPosButton = 5;
        
        //buttons
        private Button _P2;
        private Button _P3;
        private Button _P4;
        private Button _P5;
        private Button _P6;
        private Button _P7;

        public PlayerSelectionMenu(int x, int y, int width, int height) : base(x, y, width, height)
        {
            /*
             *       0    1
             *      [2]   3     [0]    1 
             *       4    5
             */
        }

        public override void Init()
        {
            _yPosButton = Height / 2 - 5 - HeightMenuButton / 2;

            //title
            string titleMsg = "How many players play this game?";
            int titlePos = Width / 2 - titleMsg.Length / 2;
            TitleMenu = new TextLine(titlePos, _yPosButton - 2, titleMsg.Length, titleMsg);
            
            int space = 2;
            int firstBtn = (Width / 2 - (WidthMenuButton * 2 + space) / 2);

            _P2 = new Button("P2", firstBtn, _yPosButton, WidthMenuButton, HeightMenuButton, "P2");//0
            _P2.OnEnter += _P2_OnEnter;
            _P3 = new Button("P3", firstBtn + WidthMenuButton + space, _yPosButton, WidthMenuButton, HeightMenuButton, "P3");//1
            _P3.OnEnter += _P2_OnEnter;

            _P4 = new Button("P4", firstBtn, _yPosButton + 5, WidthMenuButton, HeightMenuButton, "P4");
            _P4.OnEnter += _P2_OnEnter;
            _P5 = new Button("P5", firstBtn + WidthMenuButton + space, _yPosButton + 5, WidthMenuButton, HeightMenuButton, "P5");
            _P5.OnEnter += _P2_OnEnter;

            _P6 = new Button("P6", firstBtn, _yPosButton + 10, WidthMenuButton, HeightMenuButton, "P6");
            _P6.OnEnter += _P2_OnEnter;
            _P7 = new Button("P7", firstBtn + WidthMenuButton + space, _yPosButton + 10, WidthMenuButton, HeightMenuButton, "P7");
            _P7.OnEnter += _P2_OnEnter;


            AddButton(new List<Button> {
                _P2,
                _P3,
                _P4,
                _P5,
                _P6,
                _P7,
            });
        }

        private void _P2_OnEnter(Button button)
        {
            switch (button.Name)
            {
                case "P2":
                    _players = 2;
                    break;
                case "P3":
                    _players = 3;
                    break;
                case "P4":
                    _players = 4;
                    break;
                case "P5":
                    _players = 5;
                    break;
                case "P6":
                    _players = 6;
                    break;
                case "P7":
                    _players = 7;
                    break;
                default:
                    _players = 2;
                    break;
            }

            if (OnPlayersSelect != null)
            {
                OnPlayersSelect(this, _players);
                ExitMenu();
            }
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
                case ConsoleKey.RightArrow:
                    MenuRightMove();
                    break;
                case ConsoleKey.LeftArrow:
                    MenuLeftMove();
                    break;
                case ConsoleKey.UpArrow:
                    MenuUpMove();
                    break;
                case ConsoleKey.DownArrow:
                    MenuDownMove();
                    break;
                default:
                    break;
            }
        }

        public override void Render()
        {
            //throw new NotImplementedException();
        }

        public override void Clear()
        {
            //throw new NotImplementedException();
        }

        public override void CloseMenu()
        {
            OnMenuLeave = null;
            OnPlayersSelect = null;
        }
    }
}
