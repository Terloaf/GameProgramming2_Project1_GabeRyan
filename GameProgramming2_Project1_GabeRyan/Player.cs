using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class Player
    {

        public Position _position;
        public Health _health;
        public string _pDisplay;
        public ConsoleColor _pColour;

        public Player(string display, ConsoleColor colour, Position position, Health health)
        {

            _health = health;
            _pDisplay = display;
            _pColour = colour;
            _position = position;
        }

        public void PlayerMove()
        {
            DisplayPlayer();
            if (Program._gameManager._playerTurn == true)
            {
                
                int playerXinput = 0;
                int playerYinput = 0;

                if (!Console.KeyAvailable)
                {
                    return;
                }
                
                ConsoleKeyInfo Input = Console.ReadKey(true);
                if (Input.Key == ConsoleKey.W) playerYinput -= 1;
                if (Input.Key == ConsoleKey.S) playerYinput += 1;
                if (Input.Key == ConsoleKey.D) playerXinput += 1;
                if (Input.Key == ConsoleKey.A) playerXinput -= 1;


                
                _position._x += playerXinput;
                _position._y += playerYinput;

                if (Program._gameManager._enemy._position._x == _position._x && Program._gameManager._enemy._position._y == _position._y)
                {
                    Program._gameManager._enemy._health.TakeDmg();
                    _position._x -= playerXinput;
                    _position._y -= playerYinput;
                    return;
                }

                if (playerXinput == -1 && _position._x == -1)
                {
                    _position._x += 1;
                    return;
                }

                if (playerXinput == 1 && _position._x == Program._gameManager._map._map[0].Length)
                {
                    _position._x -= 1;
                    return;
                }

                if (playerYinput == -1 && _position._y == -1)
                {
                    _position._y += 1;
                    return;
                }
                if (playerYinput == 1 && _position._y == Program._gameManager._map._map.Length)
                {
                    _position._y -= 1;
                    return;
                }
                

                if (Program._gameManager._map.IsSpaceOccupied(_position) == true)
                {
                    _position._x -= playerXinput;
                    _position._y -= playerYinput;
                }

                
                Program._gameManager._playerTurn = false;
                
            }
            Console.Clear();


        }

        

        private void DisplayPlayer()
        {
            Console.SetCursorPosition(_position._x, _position._y);
            Console.ForegroundColor = _pColour;
            Console.Write(_pDisplay);
            Console.ResetColor();

            Console.SetCursorPosition(50, 20);
            Console.Write($"Health {_health._currentHealth}");

        }

        public void GameOverCheck()
        {
            if(_health._currentHealth <= 0)
            {
                Program._gameManager._isPlaying = false;
            }
        }

    }
}
