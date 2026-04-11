using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    
    internal class Collectables
    {

        public Position Position;
        public int CollectableCount = 15;
        public string Display;
        public ConsoleColor Colour;
        public bool IsCollected = false;
        public Collectables(string display, ConsoleColor colour, Position position)
        {
            Position = position;
            Display = display;
            Colour = colour;
        }

        public virtual void SpawnCollectable()
        {

            
            
        }

        public virtual void DisplayCollectable()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.ForegroundColor = Colour;
            Console.Write(Display);
            Console.ResetColor();
        }



        public virtual void Collect()
        {
            if (Program.GameManager.Player.Position.X == Position.X && Program.GameManager.Player.Position.Y == Position.Y)
            {
                Program.GameManager.Player.Position.X -= Program.GameManager.Player.PlayXInput;
                Program.GameManager.Player.Position.Y -= Program.GameManager.Player.PlayerYInput;
                Program.GameManager.score += 1;
                IsCollected = true;
                
            }
        }
    }
}
