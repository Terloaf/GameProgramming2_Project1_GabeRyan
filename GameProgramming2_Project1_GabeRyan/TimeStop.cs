using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class TimeStop : Collectables
    {
        public TimeStop(string display, ConsoleColor colour, Position position) : base(display, colour, position)
        {


        }

        public override void SpawnCollectable()
        {
            base.SpawnCollectable();
        }

        public override void DisplayCollectable()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.ForegroundColor = Colour;
            Console.Write(Display);
            Console.ResetColor();
        }

        public override void Collect()
        {
            if (Program.GameManager.Player.Position.X == Position.X && Program.GameManager.Player.Position.Y == Position.Y)
            {
                Program.GameManager.Player.Position.X -= Program.GameManager.Player.PlayXInput;
                Program.GameManager.Player.Position.Y -= Program.GameManager.Player.PlayerYInput;
                CollectableCount += 1;
                IsCollected = true;

                for (int i = 0; i < Program.GameManager.Enemies.Count; i++)
                {
                    Program.GameManager.Enemies[i].EnemyWait = -20;
                }
            }
        }
    }
}
