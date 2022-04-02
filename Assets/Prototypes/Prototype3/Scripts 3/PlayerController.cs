using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto3
{

    public class PlayerController : GameBehaviour
    {
        private CharacterController controller;
        private GameObject player;

        private float inputX;
        private float inputZ;
        private Vector3 movement;
        private Vector3 velocity;
        private float moveSpeed;

        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;

        public bool isGrounded;

        public AudioSource audioSource;


        void Start()
        {
            player = GameObject.Find("Player");
            controller = player.GetComponent<CharacterController>();
            moveSpeed = 10f;

        }

        void Update()
        {
            inputX = Input.GetAxis("Horizontal");
            inputZ = Input.GetAxis("Vertical");

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        }

        private void FixedUpdate()
        {
            movement = controller.transform.forward * inputZ;
            controller.transform.Rotate(Vector3.up * inputX * (200f * Time.deltaTime));

            if(isGrounded == true)
            {
               controller.Move(movement * moveSpeed * Time.deltaTime);
            }    
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Pickup"))
            {
                Debug.Log("Pickup");
                audioSource.Play();
            }
        }
    }
}