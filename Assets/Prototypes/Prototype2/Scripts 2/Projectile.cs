using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto2
{
    public class Projectile : GameBehaviour
    {
        public Transform target;

        public float speed;

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
                HitTarget();
                return;
            }

            transform.Translate(dir.normalized * distanceThisFame, Space.World);
        }

        void HitTarget()
        {
            Destroy(target.gameObject);
        }

        public void Seek(Transform _target)
        {
            target = _target;
        }
    }
}