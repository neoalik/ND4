using System;
using System.Collections.Generic;
using System.Text;

namespace DiceConsoleGame.Gui
{
    abstract class Dice : GuiObject
    {
        private readonly int _diceMaxWall;

        private Frame _diceFrame;
        private TextBlock _textBlock;

        /// <summary>
        /// Get walls number of dice
        /// </summary>
        public int DiceWalls
        {
            get { return _diceMaxWall; }
        }

        public Dice(int x, int y, int width, int height, int maxWall, int setdicewall/*, List<string> template*/) : base(x, y, width, height)
        {
            _diceMaxWall = maxWall;

            _diceFrame = new Frame(x, y, width, height);

            _textBlock = new TextBlock(x + 1, y + 1, width - 1, GetDiceTemplateByValue(setdicewall));
        }

        protected void UpdateWall(int wallNumber)
        {
            //_diceFrame.Height

            var template = GetDiceTemplateByValue(wallNumber);

            _textBlock = new TextBlock(base.X + 1, base.Y + ((_diceFrame.Height - template.Count) / 2), base.Width - 1, template);
            Render();
        }

        public override void Render()
        {
            _diceFrame.Render();
            _textBlock.Render();
        }

        public override void Clear()
        {
            _textBlock.Clear();
            //_diceFrame.Clear();
            Render();
        }

        abstract public List<string> GetDiceTemplateByValue(int dicewall);
    }
}
