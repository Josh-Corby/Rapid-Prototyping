using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto2
{
    public class Player : GameBehaviour<Player>
    {
        public GameObject player;
        public AttackZone attackzone;
        private Animator animator;
        private CharacterController controller;

        public int damage;
        private void Start()
        {

            animator = GetComponent<Animator>();
            controller = GetComponent<CharacterController>();
            controller.detectCollisions = false;
            _UI2.UpdateSeedAmount(_PS.seeds);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                PerformAttack();
                attackzone.Attack();           
            }    

        }

        public void PerformAttack()
        {
            animator.SetTrigger("Base_Attack");
        }

    }
}