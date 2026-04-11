using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class CollisionSystem
    {
        public bool[,] Colliders;

        public void ColliderSetup()
        {
            for(int i = 0; i < Program.GameManager.Map._map.GetLength(0); i++)
            {
                for (int j = 0; j < Program.GameManager.Map._map.GetLength(1); j++)
                {
                    if (Program.GameManager.Map._map[j][i] != '`')
                    {
                        
                    }
                }
            }
            
        }


    }
}
