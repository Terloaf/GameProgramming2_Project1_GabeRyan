using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class Program
    {
         public static GameManager _gameManager;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Map map = new Map();
            Player player = new Player(health: 3, display: "X", colour: ConsoleColor.Blue);
            _gameManager = new GameManager(map: map, player: player);


            map.LoadMap("mapData.txt");
            while (true)
            {
                map.DisplayMap();
                player.PlayerHandler();
                


            }

            


        }


       
    }
}
