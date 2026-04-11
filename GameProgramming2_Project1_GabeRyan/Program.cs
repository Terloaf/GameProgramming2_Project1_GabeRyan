using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{

    // Make a list for turn order some how and add 3 instances of an enemy.
    internal class Program
    {
        public static GameManager GameManager;





        static void Main(string[] args)
        {
            GameManager = new GameManager();

            GameManager.PlayGame();

            Console.WriteLine("Play game has ended");
            Console.ReadKey();

        }
       
    }
}
