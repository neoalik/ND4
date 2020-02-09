using DiceConsoleGame.Data;
using DiceConsoleGame.Gui;
using DiceConsoleGame.MenuGui;
using System;

namespace DiceConsoleGame.Game
{
    class MenuController : Window
    {
        private MainMenu mainMenu;
        private PlayerSelectionMenu playerSelectionMenu;
        private DiceSelectionMenu diceSelectionMenu;
        private GameOverMenu gameOverMenu;
        private Config config;
        private GameController gameController;

        public MenuController(int x, int y, int width, int height, char borderChar) : base(x, y, width, height, borderChar)
        {
            config = new Config();
        }

        public void Show()
        {
            mainMenu = new MainMenu(X, Y, Width, Height);
            mainMenu.OnMenuLeave += MainMenu_OnMenuLeave;
            mainMenu.Show();
        }

        /// <summary>
        /// Alls menu controls
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="op"></param>
        private void MainMenu_OnMenuLeave(Menu menu, MenuOperations op)
        {
            Console.Clear();
            Render();
            switch (op)
            {
                case MenuOperations.GotoMainMenu:
                    mainMenu.Show();
                    break;
                case MenuOperations.GotoPlayerSelectionMenu:
                    if (playerSelectionMenu == null)
                    {
                        playerSelectionMenu = new PlayerSelectionMenu(X, Y, Width, Height);
                        playerSelectionMenu.OnPlayersSelect += PlayerSelectionMenu_OnPlayersSelect;
                        playerSelectionMenu.OnMenuLeave += MainMenu_OnMenuLeave;
                    }
                    playerSelectionMenu.Show();
                    break;
                case MenuOperations.Replay:
                    Console.Clear();//start game
                    gameController.ResetGame();
                    gameController.StartGame(config.PlayersQ, config.DicesQ);
                    break;
                case MenuOperations.GotoGameOverMenu:
                    if (gameOverMenu == null)
                    {
                        gameOverMenu = new GameOverMenu(X, Y, Width, Height);
                        gameOverMenu.OnMenuLeave += MainMenu_OnMenuLeave;
                    }

                    gameOverMenu.Show();
                    break;
                case MenuOperations.Quit:
                    if (menu is PlayerSelectionMenu)
                    {
                        mainMenu.Show();
                        break;
                    }
                    else if (menu is DiceSelectionMenu)
                    {
                        playerSelectionMenu.Show();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Environment.Exit(0);
                    }

                    break;
                default:
                    break;
            }
        }

        private void PlayerSelectionMenu_OnPlayersSelect(Menu menu, int players)
        {
            config.PlayersQ = players;

            diceSelectionMenu = new DiceSelectionMenu(X, Y, Width, Height);
            diceSelectionMenu.OnDiceQuantitySelect += DiceSelectionMenu_OnDiceQuantitySelect;
            diceSelectionMenu.OnMenuLeave += MainMenu_OnMenuLeave;
            diceSelectionMenu.Show();
        }

        private void DiceSelectionMenu_OnDiceQuantitySelect(int dicequantity)
        {
            config.DicesQ = dicequantity;

            Console.Clear();//start game
            gameController = new GameController(X, Y, Width, Height);
            gameController.OnMenuLeave += MainMenu_OnMenuLeave;
            gameController.StartGame(config.PlayersQ, config.DicesQ);
        }
    }
}
