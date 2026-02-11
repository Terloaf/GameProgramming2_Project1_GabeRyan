using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class Map
    {

        public string[] _map;
        public char[] _boarder = {'═', '║', '^', '#', '~'};

        public bool[,] _occupiedSpaces;

        int _mapOffset = -1;

        


        public void LoadMap(string mapPath)
        {
            _map = File.ReadAllLines(mapPath);

            _occupiedSpaces = new bool[_map.Length, _map[0].Length];
        }

        public bool IsSpaceOccupied(Position position)
        {
            // check _occupiedSpaces if position = true or false

            return _occupiedSpaces[position._y, position._x];

        }

        public void SetOccupied(Position position, bool state)
        {
            _occupiedSpaces[position._x, position._y] = state;
        }

        public void DisplayMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < _map.Length; i++)
            {
                
                Console.WriteLine(_map[i]);


            }

            

            Console.Write("\n");

            

        }

        public bool CheckCharInBoarder(char boarderchar)
        {
            for(int i = 0; i < _boarder.Length; i++)
            {
                if (_boarder[i] == boarderchar)
                {
                    return true;
                }
               
            }
            return false;
        }

    }
}
