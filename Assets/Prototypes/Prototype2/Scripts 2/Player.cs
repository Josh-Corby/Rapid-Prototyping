using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto2
{
    public class Player : GameBehaviour
    {
        public GameObject player;
        private Animator animator;
        public CharacterController controller;

        public int damage;
        private void Start()
        {
            animator = GetComponent<Animator>();
            controller = GetComponent<CharacterController>();
            controller.detectCollisions = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartCoroutine(AttackZoneToggle());
                PerformAttack();
            }
                

            if (Input.GetKey(KeyCode.W))
                PerformRun();
            if (Input.GetKey(KeyCode.A))
                PerformRun();
            if (Input.GetKey(KeyCode.S))
                PerformRun();
            if (Input.GetKey(KeyCode.D))
                PerformRun();   
        }

        IEnumerator AttackZoneToggle()
        {
            controller.detectCollisions = true;
            yield return new WaitForSeconds(0.5f);
            controller.detectCollisions = false;
        }

        public void PerformAttack()
        {
            animator.SetTrigger("Base_Attack");
        }

        public void PerformRun()
        {
            animator.SetTrigger("Run");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().TakeDamage(damage);
                Debug.Log("Enemy Hit");
            }
        }
    }
}