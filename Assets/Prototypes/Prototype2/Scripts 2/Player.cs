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
                attackzone.Attack();
                PerformAttack();
            }    

            if (Input.GetKeyDown(KeyCode.E))
            {
                BuildTree();
            }
        }

        public void PerformAttack()
        {
            animator.SetTrigger("Base_Attack");
        }

        public void BuildTree()
        {
            if (_PS.seeds >= 10)
            {
                Vector3 pos = transform.position;
                Instantiate(_SH.treeToBuild, pos, player.transform.rotation);
                _PS.seeds -= 10;
                _UI2.UpdateSeedAmount(_PS.seeds);
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