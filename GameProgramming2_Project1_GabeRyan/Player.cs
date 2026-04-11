using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class Player
    {

        public Position Position;
        public Health Health;
        public string PDisplay;
        public ConsoleColor PColour;
        public int PlayXInput;
        public int PlayerYInput;

        public Player(string display, ConsoleColor colour, Position position, Health health)
        {

            Health = health;
            PDisplay = display;
            PColour = colour;
            Position = position;
        }

        public void PlayerMove()
        {
            
            if (Program.GameManager.PlayerTurn == true)
            {
                
                int playerXinput = 0;
                int playerYinput = 0;

                if (!Console.KeyAvailable)
                {
                    return;
                }
                
                ConsoleKeyInfo Input = Console.ReadKey(true);
                if (Input.Key == ConsoleKey.W) playerYinput -= 1;
                if (Input.Key == ConsoleKey.S) playerYinput += 1;
                if (Input.Key == ConsoleKey.D) playerXinput += 1;
                if (Input.Key == ConsoleKey.A) playerXinput -= 1;


                
                Position.X += playerXinput;
                Position.Y += playerYinput;
                PlayXInput = playerXinput;
                PlayerYInput = playerYinput;

                for(int i = 0; i < Program.GameManager.Enemies.Count; i++)
                {
                    if (Program.GameManager.Enemies[i].Position.X == Position.X && Program.GameManager.Enemies[i].Position.Y == Position.Y)
                        {
                        Program.GameManager.Enemies[i].Health.TakeDmg();
                            Position.X -= playerXinput;
                            Position.Y -= playerYinput;
                            Program.GameManager.PlayerTurn = false;
                            return;
                        }
                }
                for (int i = 0; i < Program.GameManager.Collectables.Count; i++)
                {
                    if (Program.GameManager.Collectables[i].Position.X == Position.X && Program.GameManager.Collectables[i].Position.Y == Position.Y)
                    {
                        Program.GameManager.Collectables[i].Collect();
                        Position.X -= playerXinput;
                        Position.Y -= playerYinput;
                        Program.GameManager.PlayerTurn = false;
                        return;
                    }
                }



                if (playerXinput == -1 && Position.X == -1)
                {
                    Position.X += 1;
                    return;
                }

                if (playerXinput == 1 && Position.X == Program.GameManager.Map._map[0].Length)
                {
                    Position.X -= 1;
                    return;
                }

                if (playerYinput == -1 && Position.Y == -1)
                {
                    Position.Y += 1;
                    return;
                }
                if (playerYinput == 1 && Position.Y == Program.GameManager.Map._map.Length)
                {
                    Position.Y -= 1;
                    return;
                }


                if (Program.GameManager.Map.IsSpaceOccupied(Position) == true)
                {
                    Position.X -= playerXinput;
                    Position.Y -= playerYinput;
                }

                
                Program.GameManager.PlayerTurn = false;
                Program.GameManager.ScreenIsDirty = true;
                
            }
            


        }

        

        public void DisplayPlayer()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.ForegroundColor = PColour;
            Console.Write(PDisplay);
            Console.ResetColor();

            Console.SetCursorPosition(70, 20);
            Console.Write($"Player Health {Health.CurrentHealth}");

        }


    }
}
