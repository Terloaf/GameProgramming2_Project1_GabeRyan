using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class GameManager
    {
        public bool _playerTurn = true;
        public Map _map;
        public Player _player;
        public bool _isPlaying = true;
        public List<Enemy> _enemies;
        public List<Collectables> _collectableList;
        public Random _random;
        public string[] _enemyFile;
        public bool _screenIsDirty = false;
        //public string[] _enemyStringArray;


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
        

        public void PlayGame()
        {
            _screenIsDirty = true;
            Initialize();


            Thread.Sleep(17);


            while (_isPlaying)
            {
                Thread.Sleep(17);

                


                for (int i = 0; i < _collectableList.Count; i++)
                {
                    _collectableList[i].SpawnCollectable();
                    _collectableList[i].Collect();
                }

                _player.PlayerMove();

                if (_playerTurn == false)
                {


                    for (int j = 0; j < _enemies.Count; j++)
                    {
                        _enemies[j].EnemyMove();
                    }

                    _playerTurn = true;
                }

                GameOverCheck();


                Draw();
                

            }
        }

        private void Draw()
        {
            if (_screenIsDirty == false)
            {
                return;
            }
            _map.DisplayMap();

            _player.DisplayPlayer();
            
            for (int k = 0; k < _enemies.Count; k++)
            {
                _enemies[k].DisplayEnemy();
            }
            for (int i = 0; i < _collectableList.Count; i++)
            {
                _collectableList[i].DisplayCollectable();
            }

            _screenIsDirty = false;
        }
        private void Initialize()
        {
            Console.CursorVisible = false;
            _map = new Map();
            _player = new Player(display: "O", colour: ConsoleColor.Blue, position: new Position(1, 1), new Health(3));
            Collectables collectables = new Collectables(position: new Position(0, 0), "P", ConsoleColor.Yellow);
            CollectablesHealthPickup healthPickup = new CollectablesHealthPickup(position: new Position(0, 0), "H", ConsoleColor.Green);
            TimeStop timeStop = new TimeStop(position: new Position(0, 0), "T", ConsoleColor.Gray);
            _random = new Random();
            _enemies = new List<Enemy>();
            _collectableList = new List<Collectables>();


            FileEnemies("enemyData.txt");

            _collectableList.Add(collectables);
            _collectableList.Add(healthPickup);
            _collectableList.Add(timeStop);


            _map.LoadMap("mapData.txt");

            for (int i = 0; i < _map._map.Length; i++)
            {
                for (int j = 0; j < _map._map[0].Length; j++)
                {
                    if (_map.CheckCharInBoarder(_map._map[i][j]))
                    {
                        _map.SetOccupied(new Position(i, j), true);
                    }

                }

            }
        }


        public void GameOverCheck()
        {
            if (_player._health._currentHealth <= 0)
            {
                Program._gameManager._isPlaying = false;
                Console.Clear();
                Console.WriteLine("You Lose");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

    }
}
