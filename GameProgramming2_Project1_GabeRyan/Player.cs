using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class Player
    {
        public int _playerXPos = 0;
        public int _playerYPos = 0;

        public int _pHealth;
        public string _pDisplay;
        public ConsoleColor _pColour;

        public Player(int health, string display, ConsoleColor colour)
        {
            _pHealth = health;
            _pDisplay = display;
            _pColour = colour;
        }

        public void PlayerHandler()
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

            _playerXPos += playerXinput;
            _playerYPos += playerYinput;

            if (playerXinput == -1 && _playerXPos == -1)
            {
                _playerXPos += 1;
                return;
            }

            if (playerYinput == -1 && _playerYPos == -1)
            {
                _playerYPos += 1;
                return;
            }
            if(playerYinput == 1 && _playerYPos == 30)
            {
                _playerYPos -= 1;
                return;
            }

            
            DisplayPlayer();
            Console.Clear();
        }

        private void DisplayPlayer()
        {
            Console.SetCursorPosition(_playerXPos, _playerYPos);
            Console.ForegroundColor = _pColour;
            Console.Write(_pDisplay);
            Console.ResetColor();

            Console.SetCursorPosition(50, 20);
            Console.Write(_pHealth);

        }

    }
}
