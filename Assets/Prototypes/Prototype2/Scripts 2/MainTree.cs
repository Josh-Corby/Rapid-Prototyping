using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto2
{
    public class MainTree : GameBehaviour
    {
        public HealthBar healthbar;

        public int maxHealth;
        public int currentHealth;


        private void Start()
        {
            currentHealth = maxHealth;
            healthbar.SetMaxHealth(maxHealth);
        }

        public void TakeDamage(int _damage)
        {
            currentHealth -= _damage;
            healthbar.SetHealth(currentHealth);
            if (currentHealth <= 0)
                Die();
        }

        void Die()
        {
            Destroy(gameObject);
        }
    }
}