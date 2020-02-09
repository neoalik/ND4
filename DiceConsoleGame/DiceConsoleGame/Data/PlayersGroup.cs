using DiceConsoleGame.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceConsoleGame.Data
{
    class PlayersGroup : GuiObject
    {
        private List<Player> _players = new List<Player>();

        private const int PLAYER_LABEL_HEIGHT = 5;
        private const int PLAYER_LABEL_SPACE_HORIZONTAL = 2;
        private const int PLAYER_LABEL_SPACE_VERTICAL = 10;

        public PlayersGroup(int x, int y, int width, int height) : base(x, y, width, height)
        {

        }

        /// <summary>
        /// Get next position for player in screen
        /// </summary>
        /// <param name="nameLenght"></param>
        /// <returns></returns>
        private Point GetNextPlayerLocation(int nameLenght)
        {
            int countPlayers = _players.Count;
            int column = countPlayers / 2 + countPlayers % 2;
            
            int x;
            int y;

            if (countPlayers % 2 != 0)
            {
                //change X
                _players[countPlayers - 1].X = Width / 2 - (_players[countPlayers - 1].Width + nameLenght) / 2;
                _players[countPlayers - 1].Render();//change coord

                x = _players[countPlayers - 1].X + nameLenght + PLAYER_LABEL_SPACE_HORIZONTAL;
                y = Height / 2 - PLAYER_LABEL_HEIGHT / 2 + ((column - 1) * PLAYER_LABEL_HEIGHT) - PLAYER_LABEL_SPACE_VERTICAL;

                return new Point { X = x, Y = y};
            }
            else
            {
                //change Y
                if (countPlayers == 0)
                {
                    x = Width / 2 - nameLenght / 2;
                    y = Height / 2 - PLAYER_LABEL_HEIGHT / 2 - PLAYER_LABEL_SPACE_VERTICAL;
                    return new Point { X = x, Y = y };
                }

                x = Width / 2 - nameLenght / 2 + PLAYER_LABEL_SPACE_HORIZONTAL / 2;
                y = Height / 2 - PLAYER_LABEL_HEIGHT / 2 + (PLAYER_LABEL_HEIGHT * column) - PLAYER_LABEL_SPACE_VERTICAL;

                return new Point { X = x, Y = y };
            }
        }

        public override void Clear()
        {
            _players.Clear();
        }

        public override void Render()
        {
            _players.ForEach(p => p.Render());
        }

        /// <summary>
        /// Add player to list group
        /// </summary>
        /// <param name="name"></param>
        public void AddPlayer(string name)
        {
            int nameLenght = name.Length + 6;

            Point point = GetNextPlayerLocation(nameLenght);

            _players.Add(new Player(point.X, point.Y, nameLenght, PLAYER_LABEL_HEIGHT, name));
        }

        /// <summary>
        /// Set player active
        /// </summary>
        /// <param name="playerid"></param>
        public void SetActivePlayer(int playerid)
        {
            if (_players.Count - 1 >= playerid)
            {
                _players.ForEach(p => p.SelectPlayer(false));

                _players[playerid].SelectPlayer(true);
            }
        }

        /// <summary>
        /// Get id player is active
        /// </summary>
        /// <returns></returns>
        public int GetActivePlayer()
        {
            for (int i = 0; i < CountPlayers(); i++)
            {
                if (_players[i].IsSelected)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// How many players in list
        /// </summary>
        /// <returns></returns>
        public int CountPlayers()
        {
            return _players.Count;
        }

        /// <summary>
        /// Add score for player
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sumaDices"></param>
        public void AddScore(int id, int sumaDices)
        {
            _players[id].AddScore(sumaDices);
        }

        /// <summary>
        /// Get player scores
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetPlayerScore(int id)
        {
            return _players[id].Score;
        }

        /// <summary>
        /// Get winner
        /// </summary>
        /// <returns></returns>
        public string GetWinner()
        {
            var maxScore = _players.Max(p => p.Score);

            var players = _players.Where(x => x.Score == maxScore).ToList();

            if(players.Count == 1)
            {
                return $"Winner is the {players[0].Name} with a score {maxScore}.";
            }

            return string.Empty;
        }
    }
}
