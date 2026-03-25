using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
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
        public Random _random;
        public string[] _enemyFile;
        //public string[] _enemyStringArray;

        public GameManager(Map map, Player player, bool isPlaying, List<Enemy> enemies, List<Collectables> collectableList, Random random)
        {
            _map = map;
            _player = player;
            _isPlaying = isPlaying;


            _enemies = enemies;
            _collectableList = collectableList;
            _random = random;
        }


        public void FileEnemies(string enemyData)
        {
            _enemyFile = File.ReadAllLines(enemyData);

            for(int i = 0; i < _enemyFile.Length; i++)
            {
                LoadEnemy(_enemyFile[i]);
               
            }
        }
        
        public void LoadEnemy(string enemyString)
        {

            string[] enemyStringArray;
            enemyStringArray = enemyString.Split(',');

            

            string enemyDisplay = enemyStringArray[1];
            ConsoleColor.TryParse(enemyStringArray[2], out ConsoleColor enemyColour);
            Position enemyPos = new Position(int.Parse(enemyStringArray[3]), int.Parse(enemyStringArray[4]));
            Health enemyHealth = new Health(int.Parse(enemyStringArray[5]));

            if (enemyStringArray[0] == "Enemy")
            {
                Enemy e = new Enemy(enemyDisplay, enemyColour, enemyPos, enemyHealth);
                _enemies.Add(e);
            }
            if (enemyStringArray[0] == "EnemyBlind")
            {
                EnemyBlind e = new EnemyBlind(enemyDisplay, enemyColour, enemyPos, enemyHealth);
                _enemies.Add(e);
            }
            if (enemyStringArray[0] == "EnemyScared")
            {
                 EnemyScared e = new EnemyScared(enemyDisplay, enemyColour, enemyPos, enemyHealth);
                _enemies.Add(e);
            }
            

        }
        
        

    }
}
