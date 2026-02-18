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
            Enemy enemy2 = new Enemy(display: "x", colour: ConsoleColor.Red, position: new Position(24, 18), new Health(1));
            Player player = new Player(display: "O", colour: ConsoleColor.Blue, position: new Position(1, 1), new Health(3));
            Collectables collectables = new Collectables(position: new Position(0, 0));
            List<Enemy> enemies = new List<Enemy>();
            _gameManager = new GameManager(map: map, player: player, collectables: collectables ,isPlaying: true, enemies: enemies);

            

            enemies.Add(enemy);
            enemies.Add(enemy2);
            


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
                collectables.SpawnCollectable();
                player.PlayerMove();

                if (_gameManager._playerTurn == false)
                {

                    enemy.EnemyMove();
                    enemy2.EnemyMove();
                    for (int j = 0; j < enemies.Count; j++)
                    {
                        map.SetOccupied(new Position(enemies[j]._position._y, enemies[j]._position._x), true);
                    }
                    _gameManager._playerTurn = true;
                }
                
                player.GameOverCheck();

                player.DisplayPlayer();
                enemy.DisplayEnemy();
                enemy2.DisplayEnemy();
               
            }



        }

       
    }
}
