using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal struct Health
    {
        public int MaxHealth;
        public int CurrentHealth;
        public Health(int maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;

        }
        public void TakeDmg()
        {
            CurrentHealth -= 1;
            if(CurrentHealth <= 0)
            {
                CurrentHealth = 0;
            }

        }

        public void Heal()
        {
            CurrentHealth += 1;
            if(CurrentHealth >= MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
        }

       public void RespawnHealth()
        {
            CurrentHealth = MaxHealth;
        }
           


    }
}
