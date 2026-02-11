using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
            Player player = new Player(health: 3, display: "X", colour: ConsoleColor.Blue, position: new Position(1, 1));
            _gameManager = new GameManager(map: map, player: player);


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
            
           
            while (true)
            {
                map.DisplayMap();
                player.PlayerMove();
                


            }



        }


       
    }
}
