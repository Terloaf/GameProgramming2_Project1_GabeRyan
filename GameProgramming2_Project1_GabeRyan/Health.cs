using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal struct Health
    {
        public int _maxHealth;
        public int _currentHealth;
        public Health(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;

        }
        public void TakeDmg()
        {
            _currentHealth -= 1;
            if(_currentHealth <= 0)
            {
                _currentHealth = 0;
            }

        }

        public void Heal()
        {
            _currentHealth += 1;
            if(_currentHealth >= _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }

       
           


    }
}
