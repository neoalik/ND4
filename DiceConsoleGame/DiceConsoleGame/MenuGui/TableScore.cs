using DiceConsoleGame.Gui;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiceConsoleGame.MenuGui
{
    class TableScore : GuiObject
    {
        private List<TextLine> _textLinesNames = new List<TextLine>();
        private List<TextLine> _textLinesScores = new List<TextLine>();

        private TextLine _messageText;

        private const int TABLE_COLUMN_WIDTH = 8;

        public TableScore(int x, int y, int width, int height) : base(x, y, width, height)
        {
            /**
             *        Name  |  Score
             *      ------------------
             *     
             */
        }

        /// <summary>
        /// Add to table score new row with title
        /// </summary>
        /// <param name="title"></param>
        public void AddRow(string title)
        {
            Console.SetCursorPosition(X, ++Y);

            int center = Width / 2 - title.Length / 2;

            _textLinesNames.Add(new TextLine(X, Y, TABLE_COLUMN_WIDTH, title));
            _textLinesScores.Add(new TextLine(X + center + 7, Y, title.Length, ""));


            Console.SetCursorPosition(X, ++Y);

            for (int topborder = 0; topborder < Width; topborder++)
            {
                Console.Write('-');
            }
        }

        /// <summary>
        /// Message on bottom tablescore like info
        /// </summary>
        /// <param name="msg"></param>
        public void Message(string msg)
        {
            if(_messageText == null)
            {
                _messageText = new TextLine(X, ++Y, Width, msg);
            }
            else
            {
                _messageText.Label = msg;
            }
        }

        /// <summary>
        /// Update table score
        /// </summary>
        /// <param name="playerid"></param>
        /// <param name="score"></param>
        public void UpdateTableScore(int playerid, int score)
        {
            _textLinesScores[playerid].Label = score.ToString();
        }

        /// <summary>
        /// Generate in table score titles
        /// </summary>
        public void Title()
        {
            string[] columns = new string[] { "Name", "Score" };
            Console.SetCursorPosition(X, Y);

            for(int topborder = 0; topborder < Width; topborder++)
            {
                Console.Write('-');
            }

            Console.SetCursorPosition(X, ++Y);

            for (int i = 0; i < columns.Length; i++)
            {
                Console.Write(columns[i]);

                if(i + 1 < columns.Length)
                {
                    for(int z = 0; z < TABLE_COLUMN_WIDTH; z++)
                    {
                        Console.Write(' ');
                    }

                    Console.Write("|");

                    Console.Write(' ');
                }
            }

            Console.SetCursorPosition(X, ++Y);

            for (int topborder = 0; topborder < Width; topborder++)
            {
                Console.Write('-');
            }
        }

        public override void Clear()
        {
            //TODO: neaprasyta
        }

        public override void Render()
        {
            //TODO: neaprasyta
        }
    }
}
