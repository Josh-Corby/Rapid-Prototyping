using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto2
{
    public class MainTree : GameBehaviour
    {
        public int maxHealth;
        public int currentHealth;


        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(int _damage)
        {
            currentHealth -= _damage;
            if (currentHealth <= 0)
                Die();
        }

        void Die()
        {
            Destroy(gameObject);
        }
    }
}