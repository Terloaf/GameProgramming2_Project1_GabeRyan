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

           

            string enemyDisplay = enemyStringArray[0];
            ConsoleColor.TryParse(enemyStringArray[1], out ConsoleColor enemyColour);
            Position enemyPos = new Position(int.Parse(enemyStringArray[2]), int.Parse(enemyStringArray[3]));
            Health enemyHealth = new Health(int.Parse(enemyStringArray[4]));

            Enemy e = new Enemy(enemyDisplay, enemyColour, enemyPos, enemyHealth);
            _enemies.Add(e);

            Enemy d = new Enemy("E", ConsoleColor.Red, new Position(0, 0), new Health(100));
            // add to list 

        }
        
        

    }
}
