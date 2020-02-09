using System;
using System.Collections.Generic;
using System.Text;

namespace DiceConsoleGame.Gui
{
    class Player : GuiObject
    {
        private readonly string _name;

        private Button _playerPlate;

        private int _score = 0;

        /// <summary>
        /// Get player score
        /// </summary>
        public int Score
        {
            get
            {
                return _score;
            }
        }

        /// <summary>
        /// Get player name
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        public bool IsSelected
        {
            get
            {
                return _playerPlate.IsActive;
            }
        }

        public Player(int x, int y, int width, int height, string name) : base(x, y, width, height)
        {
            _name = name;

            _playerPlate = new Button(Name.Replace(' ', '_'), X, Y, Width, Height, Name);

            Render();
        }

        public void SelectPlayer(bool active)
        {
            if (active)
            {
                _playerPlate.SetActive();
            }
            else
            {
                _playerPlate.NoActive();
            }

            Render();
        }

        

        public void AddScore(int score)
        {
            _score += score;
        }

        public void ResetScore()
        {
            _score = 0;
        }
        
        public override void Clear()
        {
            _playerPlate.Clear();
        }

        public override void Render()
        {
            Clear();
            _playerPlate.X = X;
            _playerPlate.Y = Y;
            //
            _playerPlate.Render();
        }
    }
}
