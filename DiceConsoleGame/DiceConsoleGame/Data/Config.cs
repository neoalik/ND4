using System;
using System.Collections.Generic;
using System.Text;

namespace DiceConsoleGame.Data
{
    class Config
    {
        private int _playersQ;
        private int _dicesQ;

        public int PlayersQ
        {
            get
            {
                return _playersQ;
            }
            set
            {
                _playersQ = value;
            }
        }

        public int DicesQ
        {
            get
            {
                return _dicesQ;
            }
            set
            {
                _dicesQ = value;
            }
        }

        public Config()
        {

        }
    }
}
