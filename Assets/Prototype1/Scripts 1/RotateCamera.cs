using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto1
{


    public class RotateCamera : GameBehaviour
    {
        /// <summary>
        /// References
        /// </summary>
        public float rotationSpeed;
        public PlayerController thePlayer;

        private Vector3 pos;
        //offset for how high the camera is to the player
        public int cameraYOffset;

        void Start()
        {
            thePlayer = FindObjectOfType<PlayerController>();
        }
        /// <summary>
        /// the camera follows the player at a set height
        /// </summary>
        private void Update()
        {
            pos = new Vector3(thePlayer.transform.position.x, cameraYOffset, thePlayer.transform.position.z);
            transform.position = pos;
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }
    }
}