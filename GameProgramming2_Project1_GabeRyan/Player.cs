using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class Player
    {

        Position _position;

        public int _pHealth;
        public string _pDisplay;
        public ConsoleColor _pColour;

        public Player(int health, string display, ConsoleColor colour, Position position)
        {
            _pHealth = health;
            _pDisplay = display;
            _pColour = colour;
            _position = position;
        }

        public void PlayerMove()
        {
            DisplayPlayer();

            


           
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

            _position._y += playerXinput;
            _position._y += playerYinput;

            if (playerXinput == -1 && _position._x == -1)
            {
                _position._x += 1;
                return;
            }

            if (playerYinput == -1 && _position._y == -1)
            {
                _position._y += 1;
                return;
            }
            if(playerYinput == 1 && _position._y == 30)
            {
                _position._y -= 1;
                return;
            }

            
            DisplayPlayer();
            Console.Clear();
        }

        private void DisplayPlayer()
        {
            Console.SetCursorPosition(_position._x, _position._y);
            Console.ForegroundColor = _pColour;
            Console.Write(_pDisplay);
            Console.ResetColor();

            Console.SetCursorPosition(50, 20);
            Console.Write(_pHealth);

        }

    }
}
