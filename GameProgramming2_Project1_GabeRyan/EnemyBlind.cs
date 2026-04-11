using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class EnemyBlind : Enemy
    {
        public EnemyBlind(string display, ConsoleColor colour, Position position, Health health) : base(display, colour, position, health)
        {


        }


        public override void EnemyMove()
        {
            int enemyXInput = 0;
            int enemyYInput = 0;

            if (Health.CurrentHealth <= 0)
            {
                Random random = new Random();

                Position.X = random.Next(1, Program.GameManager.Map._map[0].Length - 1);
                Position.Y = random.Next(1, Program.GameManager.Map._map.Length - 1);

                if (Program.GameManager.Map._map[Position.Y][Position.X] != '`')
                {
                    EnemyMove();
                }

                Health.RespawnHealth();
                return;
            }
            if (Program.GameManager.PlayerTurn == false)
            {
                Console.SetCursorPosition(0, 25);
                Console.WriteLine("debug");

                EnemyWait += 1;
                if (EnemyWait >= 2)
                {
                    EnemyWait = 0;

                    enemyXInput += Program.GameManager.Random.Next(-1, 2);
                    enemyYInput += Program.GameManager.Random.Next(-1, 2);
                   

                    Position.X += enemyXInput;
                    Position.Y += enemyYInput;


                    if (Program.GameManager.Player.Position.X == Position.X && Program.GameManager.Player.Position.Y == Position.Y)
                    {
                        Program.GameManager.Player.Health.TakeDmg();
                        Position.X -= enemyXInput;
                        Position.Y -= enemyYInput;


                    }



                    if (Program.GameManager.Map.IsSpaceOccupied(Position) == true)
                    {
                        Position.X -= enemyXInput;
                        Position.Y -= enemyYInput;

                    }

                }

            }

        }

        public override void DisplayEnemy()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.ForegroundColor = PColour;
            Console.Write(PDisplay);
            Console.ResetColor();

        }

    }
}

