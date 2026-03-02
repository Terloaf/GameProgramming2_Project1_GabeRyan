using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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
            Enemy enemy = new Enemy(display: "X", colour: ConsoleColor.Red, position: new Position(20, 20), new Health(2));
            EnemyBlind enemy2 = new EnemyBlind(display: "x", colour: ConsoleColor.Red, position: new Position(24, 18), new Health(4));
            EnemyScared enemy3 = new EnemyScared(display: "m", colour: ConsoleColor.Red, position: new Position(22, 18), new Health(1));
            Player player = new Player(display: "O", colour: ConsoleColor.Blue, position: new Position(1, 1), new Health(3));
            Collectables collectables = new Collectables(position: new Position(0, 0), "P", ConsoleColor.Yellow);
            CollectablesHealthPickup healthPickup = new CollectablesHealthPickup(position: new Position(0, 0), "H", ConsoleColor.Green);
            List<Enemy> enemies = new List<Enemy>();
            _gameManager = new GameManager(map: map, player: player, collectables: collectables, healthPickups: healthPickup, isPlaying: true, enemies: enemies);

            

            enemies.Add(enemy);
            enemies.Add(enemy2);
            enemies.Add(enemy3);


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
                healthPickup.SpawnCollectableHealth();
                collectables.SpawnCollectable();

                player.PlayerMove();

                if (_gameManager._playerTurn == false)
                {

                    enemy.EnemyMove();
                    enemy2.EnemyBlindMove();
                    enemy3.EnemyScaredMove();

                    _gameManager._playerTurn = true;
                }
                
                player.GameOverCheck();

                player.DisplayPlayer();
                enemy.DisplayEnemy();
                enemy2.DisplayBlindEnemy();
                enemy3.DisplayScaredEnemy();
               
            }



        }

       
    }
}
