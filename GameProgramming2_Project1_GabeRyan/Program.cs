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

    struct PersonInfo
    {
        public string _name;
        public int _birthyear;
    }

    internal class Program
    {
        public static GameManager _gameManager;





        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Map map = new Map();
            Enemy enemy = new Enemy(display: "X", colour: ConsoleColor.Red, position: new Position(20, 20), new Health(2));
            Player player = new Player(display: "O", colour: ConsoleColor.Blue, position: new Position(1, 1), new Health(3));
            _gameManager = new GameManager(map: map, player: player, enemy: enemy, isPlaying: true);


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
                
                map.DisplayMap();
                player.PlayerMove();
                enemy.EnemyMove();
                map.DisplayMap();
                player.GameOverCheck();
               
                


            }



        }

       
    }
}
