using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto3
{

    public class RotatingObject : GameBehaviour
    {
        public GameObject rotatingObject;
        public float rotationSpeed;
        public bool isRotating = false;
        public bool canSpin = false;

        private float inputX;
        
        void Update()
        {
            inputX = Input.GetAxis("Horizontal");
            if (Input.GetKeyDown(KeyCode.R))
            {
                isRotating = !isRotating;
            }
            if (isRotating == true && canSpin == true)
            {
                rotatingObject.transform.Rotate(Vector3.up * inputX * (rotationSpeed * Time.deltaTime));
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                canSpin = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                canSpin = false;
            }
        }
    }
}