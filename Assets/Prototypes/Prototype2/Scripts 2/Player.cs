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
        public GameObject treePrefab;

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

            if (Input.GetKeyDown(KeyCode.B))
            {
                BuildTree();
            }
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

        public void BuildTree()
        {
            if (_PS.seeds >= 10)
            {
                Vector3 pos = transform.position;
                Instantiate(treePrefab, pos, player.transform.rotation);
                _PS.seeds -= 10;
                _UI2.UpdateSeedAmount(_PS.seeds);
            }    
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().TakeDamage(damage);
                Debug.Log("Enemy Hit");
            }
        }

        /*
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("BuildZone"))
            {
                Debug.Log("Can Build");
                if (Input.GetKeyDown(KeyCode.B))
                {
                    other.GetComponent<BuildZone>().BuildTree();
                }
            }
        }
        */
    }
}