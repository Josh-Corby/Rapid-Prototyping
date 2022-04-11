using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto4
{
    public class Enemy : GameBehaviour
    {
        private GameObject player;
        public Algorithm algorithm;
        private float speed;

        private void Start()
        {
            player = GameObject.Find("Player");
            speed = _GM4.speed;
        }
        // Update is called once per frame
        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            if (algorithm.solution.ToString() == _IM.input)
            {
                Destroy(gameObject);
            }
        }
    }
}