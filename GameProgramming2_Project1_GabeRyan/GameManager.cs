using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        public Collectables _collectables;
        public List<Enemy> _enemies;


        public GameManager(Map map, Player player, Collectables collectables, bool isPlaying, List<Enemy> enemies)
        {
            _map = map;
            _player = player;
            _isPlaying = isPlaying;

            _collectables = collectables;

            _enemies = enemies;
        }

        

        
        

    }
}
