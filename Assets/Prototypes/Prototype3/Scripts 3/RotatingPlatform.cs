using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Proto3
{

    public class RotatingPlatform : GameBehaviour
    {
        public GameObject rotatingObject;
        public bool isRotating = false;
        public bool canSpin = false;

        private float inputX;
        private Vector3 rotationPoint;

        private void Start()
        {
            rotationPoint = new Vector3(0, transform.localRotation.y - 90, 0);
        }

        void Update()
        {
            //First rotation input system used
            //inputX = Input.GetAxis("Horizontal");
            //if (Input.GetKeyDown(KeyCode.R))
            //{
            //    isRotating = !isRotating;
            //}
            //if (isRotating == true && canSpin == true)
            //{
            //    rotatingObject.transform.Rotate(Vector3.up * inputX * (rotationSpeed * Time.deltaTime));
            //}

            if (canSpin == true)
            {
                if (Input.GetKeyDown(KeyCode.Q)) rotatingObject.transform.Rotate(0, - 90, 0);

                if (Input.GetKeyDown(KeyCode.E)) rotatingObject.transform.Rotate(0, + 90, 0);
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