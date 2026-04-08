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
        public int _playerXInput;
        public int _playerYInput;

        public Player(string display, ConsoleColor colour, Position position, Health health)
        {

            _health = health;
            _pDisplay = display;
            _pColour = colour;
            _position = position;
        }

        public void PlayerMove()
        {
            
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


                int _desiredX = _position._x + playerXinput;
                int _desiredY = _position._y + playerYinput;
                //_position._x += playerXinput;
                //_position._y += playerYinput;
                _playerXInput = playerXinput;
                _playerYInput = playerYinput;

                for(int i = 0; i < Program._gameManager._enemies.Count; i++)
                {
                    if (Program._gameManager._enemies[i]._position._x == _desiredX && Program._gameManager._enemies[i]._position._y == _desiredY)
                    {
                        Program._gameManager._enemies[i]._health.TakeDmg();
                        Program._gameManager._playerTurn = false;
                        return;
                    }
                }

                if(_desiredX == 0)
                {
                    return;
                }
                if(_desiredX == Program._gameManager._map._map[0].Length)
                {
                    return;
                }
                if(_desiredY == Program._gameManager._map._map.Length)
                {
                    return;
                }
                if(_desiredY == 0)
                {
                    return;
                }

                if (Program._gameManager._map.IsSpaceOccupied(new Position(_desiredX, _desiredY)) == true)
                {
                    return;
                }

                _position._x = _desiredX;
                _position._y = _desiredY;
                
                Program._gameManager._playerTurn = false;
                Program._gameManager._screenIsDirty = true;
                
            }
            


        }

        

        public void DisplayPlayer()
        {
            Console.SetCursorPosition(_position._x, _position._y);
            Console.ForegroundColor = _pColour;
            Console.Write(_pDisplay);
            Console.ResetColor();

            Console.SetCursorPosition(50, 20);
            Console.Write($"Player Health {_health._currentHealth}");

        }


    }
}
