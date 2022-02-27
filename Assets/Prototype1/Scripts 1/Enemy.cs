using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto1
{
    public class Enemy : GameBehaviour
    {
        public float speed;
        private Rigidbody enemyRb;
        private GameObject player;

        private void Start()
        {
            enemyRb = GetComponent<Rigidbody>();
            player = GameObject.Find("Player");
        }

        private void Update()
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;

            enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);

            if (transform.position.y < -5)
            {
                Destroy(gameObject);
                //_GM1.AddScore(10);
    

        }
        }
    }
}