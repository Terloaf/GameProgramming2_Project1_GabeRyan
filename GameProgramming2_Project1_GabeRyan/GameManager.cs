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
        public Collectables _collectables;



        public GameManager(Map map, Player player, Enemy enemy, Collectables collectables, bool isPlaying)
        {
            _map = map;
            _player = player;
            _isPlaying = isPlaying;
            _enemy = enemy;
            _collectables = collectables;

        }
    }
}
