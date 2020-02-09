using DiceConsoleGame.Gui;
using DiceConsoleGame.MenuGui;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiceConsoleGame.Game
{
    class GameScreen : Window
    {
        private TableScore tableScore;
        private TextLine dicequantityDisplay;
        public GameScreen(int x, int y, int width, int height, char borderChar) : base(x, y, width, height, borderChar)
        {
            tableScore = new TableScore(width - 30, y + 2, 25, 30);
            tableScore.Title();
        }

        /// <summary>
        /// In screen show dices quantities select
        /// </summary>
        /// <param name="dices"></param>
        public void DicesDisplayQuantity(int dices)
        {
            string msg = $"Dices: {dices.ToString()}pcs";

            if (dicequantityDisplay == null)
            {
                dicequantityDisplay = new TextLine(X + 1, Y + 2, 20, msg) ;
            }
            else
            {
                dicequantityDisplay.Label = msg;
            }
        }
        
        /// <summary>
        /// Add player name to table
        /// </summary>
        /// <param name="name"></param>
        public void AddToTableScore(string name)
        {
            tableScore.AddRow(name);
        }

        /// <summary>
        /// Update table score by playerid
        /// </summary>
        /// <param name="playerid"></param>
        /// <param name="score"></param>
        public void UpdatePlayerScoreInTable(int playerid, int score)
        {
            tableScore.UpdateTableScore(playerid, score);
        }

        /// <summary>
        /// Message after table score for information, like how many rounds played players
        /// </summary>
        /// <param name="msg"></param>
        public void SetMessage(string msg)
        {
            tableScore.Message(msg);
        }
    }
}
