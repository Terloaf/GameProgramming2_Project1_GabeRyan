using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class GameManager
    {
        public Map _map;
        public Player _player;


        

        public GameManager(Map map, Player player)
        {
            _map = map;
            _player = player;

        }
    }
}
