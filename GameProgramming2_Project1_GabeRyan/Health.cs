using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class Health
    {
        int _maxHealth;
        int _currentHealth;

        public Health(int MaxHealth, int currentHealth)
        {
            _maxHealth = MaxHealth;
            _currentHealth = currentHealth;
        }



        public override void TakeDmg()
        {
            _currentHealth -= 1;
            if(_currentHealth < 0)
            {
                _currentHealth = 0;
            }
        }

    }
}
