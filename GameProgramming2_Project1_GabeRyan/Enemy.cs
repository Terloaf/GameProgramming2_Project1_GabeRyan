using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class Enemy
    {
        public Position _position;
        public Health _health;
        public string _pDisplay;
        public ConsoleColor _pColour;
        public int _enemyWait = 0;

        public Enemy(string display, ConsoleColor colour, Position position, Health health)
        {

            _health = health;
            _pDisplay = display;
            _pColour = colour;
            _position = position;
        }

        public void EnemyMove()
        {

            DisplayEnemy();


            if (Program._gameManager._playerTurn == false)
            {
                _enemyWait += 1;
                if(_enemyWait >= 2)
                {
                    _enemyWait = 0;
                    int enemyXInput = 0;
                    int enemyYInput = 0;
                    if (Program._gameManager._player._position._x < _position._x)
                    {
                        enemyXInput = -1;

                    }
                    if (Program._gameManager._player._position._y < _position._y)
                    {
                        enemyYInput = -1;

                    }
                    if (Program._gameManager._player._position._x > _position._x)
                    {
                        enemyXInput += 1;

                    }
                    if (Program._gameManager._player._position._y > _position._y)
                    {
                        enemyYInput += 1;

                    }

                    

                    _position._x += enemyXInput;
                    _position._y += enemyYInput;

                    if (Program._gameManager._player._position._x == _position._x && Program._gameManager._player._position._y == _position._y)
                    {
                        Program._gameManager._player._health.TakeDmg();
                        _position._x -= enemyXInput;
                        _position._y -= enemyYInput;

                        Console.SetCursorPosition(50, 25);
                        

                        return;
                    }

                    if (Program._gameManager._map.IsSpaceOccupied(_position) == true)
                    {
                        _position._x -= enemyXInput;
                        _position._y -= enemyYInput;
                    }


                }

            }
            Program._gameManager._playerTurn = true;

            Console.Clear();
        }


        private void DisplayEnemy()
        {
            Console.SetCursorPosition(_position._x, _position._y);
            Console.ForegroundColor = _pColour;
            Console.Write(_pDisplay);
            Console.ResetColor();

            Console.SetCursorPosition(50, 21);
            Console.Write($"Health {_health._currentHealth}");

        }
    }
}
