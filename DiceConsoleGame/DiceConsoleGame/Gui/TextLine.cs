using System;

namespace DiceConsoleGame.Gui
{
    class TextLine : GuiObject
    {
        private string _label;

        public TextLine(int x, int y, int width, string label) : base(x, y, width, 0)
        {
            Label = label;
        }

        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                //this need, if textline label is changed text
                if (_label != null && _label.Length != 0 && _label.Length != value.Length)
                {
                    Clear();
                    if (value.Length > _label.Length)
                    {
                        // x-- <<
                        X = X - (value.Length - _label.Length) / 2;
                    }
                    else if (value.Length < _label.Length)
                    {
                        // x++ >>
                        X = X + (_label.Length - value.Length) / 2;
                        Width = value.Length;
                    }
                    else
                    {
                        //nothing if lenght same
                    }

                    
                }

                _label = value;
                Render();
            }
        }

        public override void Clear()
        {
            Console.SetCursorPosition(X, Y);
            if (Width > Label.Length)
            {
                int offset = (Width - Label.Length) / 2;
                for (int i = 0; i < offset; i++)
                {
                    Console.Write(' ');
                }
            }
        }

        public override void Render()
        {
            Clear();
            Console.Write(Label);
        }
    }
}
