using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{

    // Make a list for turn order some how and add 3 instances of an enemy.
    internal class Program
    {
        public static GameManager _gameManager;

        

        

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Map map = new Map();
            Player player = new Player(display: "O", colour: ConsoleColor.Blue, position: new Position(1, 1), new Health(3));
            Collectables collectables = new Collectables(position: new Position(0, 0), "P", ConsoleColor.Yellow);
            CollectablesHealthPickup healthPickup = new CollectablesHealthPickup(position: new Position(0, 0), "H", ConsoleColor.Green);
            TimeStop timeStop = new TimeStop(position: new Position(0, 0), "T", ConsoleColor.Gray);
            Random random = new Random();
            List<Enemy> enemies = new List<Enemy>();
            List<Collectables> collectableList = new List<Collectables>();
            _gameManager = new GameManager(map: map, player: player, isPlaying: true, enemies: enemies, collectableList: collectableList, random: random);

            _gameManager.FileEnemies("enemyData.txt");


            //enemies.Add(enemy);
            //enemies.Add(enemy2);
            //enemies.Add(enemy3);
            //enemies.Add(enemy4);

            collectableList.Add(collectables);
            collectableList.Add(healthPickup);
            collectableList.Add(timeStop);


            map.LoadMap("mapData.txt");



            for(int i = 0; i < map._map.Length; i++)
            {
                for(int j = 0; j < map._map[0].Length; j++)
                {
                    if (map.CheckCharInBoarder(map._map[i][j]))
                    {
                        map.SetOccupied(new Position(i, j), true);
                    }

                }
                
            }


            Thread.Sleep(17);
            
            
            while (_gameManager._isPlaying)
            {
                Thread.Sleep(17);


                map.DisplayMap();

                for(int i = 0; i < collectableList.Count; i++)
                {
                    collectableList[i].SpawnCollectable();
                    collectableList[i].Collect();
                }

                player.PlayerMove();
                
                if (_gameManager._playerTurn == false)
                {


                    for(int j = 0; j < enemies.Count; j++)
                    {
                        enemies[j].EnemyMove();
                    }
                 
                    _gameManager._playerTurn = true;
                }
                
                player.GameOverCheck();

                player.DisplayPlayer();

                for(int k = 0; k < enemies.Count; k++)
                {
                    enemies[k].DisplayEnemy();
                }

               
            }



        }

       
    }
}
