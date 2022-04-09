using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto4
{
    public class Player : GameBehaviour<Player>
    {
        public int health ;
        private void Start()
        {
            _UI4.UpdatePlayerHPText();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
                health -= 1;
                _UI4.UpdatePlayerHPText();
            }
        }
    }
}