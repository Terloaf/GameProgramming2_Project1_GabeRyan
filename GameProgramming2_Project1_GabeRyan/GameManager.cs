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
        public bool _isPlaying;



        public GameManager(Map map, Player player, bool isPlaying)
        {
            _map = map;
            _player = player;
            _isPlaying = isPlaying;

        }
    }
}
