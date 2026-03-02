using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class CollectablesHealthPickup : Collectables
    {
        public CollectablesHealthPickup(Position position, string display, ConsoleColor colour) : base(position, display, colour)
        {

        }

        public void SpawnCollectableHealth()
        {
            DisplayCollectableHealth();
            if (_collectablesCurrentlyActive == 0)
            {
                Random random = new Random();

                _position._x = random.Next(1, Program._gameManager._map._map[0].Length - 1);
                _position._y = random.Next(1, Program._gameManager._map._map.Length - 1);



                if (Program._gameManager._map._map[_position._y][_position._x] != '`')
                {

                    SpawnCollectableHealth();
                }

                _collectablesCurrentlyActive += 1;



            }


        }
        public void DisplayCollectableHealth()
        {
            Console.SetCursorPosition(_position._x, _position._y);
            Console.ForegroundColor = _colour;
            Console.Write(_display);
            Console.ResetColor();
        }
    }
}
