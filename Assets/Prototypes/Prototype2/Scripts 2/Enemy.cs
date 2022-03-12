using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto2
{
    public class Enemy : GameBehaviour
    {
        public GameObject target;
        public ParticleSystem hitEffect;
        public float speed;
        public float currentHealth;
        public float maxHealth = 10;
        public int damage;

        public Transform partToRotate;
        public float turnspeed = 10f;

        private void Start()
        {
            currentHealth = maxHealth;
            target = GameObject.Find("WayPoint");
        }

        private void Update()
        {
            transform.LookAt(target.transform.position);
            Vector3 dir = target.transform.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }

        public void TakeDamage(int _damage)
        {
            Instantiate(hitEffect, transform.position, transform.rotation);
            currentHealth -= _damage;
            if (currentHealth <= 0)
            Die();
        }

        void Die()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("MainTree"))
            {
                other.GetComponent<MainTree>().TakeDamage(damage);
                Debug.Log("Tree Hit!");
                Die();
            }
        }
    }
}