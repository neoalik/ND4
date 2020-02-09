using System;
using System.Collections.Generic;
using System.Text;

namespace DiceConsoleGame.Gui
{
    class DiceD6 : Dice
    {
        public const int DICE_WIDTH = 9;// + 8;
        public const int DICE_HEIGHT = 5;// + 4;
        public const int DICE_MAX_WALL = 6;

        private int _diceValue;
        public int Value
        {
            get
            {
                return _diceValue;
            }
            set
            {
                _diceValue = (Math.Abs(value) > DiceWalls) ? 1 : value;
                base.UpdateWall(_diceValue);
            }
        }

        public DiceD6(int x, int y, int value) : base(x, y, DICE_WIDTH, DICE_HEIGHT, DICE_MAX_WALL, value)
        {
            Value = value;
        }

        public override List<string> GetDiceTemplateByValue(int wall)
        {
            switch (wall)
            {
                case 1:
                    return new List<string> { "     ", "  ●  ", "     " };
                case 2:
                    return new List<string> { "    ●", "     ", "●    " };
                case 3:
                    return new List<string> { "    ●", "  ●  ", "●    " };
                case 4:
                    return new List<string> { "●   ●", "     ", "●   ●" };
                case 5:
                    return new List<string> { "●   ●", "  ●  ", "●   ●" };
                case 6:
                    return new List<string> { "●   ●", "●   ●", "●   ●" };
                default:
                    throw new Exception("Is not found wall by value");

            }
        }

        public override void Render()
        {
            base.Render();
        }

        public override void Clear()
        {
            base.Clear();
        }
    }
}
