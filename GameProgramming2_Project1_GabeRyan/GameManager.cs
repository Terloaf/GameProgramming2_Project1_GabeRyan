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
        public List<Enemy> _enemies;
        public List<Collectables> _collectableList;

        Random random = new Random();

        public GameManager(Map map, Player player, bool isPlaying, List<Enemy> enemies, List<Collectables> collectableList)
        {
            _map = map;
            _player = player;
            _isPlaying = isPlaying;


            _enemies = enemies;
            _collectableList = collectableList;
        }

        

        
        

    }
}
