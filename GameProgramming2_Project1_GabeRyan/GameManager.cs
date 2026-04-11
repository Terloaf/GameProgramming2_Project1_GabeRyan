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
        public int score;
        public bool PlayerTurn = true;
        public Map Map;
        public Player Player;
        public bool IsPlaying = true;
        public List<Enemy> Enemies;
        public List<Collectables> Collectables;
        public Random Random;
        public string[] EnemyFile;
        public string[] CollectableFile;
        public bool ScreenIsDirty = false;
        //public string[] _enemyStringArray;


        public void FileEnemies(string enemyData)
        {
            EnemyFile = File.ReadAllLines(enemyData);

            for(int i = 0; i < EnemyFile.Length; i++)
            {
                LoadEnemy(EnemyFile[i]);
               
            }
        }
        public void FileCollectables(string collectableData)
        {
            CollectableFile = File.ReadAllLines(collectableData);

            for(int i = 0; i < CollectableFile.Length; i++)
            {
                LoadCollectables(CollectableFile[i]);
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
                Enemies.Add(e);
            }
            if (enemyStringArray[0] == "EnemyBlind")
            {
                EnemyBlind e = new EnemyBlind(enemyDisplay, enemyColour, enemyPos, enemyHealth);
                Enemies.Add(e);
            }
            if (enemyStringArray[0] == "EnemyScared")
            {
                 EnemyScared e = new EnemyScared(enemyDisplay, enemyColour, enemyPos, enemyHealth);
                Enemies.Add(e);
            }
            

        }

        public void LoadCollectables(string collectableString)
        {
            string[] collectableStringArray;
            collectableStringArray = collectableString.Split(',');



            string collectableDisplay = collectableStringArray[1];
            ConsoleColor.TryParse(collectableStringArray[2], out ConsoleColor collectableColour);
            Position CollectablePos = new Position(int.Parse(collectableStringArray[3]), int.Parse(collectableStringArray[4]));

            if (collectableStringArray[0] == "Collectable")
            {
                Collectables c = new Collectables(collectableDisplay, collectableColour, CollectablePos);
                Collectables.Add(c);
            }
            if (collectableStringArray[0] == "CollectableHealth")
            {
                CollectablesHealthPickup c = new CollectablesHealthPickup(collectableDisplay, collectableColour, CollectablePos);
                Collectables.Add(c);
            }
            if (collectableStringArray[0] == "CollectableTimeStop")
            {
                TimeStop c = new TimeStop(collectableDisplay, collectableColour, CollectablePos);
                Collectables.Add(c);
            }
        }
        


        public void PlayGame()
        {
            IsPlaying = true;
            ScreenIsDirty = true;
            Initialize();


            Thread.Sleep(17);


            while (IsPlaying)
            {

                Thread.Sleep(17);

                Player.PlayerMove();

                for (int i = 0; i < Collectables.Count; i++)
                {

                    Collectables[i].Collect();
                    
                }

               

                if (PlayerTurn == false)
                {


                    for (int j = 0; j < Enemies.Count; j++)
                    {
                        Enemies[j].EnemyMove();
                    }

                    PlayerTurn = true;
                }

                GameOverCheck();
                WinCheck();
                Collectables.RemoveAll(c => c.IsCollected);




                Draw();

            }
        }

        private void Draw()
        {
            if (ScreenIsDirty == false)
            {
                return;
            }
            Map.DisplayMap();

            Player.DisplayPlayer();
            
            for (int k = 0; k < Enemies.Count; k++)
            {
                Enemies[k].DisplayEnemy();
            }
            for (int i = 0; i < Collectables.Count; i++)
            {
                Collectables[i].DisplayCollectable();
                

            }

            Console.SetCursorPosition(70, 26);
            Console.WriteLine($"Score: {score}");
            ScreenIsDirty = false;
        }
        private void Initialize()
        {
            Console.CursorVisible = false;
            Map = new Map();
            Player = new Player(display: "O", colour: ConsoleColor.Blue, position: new Position(1, 1), new Health(3));
            //Collectables collectables = new Collectables(position: new Position(0, 0), "P", ConsoleColor.Yellow);
            //CollectablesHealthPickup healthPickup = new CollectablesHealthPickup(position: new Position(0, 0), "H", ConsoleColor.Green);
            //TimeStop timeStop = new TimeStop(position: new Position(0, 0), "T", ConsoleColor.Gray);
            Random = new Random();
            Enemies = new List<Enemy>();
            Collectables = new List<Collectables>();


            FileEnemies("enemyData.txt");


            FileCollectables("collectableData.txt");


            Map.LoadMap("mapData.txt");

            for (int i = 0; i < Map._map.Length; i++)
            {
                for (int j = 0; j < Map._map[0].Length; j++)
                {

                    if (Map.CheckCharInBoarder(Map._map[i][j]))
                    {
                        Map.SetOccupied(new Position(i, j), true);
                        
                    }

                }

            }
        }


        public void GameOverCheck()
        {
            if (Player.Health.CurrentHealth <= 0)
            {
                Program.GameManager.IsPlaying = false;
                Console.Clear();
                Console.WriteLine("You Lose");
                Console.ReadKey();
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Retry? Y/N");

                ConsoleKeyInfo Input = Console.ReadKey(true);
                
                if (Input.Key == ConsoleKey.Y)
                {
                    PlayGame();
                }
                if(Input.Key == ConsoleKey.N)
                {
                    Environment.Exit(0);
                }
            }
        }

        public void WinCheck()
        {
            for (int i = 0; i < Collectables.Count; i++)
            {

                if (Collectables[i].CollectableCount == 25)
                {
                    Program.GameManager.IsPlaying = false;
                    Console.Clear();
                    Console.WriteLine("You Win!");
                    Console.ReadKey();
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Play Again?");

                    ConsoleKeyInfo Input = Console.ReadKey(true);

                    if (Input.Key == ConsoleKey.Y)
                    {
                        PlayGame();
                    }
                    if (Input.Key == ConsoleKey.N)
                    {
                        Environment.Exit(0);
                    }
                }
            }
            
        }
    }
}
