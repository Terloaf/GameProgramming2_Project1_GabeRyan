using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class GameManager
    {
        public bool _playerTurn = true;
        public Map _map;
        public Player _player;
        public bool _isPlaying;
        public Enemy _enemy;



        public GameManager(Map map, Player player, Enemy enemy, bool isPlaying)
        {
            _map = map;
            _player = player;
            _isPlaying = isPlaying;
            _enemy = enemy;

        }
    }
}
