using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class EnemyScared : Enemy
    {

        public EnemyScared(string display, ConsoleColor colour, Position position, Health health) : base(display, colour, position, health)
        {
            

        }

        public void EnemyScaredMove()
        {
            int enemyXInput = 0;
            int enemyYInput = 0;

            if (_health._currentHealth <= 0)
            {
                Random random = new Random();

                _position._x = random.Next(1, Program._gameManager._map._map[0].Length - 1);
                _position._y = random.Next(1, Program._gameManager._map._map.Length - 1);

                if (Program._gameManager._map._map[_position._y][_position._x] != '`')
                {
                    EnemyMove();
                }

                _health.RespawnHealth();
                return;
            }
            if (Program._gameManager._playerTurn == false)
            {
                Console.SetCursorPosition(0, 25);
                Console.WriteLine("debug");

                _enemyWait += 1;
                if (_enemyWait >= 2)
                {
                    _enemyWait = 0;

                    if (Program._gameManager._player._position._x < _position._x)
                    {
                        enemyXInput += 1;

                    }
                    if (Program._gameManager._player._position._y < _position._y)
                    {
                        enemyYInput += 1;

                    }
                    if (Program._gameManager._player._position._x > _position._x)
                    {
                        enemyXInput -= 1;

                    }
                    if (Program._gameManager._player._position._y > _position._y)
                    {
                        enemyYInput -= 1;

                    }

                    _position._x += enemyXInput;
                    _position._y += enemyYInput;


                    if (Program._gameManager._player._position._x == _position._x && Program._gameManager._player._position._y == _position._y)
                    {
                        Program._gameManager._player._health.TakeDmg();
                        _position._x -= enemyXInput;
                        _position._y -= enemyYInput;


                    }



                    if (Program._gameManager._map.IsSpaceOccupied(_position) == true)
                    {
                        _position._x -= enemyXInput;
                        _position._y -= enemyYInput;

                    }

                }

            }

        }




    }
}
