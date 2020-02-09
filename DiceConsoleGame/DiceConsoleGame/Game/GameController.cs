using DiceConsoleGame.Data;
using DiceConsoleGame.Gui;
using DiceConsoleGame.MenuGui;
using System;

namespace DiceConsoleGame.Game
{
    class GameController : GuiObject
    {
        public event Action<Menu, MenuOperations> OnMenuLeave;//action for menu control

        private GameScreen gameScreen;
        private PlayersGroup playersGroup;
        private DicesGroup dicesGroup;

        private const int TIME_DICE_ROLL = 50;//roll dice time
        private const int WAIT_TIME_NEXT_ROLL = 100;//pausing rolling dice

        public GameController(int x, int y, int width, int height) : base(x, y, width, height)
        {
            playersGroup = new PlayersGroup(X, Y, Width, Height);
        }

        /// <summary>
        /// Start Game with initialization
        /// </summary>
        /// <param name="players"></param>
        /// <param name="dices"></param>
        public void StartGame(int players, int dices)
        {
            //init game
            InitGame(players, dices);

            // render loop
            StartGameLoop();
        }

        /// <summary>
        /// Game initialization
        /// </summary>
        /// <param name="players"></param>
        /// <param name="dices"></param>
        private void InitGame(int players, int dices)
        {
            gameScreen = new GameScreen(X, Y, Width, Height, '#');
            GeneratePlayers(players);
            GenerateDices(dices);
        }

        /// <summary>
        /// Reseting game for reply
        /// </summary>
        public void ResetGame()
        {
            playersGroup.Clear();
        }

        /// <summary>
        /// AutoGenerate selected number dices
        /// </summary>
        /// <param name="dices"></param>
        private void GenerateDices(int dices)
        {
            dicesGroup = new DicesGroup(X + 1, Height - 1 - DiceD6.DICE_HEIGHT, Width - 2, Height - 2, typeof(DiceD6), dices);
            gameScreen.DicesDisplayQuantity(dices);
        }

        /// <summary>
        /// AutoGenerate selected number players
        /// </summary>
        /// <param name="players"></param>
        private void GeneratePlayers(int players)
        {
            for (int i = 0; i < players; i++)
            {
                string name = "Player " + (i + 1);
                playersGroup.AddPlayer(name);
                //add to table score
                gameScreen.AddToTableScore(name);
            }
            playersGroup.SetActivePlayer(0);
        }

        /// <summary>
        /// Game loop
        /// </summary>
        private void StartGameLoop()
        {
            bool needToRender = true;

            int timeCountRoll = 0;
            int waitTimeCountRoll = 0;
            int rounds = 1;

            do
            {
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();


                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.Escape:
                            needToRender = false;
                            OnMenuLeave?.Invoke(null, MenuOperations.GotoGameOverMenu);
                            break;
                        default:
                            break;
                    }
                }

                //game
                if (timeCountRoll <= TIME_DICE_ROLL)
                {
                    dicesGroup.RollingDiceAnimation();
                    timeCountRoll++;
                }
                else
                {
                    int id = playersGroup.GetActivePlayer();

                    if (waitTimeCountRoll == 0)
                    {
                        dicesGroup.RollDice();

                        playersGroup.AddScore(id, dicesGroup.SumaDices);
                        gameScreen.UpdatePlayerScoreInTable(id, playersGroup.GetPlayerScore(id));
                    }

                    if (id + 1 > playersGroup.CountPlayers() - 1)
                    {
                        if (waitTimeCountRoll <= WAIT_TIME_NEXT_ROLL)
                        {
                            waitTimeCountRoll++;
                        }
                        else
                        {
                            //visi zaidejai suzeide
                            //TODO: rezultatai
                            string winnerExist = playersGroup.GetWinner();

                            if (winnerExist != string.Empty)
                            {
                                needToRender = false;

                                Console.Clear();
                                gameScreen.Render();

                                GameOverMenu gameOverMenu = new GameOverMenu(X, Y, Width, Height);
                                gameOverMenu.TitleMenu.Label = winnerExist;

                                gameOverMenu.OnMenuLeave += (sender, args) =>
                                {
                                    OnMenuLeave?.Invoke(gameOverMenu, args);
                                };

                                gameOverMenu.Show();
                            }
                            else
                            {
                                gameScreen.SetMessage($"Run next round {++rounds}");
                                //next add one round
                                playersGroup.SetActivePlayer(0);
                                dicesGroup.SetReadyDices();
                                timeCountRoll = 0;
                                waitTimeCountRoll = 0;
                            }
                        }
                    }
                    else
                    {
                        if (waitTimeCountRoll <= WAIT_TIME_NEXT_ROLL)
                        {
                            waitTimeCountRoll++;
                        }
                        else
                        {
                            playersGroup.SetActivePlayer(id + 1);
                            dicesGroup.SetReadyDices();
                            timeCountRoll = 0;
                            waitTimeCountRoll = 0;
                        }
                    }
                }

                Render();
                System.Threading.Thread.Sleep(20);
            } while (needToRender);
        }

        public override void Render()
        {
            //TODO: GameControl Render neaprasytas
        }

        public override void Clear()
        {
            //TODO: GameControl Clear neaprasytas
        }
    }
}
