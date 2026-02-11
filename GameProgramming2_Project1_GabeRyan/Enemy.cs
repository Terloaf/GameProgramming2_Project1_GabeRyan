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
            if (Program._gameManager._player._position._x < _position._x)
            {
                _position._x -= 1;
            }
            if (Program._gameManager._player._position._y < _position._y)
            {
                _position._y -= 1;
            }
            if (Program._gameManager._player._position._x > _position._x)
            {
                _position._x += 1;
            }
            if (Program._gameManager._player._position._y > _position._y)
            {
                _position._y += 1;
            }
            DisplayEnemy();
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
