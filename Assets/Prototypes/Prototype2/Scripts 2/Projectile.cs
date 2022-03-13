using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto2
{
    public class Projectile : GameBehaviour
    {
        public Transform target;

        public float speed;
        public int damage;

        private void Update()
        {
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }

            Vector3 dir = target.position - transform.position;
            float distanceThisFame = speed * Time.deltaTime;

            if (dir.magnitude <= distanceThisFame)
            {
                Damage(target);
                return;
            }

            transform.Translate(dir.normalized * distanceThisFame, Space.World);
        }

        void Damage (Transform enemy)
        {
            Enemy e = enemy.GetComponent<Enemy>();

            if (e != null)
            {
                e.TakeDamage(damage);
                Destroy(gameObject);
            }
            

        }
        public void Seek(Transform _target)
        {
            target = _target;
        }
    }
}