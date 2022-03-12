using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto2
{
    public class DefenseTree : GameBehaviour
    {
        public Transform target;
        public GameObject bulletPrefab;
        public Transform firePoint;

        [Header("Attributes")]
        public float range;
        public float fireRate = 1f;
        private float fireCountdown = 0f;

        private void Start()
        {
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
        private void Update()
        {
            if (target == null)
                return;

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }

        void Shoot()
        {
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Projectile bullet = bulletGO.GetComponent<Projectile>();

            if (bullet != null)
                bullet.Seek(target);
        }

        void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}