using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    
    internal class Collectables
    {
        public int _collectablesCurrentlyActive = 0;
        public Position _position;
        public int _collectablesCount;
        public Collectables(Position position)
        {
            _position = position;
        }

        public void SpawnCollectable()
        {
            DisplayCollectable();
            if (_collectablesCurrentlyActive == 0)
            {
                Random random = new Random();

                _position._x = random.Next(2, Program._gameManager._map._map[0].Length - 1);
                _position._y = random.Next(2, Program._gameManager._map._map.Length - 1);



                if (Program._gameManager._map._map[_position._y][_position._x] != '`')
                {

                    SpawnCollectable();
                }

                _collectablesCurrentlyActive += 1;

                

            }

            
        }

        public void DisplayCollectable()
        {
            Console.SetCursorPosition(_position._x, _position._y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("P");
            Console.ResetColor();
        }

        public void DisplayScore()
        {
            Console.SetCursorPosition(50, 25);
            Console.Write($"Score: {_collectablesCount}");
        }
    }
}
