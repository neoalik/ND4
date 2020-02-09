using DiceConsoleGame.Gui;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiceConsoleGame.Data
{
    class DicesGroup : GuiObject
    {
        private const int DICES_SPACE_HORIZONTAL = 1;//space between dices

        private const int DICES_MAX_DRAW_ON_SCREEN = 10;// if dices more than 11 dices, she no draw in screen, only work like object in memory and added to dices list

        private Random _rnd = new Random();//random for dices values

        private List<Dice> _dices = new List<Dice>();

        private Type _diceType;

        private int _sumaDices = 0;

        /// <summary>
        /// Return suma all dices
        /// </summary>
        public int SumaDices
        {
            get { return _sumaDices; }
        }
        /// <summary>
        /// How many select for game dices
        /// </summary>
        public int CountDices
        {
            get { return _dices.Count; }
        }

        public DicesGroup(int x, int y, int width, int height, Type dice, int dices) : base(x, y, width, height)
        {
            _diceType = dice;
            GenerateDices(dice, dices);
        }

        /// <summary>
        /// Drawing dices on screen
        /// </summary>
        /// <param name="dice"></param>
        /// <param name="dices"></param>
        private void GenerateDices(Type dice, int dices)
        {
            if(dice == typeof(DiceD6))
            {
                if (dices < 1)
                    throw new Exception("Dices minimum must be 1");

                int _maxScreenWidthCheck;

                if (dices <= DICES_MAX_DRAW_ON_SCREEN)
                {
                    _maxScreenWidthCheck = (dices * DiceD6.DICE_WIDTH) / 2 + dices * DICES_SPACE_HORIZONTAL / 2 - DiceD6.DICE_WIDTH / 2 + 2;
                }
                else
                {
                    _maxScreenWidthCheck = (DICES_MAX_DRAW_ON_SCREEN * DiceD6.DICE_WIDTH) / 2 + DICES_MAX_DRAW_ON_SCREEN * DICES_SPACE_HORIZONTAL / 2 - DiceD6.DICE_WIDTH / 2 + 2;
                }


                //int _maxScreenWidthCheck = (dices * DiceD6.DICE_WIDTH) / 2 + ((dices < DICES_MAX_DRAW_ON_SCREEN) ? 0 : dices * DICES_SPACE_HORIZONTAL);

                /*if (_maxScreenWidthCheck >= Width / 2)
                {
                    _maxScreenWidthCheck = DiceD6.DICE_WIDTH * DICES_MAX_DRAW_ON_SCREEN / 2 + (DICES_MAX_DRAW_ON_SCREEN / 2) * DICES_SPACE_HORIZONTAL;
                }*/

                _dices.Add(new DiceD6(Width / 2 - _maxScreenWidthCheck, Y, _rnd.Next(1, DiceD6.DICE_MAX_WALL + 1)));

                int _xDiceDraw = (Width / 2 - _maxScreenWidthCheck) + _dices[0].Width + DICES_SPACE_HORIZONTAL;
                int _yDiceDraw = Y;

                for (int i = 1; i < dices; i++)
                {
                    if (DICES_MAX_DRAW_ON_SCREEN <= i)
                    {
                        _dices.Add(new DiceD6(_dices[DICES_MAX_DRAW_ON_SCREEN - 1].X, _dices[DICES_MAX_DRAW_ON_SCREEN - 1].Y, _rnd.Next(1, DiceD6.DICE_MAX_WALL + 1)));
                    }
                    else
                    {
                        _dices.Add(new DiceD6(_xDiceDraw, _yDiceDraw, _rnd.Next(1, DiceD6.DICE_MAX_WALL + 1)));
                        _xDiceDraw += DiceD6.DICE_WIDTH + DICES_SPACE_HORIZONTAL;
                    }

                    if(_xDiceDraw >= Width)
                    {
                        _yDiceDraw += _dices[0].Height;
                        _xDiceDraw = X;
                    }
                }
            }
            else
            {
                Console.WriteLine("other type");
            }

            Render();
        }

        /// <summary>
        /// Set default information dices
        /// </summary>
        public void SetReadyDices()
        {
            _sumaDices = 0;//set 0 suma points
            Clear();//clear dices point on wall
        }
        
        /// <summary>
        /// Roll dices and get value all dices
        /// </summary>
        public void RollDice()
        {
            _dices.ForEach(dice => {
                if(_diceType == typeof(DiceD6))
                {
                    DiceD6 diceD6 = dice as DiceD6;
                    _sumaDices += diceD6.Value = _rnd.Next(1, DiceD6.DICE_MAX_WALL + 1);
                }
            });
        }

        /// <summary>
        /// Dices animation without summa
        /// </summary>
        public void RollingDiceAnimation()
        {
            _dices.ForEach(dice => {
                if (_diceType == typeof(DiceD6))
                {
                    DiceD6 diceD6 = dice as DiceD6;
                    diceD6.Value = _rnd.Next(1, DiceD6.DICE_MAX_WALL + 1);
                }
            });
        }

        public override void Render()
        {
            _dices.ForEach(dice => dice.Render());
        }

        public override void Clear()
        {
            _dices.ForEach(dc => dc.Clear());
        }
    }
}
