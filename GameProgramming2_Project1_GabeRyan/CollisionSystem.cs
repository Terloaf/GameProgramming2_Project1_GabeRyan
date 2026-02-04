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
            for(int i = 0; i < Program._gameManager._map._map.GetLength(0); i++)
            {
                for (int j = 0; j < Program._gameManager._map._map.GetLength(1); j++)
                {
                    if (Program._gameManager._map._map[j][i] != '`')
                    {
                        
                    }
                }
            }
            
        }


    }
}
