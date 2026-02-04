using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class Map
    {

        public string[] _map;
        public string[] _boarder = { "═", "║" };

        int _mapOffset = -1;

        


        public void LoadMap(string mapPath)
        {
            _map = File.ReadAllLines(mapPath);
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

    }
}
